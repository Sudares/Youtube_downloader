using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using YoutubeDLSharp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Youtube_downloader
{
    public partial class MainForm : Form
    {
        YouTubeDownload youtubeDownload;
        //private BackgroundWorker backgroundWorker = new BackgroundWorker();    для ProgressBar
        Database database;
        static string databasePath = @"C:\Users\Home\Desktop\Downloads\downloads.xml";
        private List<Song> currentSongs;
        private Playlist currentPlaylist;

        public MainForm()
        {
            InitializeComponent();
            youtubeDownload = new YouTubeDownload(); 
            database = Database.Load(databasePath);
            currentSongs = database.Songs;
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
            foreach (Song item in currentSongs) {
                trackListBox.Items.Add(item.songName);
            }

            playlistListBox.Items.Clear();
            playlistListBox.Items.Add("Все загруженные песни");
            foreach (Playlist item in database.Playlists) {
                playlistListBox.Items.Add(item.playlistName);
            }
        }

        private void trackListBox_SelectedIndexChanged(object sender, EventArgs e) {
            if(trackListBox.SelectedIndex == -1) {
                return;
            }

            Song song = currentSongs[trackListBox.SelectedIndex];
            
            player.currentPlaylist = player.newPlaylist("", ""); // создаём плейлист для плеера из списка песен
            
            foreach (Song item in currentSongs) {
                player.currentPlaylist.appendItem(player.newMedia(item.filePath));
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
                currentPlaylist = null;
                currentSongs = database.Songs;
            } else {
                Playlist playlist = database.Playlists[playlistListBox.SelectedIndex - 1];
                currentPlaylist = playlist;
                currentSongs = playlist.songs;
            }
            Update();
        }
    }
}
