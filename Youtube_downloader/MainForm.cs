using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using YoutubeDLSharp;
using System.Linq;
using Microsoft.Win32;

namespace Youtube_downloader
{
    public partial class MainForm : Form
    {
        private string downloadsPath;
        private readonly string applicationPath;

        private  YouTubeDownload youtubeDownload;
        private readonly Database database;
        private List<Song> currentSongs;
        private Playlist currentPlaylist;
        private List<Playlist> currentPlaylists;

        private bool playlistListViewSelected => playlistListView.SelectedIndices.Count > 0;
        private int playlistListViewSelectedIndex => playlistListViewSelected ? playlistListView.SelectedIndices[0] : -1;

        private bool trackListViewSelected => trackListView.SelectedIndices.Count > 0;
        private int trackListViewSelectedIndex => trackListViewSelected ? trackListView.SelectedIndices[0] : -1;


        public MainForm()
        {
            InitializeComponent();

            if (File.Exists(Path.Combine(Application.UserAppDataPath, "downloadsPath.txt"))) {
                downloadsPath = File.ReadAllText(Path.Combine(Application.UserAppDataPath, "downloadsPath.txt"));
            } else {
                downloadsPath = GetDownloadFolderPath();
            }

            applicationPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Application.StartupPath).ToString()).ToString()).ToString();

            if (!Directory.Exists(downloadsPath))
            {
                Directory.CreateDirectory(downloadsPath);
            }

            youtubeDownload = new YouTubeDownload(downloadsPath, applicationPath);
            database = new Database($"Data Source={Application.UserAppDataPath}\\downloads.sqlite");

            MinimumSize = new Size(450, 300);

            UpdateView();
        }

        string GetDownloadFolderPath() {
            return Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", 
                                      "{374DE290-123F-4565-9164-39C4925E467B}", String.Empty).ToString();
        }

        private async void downloadAudioButton_Click(object sender, EventArgs e)
        {
            var link = linkInputTextBox.Text;
            linkInputTextBox.Text = "";
            Download(link);
        }

        private async void Download(string link) {
            var progress = new Progress<DownloadProgress>(p => downloadProgressBar.Value = (int)(p.Progress * 100));
            var result = await youtubeDownload.Download(link, progress);
            if (result.Success) {
                if (result.Playlist != null) {
                    database.AddPlaylist(result.Playlist);
                }
                if (result.Song != null) {
                    if (currentPlaylist != null) {
                        var newPath = currentPlaylist.directoryPath + "\\" + Path.GetFileName(result.Song.filePath);
                        File.Move(result.Song.filePath, newPath);
                        result.Song.filePath = newPath;
                        currentPlaylist.songs.Add(result.Song);
                    }
                    database.AddSong(result.Song, currentPlaylist);
                }
            }
            UpdateView();
        }

        private void UpdateView()
        {
            if (currentPlaylist != null)
            {
                currentSongs = database.GetSongs($"WHERE playlistId = {currentPlaylist.id}");
            }
            else
            {
                currentSongs = database.GetSongs();
            }

            currentPlaylists = database.GetPlaylists();

            var songsSearch = searchTrackTextBox.Text.Trim().ToLower();
            if (songsSearch.Length > 0) {
                currentSongs = currentSongs.Where(song => song.songName.ToLower().Contains(songsSearch)).ToList();
            }

            var playlistsSearch = searchPlaylistTextBox.Text.Trim().ToLower();
            if (playlistsSearch.Length > 0) {
                currentPlaylists = currentPlaylists.Where(playlist => playlist.playlistName.ToLower().Contains(playlistsSearch)).ToList();
            }
            //var songImages = new ImageList();
            //songImages.ImageSize = new Size(64, 64);
            //for (var i = 0; i < currentSongs.Count; i++)
            //{
            //songImages.Images.Add(new Bitmap("C:\\Users\\One\\Pictures\\жабздец.jpg"));
            //}

            var songItems = new List<ListViewItem>();
            foreach (Song song in currentSongs)
            {
                songItems.Add(new ListViewItem(song.songName, 0));
            }

            var playlistItems = new List<ListViewItem>();
            playlistItems.Add(new ListViewItem("Все загруженные песни"));
            foreach (Playlist playlist in currentPlaylists)
            {
                playlistItems.Add(new ListViewItem(playlist.playlistName, 0));
            }

            trackListView.Items.Clear();
            //trackListView.SmallImageList = songImages;
            trackListView.Items.AddRange(songItems.ToArray());

            playlistListView.Items.Clear();
            playlistListView.Items.AddRange(playlistItems.ToArray());
        }

        private void trackListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeletetrackListViewItem();
            }
        }

        private void DeletetrackListViewItem()
        {
            if (trackListViewSelectedIndex != -1)
            {
                Song song = currentSongs[trackListViewSelectedIndex];
                DeleteSong(song);
                UpdateView();
            }
        }

        private void MovetrackListViewItem() {
            if (trackListViewSelectedIndex != -1) {
                Song song = currentSongs[trackListViewSelectedIndex];
                var selectingPlaylistForm = new SelectingPlaylistForm(database);
                selectingPlaylistForm.ShowDialog();
                if(selectingPlaylistForm.selectedPlaylist != null) {
                    MoveSongToPlaylist(song, selectingPlaylistForm.selectedPlaylist);
                }
                UpdateView();
            }
        }

        private void trackListView_DoubleClick(object sender, EventArgs e)
        {
            if (trackListViewSelectedIndex == -1)
            {
                return;
            }

            player.currentPlaylist = player.newPlaylist("", ""); // создаём плейлист для плеера из списка песен

            foreach (Song item in currentSongs)
            {
                player.currentPlaylist.appendItem(player.newMedia(item.filePath)); // добавление медиа в плейлист плеера
            }

            // Получаем медиа песни из плейлиста плеера по индексу песни
            var songMedia = player.currentPlaylist.Item[trackListViewSelectedIndex];
            player.Ctlcontrols.playItem(songMedia); // начинает воспроизводить плейлист с заданной песни
        }

        private void playlistListView_DoubleClick(object sender, EventArgs e)
        {
            if (playlistListViewSelectedIndex == -1)
            {
                return;
            }

            if (playlistListViewSelectedIndex == 0)
            {
                currentPlaylist = null;
            }
            else
            {
                currentPlaylist = database.GetPlaylists()[playlistListViewSelectedIndex - 1];
            }
            UpdateView();
        }

        private void DeletePlaylistListViewItem()
        {
            Playlist playlist = database.GetPlaylists()[playlistListViewSelectedIndex - 1];
            DeletePlaylist(playlist);
            UpdateView();
        }

        private void playlistListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeletePlaylistListViewItem();
            }
        }

        private void DeleteSong(Song song)
        {
            database.DeleteSong(song);
            if (File.Exists(song.filePath))
            {
                File.Delete(song.filePath);
            }
            // Удаление песни из player.currentPlaylist, с проверкой на то, что SelectedIndex не выходит за границу списка
            if (trackListViewSelectedIndex != -1 && player.currentPlaylist.count > trackListViewSelectedIndex)
            {
                player.currentPlaylist.removeItem(player.currentPlaylist.Item[trackListViewSelectedIndex]);
            }
        }

        private void MoveSongToPlaylist(Song song, Playlist playlist) {
            database.UpdateSongPlaylist(song, playlist);
            var newPath = $@"{playlist.directoryPath}\{Path.GetFileName(song.filePath)}";
            File.Move(song.filePath, newPath);
            song.filePath = newPath;
            database.UpdateSongPath(song, newPath);
        }

        private void DeletePlaylist(Playlist playlist)
        {
            database.DeletePlaylist(playlist);
            if (Directory.Exists(playlist.directoryPath))
            {
                Directory.Delete(playlist.directoryPath, true);
            }

            foreach (Song song in playlist.songs)
            {
                DeleteSong(song);
            }

            // Сброс удалённого плейлиста
            if (currentPlaylist != null && currentPlaylist.id == playlist.id)
            {
                currentPlaylist = null;
            }
        }

        private void addPlaylistButton_Click(object sender, EventArgs e)
        {
            CreatePlaylistForm form = new CreatePlaylistForm(database, downloadsPath);
            form.ShowDialog();
            UpdateView();
        }

        private void trackListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = trackListView.GetItemAt(e.Location.X, e.Location.Y);
                if (item != null)
                {
                    trackListView.SelectedIndices.Clear();
                    trackListView.SelectedIndices.Add(item.Index);

                    trackListView.ContextMenu = new ContextMenu(
                        new MenuItem[]{
                           new MenuItem("Добавить в", (s, ev) => MovetrackListViewItem()),
                            new MenuItem("Удалить", (s, ev) => DeletetrackListViewItem())
                        }
                    );
                } else
                {
                    trackListView.ContextMenu = null;
                }
            }
        }

        private void playlistListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = playlistListView.GetItemAt(e.Location.X, e.Location.Y);
                if (item != null)
                {
                    playlistListView.SelectedIndices.Clear();
                    playlistListView.SelectedIndices.Add(item.Index);

                    playlistListView.ContextMenu = new ContextMenu(
                        new MenuItem[]{
                            new MenuItem("Удалить", (s, ev) => DeletePlaylistListViewItem())
                        }
                    );
                }
                else
                {
                    playlistListView.ContextMenu = null;
                }
            }
        }

        private void searchTrackTextBox_TextChanged(object sender, EventArgs e) {
            UpdateView();
        }

        private void searchPlaylistTextBox_TextChanged(object sender, EventArgs e) {
            UpdateView();
        }

        private void выбратьПутьДляСохраненияToolStripMenuItem_Click(object sender, EventArgs e) {
            using (var dialog = new FolderBrowserDialog()) {
                var res = dialog.ShowDialog();
                if (res == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath)) {
                    File.WriteAllText(Path.Combine(Application.UserAppDataPath, "downloadsPath.txt"), dialog.SelectedPath);
                    downloadsPath = dialog.SelectedPath;
                    youtubeDownload = new YouTubeDownload(downloadsPath, applicationPath);
                }
            }
        }

        private void выбратьВБраузереToolStripMenuItem_Click(object sender, EventArgs e) {
            var form = new BrowserForm();
            form.SelectedUrlChanged += (s, url) => Download(url);
            form.Show();
        }
    }
}
