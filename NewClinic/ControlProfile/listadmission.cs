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
    public partial class listadmission : UserControl
    {
        public static string id = "";
        public string id2 = "";

        public listadmission()
        {
            InitializeComponent();
        }

        private void listadmission_Load(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            id = lblid.Text;
        }
    }
}
