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
    public partial class Addcollege : Form
    {

        public Addcollege()
        {
            InitializeComponent();
        }

        private void Addcollege_Load(object sender, EventArgs e)
        {
            loadd(ControlAdd.addprofile.category);
            txtdep.Text = addprofile.Dept;
            txtcourse.Text = addprofile.course2;
        }

        void loadd(String category)
        {
            switch (category)
            {
                case "Senior High":
                    lbldep.Text = "Track:";
                    lblcourse.Text = "Strand:";
                    lblsec.Text = "Grade and Sectiion:";
                    break;
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            (this.Owner as MainForm.AddProfile).Enabled = true;
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (txtsec.Text == "" || txtdep.Text == "" || txtcourse.Text == "")
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
            MessageBox.Show(category);
            clinic.conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            switch (category)
            {
                case "Senior High":
                    cmd = new MySqlCommand("Insert into tbladdsecsenior values ('" + "" + "','" + txtdep.Text + "','" + txtcourse.Text + "','" + txtsec.Text + "')", clinic.conn);
                    break;
                case "College":
                    cmd = new MySqlCommand("Insert into tbladdcollege values ('" + "" + "','" + txtdep.Text + "','" + txtcourse.Text + "','" + txtsec.Text + "')", clinic.conn);
                    break;
            }

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully Save!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clinic.conn.Close();
        }

        private void txtsec_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ControlAdd.addprofile.category != "Senior High")
            {
                if (!char.IsNumber(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
