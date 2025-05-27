using System;
using System.Collections.Generic;

namespace Wifi.PlaylistEditor.Core
{
    public interface IPlaylist
    {
        string Author { get; }
        DateTime CreatedAt { get; }
        TimeSpan Duration { get; }
        IEnumerable<IPlaylistItem> ItemList { get; }
        string Name { get; }

        void Add(IPlaylistItem newItem);
        void Clear();
        void Remove(IPlaylistItem itemToRemove);
    }
}