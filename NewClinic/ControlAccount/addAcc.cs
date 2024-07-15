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
    public partial class addAcc : Form
    {

        public static string enab1 = "onpass";
        public static string enab2 = "onpass";

        public addAcc()
        {
            InitializeComponent();
        }

        private void addAcc_Load(object sender, EventArgs e)
        {
            txtpas.UseSystemPasswordChar = true;
            txtconfirm.UseSystemPasswordChar = true;
        }

        void cleared()
        {
            txtid.Clear();
            txtname.Clear();
            txtcontact.Clear();
            txtemail.Clear();
            txtusername.Clear();
            txtpas.Clear();
            txtconfirm.Clear();
            cbtype.SelectedIndex = -1;
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            clinic.conn.Open();
            if (txtid.Text == "" || txtname.Text == "" || txtcontact.Text == "" || txtemail.Text == "" || txtusername.Text == "" || txtpas.Text == "" || cbtype.Text == "" || txtconfirm.Text == "")
            {
                MessageBox.Show("Please fill up all the important fields!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtpas.Text != txtconfirm.Text)
                {
                    MessageBox.Show("Password and Confirm Password is not match!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand("Insert into tblacc value ('" + txtid.Text + "','" + txtname.Text + "','" + txtcontact.Text + "','" + txtemail.Text + "','" + txtusername.Text + "','" + txtpas.Text + "','" + cbtype.Text + "')", clinic.conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully save!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cleared();
                }
            }
            
            clinic.conn.Close();
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            if (enab1 == "offpass")
            {
                enab1 = "onpass";
                btnpass1.IconChar = IconChar.EyeSlash;
                txtpas.UseSystemPasswordChar = true;

            }
            else
            {
                enab1 = "offpass";
                btnpass1.IconChar = IconChar.Eye;
                txtpas.UseSystemPasswordChar = false;
            }
        }

        private void btnpass2_Click(object sender, EventArgs e)
        {
            if (enab2 == "offpass")
            {
                enab2 = "onpass";
                btnpass2.IconChar = IconChar.EyeSlash;
                txtconfirm.UseSystemPasswordChar = true;

            }
            else
            {
                enab2 = "offpass";
                btnpass2.IconChar = IconChar.Eye;
                txtconfirm.UseSystemPasswordChar = false;
            }
        }

        private void txtid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            cleared();
        }
    }
}
