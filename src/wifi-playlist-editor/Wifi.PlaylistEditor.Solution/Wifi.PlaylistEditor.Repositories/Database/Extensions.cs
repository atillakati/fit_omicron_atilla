using Amazon.Runtime.Credentials.Internal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.PlaylistEditor.Core;

namespace Wifi.PlaylistEditor.Repositories.Database
{
    internal static class Extensions
    {
        public static PlaylistEntity ToEntity(this IPlaylist playlist)
        {
            return new PlaylistEntity
            {
                Author = playlist.Author,
                Title = playlist.Name,
                CreateAt = playlist.CreatedAt.ToString("yyyy-MM-dd"),  //"2025-05-22"
                ItemPathList = playlist.ItemList.Select(x => x.Path)
            };
        }

        public static IPlaylist ToDomain(this PlaylistEntity entity, IPlaylistItemFactory itemFactory)
        {
            var createAt = DateTime.ParseExact(entity.CreateAt, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            //ToDo: get rid of instance generation parts!!!
            var playlist = new Playlist(entity.Title, entity.Author, createAt);

            foreach (var itemPath in entity.ItemPathList)
            {
                //create items (Mp3Item, PictureItem) based on the extension of its name (.mp3, .jpg)
                var item = itemFactory.Create(itemPath);
                if (item != null)
                {
                    //add item into playlist
                    playlist.Add(item);
                }
            }

            return playlist;
        }
    }
}
