using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using YoutubeDLSharp;
using YoutubeDLSharp.Metadata;
using YoutubeDLSharp.Options;

namespace Youtube_downloader {
    class YouTubeDownload
    {
        public string DownloadsPath { get; set; }
        private readonly string applicationPath;
        private readonly YoutubeDL youtubeDownloader;

        readonly Dictionary<int, CancellationTokenSource> songsCancelTokens = new Dictionary<int, CancellationTokenSource>();

        public delegate void CreateSongHandler(Song song, Playlist playlist);
        public event CreateSongHandler OnCreateSong;

        public delegate void UpdateSongProgressHandler(Song song, int progress);
        public event UpdateSongProgressHandler OnUpdateSongProgress;
        public delegate void UpdateSongPathHandler(Song song, string path);
        public event UpdateSongPathHandler OnUpdateSongPath;
        public delegate void StopSongHandler(Song song);
        public event StopSongHandler OnStopSong;
        public delegate void SongHandler(Song song);
        public event SongHandler OnDeleteSong;

        public delegate void PlaylistHandler(Playlist playlist);
        public event PlaylistHandler OnCreatePlaylist;
        public event PlaylistHandler OnDeletePlaylist;

        public YouTubeDownload(string _downloadsPath, string _applicationPath)
        {
            DownloadsPath = _downloadsPath;
            applicationPath = _applicationPath;

            youtubeDownloader = new YoutubeDL
            {
                YoutubeDLPath = $"{applicationPath}\\Youtube_downloader\\ytDownloader\\yt-dlp.exe",
                FFmpegPath = $"{applicationPath}\\Youtube_downloader\\ytDownloader\\ffmpeg\\bin\\ffmpeg.exe",
                OutputFolder = DownloadsPath
            };
        }

        public void CancelDownload(Song song) {
            if (songsCancelTokens.ContainsKey(song.id)) {
                var sct = songsCancelTokens[song.id];
                sct.Cancel();
            }
        }

        public void CancelDownload(Playlist playlist) {
            foreach(var song in playlist.songs) {
                CancelDownload(song);
            }
        }

        public async void Download(string link)
        {
            var result = await youtubeDownloader.RunVideoDataFetch(link);
            if (!result.Success) {
                return;
            }

            var data = result.Data;
            if (data.Entries == null) {
                await DownloadAudio(data);
            } else {
                await DownloadPlaylist(data);
            }
        }

        public async Task StartSongDownload(Song song, Playlist playlist) {
            var cts = new CancellationTokenSource();
            songsCancelTokens[song.id] = cts;

            try {
                var result = await youtubeDownloader.RunAudioDownload(
                    song.url,
                    AudioConversionFormat.Mp3, // TODO: Настройка "В каком формате хотите сохранять файлы
                    ct: cts.Token,
                    progress: new Progress<DownloadProgress>(p => {
                        OnUpdateSongProgress?.Invoke(song, (int)(p.Progress * 100));
                    }),
                    overrideOptions: new OptionSet() {
                        Continue = true,
                        Output = Path.Combine(
                            playlist?.directoryPath ?? DownloadsPath,
                            youtubeDownloader.OutputFileTemplate
                        ),
                        EmbedThumbnail = true,
                        ConvertThumbnails = "jpg",
                        WriteThumbnail  = true,
                    }
                );

                if (!result.Success)
                {
                    OnDeleteSong?.Invoke(song);
                    return;
                }

                OnUpdateSongProgress?.Invoke(song, 100);

                OnUpdateSongPath?.Invoke(song, result.Data);

                // TODO: Fix thumbnail view
            } catch (OperationCanceledException) {
                OnStopSong?.Invoke(song);
            } catch (Exception) {
                OnDeleteSong?.Invoke(song);
            }
        }

        private async Task DownloadAudio(VideoData videoData, Playlist playlist = null)
        {
            var song = new Song {
                songName = videoData.Title,
                author = videoData.Channel,
                url = videoData.Url ?? videoData.WebpageUrl,
                authorUrl = videoData.ChannelUrl,
                progress = 0
            };

            OnCreateSong?.Invoke(song, playlist);

            await StartSongDownload(song, playlist);
        }

        private async Task<Playlist> DownloadPlaylist(VideoData playlistData)
        {
            var playlist = new Playlist
            {
                playlistName = playlistData.Title,
                playlistUrl = playlistData.Url ?? playlistData.WebpageUrl,
                directoryPath = $@"{DownloadsPath}\{playlistData.Title}"
            };

            OnCreatePlaylist?.Invoke(playlist);

            if (!Directory.Exists(playlist.directoryPath))
            {
                Directory.CreateDirectory(playlist.directoryPath);
            }

            List<Task> tasks = new List<Task>();
            foreach (var videoData in playlistData.Entries)
            {
                tasks.Add(DownloadAudio(videoData, playlist));
            }

            try
            {
                await Task.WhenAll(tasks);
            }
            catch (Exception)
            {
                OnDeletePlaylist?.Invoke(playlist);
                throw;
            }

            return playlist;
        }
    }
}
