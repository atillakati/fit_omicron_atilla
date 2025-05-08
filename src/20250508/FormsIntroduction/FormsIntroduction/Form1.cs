using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsIntroduction
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btt_ok_Click(object sender, EventArgs e)
        {
            lbl_header.Text = "Hello " + txt_name.Text + " !";
        }
        
    }
}
