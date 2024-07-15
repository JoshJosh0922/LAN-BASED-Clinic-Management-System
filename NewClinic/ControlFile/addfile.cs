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
    public partial class addfile : UserControl
    {
        public static string loc2;
        byte[] contents;
        string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        public  string name1;

        public addfile()
        {
            InitializeComponent();
        }

        private void addfile_Load(object sender, EventArgs e)
        {

        }

        public void setdata(String file, String name/*, String id*/)
        {
            FileStream fr = File.OpenRead(file);

            contents = new byte[fr.Length];
            fr.Read(contents, 0, (int)fr.Length);

            int mag = (int)Math.Log(fr.Length, 1024);
            decimal size = ((int)fr.Length) / 1024;
            //lblid.Text = id;
            lblname.Text = name;
            lblsize.Text = size.ToString("f") + " " + SizeSuffixes[mag];
            fr.Close();
        }

        public void savedata(object sender, EventArgs e)
        {
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }
            //clinic.conn.Open();

            //MySqlCommand cmd = new MySqlCommand("Insert into tblpatien_file values('" + "" + "','" + lblid.Text + "','" + lblname.Text + "','" + DateTime.Today.ToShortDateString() + "', @file )", clinic.conn);
            //cmd.Parameters.AddWithValue("@file", contents);
            //cmd.ExecuteNonQuery();
            //clinic.conn.Close();

            clinic.conn.Open();
            MySqlCommand cmd = new MySqlCommand("Insert into tblpatien_file (`person_id`,`File_name`,`Date_create`,`Document`) values('" + lblid.Text + "','" + name1+ "','" + DateTime.Today.ToShortDateString() + "', @file )", clinic.conn);
            cmd.Parameters.AddWithValue("@file", contents);
            int result = cmd.ExecuteNonQuery();

            //if (result > 0)
            //{
            //    MessageBox.Show("Successfully Save! " + lblname.Text, "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            clinic.conn.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Dispose();
        }

        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
