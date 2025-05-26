using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.PlaylistEditor.Core
{
    public interface IPlaylistRepositoryFactory
    {
        //ToDO: Define here a different return type!!!!
        IPlaylistRepository AvailableTypes { get; }

        IPlaylistRepository Create(string filePath);
    }
}
