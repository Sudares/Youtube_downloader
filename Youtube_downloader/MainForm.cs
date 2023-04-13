using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeDLSharp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Youtube_downloader
{
    public partial class MainForm : Form
    {
        YouTubeDownload youtubeDownload; 
        //private BackgroundWorker backgroundWorker = new BackgroundWorker();    для ProgressBar

        public MainForm()
        {
            InitializeComponent();
            youtubeDownload = new YouTubeDownload();
            youtubeDownload.SongsEvent += (object o, Playlist playlist, List<Song> songs) => {
                if(playlist == null) { 
                    trackListBox.Items.Clear();
                    foreach(Song song in songs) {
                        trackListBox.Items.Add(song.songName);
                    }
                }
            };

            youtubeDownload.PlaylistsEvent += (object o, List<Playlist> playlists) => {
                playlistListBox.Items.Clear();
                foreach (Playlist playlist in playlists) {
                    playlistListBox.Items.Add(playlist.playlistName);
                }
            };
        }

        private async void downloadAudioButton_Click(object sender, EventArgs e)
        {
            var progress = new Progress<DownloadProgress>(p => downloadProgressBar.Value = (int)(p.Progress*10));
            youtubeDownload.Download(linkInputTextBox.Text, progress);
        }
    }
}
