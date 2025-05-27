using System.Collections.Generic;
using System.Windows.Forms;

namespace Wifi.PlaylistEditor
{
    public interface ITitleSelector
    {
        string SelectedTitle { get; }
        DialogResult StartDialog(IEnumerable<string> titleList);
    }
}