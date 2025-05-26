using PlaylistsNET.Content;
using PlaylistsNET.Models;
using System;
using System.IO;
using System.Linq;
using Wifi.PlaylistEditor.Core;

namespace Wifi.PlaylistEditor.Repositories
{
    public class ZplRepository : IPlaylistRepository
    {
        private readonly IPlaylistFactory _playlistFactory;
        private readonly IPlaylistItemFactory _playlistItemFactory;


        public ZplRepository(IPlaylistFactory playlistFactory, IPlaylistItemFactory playlistItemFactory)
        {
            _playlistFactory = playlistFactory;
            _playlistItemFactory = playlistItemFactory;
        }


        public string Description => "ZPL playlist file format";

        public string Extension => ".zpl";


        public bool Save(string filePath, IPlaylist playlist)
        {
            if (playlist == null)
            {
                return false;
            }

            var zplPlaylist = new ZplPlaylist
            {
                Title = playlist.Name,
                Author = playlist.Author,
                TotalDuration = playlist.Duration,
                FileName = Path.GetFileName(filePath),
                Generator = "WIFI Playlist Editor",
                Path = filePath,
                ItemCount = playlist.ItemList.Count(),
                Guid = Guid.NewGuid().ToString(),
            };
            
            
            //add items into m3u playlist
            foreach (var item in playlist.ItemList)
            {
                zplPlaylist.PlaylistEntries.Add(new ZplPlaylistEntry()
                {
                    Duration = item.Duration,
                    Path = item.Path,
                    TrackTitle = item.Title,
                    TrackArtist = item.Artist
                });
            }

            var content = new ZplContent();
            var text = content.ToText(zplPlaylist);

            //write content into file
            using (var sw = new StreamWriter(filePath, false))
            {
                sw.WriteLine(text);
            }

            return true;
        }

        public IPlaylist Load(string filePath)
        {
            ZplPlaylist zplPlaylist;
            var content = new ZplContent();

            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath) || Path.GetExtension(filePath) != Extension)
            {
                return null;
            }

            //open file and convert content into M3uPlaylist type
            using (var sr = new StreamReader(filePath))
            {
                zplPlaylist = content.GetFromStream(sr.BaseStream);
            }

            //create Playlist instance
            var playlist = _playlistFactory.Create(zplPlaylist.Title, 
                                                   zplPlaylist.Author, 
                                                   File.GetCreationTime(filePath));
            
            //add item instances
            foreach (var zplItem in zplPlaylist.PlaylistEntries)
            {
                var item = _playlistItemFactory.Create(zplItem.Path);
                if (item != null)
                {
                    playlist.Add(item);
                }
            }

            return playlist;
        }
    }
}
