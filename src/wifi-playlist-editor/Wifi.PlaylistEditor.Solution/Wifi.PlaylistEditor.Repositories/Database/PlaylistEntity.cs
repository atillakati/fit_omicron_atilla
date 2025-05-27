using System.Collections.Generic;

namespace Wifi.PlaylistEditor.Repositories.Database
{
    public class PlaylistEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string CreateAt { get; set; }
        public IEnumerable<string> ItemPathList { get; set; }
    }
}