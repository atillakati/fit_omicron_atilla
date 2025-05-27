using System.Collections.Generic;

namespace Wifi.PlaylistEditor.Core
{
    public interface IPlaylistRepositoryFactory
    {
        IEnumerable<IFileTypeInfo> AvailableTypes { get; }

        IPlaylistRepository Create(string filePath);
    }
}
