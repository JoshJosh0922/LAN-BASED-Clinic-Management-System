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
using System.IO;
using MaterialSkin.Controls;
using System.Runtime.InteropServices;

namespace NewClinic.ControlProfile
{
    public partial class admision : UserControl
    {
        public static String id = "";

        public admision()
        {
            InitializeComponent();
        }

        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWmd, int wMsg, int wParam, int lParam);

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void admision_Load(object sender, EventArgs e)
        {

        }

        void loaddata()
        {
            id = ControlProfile.listadmission.id + "";
            //showdata(id);
        }

        

        private void p_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
