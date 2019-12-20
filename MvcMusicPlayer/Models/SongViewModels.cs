using System.Collections.Generic;

namespace MvcMusicPlayer.Models
{
    public class SongViewModel
    {
        public SongViewModel()
        {
            OtherAvailableSongs = new List<Song>();
        }
        public Song CurrentlyPlayingSong { get; set; }
        public List<Song> OtherAvailableSongs { get; set; }
    }
}

