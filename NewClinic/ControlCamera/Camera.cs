using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FontAwesome.Sharp;
using AForge.Video;
using AForge.Video.DirectShow;

namespace NewClinic.ControlCamera
{
    public partial class Camera : Form
    {
        VideoCaptureDevice frame;
        FilterInfoCollection devices;

        public static Image img = null;

        public static string id = "";
        
        public Camera()
        {
            InitializeComponent();
            
        }

        private void Camera_Load(object sender, EventArgs e)
        {
            if (ControlProfile.editprofile.camid == "2")
            {
                id = ControlProfile.editprofile.camid;
                (this.Owner as ControlProfile.editform).Enabled = false;
            }
            else
            {
                (this.Owner as MainForm.AddProfile).Enabled = false;
                id = ControlAdd.addprofile.camid;
            }
            camstart();
        }

        void camstart()
        {
            try
            {
                devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                frame = new VideoCaptureDevice(devices[0].MonikerString);
                frame.NewFrame += new AForge.Video.NewFrameEventHandler(cam_event);
                frame.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "");
            }

        }

        void cam_event(object send, NewFrameEventArgs e)
        {
            try
            {
                jpictureBox1.Image = (Image)e.Frame.Clone();
            }
            catch (Exception ex)
            {

            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            jpictureBox1.Refresh();
            frame.Start();
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            frame.Stop();
        }

        private void iconButton3_MouseEnter(object sender, EventArgs e)
        {
            iconButton3.IconColor = Color.Red;
        }

        private void iconButton3_MouseLeave(object sender, EventArgs e)
        {
            iconButton3.IconColor = Color.White;
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (id == "2")
            {
                (this.Owner as ControlProfile.editform).Enabled = true;
            }
            else
            {
                (this.Owner as MainForm.AddProfile).Enabled = true;
            }
            iconButton1.IconFont = IconFont.Solid;
            iconButton1.IconColor = Color.Red;
            frame.Stop();
            this.Close();
        }


        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (id == "2")
            {
                (this.Owner as ControlProfile.editform).Enabled = true;
            }
            else
            {
                (this.Owner as MainForm.AddProfile).Enabled = true;
            }
            img = jpictureBox1.Image;
            frame.Stop();
            this.Close();
        }
    }
}
