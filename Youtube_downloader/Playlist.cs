using System.Collections.Generic;

namespace Youtube_downloader {
    public class Playlist {
        public int id;
        public string playlistName;
        public List<Song> songs;
        public string playlistUrl;
        public string directoryPath;
    }
}
