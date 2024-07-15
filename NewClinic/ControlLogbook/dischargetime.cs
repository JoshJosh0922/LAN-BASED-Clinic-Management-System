using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewClinic.ControlLogbook
{
    public partial class dischargetime : Form
    {
        public static string dateout, timeout;

        public dischargetime()
        {
            InitializeComponent();
        }

        private void dischargetime_Load(object sender, EventArgs e)
        {

        }

        private void cbtime_CheckedChanged(object sender, EventArgs e)
        {
            if (cbtime.Checked == true)
            {
                timer1.Start();
                txtdate.Enabled = false;
                txtout.Enabled = false;
            }
            else
            {
                timer1.Stop();
                txtout.Enabled = true;
                txtdate.Enabled = true;
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            (this.Owner as Arrive).Enabled = true;
            this.Close();
        }

        private void iconok_Click(object sender, EventArgs e)
        {
            dateout = txtdate.Text;
            timeout = txtout.Text;
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtdate.Text = DateTime.Today.ToString("yyyy-MM-dd");
            txtout.Text = DateTime.Now.ToShortTimeString();
        }
    }
}
