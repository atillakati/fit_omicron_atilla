using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.PlaylistEditor.Core;
using Wifi.PlaylistEditor.Repositories.Database;

namespace Wifi.PlaylistEditor.Repositories
{
    public class DatabaseRepository
    {
        private IDataBaseDriver<PlaylistEntity> _dataBaseDriver;
        private readonly IPlaylistFactory _playlistFactory;
        private IPlaylistItemFactory _playlistItemFactory;


        public DatabaseRepository(IDataBaseDriver<PlaylistEntity> dataBaseDriver,
                                  IPlaylistFactory playlistFactory,
                                  IPlaylistItemFactory playlistItemFactory)
        {
            _dataBaseDriver = dataBaseDriver;
            _playlistFactory = playlistFactory;
            _playlistItemFactory = playlistItemFactory;
        }

        //public DatabaseRepository()
        //{
        //    //app.config file setting?
        //    var connection = "mongodb://admin:password@localhost:27017";            

        //    _dataBaseDriver = new MongoDbDriver<PlaylistEntity>(connection, "playlist-db", "playlist-collection");
            
        //    //someone has to provide us an instance ...??
        //    //_playlistItemFactory = new PlaylistItemFactory();
        //}

        public async Task<IEnumerable<string>> LoadAllPlaylistTitles()
        {
            var playlists = await _dataBaseDriver.GetAllAsync();

            return playlists.Select(x => x.Title);
        }

        public async Task<bool> Save(IPlaylist playlistToSave)
        {
            if(playlistToSave == null)
            {
                return false;
            }

            //is the title unique?
            var allPlaylistEntries = await _dataBaseDriver.GetAllAsync();
            var existingPlaylist = allPlaylistEntries.FirstOrDefault(x => x.Title == playlistToSave.Name);
            if(existingPlaylist != null)
            {
                return false;
            }

            //convert domain => entiy
            var entity = playlistToSave.ToEntity();

            await _dataBaseDriver.CreateAsync(entity);
            return true;
        }

        public async Task<IPlaylist> Load(string playlistTitle)
        {
            var allPlaylistEntries = await _dataBaseDriver.GetAllAsync();
            var entity = allPlaylistEntries.FirstOrDefault(x => x.Title == playlistTitle);

            if(entity == null)
            {
                return null;
            }

            //convert entity => domain
            return entity.ToDomain(_playlistFactory, _playlistItemFactory);
        }
    }
}
