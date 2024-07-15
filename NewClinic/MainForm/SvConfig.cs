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

namespace NewClinic.MainForm
{
    public partial class SvConfig : Form
    {
        string pass = "on", id2 = "";

        public SvConfig()
        {
            InitializeComponent();
        }

        private void iconButton3_MouseEnter(object sender, EventArgs e)
        {
            iconButton1.IconColor = Color.Red;
        }

        private void iconButton3_MouseLeave(object sender, EventArgs e)
        {
            iconButton1.IconColor = Color.White;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SvConfig_Load(object sender, EventArgs e)
        {
            load();
        }

        void load()
        {
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }

            flpsv.Controls.Clear();
            clinic.conn.Open();
            MySqlCommand cmd = new MySqlCommand();

            cmd = new MySqlCommand("Select count(num) from tblserver", clinic.conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            cmd = new MySqlCommand("Select * from tblserver", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            ControlSV.svlist[] sv = new ControlSV.svlist[count];

            for (int i = 0; i <count; i++)
            {
                if (dr.Read())
                {
                    sv[i] = new ControlSV.svlist();
                    sv[i].lblsvid.Text = dr[2].ToString();
                    sv[i].lblsvname.Text = dr[1].ToString();

                    sv[i].btnselect.Click += new EventHandler(select);
                    sv[i].btndel.Click += new EventHandler(RELOAD);
                    if (flpsv.Controls.Count < 0)
                    {
                        flpsv.Controls.Clear();
                    }
                    else
                        flpsv.Controls.Add(sv[i]);
                }
            }

            clinic.conn2.Close();
        }

        void select(object s, EventArgs e)
        {
            showdata(ControlSV.svlist.id);
        }

        void RELOAD(object s, EventArgs e)
        {
            load();
        }

        void showdata(String id)
        {
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }
            clinic.conn.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from tblserver where svname = '" + id + "'", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txtservername.Text = dr[1].ToString();
                txtuserid.Text = dr[2].ToString();
                txtpass.Text = dr[3].ToString();
                id2 = dr[0].ToString();
            }

            clinic.conn.Close();
        }

        private void btpass_Click(object sender, EventArgs e)
        {
            if (pass == "offpass")
            {
                pass = "onpass";
                btpass.IconChar = IconChar.EyeSlash;
                txtpass.UseSystemPasswordChar = true;

            }
            else
            {
                pass = "offpass";
                btpass.IconChar = IconChar.Eye;
                txtpass.UseSystemPasswordChar = false;
            }
        }

        private void btpass_MouseEnter(object sender, EventArgs e)
        {
            btpass.IconSize = 40;
        }

        private void btpass_MouseLeave(object sender, EventArgs e)
        {
            btpass.IconSize = 30;
        }

        private void btnconec_Click(object sender, EventArgs e)
        {
            clinic.connec2(id2);
            iconButton2_Click(sender, e);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            id2 = "";
            txtuserid.Clear();
            txtservername.Clear();
            txtpass.Clear();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            bool a = false;
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }
            clinic.conn.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from tblserver where svname = '" + id2 + "'", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                a = true;
            }
            clinic.conn.Close();

            if (a == false)
            {
                if (txtservername.Text.Replace(" ", "") != "" && txtuserid.Text.Replace(" ", "") != "" && txtpass.Text.Replace(" ", "") != "")
                {
                    clinic.conn.Open();
                    MySqlCommand cmd2 = new MySqlCommand("Insert into tblserver values('','" + txtservername.Text + "','" + txtuserid.Text + "','" + txtpass.Text + "')", clinic.conn);
                    cmd2.ExecuteNonQuery();

                    MessageBox.Show("Successfully save!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    id2 = "";
                    clinic.conn.Close();
                    load();
                }
                else
                {
                    MessageBox.Show("Please fill up the important fields!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Server Already Exists!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
