using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        public int Duration { get; set; }

        public string GetDurationString()
        {
            var ts = TimeSpan.FromSeconds(this.Duration);
            return $"{ts.Minutes:D2}:{ts.Seconds:D2}";
        }

        public static IEnumerable<Song> GetSongs()
        {
            var songs = new List<Song>();
            var rootFolderName = ConfigurationManager.AppSettings["MusicFilesVirtualDirectoryName"]?.ToString();
            var publishFolderName = ConfigurationManager.AppSettings["PublishVirtualDirectoryName"]?.ToString();

            using (StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath("~/Data/music.json")))
                songs.AddRange(JsonConvert.DeserializeObject<List<Song>>(sr.ReadToEnd()));

            songs.ForEach(x =>
            {
                x.Path = System.IO.Path.Combine(rootFolderName, x.Path);
            });
            return songs;
        }
    }
}
