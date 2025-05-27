using System.Windows.Forms;

namespace Wifi.PlaylistEditor
{
    public class DummyNewPlaylist : INewPlaylistDataCreator
    {
        public string Title { get => "Super Charts 2025"; }
        public string Author { get => "DJ Gandalf"; }
        public DialogResult StartDialog()
        {
            return DialogResult.OK;
        }
    }
}