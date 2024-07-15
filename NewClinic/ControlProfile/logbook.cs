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
    public partial class logbook : UserControl
    {
        public static string id = "";

        public logbook()
        {
            InitializeComponent();
        }

        private void logbook_Load(object sender, EventArgs e)
        {

        }

        void loaddata()
        {
            id = ControlProfile.listadmission.id + "";
            showdata(id);
        }

        public void showdata(String idno)
        {
            clinic.conn.Open();

            MySqlCommand cmd = new MySqlCommand("Select * from tblogbook Where Person_id = '" + idno + "' or lb_id = '" + idno + "'", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtdate.Text = dr[4].ToString();
                txtin.Text = dr[5].ToString();
                txtout.Text = dr[7].ToString();
                txtreason.Text = dr[8].ToString();
                txtassess.Text = dr[9].ToString();
                txtintervent.Text = dr[10].ToString();
                
                if (dr[11].ToString().Replace(" ", "") != "")
                {
                    String[] med = dr[11].ToString().Split(',');

                    for (int i = 0; i<med.Length; i++)
                    {
                        listView1.Items.Add(med[i]);
                    }
                }

                cbattented.Text = dr[12].ToString();


                try
                {
                    byte[] im = (byte[])dr[14];
                    MemoryStream ms = new MemoryStream(im);
                    signa.Image = Image.FromStream(ms);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }


            }
            clinic.conn.Close();
        }
    }
}
