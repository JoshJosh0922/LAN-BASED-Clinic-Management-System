using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//My library
using FontAwesome.Sharp;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace NewClinic
{
    public partial class Main : Form
    {

        public static Form currentform = new Form();
        public static IconButton btn = new IconButton();

        public static String usertype = "";
        public static string name = ControlLogin.Login2.Fullname, id = ControlLogin.Login2.id, pass = ControlLogin.Login2.pass;
        //public static String usertype = "superadmin";
        //public static string name = "Superadmin", id = "0000000", pass = "09227412";

        //public static String usertype = "admin";
        //public static string name = "AdminAccount", id = "123456", pass = "password";
        //public static string name = "jb", id = "18923", pass = "password";
        //public static String usertype = "nurse";
        //public static String usertype = "Inventory";
        //public static string name = "Morales, Kurt", id = "12312", pass = "password";

        public Main()
        {
            InitializeComponent();

            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //clinic.Connect("");
            openchild(new MainForm.dashboard(), btndash);
            useracc();
        }

        void useracc()
        {
            bool good = false;

            clinic.conn.Open();


            //MessageBox.Show("he " + id + " " + name + " " + pass);

            MySqlCommand cmd = new MySqlCommand("Select * from tblacc where person_id = '" + id + "' and Full_Name = '" + name + "' and password = '" + pass + "'", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                good = true;
            }


            
            if (good == true)
            {
                switch (usertype)
                {
                    case "Admin":
                    case "Administrator":
                    case "admin":
                    case "administrator":
                        btnlogb.Visible = true;
                        btnadm.Visible = true;
                        btnprof.Visible = true;
                        btnrep.Visible = true;
                        btnlist.Visible = true;
                        btninv.Visible = true;
                        btnadd.Visible = true;
                        btnarch.Visible = true;
                        btnaction.Visible = true;
                        break;
                    case "nurse":
                    case "Nurse":
                        btnlist.Visible = false;
                        btninv.Visible = false;
                        break;
                    case "inventory":
                    case "Inventory":
                        btnlogb.Visible = false;
                        btnadm.Visible = false;
                        btnprof.Visible = false;
                        //btnrep.Visible = false;
                        btnlist.Visible = false;
                        break;
                    case "superadmin":
                    case "Superadmin":
                        btcv.Visible = true;
                        btnlogb.Visible = true;
                        btnadm.Visible = true;
                        btnprof.Visible = true;
                        btnrep.Visible = true;
                        btnlist.Visible = true;
                        btninv.Visible = true;
                        btnadd.Visible = true;
                        btnarch.Visible = true;
                        btnaction.Visible = true;
                        break;
                }
            }
            
            clinic.conn.Close();
        }

        //--------------------------------------------------------------------------Panel4 code--------------------------------------------------------------------------

        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWmd, int wMsg, int wParam, int lParam);

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //------------------------------------------------------------------------Code For opening the form and highlight/property change button------------------------------

        void activeButton(object sender)
        {
            if (sender != null)
            {
                if (btn != (IconButton)sender)
                {
                    disable();
                    btn = (IconButton)sender;
                    btn.BackColor = Color.FromArgb(30, 90, 150);
                    btn.FlatAppearance.BorderColor = Color.White;
                    //clinic.Connect("");
                    //clinic.actionuser("Go to " + btn.Text, id, name, DateTime.Now.ToShortTimeString(), DateTime.Today.ToShortDateString());
                }
            }
        }

        void disable()
        {
            if (btn != null)
            {
                btn.BackColor = Color.FromArgb(0, 58, 107);
                btn.FlatAppearance.BorderColor = Color.White;
            }
        }

        void openchild(Form childf, object sender)
        {

            if (currentform != null)
            {
                currentform.Close();
            }
            activeButton(sender);
            currentform = childf;
            currentform.Owner = this;
            childf.TopLevel = false;
            childf.FormBorderStyle = FormBorderStyle.None;
            childf.Dock = DockStyle.Fill;
            this.childpan.Controls.Add(childf);
            this.childpan.Tag = childpan;
            childf.BringToFront();
            childf.Show();
            object c = btnacc, d = btnadd, e = btnlist;
            Boolean a = false, b = false, f = false;
            if (sender == c)
            {
                a = true;
            }

            if (sender == d)
            {
                b = true;
            }
            if (sender == e)
            {
                f = true;
            }

            //    if (pbtn1.Height == 220)
            //    {
            //        pbtn1.Height = 49;
            //    }

            if (a != true || b != true || f != true)
            {
                if (pbtn1.AutoSize == true)
                {
                    pbtn1.AutoSize = false;
                }
            }

            


    }

        //---------------------------------------------------------------------Button Properties------------------------------------------

        private void iconButton1_Click(object sender, EventArgs e)
        {
            openchild(new MainForm.dashboard(), sender);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            openchild(new MainForm.logbook(), sender);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            iconButton3.IconColor = Color.Firebrick;
            this.Close();
        }

        private void iconButton3_MouseEnter(object sender, EventArgs e)
        {
            iconButton3.IconColor = Color.Firebrick;
        }

        private void iconButton3_MouseLeave(object sender, EventArgs e)
        {
            iconButton3.IconColor = Color.FromArgb(0, 57, 101);
        }
        private void iconButton4_Click(object sender, EventArgs e)
        {
            //if (pbtn1.Height != 220)
            //{
            //    pbtn1.Height = 220;
            //    pbtn1.Focus();
            //}
            pbtn1.AutoSize = true;
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void iconButton5_MouseEnter(object sender, EventArgs e)
        {
            iconButton5.IconColor = Color.FromArgb(30, 158, 141);
        }

        private void iconButton5_MouseLeave(object sender, EventArgs e)
        {
            iconButton5.IconColor = Color.FromArgb(0, 57, 101);
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            openchild(new MainForm.admission(), sender);
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            openchild(new MainForm.Profile(), sender);
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            openchild(new MainForm.Report(), sender);
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            //openchild(new smallform.Appointment(), sender);
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            openchild(new ControlAccount.changeuser(), sender);
        }

        private void btnlist_Click(object sender, EventArgs e)
        {
            openchild(new ControlAccount.listacc(), sender);
        }

        private void btnarch_Click(object sender, EventArgs e)
        {
            openchild(new MainForm.Archive(), sender);
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to log out?", "Clinic System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

           if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btcv_Click(object sender, EventArgs e)
        {
            MainForm.SvConfig sc = new MainForm.SvConfig();
            this.Enabled = false;
            sc.Closed += new EventHandler(enable);
            sc.Show();
        }
        
        void enable(object sender, EventArgs e)
        {
            this.Enabled = true;
            this.Focus();
        }

        private void btnaction_Click(object sender, EventArgs e)
        {
            openchild(new ControlAccount.action(), sender);
        }

        private void iconButton11_Click(object sender, EventArgs e)
        {
            openchild(new ControlAccount.addAcc(), sender);
        }

        private void iconButton12_Click(object sender, EventArgs e)
        {
            openchild(new inventory.Inventory(), sender);
        }
    }
}
