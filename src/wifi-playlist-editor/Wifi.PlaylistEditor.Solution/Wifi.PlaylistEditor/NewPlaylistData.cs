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
    public partial class NewPlaylistData : Form, INewPlaylistDataCreator
    {
        public NewPlaylistData()
        {
            InitializeComponent();
        }

        
        private void btt_create_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_author.Text) || string.IsNullOrEmpty(txt_title.Text))
            {
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btt_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public string Title { get => txt_title.Text; }

        public string Author { get => txt_author.Text; }

        public DialogResult StartDialog()
        {
            return ShowDialog();
        }
    }
}
