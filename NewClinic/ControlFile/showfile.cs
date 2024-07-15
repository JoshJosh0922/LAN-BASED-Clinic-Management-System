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

namespace NewClinic.ControlFile
{
    public partial class showfile : UserControl
    {
        public showfile()
        {
            InitializeComponent();
        }

        private void showfile_Load(object sender, EventArgs e)
        {

        }

        public void downloadfile(String filename)
        {
            clinic.conn.Open();
            bool res = false;
            MySqlCommand cmd = new MySqlCommand("Select File_name, Document from tblpatien_file where file_name = '" + lblfilename.Text + "' and no = '" + lblid.Text + "'", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                res = true;
                byte[] datafile = (byte[])dr[1];
                FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite);
                BinaryWriter bw = new BinaryWriter(fs);

                bw.Write(datafile);
                bw.Close();
            }

            if (res != false)
            {
                MessageBox.Show("Finished Downloaded Files!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No Data Found!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            clinic.conn.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            iconButton1.IconColor = Color.LightGreen;

            String[] splitext = lblfilename.Text.Split('.');

            SaveFileDialog sd = new SaveFileDialog() { Filter = "All Files(*.*)|*.*|PNG Image|*.png|JPEG Image |*.jpg; *.jpeg; *.jfif; |Text Documents|*.pdf|Text Documents|*.docx|Text Documents|*.doc", ValidateNames = true };
            sd.FileName = lblfilename.Text;


            switch (splitext[1])
            {
                case "png":
                    sd.FilterIndex = 2;
                    break;
                case "jpeg":
                case "jpg":
                case "jfif":
                    sd.FilterIndex = 3;
                    break;
                case "pdf":
                    sd.FilterIndex = 4;
                    break;
                case "docx":
                    sd.FilterIndex = 5;
                    break;
                case "doc":
                    sd.FilterIndex = 6;
                    break;
                default:
                    sd.FilterIndex = 1;
                    break;
            }

            if (sd.ShowDialog() == DialogResult.OK)
            {
                DialogResult dr = MessageBox.Show("Are You Sure You Want To Dowload This Files!", "Clinic System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    String name = sd.FileName;
                    downloadfile(name);
                }
            }
        }
    }
}
