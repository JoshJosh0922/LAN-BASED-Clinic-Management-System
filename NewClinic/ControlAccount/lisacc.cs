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
using FontAwesome.Sharp;

namespace NewClinic.ControlAccount
{
    public partial class lisacc : UserControl
    {
        public static string id = "";
        public lisacc()
        {
            InitializeComponent();
        }

        private void lisacc_Load(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            id = lblid.Text;
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();

            if (MessageBox.Show("Are you sure you want to delete this ID " + lblid.Text + "?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                clinic.conn.Open();
                cmd = new MySqlCommand("INSERT INTO `tblacc_archive` SELECT * from tblacc where person_id = '" + lblid.Text + "'", clinic.conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand("Delete from tblacc where person_id = '" + lblid.Text + "'", clinic.conn);
                int count1 = cmd.ExecuteNonQuery();
                clinic.conn.Close();
                if (count1 > 0)
                {
                    clinic.actionuser("Delete Account Profile of ID " + id, Main.id, Main.name, DateTime.Now.ToShortTimeString(), DateTime.Today.ToShortDateString());
                    MessageBox.Show("Successfully Deleted!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
