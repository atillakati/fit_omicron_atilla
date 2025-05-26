using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wifi.PlaylistEditor
{
    public partial class NewPlaylistData : Form
    {
        public NewPlaylistData()
        {
            InitializeComponent();
        }

        public string PlaylistTitle
        {
            get
            {
                return txt_title.Text;
            }
        }

        public string PlaylistAuthor
        {
            get
            {
                return txt_author.Text;
            }
        }

        private void btt_create_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btt_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
