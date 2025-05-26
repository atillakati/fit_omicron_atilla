using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.PlaylistEditor.Core
{
    public interface IPlaylistItemFactory
    {
        //ToDo: Use here a different type!
        IPlaylistItem[] AvailableTypes { get; }

        IPlaylistItem Create(string filePath);
    }
}
