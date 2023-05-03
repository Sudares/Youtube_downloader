using System;
using System.IO;
using System.Windows.Forms;
using YoutubeDLSharp;

namespace Youtube_downloader
{
    public partial class MainForm : Form
    {
        YouTubeDownload youtubeDownload;
        //private BackgroundWorker backgroundWorker = new BackgroundWorker();    для ProgressBar
        Database database;
        static string databasePath = @"C:\Users\Home\Desktop\Downloads\downloads.xml";
        public MainForm()
        {
            InitializeComponent();
            youtubeDownload = new YouTubeDownload(); 
            database = Database.Load(databasePath);
            Update();
        }

        private async void downloadAudioButton_Click(object sender, EventArgs e)
        {
            var progress = new Progress<DownloadProgress>(p => downloadProgressBar.Value = (int)(p.Progress*100));
            var result = await youtubeDownload.Download(linkInputTextBox.Text, progress);
            if(result.Success) {
                if(result.Playlist != null) {
                    AddPlaylist(result.Playlist);
                }
                if (result.Song != null) {
                    AddSong(result.Song);
                }
            }

            Update();
            Database.Save(database, databasePath);
        }
        private void AddSong(Song song) {
            database.Songs.Insert(0, song);
        }

        private void AddPlaylist(Playlist playlist) {
            database.Playlists.Add(playlist);
            foreach (var song in playlist.songs) {
                AddSong(song);
            }
        }

        private void Update() {
            trackListBox.Items.Clear();
            foreach (Song item in database.Songs) {
                trackListBox.Items.Add(item.songName);
            }

            playlistListBox.Items.Clear();
            foreach (Playlist item in database.Playlists) {
                playlistListBox.Items.Add(item.playlistName);
            }
        }
    }
}
