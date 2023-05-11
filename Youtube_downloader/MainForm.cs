using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeDLSharp;

namespace Youtube_downloader
{
    public partial class MainForm : Form
    {
        YouTubeDownload youtubeDownload;
        Database database;
        static string databasePath = @"Data Source=C:\Users\Home\Desktop\Downloads\downloads.sqlite";
        private List<Song> currentSongs;

        public MainForm()
        {
            InitializeComponent();
            youtubeDownload = new YouTubeDownload(); 
            database = new Database(databasePath);
            currentSongs = database.GetSongs();
            Update();
        }

        private async void downloadAudioButton_Click(object sender, EventArgs e)
        {
            var progress = new Progress<DownloadProgress>(p => downloadProgressBar.Value = (int)(p.Progress*100));
            var result = await youtubeDownload.Download(linkInputTextBox.Text, progress);
            if(result.Success) {
                if(result.Playlist != null) {
                    database.AddPlaylist(result.Playlist);
                }
                if (result.Song != null) {
                    database.AddSong(result.Song);
                    currentSongs = database.GetSongs();
                }
            }
            Update();
        }

        private void Update() {
            trackListBox.Items.Clear();
            foreach (Song item in currentSongs) {
                trackListBox.Items.Add(item.songName);
            }

            playlistListBox.Items.Clear();
            playlistListBox.Items.Add("Все загруженные песни");
            foreach (Playlist item in database.GetPlaylists()) {
                playlistListBox.Items.Add(item.playlistName);
            }
        }

        private void trackListBox_SelectedIndexChanged(object sender, EventArgs e) {
            if(trackListBox.SelectedIndex == -1) {
                return;
            }
            
            player.currentPlaylist = player.newPlaylist("", ""); // создаём плейлист для плеера из списка песен
            
            foreach (Song item in currentSongs) {
                player.currentPlaylist.appendItem(player.newMedia(item.filePath)); // добавление медиа в плейлист плеера
            }

            // Получаем медиа песни из плейлиста плеера по индексу песни
            var songMedia = player.currentPlaylist.get_Item(trackListBox.SelectedIndex);
            player.Ctlcontrols.playItem(songMedia); // начинает воспроизводить плейлист с заданной песни
        }

        private void playlistListBox_SelectedIndexChanged(object sender, EventArgs e) {
            if(playlistListBox.SelectedIndex == -1) {
                return;
            }

            if(playlistListBox.SelectedIndex == 0) {
                currentSongs = database.GetSongs();
            } else {
                Playlist playlist = database.GetPlaylists()[playlistListBox.SelectedIndex - 1];
                currentSongs = playlist.songs;
            }
            Update();
        }
    }
}
