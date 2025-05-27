using DnsClient.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Wifi.PlaylistEditor
{
    public partial class TitleSelector : Form, ITitleSelector
    {
        public TitleSelector()
        {
            InitializeComponent();
        }

        public string SelectedTitle => lst_titleSelection.SelectedItem as string;

        public DialogResult StartDialog(IEnumerable<string> titleList)
        {
            if (titleList == null)
            {
                return DialogResult.Cancel;
            }

            lst_titleSelection.Items.Clear();
            lst_titleSelection.Items.AddRange(titleList.ToArray<object>());
            //titleList.Select(x => lst_titleSelection.Items.Add(x));

            return ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void lst_titleSelection_DoubleClick(object sender, EventArgs e)
        {
            if (lst_titleSelection.SelectedItem != null)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
