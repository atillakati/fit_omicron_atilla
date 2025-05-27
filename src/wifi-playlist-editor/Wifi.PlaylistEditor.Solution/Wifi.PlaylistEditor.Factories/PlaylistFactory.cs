using System;
using Wifi.PlaylistEditor.Core;

namespace Wifi.PlaylistEditor.Factories
{
    public class PlaylistFactory : IPlaylistFactory
    {
        public IPlaylist Create(string title, string author, DateTime createAt)
        {
            if(string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author))
            {
                return null;
            }

            return new Playlist(title, author, createAt);
        }        
    }
}
