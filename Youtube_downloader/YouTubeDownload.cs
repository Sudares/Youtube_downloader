using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using YoutubeDLSharp;
using YoutubeDLSharp.Metadata;
using YoutubeDLSharp.Options;

namespace Youtube_downloader {
    internal class YouTubeDownload {
        YoutubeDL youtubeDownloader;
        string sourcePath = @"C:\Users\Home\Desktop";
        List<Playlist> playlists = new List<Playlist>();
        List<Song> songs = new List<Song>();
        public delegate void PlaylistsEventHandler(object sender, List<Playlist> playlists);
        internal event PlaylistsEventHandler PlaylistsEvent;
        public delegate void SongsEventHandler(object sender, Playlist playlist, List<Song> songs);
        internal event SongsEventHandler SongsEvent;

        internal YouTubeDownload() {
            youtubeDownloader = new YoutubeDL();
            youtubeDownloader.YoutubeDLPath = @"C:\Users\Home\source\repos\Youtube_downloader\Youtube_downloader\ytDownloader\yt-dlp.exe";
            youtubeDownloader.FFmpegPath = @"C:\Users\Home\source\repos\Youtube_downloader\Youtube_downloader\ytDownloader\ffmpeg\bin\ffmpeg.exe";
            youtubeDownloader.OutputFolder = sourcePath;
        }

        public async void Download(string link, IProgress<DownloadProgress> progress) {
            var result = await youtubeDownloader.RunVideoDataFetch(link);

            if(result.Success) {
                var data = result.Data;
                if(data.Entries == null) {
                    var song = await DownloadAudio(data, progress);
                    AddSong(song);
                } else {
                    var playlist = await DownloadPlaylist(data, progress);
                    AddPlaylist(playlist);
                }
            }
        }

        private async Task<Song> DownloadAudio(VideoData videoData, IProgress<DownloadProgress> progress) 
        {
            var url = videoData.Url ?? videoData.WebpageUrl;
            var result = await youtubeDownloader.RunAudioDownload(url, AudioConversionFormat.Mp3, progress: progress);
            if(result.Success) {
                var song = new Song();
                song.songName = videoData.Title;
                song.author = videoData.Channel;
                song.url = url;
                song.authorUrl = videoData.ChannelUrl;
                song.filePath = result.Data;
                return song;
            } else { 
                return null; 
            }
        }

        private async Task<Playlist> DownloadPlaylist(VideoData playlistData, IProgress<DownloadProgress> progress) 
        {
            List<Task<Song>> tasks = new List<Task<Song>>();
            foreach(var videoData in playlistData.Entries) {
                tasks.Add(DownloadAudio(videoData, progress));
            }

            var songs = await Task.WhenAll(tasks);
            var playlist = new Playlist();
            playlist.playlistName = playlistData.Title;
            playlist.playlistUrl = playlistData.Url;
            playlist.songs = songs.ToList();
            playlist.directoryPath = sourcePath + "\\" + playlist.playlistName;

            if (!System.IO.Directory.Exists(playlist.directoryPath)) {
                System.IO.Directory.CreateDirectory(playlist.directoryPath);
            }

            foreach(var song in songs) {
                var newPath = playlist.directoryPath + "\\" + System.IO.Path.GetFileName(song.filePath);
                System.IO.File.Move(song.filePath, newPath);
                song.filePath = newPath;
            }

            return playlist;
        }

        public void AddSong(Song song) {
            songs.Insert(0,song);
            SongsEvent?.Invoke(this, null, songs);
        }

        public void AddPlaylist(Playlist playlist) {
            playlists.Add(playlist);
            foreach (var song in playlist.songs) {
                AddSong(song);
            }

            SongsEvent?.Invoke(this, playlist, playlist.songs);
            PlaylistsEvent?.Invoke(this, playlists);
        }
    }
}
