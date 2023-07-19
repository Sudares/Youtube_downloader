using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youtube_downloader {
    public partial class SelectingPlaylistForm : Form {

        private Database database;
        private List<Playlist> currentPlaylists;
        public Playlist selectedPlaylist;

        public SelectingPlaylistForm(Database database) {
            InitializeComponent();
            this.database = database;
            UpdateView();
        }

        private void UpdateView() {
            currentPlaylists = database.GetPlaylists();

            var playlistsSearch = playlistSearchTextBox.Text.Trim().ToLower();
            if (playlistsSearch.Length > 0) {
                currentPlaylists = currentPlaylists.Where(playlist => playlist.playlistName.ToLower().Contains(playlistsSearch)).ToList();
            }

            var playlistItems = new List<string>();
            foreach (Playlist playlist in currentPlaylists) {
                playlistItems.Add(playlist.playlistName);
            }

            searchPlaylistListBox.Items.Clear();
            searchPlaylistListBox.Items.AddRange(playlistItems.ToArray());
        }

        private void playlistSearchTextBox_TextChanged(object sender, EventArgs e) {
            UpdateView();
        }

        private void searchPlaylistListBox_Click(object sender, EventArgs e) {
            if(searchPlaylistListBox.SelectedIndex != -1) {
                selectedPlaylist = currentPlaylists[searchPlaylistListBox.SelectedIndex];
                Close();
            }
        }
    }
}
