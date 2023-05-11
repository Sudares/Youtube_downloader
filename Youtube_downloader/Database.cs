using System.Data.SQLite;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace Youtube_downloader {
    public class Database {
        private SQLiteConnection connection;

        public Database(string path) {
            connection = new SQLiteConnection(path);
            //SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
            //SQLitePCL.Battaries.Init();
            connection.Open();

            CreateTable("playlists", new string[]{"id INTEGER PRIMARY KEY",
                                                  "playlistName VARCHAR(255) NOT NULL",
                                                  "playlistUrl VARCHAR(255) NOT NULL",
                                                  "directoryPath VARCHAR(255) NOT NULL"});

            CreateTable("songs", new string[]{"id INTEGER PRIMARY KEY",
                                              "songName VARCHAR",
                                              "author VARCHAR",
                                              "url VARCHAR",
                                              "authorUrl VARCHAR",
                                              "filePath VARCHAR",
                                              "playlistId INT",
                                              "FOREIGN KEY (playlistId) REFERENCES Playlist(id)"});
        }

        private void CreateTable(string tableName, string[] columns) {
            var command = connection.CreateCommand();
            command.CommandText = $"CREATE TABLE IF NOT EXISTS {tableName} ({string.Join(",", columns)});";
            command.ExecuteNonQuery();
        }

        private int InsertInto(string tableName, string[] columns, object[] values) {
            var command = connection.CreateCommand();
            string[] parameters = new string[columns.Length];
            for(int i = 0; i < parameters.Length; i++) {
                parameters[i] = $"${i}";
            }
            command.CommandText = $"INSERT INTO {tableName} ({string.Join(",", columns)}) VALUES ({string.Join(",", parameters)});";
            for(int i = 0; i < parameters.Length; i++) {
                command.Parameters.AddWithValue($"${i}", values[i]);
            }
            command.ExecuteNonQuery();

            command = connection.CreateCommand();
            command.CommandText = $"SELECT last_insert_rowid();";
            var reader = command.ExecuteReader();
            reader.Read();
            return reader.GetInt32(0);
        }

        private List<List<string>> Select(string tableName, string[] columns, string additional = "") { 
            var command = connection.CreateCommand();
            command.CommandText = $"SELECT {string.Join(",", columns)} FROM {tableName} {additional} ORDER BY id DESC;";
            var rows = new List<List<string>>();
            using (var reader = command.ExecuteReader()) {
                while (reader.Read()) {
                   var row = new List<string>();
                   for(var i = 0; i < columns.Length; i++) {
                        row.Add(reader[i].ToString());
                   }
                   rows.Add(row);
                }
            }
            return rows;
        }

        public List<Playlist> GetPlaylists() {
            var rows = Select("playlists", new string[]{"id", "playlistName", "playlistUrl", "directoryPath"});
            var playlists = new List<Playlist>();
            foreach (var row in rows) {
                var playlist = new Playlist();
                playlist.id = int.Parse(row[0]);
                playlist.playlistName = row[1];
                playlist.playlistUrl = row[2];
                playlist.directoryPath = row[3];
                playlist.songs = GetSongs($"WHERE playlistId = {playlist.id}");
                playlists.Add(playlist);
            }
            return playlists;
        }

        public List<Song> GetSongs(string additional = "") {
            var rows = Select("songs", new string[] {"id", "songName", "author", "url", "authorUrl", "filePath", "playlistId"}, additional);
            var songs = new List<Song>();
            foreach (var row in rows) {
                var song = new Song();
                song.id = int.Parse(row[0]);
                song.songName = row[1];
                song.author= row[2];
                song.url = row[3];
                song.authorUrl = row[4];
                song.filePath = row[5];
                songs.Add(song);
            }
            return songs;
        }

        public int AddSong(Song song, Playlist playlist = null) { // добавление песни в базу данных
            return InsertInto("songs", new string[]{"songName", "author", "url", "authorUrl", "filePath", "playlistId"}, 
                                            new object[]{song.songName, song.author, song.url, song.authorUrl, song.filePath, playlist?.id});
        }

        public int AddPlaylist(Playlist playlist) { // добавление плейлиста в базу данных
            playlist.id = InsertInto("playlists", new string[]{"playlistName", "playlistUrl", "directoryPath"}, 
                       new object[]{playlist.playlistName, playlist.playlistUrl, playlist.directoryPath});
            foreach (var song in playlist.songs) { // добавление песен плейлиста в базу данных
                AddSong(song, playlist);
            }
            return playlist.id;
        }
    }
}
