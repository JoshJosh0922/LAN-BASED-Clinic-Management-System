using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace NewClinic.ControlLogbook
{
    public partial class addmed : Form
    {
        public static String id = Arrive.id;

        public addmed()
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

        private void iconButton1_Click(object sender, EventArgs e)
        {
            (this.Owner as Arrive).Enabled = true;
            iconButton1.IconColor = Color.Red;
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
        
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void addmed_Load(object sender, EventArgs e)
        {
            //flp.Controls.Clear();
            //iconButton2_Click_1(sender, e);
        }

        private void iconButton2_Click_1(object sender, EventArgs e)
        {
            //insertmed im = new insertmed();
            //im.BackColor = Color.White;
            //if
            //this.iconButton2.Click += new EventHandler(im.saved);
            //flp.Controls.Add(im);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click_2(object sender, EventArgs e)
        {
            if (insertmed1.expdate.Length != 0 || insertmed1.ammount.Length != 0 || insertmed1.med.Length != 0)
            {

                (this.Owner as Arrive).Enabled = true;
                insertmed1.saved(sender, e);
                this.Close();
            }
            else
            {
                MessageBox.Show("Please Choose Medicine!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
