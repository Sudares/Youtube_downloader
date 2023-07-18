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
    public partial class CreatePlaylistForm : Form {
        private readonly Database database;
        private readonly string downloadsPath;

        public CreatePlaylistForm(Database _database, string _downloadsPath) {
            InitializeComponent();

            database = _database;
            downloadsPath = _downloadsPath;
        }

        private void createNewPlaylistButton_Click(object sender, EventArgs e) {
            if(playlistNameTextBox.Text.Length == 0 ) {
                return;
            }

            Playlist playlist = new Playlist();
            playlist.playlistName = playlistNameTextBox.Text;
            playlist.directoryPath = $@"{downloadsPath}\{playlist.playlistName}";
            playlist.songs = new List<Song>();
            playlist.playlistUrl = "";

            if (!System.IO.Directory.Exists(playlist.directoryPath)) {
                System.IO.Directory.CreateDirectory(playlist.directoryPath);
            }
            database.AddPlaylist(playlist);
            Close();
        }
    }
}
