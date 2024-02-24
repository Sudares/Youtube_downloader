using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using Microsoft.Win32;

namespace Youtube_downloader {
    public partial class MainForm : Form {
        private readonly string downloadsPath;
        private readonly string applicationPath;

        private readonly YouTubeDownload youtubeDownload;
        private readonly Database database;
        private List<Song> currentSongs;
        private Playlist currentPlaylist;
        private bool currentPlaylistAll = true;
        private List<Playlist> currentPlaylists;

        private bool PlaylistListViewSelected => playlistListView.SelectedIndices.Count > 0;
        private int PlaylistListViewSelectedIndex => PlaylistListViewSelected ? playlistListView.SelectedIndices[0] : -1;

        private bool TrackListViewSelected => trackListView.SelectedIndices.Count > 0;
        private int TrackListViewSelectedIndex => TrackListViewSelected ? trackListView.SelectedIndices[0] : -1;

        public MainForm() {
            InitializeComponent();

            MinimumSize = new Size(450, 300);

            var dataPath = Application.UserAppDataPath;

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

            database = new Database($"Data Source={Application.UserAppDataPath}\\downloads.sqlite");
            database.OnPlaylistInsert += (Playlist playlist) => UpdateView();
            database.OnPlaylistDelete += (Playlist playlist) => {
                youtubeDownload.CancelDownload(playlist);

                if (Directory.Exists(playlist.directoryPath)) {
                    Directory.Delete(playlist.directoryPath, true);
                }

                UpdateView();
            };
            database.OnSongInsert += (Song song) => UpdateView();
            database.OnSongMove += (Song song, Playlist playlist) => UpdateView();
            database.OnSongUpdate += (Song song) => UpdateViewSong(song);
            database.OnSongDelete += (Song song) => {
                youtubeDownload.CancelDownload(song);

                if (File.Exists(song.filePath)) {
                    File.Delete(song.filePath);
                }

                UpdateView();
            };

            youtubeDownload = new YouTubeDownload(downloadsPath, applicationPath);
            youtubeDownload.OnCreateSong += (Song song, Playlist playlist) => database.AddSong(song, playlist);
            youtubeDownload.OnUpdateSongProgress += (Song song, int progress) => database.UpdateSongProgress(song, progress);
            youtubeDownload.OnUpdateSongPath += (Song song, string path) => database.UpdateSongPath(song, path);
            youtubeDownload.OnStopSong += (Song song) => database.UpdateSongStopped(song, true);
            youtubeDownload.OnDeleteSong += (Song song) => database.DeleteSong(song);
            youtubeDownload.OnCreatePlaylist += (Playlist playlist) => database.AddPlaylist(playlist);
            youtubeDownload.OnDeletePlaylist += (Playlist playlist) => database.DeletePlaylist(playlist);

            UpdateView();
        }

        string GetDownloadFolderPath() {
            return Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", 
                                      "{374DE290-123F-4565-9164-39C4925E467B}", String.Empty).ToString();
        }

        private void downloadAudioButton_Click(object sender, EventArgs e) {
            var link = linkInputTextBox.Text;
            linkInputTextBox.Text = "";
            Download(link);
        }

        private void Download(string link) {
            youtubeDownload.Download(link);
        }

        private string MakeSongListViewItemText(Song song) {
            var result = song.songName;

            if (song.progress < 100) {
                result += $" [{song.progress}%]";

                if (song.stopped) {
                    result += $" [Остановлено]";
                }
            }

            return result;
        }

        private ListViewItem MakeSongListViewItem(Song song) {
            return new ListViewItem(MakeSongListViewItemText(song), 0);
        }

        private void UpdateViewSong(Song song) {
            var songIndex = currentSongs.FindIndex(e => e.id == song.id);
            if (songIndex == -1) {
                return;
            }

            currentSongs[songIndex] = song; 
            trackListView.Items[songIndex].Text = MakeSongListViewItemText(song);
        }

