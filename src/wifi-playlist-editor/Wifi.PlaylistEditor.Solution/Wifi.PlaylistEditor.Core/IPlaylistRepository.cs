using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Wifi.PlaylistEditor.Core
{

    /// <summary>
    /// m3u, pls, json
    /// </summary>
    public interface IPlaylistRepository
    {
        string Extension { get; }
        string Description { get; }

        Playlist Load(string playlistPath);

        bool Save(string playlistPath, Playlist playlistToSave);
    }
}
