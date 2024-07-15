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
    public partial class editform : Form
    {
        public static String id = "";

        public editform()
        {
            InitializeComponent();
        }
        private void editform_Load(object sender, EventArgs e)
        {
            id = ControlProfile.viewprofile.id;
            editprofile1.datasearch(id);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            editprofile1.iconButton4_Click(sender, e);
            ControlProfile.editprofile.camid = "0";
            this.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            ControlProfile.editprofile.camid = "0";
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
