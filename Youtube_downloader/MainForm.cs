using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeDLSharp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Youtube_downloader
{
    public partial class MainForm : Form
    {
        YouTubeDownload youtubeDownload;
        Database database;
        static string databasePath = @"Data Source=C:\Users\Home\Desktop\Downloads\downloads.sqlite";
        private List<Song> currentSongs;
        private Playlist currentPlaylist;

        public MainForm()
        {
            InitializeComponent();
            MinimumSize = new System.Drawing.Size(450, 300);
            youtubeDownload = new YouTubeDownload(); 
            database = new Database(databasePath);
            Update();
            trackListBox.ContextMenu = new ContextMenu(
                new MenuItem[]{
                    new MenuItem("Удалить", (s,ev) => DeleteTrackListBoxItem())
                }
            );
             playlistListBox.ContextMenu = new ContextMenu(
                new MenuItem[]{
                    new MenuItem("Удалить", (s,ev) => DeletePlaylistListBoxItem())
                }
            );
        }

        private async void downloadAudioButton_Click(object sender, EventArgs e)
        {
            var progress = new Progress<DownloadProgress>(p => downloadProgressBar.Value = (int)(p.Progress*100));
            var link = linkInputTextBox.Text;
            linkInputTextBox.Text = "";
            var result = await youtubeDownload.Download(link, progress);
            if(result.Success) {
                if(result.Playlist != null) {
                    database.AddPlaylist(result.Playlist);
                }
                if(result.Song != null) {
                    if(currentPlaylist != null) {
                        var newPath = currentPlaylist.directoryPath + "\\" + System.IO.Path.GetFileName(result.Song.filePath);
                        System.IO.File.Move(result.Song.filePath, newPath);
                        result.Song.filePath = newPath;
                        currentPlaylist.songs.Add(result.Song);
                    }
                    database.AddSong(result.Song, currentPlaylist);
                }
            }
            Update();
        }

        private void Update() {
            if(currentPlaylist != null) {
                currentSongs = database.GetSongs($"WHERE playlistId = {currentPlaylist.id}");
            } else {
                currentSongs = database.GetSongs();
            }

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

        private void trackListBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete) {
                DeleteTrackListBoxItem();
            }
        }

        private void DeleteTrackListBoxItem() {
            if (trackListBox.SelectedIndex != -1) {
                Song song = currentSongs[trackListBox.SelectedIndex];
                DeleteSong(song);
                Update();
            }
        }

        private void trackListBox_DoubleClick(object sender, EventArgs e) {
            if (trackListBox.SelectedIndex == -1) {
                return;
            }

            player.currentPlaylist = player.newPlaylist("", ""); // создаём плейлист для плеера из списка песен

            foreach (Song item in currentSongs) {
                player.currentPlaylist.appendItem(player.newMedia(item.filePath)); // добавление медиа в плейлист плеера
            }

            // Получаем медиа песни из плейлиста плеера по индексу песни
            var songMedia = player.currentPlaylist.Item[trackListBox.SelectedIndex];
            player.Ctlcontrols.playItem(songMedia); // начинает воспроизводить плейлист с заданной песни
        }

        private void playlistListBox_DoubleClick(object sender, EventArgs e) {
            if (playlistListBox.SelectedIndex == -1) {
                return;
            }

            if (playlistListBox.SelectedIndex == 0) {
                currentPlaylist = null;
            } else {
                currentPlaylist = database.GetPlaylists()[playlistListBox.SelectedIndex - 1];
            }
            Update();
        }

        private void DeletePlaylistListBoxItem() {
            if (playlistListBox.SelectedIndex > 0) {
                Playlist playlist = database.GetPlaylists()[playlistListBox.SelectedIndex - 1];
                DeletePlaylist(playlist);
                Update();
            }
        }

        private void playlistListBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete) {
                DeletePlaylistListBoxItem();
            }
        }

        private void DeleteSong(Song song) {
            database.DeleteSong(song);
            if (System.IO.File.Exists(song.filePath)) {
                System.IO.File.Delete(song.filePath);
            }
            // Удаление песни из player.currentPlaylist, с проверкой на то, что SelectedIndex не выходит за границу списка
            if (trackListBox.SelectedIndex != -1 && player.currentPlaylist.count > trackListBox.SelectedIndex) { 
                player.currentPlaylist.removeItem(player.currentPlaylist.Item[trackListBox.SelectedIndex]);
            }
        }

        private void DeletePlaylist(Playlist playlist) {
            database.DeletePlaylist(playlist);
            if (System.IO.Directory.Exists(playlist.directoryPath)) {
                System.IO.Directory.Delete(playlist.directoryPath, true);
            }

            foreach(Song song in playlist.songs) {
                DeleteSong(song);
            }

            // Сброс удалённого плейлиста
            if(currentPlaylist != null && currentPlaylist.id == playlist.id) {
                currentPlaylist = null;
            }
        }

        private void addPlaylistButton_Click(object sender, EventArgs e) {
            CreatePlaylistForm form = new CreatePlaylistForm(database);
            form.ShowDialog();
            Update();
        }

        private void trackListBox_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button == MouseButtons.Right) {
                trackListBox.SelectedIndex = trackListBox.IndexFromPoint(e.Location);
            }
        }

        private void playlistListBox_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                playlistListBox.SelectedIndex = playlistListBox.IndexFromPoint(e.Location);
            }
        }
    }
}
