using System.Data.SQLite;
using System.Collections.Generic;
using static Youtube_downloader.YouTubeDownload;

namespace Youtube_downloader {
    public class Database {
        private readonly SQLiteConnection connection;

        public delegate void PlaylistHandler(Playlist playlist);
        public event PlaylistHandler OnPlaylistInsert;
        public event PlaylistHandler OnPlaylistDelete;

        public delegate void SongHandler(Song song);
        public event SongHandler OnSongInsert;
        public event SongHandler OnSongUpdate;
        public event SongHandler OnSongDelete;

        public delegate void SongMoveHandler(Song song, Playlist playlist);
        public event SongMoveHandler OnSongMove;

        public Database(string path) {
            connection = new SQLiteConnection(path);
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
                                              "progress INT",
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

        private void Delete(string tableName, int id) {
            var command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM {tableName} WHERE id = $id";
            command.Parameters.AddWithValue("$id", id);
            command.ExecuteNonQuery();
        }

        private void Update(string tableName, int id, string field, object value) {
            var command = connection.CreateCommand();
            command.CommandText = $"UPDATE {tableName} SET {field} = $value WHERE id = $id";
            command.Parameters.AddWithValue("$id", id);
            command.Parameters.AddWithValue("$value", value);
            command.ExecuteNonQuery();
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
            var rows = Select("songs", new string[] {"id", "songName", "author", "url", "authorUrl", "filePath", "progress"}, additional);
            var songs = new List<Song>();
            foreach (var row in rows) {
                var song = new Song {
                    id = int.Parse(row[0]),
                    songName = row[1],
                    author = row[2],
                    url = row[3],
                    authorUrl = row[4],
                    filePath = row[5],
                    progress = int.Parse(row[6])
                };
                songs.Add(song);
            }
            return songs;
        }

        public void AddSong(Song song, Playlist playlist = null) { // добавление песни в базу данных
            song.id = InsertInto("songs", new string[]{"songName", "author", "url", "authorUrl", "filePath", "playlistId", "progress"}, 
                                            new object[]{song.songName, song.author, song.url, song.authorUrl, song.filePath, playlist?.id, song.progress});
            OnSongInsert?.Invoke(song);
        }

        public void AddPlaylist(Playlist playlist) { // добавление плейлиста в базу данных
            playlist.id = InsertInto("playlists", new string[] { "playlistName", "playlistUrl", "directoryPath" },
                       new object[] { playlist.playlistName, playlist.playlistUrl, playlist.directoryPath });
            OnPlaylistInsert?.Invoke(playlist);
        }

        public void DeleteSong(Song song) {
            Delete("songs", song.id);
            OnSongDelete?.Invoke(song);
        }

        public void DeletePlaylist(Playlist playlist) {
            Delete("playlists", playlist.id);

            foreach (Song song in playlist.songs) {
                DeleteSong(song);
            }

            OnPlaylistDelete?.Invoke(playlist);
        }

        public void UpdateSongPlaylist(Song song, Playlist playlist) {
            Update("songs", song.id, "playlistId", playlist.id);
            OnSongMove?.Invoke(song, playlist);
        }

        public void UpdateSongPath(Song song, string path) {
            song.filePath = path;
            Update("songs", song.id, "filePath", path);
            OnSongUpdate?.Invoke(song);
        }

        public void UpdateSongProgress(Song song, int progress) {
            song.progress = progress;
            Update("songs", song.id, "progress", progress);
            OnSongUpdate?.Invoke(song);
        }
    }
}
