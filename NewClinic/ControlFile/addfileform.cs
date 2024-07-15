using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewClinic.ControlFile
{
    public partial class addfileform : Form
    {
        public int count;
        public static string id = ControlProfile.ProfileForm.id;

        public addfileform()
        {
            InitializeComponent();
        }



        private void addfileform_Load(object sender, EventArgs e)
        {
            flpfile.Controls.Clear();
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog() { Filter = "All Files(*.*)|*.*|PNG Image|*.png|JPEG Image |*.jpg; *.jpeg; *.jfif; |Text Documents|*.pdf|Text Documents|*.docx|Text Documents|*.doc", ValidateNames = true };


            if (fd.ShowDialog() == DialogResult.OK)
            {
                string filname = fd.FileName;
                ++count;
                ControlFile.addfile[] fw = new ControlFile.addfile[count];
                --count;
                fw[count] = new addfile();
                this.Closed += new EventHandler(fw[count].savedata);
                fw[count].lblid.Text = id;
                fw[count].name1 = fd.SafeFileName;
                fw[count].setdata(filname, fd.SafeFileName/*, id*/);
                flpfile.Controls.Add(fw[count]);
                ++count;
            }
        }

        private void btclear_Click(object sender, EventArgs e)
        {
            flpfile.Controls.Clear();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ControlAdd.addprofile.camid = "0";
            clinic.actionuser("Cancel Upload file in ID " + id, Main.id, Main.name, DateTime.Now.ToShortTimeString(), DateTime.Today.ToShortDateString());
            this.Close();
        }

        private void iconButton3_MouseEnter(object sender, EventArgs e)
        {
            iconButton3.IconColor = Color.Red;
        }

        private void iconButton3_MouseLeave(object sender, EventArgs e)
        {
            iconButton3.IconColor = Color.White;
        }

        private void btsave_Click(object sender, EventArgs e)
        {
            if (flpfile.Controls.Count > 0)
            {
                MessageBox.Show("Successfully Save! ", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clinic.actionuser("Successfully Upload a file in ID " + id, Main.id, Main.name, DateTime.Now.ToShortTimeString(), DateTime.Today.ToShortDateString());
                this.Close();
            }
            else
            {
                MessageBox.Show("No File Yet! ", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
