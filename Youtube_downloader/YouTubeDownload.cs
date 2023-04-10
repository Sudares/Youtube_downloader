using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using YoutubeDLSharp;
using YoutubeDLSharp.Options;

namespace Youtube_downloader {
    internal class YouTubeDownload {
        static YoutubeDL youtubeDownloader;
        static string sourcePath = @"C:\Users\Home\Desktop";
        static YouTubeDownload() {
            youtubeDownloader = new YoutubeDL();
            youtubeDownloader.YoutubeDLPath = @"C:\Users\Home\source\repos\Youtube_downloader\Youtube_downloader\ytDownloader\yt-dlp.exe";
            youtubeDownloader.FFmpegPath = @"C:\Users\Home\source\repos\Youtube_downloader\Youtube_downloader\ytDownloader\ffmpeg\bin\ffmpeg.exe";
            youtubeDownloader.OutputFolder = sourcePath;
        }

        public async void DownloadAudio(string link, IProgress<DownloadProgress> progress) 
        { 
            await youtubeDownloader.RunAudioDownload(link, AudioConversionFormat.Mp3, progress: progress);
        }

        public async void DownloadPlaylist(string link) 
        {
            await youtubeDownloader.RunAudioPlaylistDownload(link, format: AudioConversionFormat.Mp3);
        }
    }
}