        private void UpdateView() {
            if (currentPlaylist == null) {
                if (currentPlaylistAll) {
                    currentSongs = database.GetSongs();
                } else {
                    currentSongs = database.GetSongs("WHERE progress < 100");
                }
            } else {
                currentSongs = database.GetSongs($"WHERE playlistId = {currentPlaylist.id}");
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
            //for (var i = 0; i < currentSongs.Count; i++) {
            //songImages.Images.Add(new Bitmap("C:\\Users\\One\\Pictures\\жабздец.jpg"));
            //}

            var songItems = new List<ListViewItem>();
            foreach (Song song in currentSongs) {
                songItems.Add(MakeSongListViewItem(song));
            }

            var playlistItems = new List<ListViewItem> {
                new ListViewItem("Все песни"),
                new ListViewItem("Все загружаемые песни")
            };
            foreach (Playlist playlist in currentPlaylists) {
                playlistItems.Add(new ListViewItem(playlist.playlistName, 0));
            }

            trackListView.Items.Clear();
            //trackListView.SmallImageList = songImages;
            trackListView.Items.AddRange(songItems.ToArray());

            playlistListView.Items.Clear();
            playlistListView.Items.AddRange(playlistItems.ToArray());
        }

        private void trackListView_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete) {
                DeletetrackListViewItem();
            }
        }

        private void DeletetrackListViewItem() {
            foreach (int i in trackListView.SelectedIndices) {
                Song song = currentSongs[i];
                DeleteSong(song);
            }
        }

        private void MovetrackListViewItem() {
            foreach (int i in trackListView.SelectedIndices)
            {
                Song song = currentSongs[i];
                if (song == null)
                {
                    return;
                }

                var selectingPlaylistForm = new SelectingPlaylistForm(database);
                selectingPlaylistForm.ShowDialog();
                if (selectingPlaylistForm.selectedPlaylist == null)
                {
                    return;
                }

                MoveSongToPlaylist(song, selectingPlaylistForm.selectedPlaylist);
            }
        }

        private void StopTrackItemDownload()
        {
            foreach (int i in trackListView.SelectedIndices) {
                Song song = currentSongs[i];
                if (song == null) {
                    return;
                }

                if (song.stopped || song.progress >= 100) {
                    return;
                }

                youtubeDownload.CancelDownload(song);
            }
        }

        private void ResumeTrackItemDownload()
        {
            foreach (int i in trackListView.SelectedIndices)
            {
                Song song = currentSongs[TrackListViewSelectedIndex];
                if (song == null)
                {
                    return;
                }

                if (!song.stopped || song.progress >= 100)
                {
                    return;
                }

                database.UpdateSongStopped(song, false);
                youtubeDownload.StartSongDownload(song, database.GetSongPlaylist(song));
            }
        }

        private void trackListView_DoubleClick(object sender, EventArgs e) {
            if (TrackListViewSelectedIndex == -1) {
                return;
            }

            player.currentPlaylist = player.newPlaylist("", ""); // создаём плейлист для плеера из списка песен

            var currentSong = currentSongs[TrackListViewSelectedIndex];
            if (currentSong == null || currentSong.progress < 100) {
                return;
            }

            foreach (Song item in currentSongs) {
                player.currentPlaylist.appendItem(player.newMedia(item.filePath)); // добавление медиа в плейлист плеера
            }

            // Получаем медиа песни из плейлиста плеера по индексу песни
            var songMedia = player.currentPlaylist.Item[TrackListViewSelectedIndex];
            player.Ctlcontrols.playItem(songMedia); // начинает воспроизводить плейлист с заданной песни
        }

        private void playlistListView_DoubleClick(object sender, EventArgs e) {
            if (PlaylistListViewSelectedIndex == -1) {
                return;
            }

            switch (PlaylistListViewSelectedIndex) {
                case 0:
                    currentPlaylist = null;
                    currentPlaylistAll = true;
                    break;
                case 1:
                    currentPlaylist = null;
                    currentPlaylistAll = false;
                    break;
                default:
                    currentPlaylist = database.GetPlaylists()[PlaylistListViewSelectedIndex - 2];
                    break;
            }

            UpdateView();
        }

        private void DeletePlaylistListViewItem() {
            if (PlaylistListViewSelectedIndex < 2) {
                return;
            }

            Playlist playlist = database.GetPlaylists()[PlaylistListViewSelectedIndex - 2];
            DeletePlaylist(playlist);
        }

        private void playlistListView_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete) {
                DeletePlaylistListViewItem();
            }
        }

        private void DeleteSong(Song song) {
            database.DeleteSong(song);

            // Удаление песни из player.currentPlaylist, с проверкой на то, что SelectedIndex не выходит за границу списка
            if (TrackListViewSelectedIndex != -1 && player.currentPlaylist.count > TrackListViewSelectedIndex) {
                player.currentPlaylist.removeItem(player.currentPlaylist.Item[TrackListViewSelectedIndex]);
            }
        }

        private void MoveSongToPlaylist(Song song, Playlist playlist) {
            database.UpdateSongPlaylist(song, playlist);

            var newPath = $@"{playlist.directoryPath}\{Path.GetFileName(song.filePath)}";
            File.Move(song.filePath, newPath);
            database.UpdateSongPath(song, newPath);
        }

        private void DeletePlaylist(Playlist playlist) {
            database.DeletePlaylist(playlist);

            // Сброс удалённого плейлиста
            if (currentPlaylist != null && currentPlaylist.id == playlist.id) {
                currentPlaylist = null;
            }
        }

        private void addPlaylistButton_Click(object sender, EventArgs e) {
            CreatePlaylistForm form = new CreatePlaylistForm(database, downloadsPath);
            form.ShowDialog();
        }

        private void trackListView_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Right) {
                return;
            }

            var item = trackListView.GetItemAt(e.Location.X, e.Location.Y);
            if (item == null) {
                trackListView.ContextMenu = null;
                return;
            }

            var song = currentSongs[item.Index];
            if (song == null) {
                return;
            }

            trackListView.SelectedIndices.Clear();
            trackListView.SelectedIndices.Add(item.Index);

            var contextMenuItems = new MenuItem[]{
                new MenuItem("Добавить в", (s, ev) => MovetrackListViewItem()),
                new MenuItem("Удалить", (s, ev) => DeletetrackListViewItem())
            };
            
            if (song.progress < 100) {
                contextMenuItems = contextMenuItems.Append(
                    song.stopped
                        ? new MenuItem("Возобновить загрузку", (s, ev) => ResumeTrackItemDownload())
                        : new MenuItem("Остановить загрузку", (s, ev) => StopTrackItemDownload())
                ).ToArray();
            }

            trackListView.ContextMenu = new ContextMenu(contextMenuItems);
        }

        private void playlistListView_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Right) {
                return;
            }

            var item = playlistListView.GetItemAt(e.Location.X, e.Location.Y);
            if (item == null) {
                playlistListView.ContextMenu = null;
                return;
            }

            if (item.Index < 2) {
                return;
            }

            playlistListView.SelectedIndices.Clear();
            playlistListView.SelectedIndices.Add(item.Index);
            playlistListView.ContextMenu = new ContextMenu(
                new MenuItem[]{
                    new MenuItem("Удалить", (s, ev) => DeletePlaylistListViewItem())
                }
            );
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
                    youtubeDownload.DownloadsPath = dialog.SelectedPath;
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
