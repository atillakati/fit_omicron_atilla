using System;
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

        public IPlaylistRepository AvailableTypes => throw new NotImplementedException();

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

                default:
                    repository = null;
                    break;
            }

            return repository;
        }
    }
}
