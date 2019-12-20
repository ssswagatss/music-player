using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace MvcMusicPlayer.Models
{
    public class Song
    {
        public int SongId { get; set; }
        public string SongName { get; set; }
        public string MovieName { get; set; }
        public int Year { get; set; }
        public string[] Singers { get; set; }
        public string Path { get; set; }

        public static IEnumerable<Song> GetSongs()
        {
            var songs = new List<Song>();
            using (StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath("~/Data/music.json")))
            {
                songs.AddRange(JsonConvert.DeserializeObject<List<Song>>(sr.ReadToEnd()));
            }
            return songs;
        }
    }
}
