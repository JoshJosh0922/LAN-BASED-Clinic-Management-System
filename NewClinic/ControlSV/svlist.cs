using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace NewClinic.ControlSV
{
    public partial class svlist : UserControl
    {
        public static string id = "";

        public svlist()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            id = lblsvname.Text;
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            //clinic.Connect("");
            clinic.conn.Open();
            MySqlCommand cmd = new MySqlCommand("Delete from tblserver where svname = '" + lblsvname.Text + "'", clinic.conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully save!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clinic.conn.Close();
            }
    }
}
