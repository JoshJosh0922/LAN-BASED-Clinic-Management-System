using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//My libraries
using FontAwesome.Sharp;
using MySql.Data.MySqlClient;
using System.Threading;
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace NewClinic.ControlLogin
{

    public partial class Login2 : Form
    {
        string a = "onpass";
        public static string category;
        public static string id, Fullname, pass = "";

        public Login2()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        private void Login2_Load(object sender, EventArgs e)
        {
            //clinic.Connect("");
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            clinic.conn.Open();
            Boolean userfound = false /*, userfound2 = false, userfound3 = false*/;
            String usertype = "";

            if (txtuser.Text == "" || txtpass.Text == "")
            {
                MessageBox.Show("The corresponding Useraccount and Password should be entered.", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MySqlCommand cmd = new MySqlCommand("Select person_id, Full_name, Username, Password, Usertype from tblacc where 	Person_ID = '" + txtuser.Text + "' or username = '" + txtuser.Text + "' or Email = '" + txtuser.Text + "' and password = '" + txtpass.Text + "'", clinic.conn);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    userfound = true;
                    id = dr[0].ToString();
                    Fullname = dr[1].ToString();
                    usertype = dr[4].ToString();
                    pass = dr[3].ToString();
                }
                dr.Close();

                if (userfound == false)
                {
                    MessageBox.Show("Incorrect Username or Password!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MySqlCommand cmd2 = new MySqlCommand("Insert into tbllogin values ('" + "" + "','" + id + "','" + Fullname + "','" + DateTime.Today.ToShortDateString() + "','" + usertype + "')", clinic.conn);
                    cmd2.ExecuteNonQuery();
                    Main.usertype = usertype;
                    Main.id = id;
                    Main.name = Fullname;
                    Main.pass = pass;

                    clinic.actionuser("Log-in", Main.id, Main.name, DateTime.Now.ToShortTimeString(), DateTime.Today.ToShortDateString());

                    Main m = new Main();
                    m.Show();
                    this.Visible = false;
                }
            }

            clinic.conn.Close();
        }

        private void iconButton1_MouseEnter(object sender, EventArgs e)
        {
            btc1.BackColor = Color.FromArgb(2, 101, 190);
        }

        private void iconButton1_MouseLeave(object sender, EventArgs e)
        {
            btc1.BackColor = Color.FromArgb(0, 58, 127);
        }

        private void iconButton2_MouseEnter(object sender, EventArgs e)
        {
            btc2.BackColor = Color.FromArgb(218, 60, 60);
        }

        private void iconButton2_MouseLeave(object sender, EventArgs e)
        {
            btc2.BackColor = Color.Firebrick;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (a == "offpass")
            {
                a = "onpass";
                iconButton3.IconChar = IconChar.EyeSlash;
                txtpass.isPassword = true;

            }
            else
            {
                a = "offpass";
                iconButton3.IconChar = IconChar.Eye;
                txtpass.isPassword = false;
            }
        }
    }
}
