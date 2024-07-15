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

namespace NewClinic.ControlAdmission
{
    public partial class Viewingform : Form
    {
        public static String id;

        public Viewingform()
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

        private void Viewingform_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        void loaddata()
        {
            if (ControlAdmission.smalladmission.id != 0)
            {
                id = ControlAdmission.smalladmission.id + "";
            }

            medicH(id);
        }

        public void medicH(String idno)
        {
            String id;
            clinic.conn.Open();

            MySqlCommand cmd = new MySqlCommand("Select	* from tbladmission where admi_id = '" + idno + "' or lb_id = '" + idno + "'", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                id = dr[1].ToString();
                String disease = dr[3].ToString();
                String[] word;
                word = disease.Split('|');

                for (int i = 0; i < word.Length; i++)
                {
                    foreach (Control cc in p1.Controls)
                    {
                        if (cc is MaterialCheckbox)
                        {
                            MaterialCheckbox cb = (MaterialCheckbox)cc;
                            if (cb.Text.ToLower() == word[i].ToLower() | cb.Text.ToUpper() == word[i].ToUpper())
                            {
                                cb.Checked = true;
                            }
                            else
                            {
                                foreach (char c in word[i])
                                {
                                    if (c == '?')
                                    {
                                        string[] alis = word[i].Split('?');
                                        txtothers.Text = alis[0];
                                        cbother.Checked = true;
                                    }
                                    else if (c == '!')
                                    {
                                        string[] alis = word[i].Split('!');
                                        txtinjury.Text = alis[0];
                                        cbinjury.Checked = true;
                                    }
                                }
                            }
                        }
                    }
                }

                if (dr[11].ToString() != "")
                {
                    materialCheckbox8.Checked = true;
                    per.Text = dr[11].ToString();
                }


                txtbp.Text = dr[4].ToString();
                txtbt.Text = dr[5].ToString();
                txtpr.Text = dr[6].ToString();
                txtrr.Text = dr[7].ToString();
                txth.Text = dr[8].ToString();
                txtw.Text = dr[9].ToString();
                txtsuggestion.Text = dr[13].ToString();
                txtdate.Text = dr[12].ToString();

                txtnoteby.Text = dr[17].ToString(); 

                try
                {
                    byte[] im2 = (byte[])dr[16];
                    MemoryStream ms2 = new MemoryStream(im2);
                    nursesig.Image = Image.FromStream(ms2);
                }

                catch (Exception ex)
                {

                }
            }

            clinic.conn.Close();
            getdate(idno);
        }

        public void getdate(String idno)
        {
            clinic.conn.Open();
            MySqlCommand cmd = new MySqlCommand("Select date_in, time_in, time_out from tblogbook where lb_id = '" + idno + "'", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtdate.Text = dr[0].ToString();
                txtin.Text = dr[1].ToString();
                txtout.Text = dr[2].ToString();
            }
            clinic.conn.Close();
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
            this.Close();
        }

        private void p_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
