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
using System.Runtime.InteropServices;
using MaterialSkin.Controls;
using System.Drawing.Imaging;

namespace NewClinic.ControlAdmission
{
    public partial class miniadmission : Form
    {
        public static String complient = "", mdate = "", logbookid, id, nurse_name, category;

        public miniadmission()
        {
            InitializeComponent();
        }

        //------------------------Moving Form

        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWmd, int wMsg, int wParam, int lParam);

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            clinic.actionuser("Cancel to add a new Admission in ID " + id, Main.id, Main.name, DateTime.Now.ToShortTimeString(), DateTime.Today.ToShortDateString());
            (this.Owner as AdmissionForm).Enabled = true;
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

        private void miniadmission_Load(object sender, EventArgs e)
        {
            loadtxt();
        }

        public void loadtxt()
        {
            id = ControlAdmission.AdmissionForm.id;
            nurse_name = ControlAdmission.AdmissionForm.nurse_name;
            logbookid = ControlAdmission.AdmissionForm.logbook_id;
            category = ControlAdmission.AdmissionForm.categories;

            getsig();
        }

        public void getsig()
        {
            clinic.conn.Open();
            MySqlCommand cmd = new MySqlCommand("Select signature from tblogbook where Person_Id = '" + id + "' and date_in = '" + DateTime.Today.ToString("yyyy-MM-dd") + "'", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr[0].ToString() != "")
                {
                    try
                    {
                        byte[] im = (byte[])dr[0];
                        MemoryStream ms = new MemoryStream(im);
                        signa.Image = Image.FromStream(ms);
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            clinic.conn.Close();
        }

        //----Textbox Zone

        private void txtbp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != '/'))
            {
                e.Handled = true;
            }
        }

        //----Clear Zone

        public void clear()
        {
            txtbp.Clear();
            txtbt.Clear();
            txtpr.Clear();
            txtrr.Clear();
            txth.Clear();
            txtw.Clear();
            txtothers.Clear();
            txtsuggestion.Clear();
            txtinjury.Clear();
            timepicker.Value = DateTime.Today;
            cbhead.Checked = false;
            cbsore.Checked = false;
            cbtooth.Checked = false;
            cbstoma.Checked = false;
            cbnot.Checked = false;
            materialCheckbox8.Checked = false;
            cbother.Checked = false;
            other.Enabled = false;
            cbinjury.Checked = false;
        }

        //----CheckBox Zone

        private void materialCheckbox8_CheckStateChanged_1(object sender, EventArgs e)
        {
            if (materialCheckbox8.Checked)
            {
                timepicker.Enabled = true;
            }
            else
            {
                timepicker.Enabled = false;
            }
        }

        private void cbinjury_CheckStateChanged(object sender, EventArgs e)
        {
            if (cbinjury.Checked)
            {
                injury.Enabled = true;
            }
            else
            {
                injury.Enabled = false;
                txtinjury.Clear();
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            complient = "";
            //getcheck();

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void iconButton4_Click_1(object sender, EventArgs e)
        {
            getcheck();
            MessageBox.Show(complient.ToString().ToLower());
        }

        private void iconButton4_Click_2(object sender, EventArgs e)
        {
            
        }

        private void iconButton4_Click_3(object sender, EventArgs e)
        {
            MessageBox.Show(category.ToString());
        }

        private void cbother_CheckStateChanged(object sender, EventArgs e)
        {
            if (cbother.Checked)
            {
                other.Enabled = true;
            }
            else
            {
                other.Enabled = false;
                txtothers.Clear();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public void getcheck()
        {
            complient = "";

            foreach (Control cc in panel1.Controls)
            {
                //MessageBox.Show("" + cc);
                if (cc is CheckBox)
                {
                    CheckBox cb = (CheckBox)cc;

                    if (cb.Checked)
                    {
                        if (cb.Name != "cbother" && cb.Name != "materialCheckbox8" && cb.Name != "cbinjury")
                        {
                            complient = cb.Text + "|" + complient;
                        }
                        else if (cb.Name == "cbother" && complient != "")
                        {
                            string[] other = txtothers.Text.Split(',');

                            for (int i = 0; i < other.Length; i++)
                            {
                                complient = complient + "|" + other[i] + "?";
                            }
                        }
                        else if (cb.Name == "cbinjury" && complient != "")
                        {
                            string[] injury = txtinjury.Text.Split(',');

                            for (int i = 0; i < injury.Length; i++)
                            {
                                complient = complient + "|" + injury[i] + "!";
                            }
                        }
                        else if (cb.Name == "cbother" && complient == "")
                        {
                            string[] other = txtothers.Text.Split(',');

                            for (int i = 0; i < other.Length; i++)
                            {
                                if (i > 0)
                                {
                                    complient = complient + "|" + other[i] + "?";
                                }
                                else
                                {
                                    complient = other[i] + "?";
                                }
                            }
                        }
                        else if (cb.Name == "cbinjury" && complient == "")
                        {
                            string[] injury = txtinjury.Text.Split(',');

                            for (int i = 0; i < injury.Length; i++)
                            {
                                if (i > 0)
                                {
                                    complient = complient + "|" + injury[i] + "!";
                                }
                                else
                                {
                                    complient = injury[i] + "!";
                                }
                            }
                        }

                    }
                }
            }

            //complient = complient.Remove(complient.Length - 1, 1);

        }

        //---Date Time Picker

        private void timepicker_ValueChanged(object sender, EventArgs e)
        {
            if (timepicker.Value.Month >= DateTime.Today.Month && timepicker.Value.Day > DateTime.Today.Day || timepicker.Value.Month >= DateTime.Today.Month && timepicker.Value.Day < DateTime.Today.Day)
            {
                timepicker.Value = DateTime.Now;
            }
            else
            {
                mdate = timepicker.Value.ToShortDateString();
            }
        }

        //---Button Save

        private void iconButton2_Click_1(object sender, EventArgs e)
        {

            //else if(txtothers.Text == "" || txtothers.Text == " ")
            //{
            //    MessageBox.Show("Please input a specific other!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else
            //{


            if (cbother.Checked != false && txtothers.Text.Replace(" ", "") == "" && cbinjury.Checked != false && txtinjury.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Please input a specific injury or other!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cbother.Checked != false && txtothers.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Please input a specific other!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cbinjury.Checked != false && txtinjury.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Please input a specific injury!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                getcheck();
                saved();

                clinic.conn.Open();
                String[] deseases = complient.Split('|');

                int result = 0;

                //MessageBox.Show(deseases.Length.ToString());

                for (int i = 0; i < deseases.Length; i++)
                {
                    if (deseases[i] != "" && deseases[i] != " ")
                    {
                        MySqlCommand cmd = new MySqlCommand("Insert into tblfindings values ('" + "" + "','" + id + "','" + deseases[i].ToString().Replace("!", "").Replace("?", "").ToLower() + "','" + DateTime.Today.ToShortDateString() + "','" + category + "')", clinic.conn);
                        result = cmd.ExecuteNonQuery();
                    }
                }

                if (result > 0)
                {
                    clinic.actionuser("Success to add a new Admission in ID " + id, Main.id, Main.name, DateTime.Now.ToShortTimeString(), DateTime.Today.ToShortDateString());
                    MessageBox.Show("Successfully Save!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                clinic.conn.Close();
                AdmissionForm.ActiveForm.Close();
            }



            //if (cbother.Checked == true || txtothers.Text.Replace(" ", "") == "" | cbinjury.Checked == true || txtinjury.Text.Replace(" ", "") == "")
            //{
            //    MessageBox.Show("Please input a specific injury or other!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else
            //{
            //getcheck();
            //saved();

            //clinic.conn.Open();
            //String[] deseases = complient.Split('|');

            //int result = 0;

            ////MessageBox.Show(deseases.Length.ToString());

            //for (int i = 0; i < deseases.Length; i++)
            //{
            //    if (deseases[i] != "" && deseases[i] != " ")
            //    {
            //        MySqlCommand cmd = new MySqlCommand("Insert into tblfindings values ('" + "" + "','" + id + "','" + deseases[i].ToString().Replace("!", "").Replace("?", "").ToLower() + "','" + DateTime.Today.ToShortDateString() + "','" + category + "')", clinic.conn);
            //        result = cmd.ExecuteNonQuery();
            //    }
            //}

            //if (result > 0)
            //{
            //    clinic.actionuser("Success to add a new Admission in ID " + id, Main.id, Main.name, DateTime.Now.ToShortTimeString(), DateTime.Today.ToShortDateString());
            //    MessageBox.Show("Successfully Save!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //clinic.conn.Close();
            //AdmissionForm.ActiveForm.Close();
            //}

            //}

        }

        public void saved()
        {
            clinic.conn.Open();
            MemoryStream ms2 = new MemoryStream();
            byte[] signature = ms2.ToArray();


            if (signa.Image != null)
            {
                signa.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg);
                signature = ms2.ToArray();
            }
            
            MemoryStream ms = new MemoryStream();
            byte[] nsignature = ms2.ToArray();


            if (nursesig.Image != null)
            {
                nursesig.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                nsignature = ms2.ToArray();
            }

            //MessageBox.Show(complient.Remove(complient.Length - 1, 1));

            //if (complient != "")
            //{
            //    complient = complient.Remove(complient.Length - 1, 1);
            //}

            MySqlCommand cmd = new MySqlCommand("Insert into tbladmission values('" + "" + "','" + logbookid + "','" + id + "','" + complient.ToLower() + "','" + txtbp.Text + "','" + txtbt.Text + "','" +
                txtpr.Text + "','" + txtrr.Text + "','" + txth.Text + "','" + txtw.Text + "','" + txtspo.Text +  "','" + mdate + "','" + nurse_name + "','" + txtsuggestion.Text + "','" + category + "', @signa, @nsigna, '" + txtnoteby.Text + "')", clinic.conn);
            cmd.Parameters.AddWithValue("@signa", signature);
            cmd.Parameters.AddWithValue("@nsigna", nsignature);
            cmd.ExecuteNonQuery();
                       
            this.Close();
            clinic.conn.Close();
        }

        private void iconButton4_Click_4(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Open Image";
            op.Filter = "All Files(*.*)|*.*|PNG Image|*.png|JPEG Image|*.jpg; *.jpeg; *.jfif";
            if (op.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    Bitmap originalImage = new Bitmap(op.FileName);

                    // Create a new Bitmap object with the desired background color and the same size as the original image
                    Bitmap newImage = new Bitmap(originalImage.Width, originalImage.Height, PixelFormat.Format32bppArgb);
                    using (Graphics graphics = Graphics.FromImage(newImage))
                    {
                        // Draw the original image onto the new Bitmap object with the desired background color
                        graphics.Clear(Color.White); // Set the background color
                        graphics.DrawImage(originalImage, new Rectangle(0, 0, originalImage.Width, originalImage.Height));
                    }


                    MemoryStream ms = new MemoryStream();
                    newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    nursesig.Image = Image.FromStream(ms);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Not Supported Image!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }


    }
}
