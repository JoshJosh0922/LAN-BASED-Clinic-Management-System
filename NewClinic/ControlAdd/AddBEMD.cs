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

namespace NewClinic.ControlAdd
{
    public partial class AddBEMD : Form
    {
        public AddBEMD()
        {
            InitializeComponent();
        }

        private void AddBEMD_Load(object sender, EventArgs e)
        {
            (this.Owner as MainForm.AddProfile).Enabled = false;
            id(ControlAdd.addprofile.category);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            (this.Owner as MainForm.AddProfile).Enabled = true;
            this.Close();
        }

        public void id(String category)
        {
            switch (category)
            {
                case "Grade School":
                case "Junior High":
                    txtsec.Visible = true;
                    lblsec.Visible = true;

                    lbldep.Visible = false;
                    txtdep.Visible = false;

                    break;
                case "Employee":
                    lbldep.Location = new Point(lblsec.Location.X, lblsec.Location.Y);
                    txtdep.Location = new Point(txtsec.Location.X, txtsec.Location.Y);

                    lbldep.Visible = true;
                    txtdep.Visible = true;

                    txtsec.Visible = false;
                    lblsec.Visible = false;
                    break;
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (txtsec.Text == "" && txtdep.Text == "")
            {
                MessageBox.Show("Please fill up all the fields!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                save(ControlAdd.addprofile.category);
                (this.Owner as MainForm.AddProfile).Enabled = true;
            }
        }

        public void save(String category)
        {
            clinic.conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            switch (category)
            {
                case "Grade School":
                case "Junior High":
                    cmd = new MySqlCommand("Insert into tbladdsecbed values ('" + "" + "','" + txtsec.Text + "','" + category + "')", clinic.conn);
                    break;
                case "Employee":
                    cmd = new MySqlCommand("Insert into tbladdemp values ('" + "" + "','" + "" + "','" + txtdep.Text + "')", clinic.conn);
                    break;
            }

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Save!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clinic.conn.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
