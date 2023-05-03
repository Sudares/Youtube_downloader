using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Youtube_downloader {
    public class Database {
        public List<Playlist> Playlists = new List<Playlist>();
        public List<Song> Songs = new List<Song>();

        public static void Save(Database database, string path) {
            XmlSerializer serializer = new XmlSerializer(typeof(Database));
            using (StreamWriter sw = new StreamWriter(path)) {
                serializer.Serialize(sw, database);
            }
        }

        public static Database Load(string path) {
            XmlSerializer serializer = new XmlSerializer(typeof(Database));
            using(StreamReader sr = File.OpenText(path)) {
                return (Database)serializer.Deserialize(sr);
            }
        }
    }
}
