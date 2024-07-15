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
using System.Runtime.InteropServices;

namespace NewClinic.ControlAccount
{
    public partial class editacc : Form
    {
        public static string id = lisacc.id, enab1 = "onpass", enab2 = "onpass", enab3 = "onpass";

        public editacc()
        {
            InitializeComponent();
        }


        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWmd, int wMsg, int wParam, int lParam);

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void editacc_Load(object sender, EventArgs e)
        {
            getdata(id);
            onpass();
        }

        void getdata(String id)
        {
            clinic.conn.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from tblacc where person_ID = '" + id + "'", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txtid.Text = dr[0].ToString();
                txtname.Text = dr[1].ToString();
                txtcontact.Text = dr[2].ToString();
                txtemail.Text = dr[3].ToString();
                txtusername.Text = dr[4].ToString();
                txttype.Text = dr[6].ToString();
                txtoldpass.Text = dr[5].ToString();
            }
            clinic.conn.Close();
        }

        private void iconsave_Click(object sender, EventArgs e)
        {
            clinic.conn.Open();
            if (txtnewpas.Text != txtcon.Text)
            {
                MessageBox.Show("Password and Confirm Password is not match!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtnewpas.Text != "" || txtcon.Text != "")
                {
                    MySqlCommand cmd = new MySqlCommand("update tblacc set password = '" + txtnewpas.Text + "' where person_id = '" + id + "'", clinic.conn);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Successfully save!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please fill up all the important fields!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            clinic.conn.Close();
        }

        void onpass()
        {
            txtoldpass.UseSystemPasswordChar = true;
            txtnewpas.UseSystemPasswordChar = true;
            txtcon.UseSystemPasswordChar = true;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void iconButton1_MouseHover(object sender, EventArgs e)
        {
            iconButton1.IconColor = Color.LightCoral;
        }

        private void iconButton1_MouseLeave(object sender, EventArgs e)
        {
            iconButton1.IconColor = Color.White;
        }
        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (enab1 == "offpass")
            {
                enab1 = "onpass";
                btold.IconChar = IconChar.EyeSlash;
                txtoldpass.UseSystemPasswordChar = true;

            }
            else
            {
                enab1 = "offpass";
                btold.IconChar = IconChar.Eye;
                txtoldpass.UseSystemPasswordChar = false;
            }
        }

        private void btnpass2_Click(object sender, EventArgs e)
        {
            if (enab2 == "offpass")
            {
                enab2 = "onpass";
                btnpass2.IconChar = IconChar.EyeSlash;
                txtnewpas.UseSystemPasswordChar = true;

            }
            else
            {
                enab2 = "offpass";
                btnpass2.IconChar = IconChar.Eye;
                txtnewpas.UseSystemPasswordChar = false;
            }
        }

        private void btcon_Click(object sender, EventArgs e)
        {
            if (enab3 == "offpass")
            {
                enab2 = "onpass";
                btcon.IconChar = IconChar.EyeSlash;
                txtcon.UseSystemPasswordChar = true;

            }
            else
            {
                enab3 = "offpass";
                btcon.IconChar = IconChar.Eye;
                txtcon.UseSystemPasswordChar = false;
            }
        }
    }
}
