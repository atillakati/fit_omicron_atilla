using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wifi.PlaylistEditor.Core
{
    public interface IDatabaseRepository
    {
        Task<IEnumerable<string>> LoadAllPlaylistTitles();
        Task<bool> Save(IPlaylist playlistToSave);
        Task<IPlaylist> Load(string playlistTitle);
    }
}