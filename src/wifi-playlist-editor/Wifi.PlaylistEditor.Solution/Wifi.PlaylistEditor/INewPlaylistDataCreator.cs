using System.Windows.Forms;

namespace Wifi.PlaylistEditor
{
    public interface INewPlaylistDataCreator
    {
        string Title { get; }
        string Author { get; }

        DialogResult StartDialog();
    }
}
