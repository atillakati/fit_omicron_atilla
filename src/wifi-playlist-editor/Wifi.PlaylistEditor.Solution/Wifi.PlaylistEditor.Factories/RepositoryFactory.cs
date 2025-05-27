using System.Collections.Generic;
using System.IO;
using Wifi.PlaylistEditor.Core;
using Wifi.PlaylistEditor.Repositories;

namespace Wifi.PlaylistEditor.Factories
{
    public class RepositoryFactory : IPlaylistRepositoryFactory
    {
        private readonly IPlaylistFactory _playlistFactory;
        private readonly IPlaylistItemFactory _playlistItemFactory;

        public RepositoryFactory(IPlaylistFactory playlistFactory, 
                                 IPlaylistItemFactory playlistItemFactory)
        {
            _playlistFactory = playlistFactory;
            _playlistItemFactory = playlistItemFactory;
        }

        public IEnumerable<IFileTypeInfo> AvailableTypes
        {
            get
            {
                return new IFileTypeInfo[]
                {
                    new M3uRepository(null, null),
                    new PlsRepository(null, null),
                    new WplRepository(null, null),
                    new ZplRepository(null, null)
                };
            }
        }

        public IPlaylistRepository Create(string filePath)
        {
            IPlaylistRepository repository = null;

            if (string.IsNullOrEmpty(filePath))
            {
                return null;
            }

            //retrieve the playlist file extension
            var extension = Path.GetExtension(filePath);

            switch (extension)
            {
                case ".m3u":
                    repository = new M3uRepository(_playlistFactory, _playlistItemFactory);
                    break;

                case ".pls":
                    repository = new PlsRepository(_playlistFactory, _playlistItemFactory);
                    break;

                case ".wpl":
                    repository = new WplRepository(_playlistFactory, _playlistItemFactory);
                    break;

                case ".zpl":
                    repository = new ZplRepository(_playlistFactory, _playlistItemFactory);
                    break;

                default:
                    repository = null;
                    break;
            }

            return repository;
        }
    }
}
