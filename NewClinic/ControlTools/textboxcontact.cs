using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewClinic.ControlTools
{
    public partial class textboxcontact : UserControl
    {
        public string txtcontact;
        public textboxcontact()
        {
            InitializeComponent();
        }

        private void textboxcontact_Load(object sender, EventArgs e)
        {
            this.Size = new Size(321, 30);
            //this.MaximumSize = new Size(240, 23);
            //this.MaximumSize = new Size(240, 27);
            //this.MinimumSize = new Size(240, 27);
            txtcontact = label1.Text + txtnumber.Text;
        }

        private void txtnumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txtnumber_TextChanged(object sender, EventArgs e)
        {
            txtcontact = label1.Text + txtnumber.Text;
        }
    }
}
