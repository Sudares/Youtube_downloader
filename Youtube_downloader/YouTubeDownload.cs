using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutubeDLSharp;
using YoutubeDLSharp.Metadata;
using YoutubeDLSharp.Options;

namespace Youtube_downloader
{
    class YouTubeDownload
    {
        private readonly string downloadsPath;
        private readonly string applicationPath;

        private readonly YoutubeDL youtubeDownloader;

        public YouTubeDownload(string _downloadsPath, string _applicationPath)
        {
            downloadsPath = _downloadsPath;
            applicationPath = _applicationPath;

            youtubeDownloader = new YoutubeDL();
            youtubeDownloader.YoutubeDLPath = $"{applicationPath}\\Youtube_downloader\\ytDownloader\\yt-dlp.exe";
            youtubeDownloader.FFmpegPath = $"{applicationPath}\\Youtube_downloader\\ytDownloader\\ffmpeg\\bin\\ffmpeg.exe";
            youtubeDownloader.OutputFolder = downloadsPath;
        }

        public readonly struct DownloadResult
        {
            public readonly Playlist Playlist;
            public readonly Song Song;
            public readonly Boolean Success;

            public DownloadResult(Playlist playlist)
            {
                Playlist = playlist;
                Song = null;
                Success = true;
            }

            public DownloadResult(Song song)
            {
                Song = song;
                Playlist = null;
                Success = true;
            }

            public DownloadResult(bool success = false)
            {
                Success = success;
                Song = null;
                Playlist = null;
            }
        }
        public async Task<DownloadResult> Download(string link, IProgress<DownloadProgress> progress)
        {
            var result = await youtubeDownloader.RunVideoDataFetch(link); // получаем данные по ссылке

            if (result.Success)
            {
                var data = result.Data;
                if (data.Entries == null)
                {
                    var song = await DownloadAudio(data, progress);
                    return new DownloadResult(song);
                }
                else
                {
                    var playlist = await DownloadPlaylist(data, progress);
                    return new DownloadResult(playlist);
                }
            }
            return new DownloadResult();
        }

        private async Task<Song> DownloadAudio(VideoData videoData, IProgress<DownloadProgress> progress)
        {
            var url = videoData.Url ?? videoData.WebpageUrl;
            var result = await youtubeDownloader.RunAudioDownload(url, AudioConversionFormat.Mp3, progress: progress);
            if (result.Success)
            {
                var song = new Song();
                song.songName = videoData.Title;
                song.author = videoData.Channel;
                song.url = url;
                song.authorUrl = videoData.ChannelUrl;
                song.filePath = result.Data;
                return song;
            }
            else
            {
                return null;
            }
        }

        private async Task<Playlist> DownloadPlaylist(VideoData playlistData, IProgress<DownloadProgress> progress)
        {
            List<Task<Song>> tasks = new List<Task<Song>>();
            foreach (var videoData in playlistData.Entries)
            {
                tasks.Add(DownloadAudio(videoData, progress));
            }

            var songs = await Task.WhenAll(tasks);
            var playlist = new Playlist();
            playlist.playlistName = playlistData.Title;
            playlist.playlistUrl = playlistData.Url ?? playlistData.WebpageUrl;
            playlist.songs = songs.ToList();
            playlist.directoryPath = $@"{downloadsPath}\{playlist.directoryPath}";

            if (!System.IO.Directory.Exists(playlist.directoryPath))
            {
                System.IO.Directory.CreateDirectory(playlist.directoryPath);
            }

            foreach (var song in songs)
            {
                var newPath = $@"{playlist.directoryPath}\{System.IO.Path.GetFileName(song.filePath)}";
                System.IO.File.Move(song.filePath, newPath);
                song.filePath = newPath;
            }

            return playlist;
        }
    }
}
