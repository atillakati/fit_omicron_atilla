using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.PlaylistEditor.Core;
using Wifi.PlaylistEditor.PlaylistItems;

namespace Wifi.PlaylistEditor.Factories
{
    public class PlaylistItemFactory : IPlaylistItemFactory
    {

        public PlaylistItemFactory() {  }

        public IEnumerable<IFileTypeInfo> AvailableTypes 
        {
            get
            {
                return new IFileTypeInfo[]
                {
                    new Mp3Item(),
                    new PictureItem()
                };
            }
        }

        public IPlaylistItem Create(string filePath)
        {
            IPlaylistItem playlistItem = null;

            var extension = Path.GetExtension(filePath);

            switch(extension)
            {
                case ".mp3":
                    playlistItem = new Mp3Item(filePath);
                    break;

                case ".jpg":
                case ".png":
                    playlistItem = new PictureItem(filePath);
                    break;

                default:
                    playlistItem = null;
                    break;
            }

            return playlistItem;
        }
    }
}
