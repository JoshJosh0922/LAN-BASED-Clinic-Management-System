using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewClinic.ControlProfile
{
    public partial class listmedicprofi : UserControl
    {
        public static String id;

        public listmedicprofi()
        {
            InitializeComponent();
        }

        private void listmedicprofi_Load(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            id = lblpersonid.Text;
        }
    }
}
