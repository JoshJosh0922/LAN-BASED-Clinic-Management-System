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
using FontAwesome.Sharp;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace NewClinic.ControlLogbook
{
    public partial class Arrive : Form
    {
        public static String id = "", cate, medic = "", lbid, name = Main.name, date = "";


        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWmd, int wMsg, int wParam, int lParam);

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        public Arrive()
        {
            InitializeComponent();
        }

        private void Arrive_Load(object sender, EventArgs e)
        {
            load();
        }

        void load()
        {
            cbattented1.Text = name;
            displaynurse();
            if (MainForm.logbook.id != "")
            {
                id = MainForm.logbook.id;
                cate = MainForm.logbook.categor;
                lbid = MainForm.logbook.lb_id;

                datasearch(id);
                id = lblid.Text;
                txtin.Text = MainForm.logbook.timein;
                txtdate.Text = MainForm.logbook.date;

                date = MainForm.logbook.date2;

            }

            if (views.discharge == "out")
            {
                disable();
                outdata(views.lgid);
                iconsave.Visible = false;
                btnout.Visible = true;
                btnout.Location = new Point(iconButton3.Location.X, iconButton3.Location.Y);
            }
            else if (views.discharge == "Edit")
            {
                edisable();
                //datasearch(id, cate);
                iconButton3.Visible = false;
                iconsave.Location = new Point(iconButton3.Location.X, iconButton3.Location.Y);
                outdata(views.lgid);
                iconsave.Text = "Update";
            }
            line();
            lodmed();
        }

        void datasearch(String idno)
        {
            if(clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }
            clinic.conn.Open();

            MySqlCommand cmd = new MySqlCommand("Select * from tblprofile Where Person_id = '" + idno + "'", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                pic.Image = NewClinic.Properties.Resources.e7a5cf5c9e;
                lblid.Text = dr[0].ToString();
                lblname.Text = dr[3].ToString() + ", " + dr[1].ToString() + " " + dr[2].ToString() + ". " + dr[4].ToString();
                lbltype.Text = dr[13].ToString();

                try
                {
                    byte[] im = (byte[])dr[14];
                    MemoryStream ms = new MemoryStream(im);
                    pic.Image = Image.FromStream(ms);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }


            }
            clinic.conn.Close();
            searchdepartment(idno, lbltype.Text);
        }

        //-----Search Student Course/GradeSec/Position
        void searchdepartment(String idno, String type)
        {
            clinic.conn.Open();

            switch (type)
            {
                case "Grade School":
                case "Junior High":
                    categoriespanel(1);
                    MySqlCommand cmd1 = new MySqlCommand("Select * from tblsgrades_junior where person_id = '" + idno + "'", clinic.conn);
                    MySqlDataReader dr1 = cmd1.ExecuteReader();

                    while (dr1.Read())
                    {
                        lbldep1.Text = "Grade and Section:";
                        lbldep.Text = dr1[1].ToString();
                    }
                    break;
                case "Senior High":
                    categoriespanel(2);
                    MySqlCommand cmd2 = new MySqlCommand("Select * from tblssenior where person_id = '" + idno + "'", clinic.conn);
                    MySqlDataReader dr2 = cmd2.ExecuteReader();

                    while (dr2.Read())
                    {
                        lbldep1.Text = "Track / Strand: ";
                        lbldep.Text = dr2[1].ToString() + "-" + dr2[2].ToString();

                        lblcourse1.Text = "Section:";
                        lblcourse.Text = dr2[3].ToString();
                    }
                    break;
                case "College":
                    MySqlCommand cmd3 = new MySqlCommand("Select * from tblscollege where person_id = '" + idno + "'", clinic.conn);
                    MySqlDataReader dr3 = cmd3.ExecuteReader();

                    while (dr3.Read())
                    {
                        lbldep.Text = dr3[1].ToString();
                        lblcourse.Text = dr3[2].ToString();
                        lblyr.Text = dr3[2].ToString() + " " + dr3[3].ToString() + dr3[4].ToString();
                    }
                    break;
                case "Employee":
                    categoriespanel(1);
                    MySqlCommand cmd4 = new MySqlCommand("Select * from tblsemp where person_id = '" + idno + "'", clinic.conn);
                    MySqlDataReader dr4 = cmd4.ExecuteReader();

                    while (dr4.Read())
                    {
                        lbldep1.Text = "Position:";
                        lbldep.Text = dr4[2].ToString();
                    }
                    break;
            }

            clinic.conn.Close();
        }

        void categoriespanel(int i)
        {
            switch (i)
            {
                case 1:
                    lblcourse1.Visible = false;
                    lblcourse.Visible = false;
                    lblyr1.Visible = false;
                    lblyr.Visible = false;

                    lbltype1.Location = new Point(lblcourse1.Location.X, lblcourse1.Location.Y);
                    lbltype.Location = new Point(lblcourse.Location.X, lblcourse.Location.Y);
                    break;
                case 2:
                    lblyr1.Visible = false;
                    lblyr.Visible = false;

                    lbltype1.Location = new Point(lblyr1.Location.X, lblyr1.Location.Y);
                    lbltype.Location = new Point(lblyr.Location.X, lblyr.Location.Y);
                    break;
            }
        }

        //-Display Nurse
        void displaynurse()
        {
            clinic.conn.Open();
            //MySqlDataAdapter da = new MySqlDataAdapter("Select distinct(Full_name) from tblacc where Date_in = '" + DateTime.Today.ToShortDateString() + "'", clinic.conn);
            MySqlDataAdapter da = new MySqlDataAdapter("Select distinct(Full_name) from tblacc where usertype = 'nurse'", clinic.conn);
            DataTable dt = new DataTable();

            cbattented1.DisplayMember = "Full_name";
            da.Fill(dt);
            cbattented1.DataSource = dt;
            cbattented1.SelectedIndex = -1;
            clinic.conn.Close();
        }

        //---------------------------------------Line--------------------------

        void line()
        {
            label1.AutoSize = false;
            label1.Width = 2;
            label1.Height = 300;
            label1.BorderStyle = BorderStyle.Fixed3D;

            label4.AutoSize = false;
            label4.Width = 470;
            label4.Height = 2;
            label4.BorderStyle = BorderStyle.Fixed3D;
        }

        

        private void iconButton3_Click(object sender, EventArgs e)
        {
            cleared();
        }

        //----------------------------------------X Button------------------
        private void iconButton1_MouseHover(object sender, EventArgs e)
        {
            iconButton1.IconColor = Color.LightCoral;
        }

        private void iconButton1_MouseLeave(object sender, EventArgs e)
        {
            iconButton1.IconColor = Color.White;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (btnout.Visible == true)
            {
                clinic.actionuser("Cancel the Out Patient of ID " + lblid.Text, Main.id, Main.name, DateTime.Now.ToShortTimeString(), DateTime.Today.ToShortDateString());
            }
            else
            {
                if (iconsave.Text.ToLower() == "time in")
                {
                    clinic.actionuser("Cancel the admitting of Patient ID " + lblid.Text, Main.id, Main.name, DateTime.Now.ToShortTimeString(), DateTime.Today.ToShortDateString());
                }
                else if (iconsave.Text.ToLower() == "update")
                {
                    clinic.actionuser("Cancel the Add Medicine in Patient of ID " + lblid.Text, Main.id, Main.name, DateTime.Now.ToShortTimeString(), DateTime.Today.ToShortDateString());
                }
                cancel();
            }

            id = "";
            iconButton1.IconColor = Color.Red;
            this.Close();
        }

        //---------------------------------------Disable Feilds---------------------

        //-Discharge
        void disable()
        {
            txtreason.Enabled = false;
            txtassess.Enabled = false;
            txtintervent.Enabled = false;
            cbattented1.Enabled = false;
            cbattented3.Enabled = false;
            iconupload.Enabled = false;
            iconmed.Enabled = false;
            flpmed.Enabled = false;
        }

        //-Add Medicine
        void edisable()
        {
            //txtreason.Enabled = false;
            //txtassess.Enabled = false;
            //txtintervent.Enabled = false;
            cbattented1.Enabled = false;
            cbattented3.Enabled = false;
            iconupload.Enabled = false;
        }

        //-----------------------------------Upload Signature---------------------------------

        private void iconupload_Click(object sender, EventArgs e)
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
                    signa.Image = Image.FromStream(ms);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Not Supported Image!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        //---------------------------------------Get date and Time in logbook---------------------

        void outdata(String lgid)
        {
            String id = "";
            clinic.conn.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from tblogbook where lb_id = '" + lgid + "'", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                id = dr[1].ToString();
                txtdate.Text = dr[4].ToString();
                txtin.Text = dr[5].ToString();
                txtreason.Text = dr[8].ToString();
                txtassess.Text = dr[9].ToString();
                txtintervent.Text = dr[10].ToString();

                if (dr[11].ToString().Replace(",", "") != "")
                {
                    string[] word;
                    word = dr[11].ToString().Split(',');
                    //medic = dr[11].ToString();

                    med[] m = new med[word.Length];

                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] != "")
                        {
                            m[i] = new med();
                            m[i].lblmed.Text = word[i];
                            flpmed.Controls.Add(m[i]);
                        }
                    }
                }

                
                cbattented1.Text = dr[12].ToString();
                try
                {
                    byte[] im2 = (byte[])dr[14];
                    MemoryStream ms2 = new MemoryStream(im2);
                    signa.Image = Image.FromStream(ms2);
                }

                catch (Exception ex)
                {

                }
            }
            datasearch(id);

            clinic.conn.Close();
        }

        private void iconsave_Click(object sender, EventArgs e)
        {
             clinic.conn.Open();
            if (iconsave.Text == "Update")
            {
                MySqlCommand cmd = new MySqlCommand("Update tblogbook set Reason = '" + txtreason.Text + "', Assessment = '" + txtassess.Text + "', Intervention = '"+ txtintervent.Text +"', Medicine = '" + medic.Remove(medic.Length - 1, 1) + "' where lb_id = '" + views.lgid + "'", clinic.conn);
                cmd.ExecuteNonQuery();


                MySqlCommand med = new MySqlCommand("Update tblpatient_med set Status = 'Confirm' where person_id = '" + id + "'", clinic.conn);
                med.ExecuteNonQuery();

                clinic.actionuser("Succsess to Admit Patient ID " + lblid.Text, Main.id, Main.name, DateTime.Now.ToShortTimeString(), DateTime.Today.ToShortDateString());
                MessageBox.Show("Successfully save!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (iconsave.Text == "Time In")
            {
                if (txtreason.Text != "" && txtassess.Text != "" && txtintervent.Text != "" && cbattented1.Text != "" && signa.Image != null)
                {
                    MemoryStream ms = new MemoryStream();
                    signa.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] signature = ms.ToArray();

                    MySqlCommand cmd = new MySqlCommand("insert into tblogbook values ('" + "" + "','" + lblid.Text + "','" + lblname.Text + "','" + lblyr.Text + "','" + date + "','" + txtin.Text + "','" + "" + "','" + "" + "','" + txtreason.Text +
                        "','" + txtassess.Text + "','" + txtintervent.Text + "','" + medic.Remove(medic.Length - 1, 1) + "','" + cbattented1.Text + "','" + lbltype.Text + "', @pic )", clinic.conn); ;
                    cmd.Parameters.AddWithValue("@pic", signature);
                    cmd.ExecuteNonQuery();


                    MySqlCommand med = new MySqlCommand("Update tblpatient_med set Status = 'Confirm' where person_id = '" + id + "'", clinic.conn);
                    med.ExecuteNonQuery();

                    clinic.actionuser("Succsess to Time Out Patient ID " + lblid.Text, Main.id, Main.name, DateTime.Now.ToShortTimeString(), DateTime.Today.ToShortDateString());
                    MessageBox.Show("Successfully save!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    medic = "";
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please Fill up all the fields before saving", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Data did not save!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            clinic.conn.Close();
        }

        //-----------------------------------Discharge button--------------------------------

        private void btnout_Click(object sender, EventArgs e)
        {
            dischargetime ds = new dischargetime();
            ds.iconok.Click += new EventHandler(dosave);
            ds.iconcan.Click += new EventHandler(doable);
            ds.Owner = this;
            this.Enabled = false;
            ds.Show();
        }

        void doable(object sender, EventArgs e)
        {
            this.Focus();
            this.Enabled = true;
        }

        void dosave(object send, EventArgs e)
        {
            this.Enabled = true;
            string dateout = dischargetime.dateout, timeout = dischargetime.timeout;

            //MessageBox.Show("" + dateout + " " + timeout);

            clinic.conn.Open();


            MySqlCommand cmd = new MySqlCommand("Update tblogbook set Date_out = '" + dateout + "', time_out = '" + timeout + "' where lb_id = '" + lbid + "'", clinic.conn);
            cmd.ExecuteNonQuery();


            MySqlCommand del = new MySqlCommand("Delete from tblpatient_med where person_id = '" + lblid.Text + "'", clinic.conn);
            del.ExecuteNonQuery();

            clinic.conn.Close();
            medic = "";
            this.Close();
            MessageBox.Show("Successfully save!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //-------------------------------Add new Medic---------------------------------------

        private void iconButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(medic + "");
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void iconButton2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(id);
        }

        private void iconmed_Click(object sender, EventArgs e)
        {
            addmed med = new addmed();
            this.Enabled = false;
            id = lblid.Text;
            med.Owner = this;
            med.Show();
            //med.iconButton2.Click += new EventHandler(load);
            med.Closed += new EventHandler(load);
        }

        void load(object sender, EventArgs e)
        {
            this.Focus();
            this.Enabled = true;
            lodmed();
        }

        //--------------------------------------Cleared-----------------------------

        void cleared()
        {
            txtreason.ResetText();
            txtassess.Clear();
            txtintervent.Clear();
            flpmed.Controls.Clear();
            cbattented1.SelectedIndex = -1;
            cbattented3.Clear();
            signa.Image = null;
        }

        public void lodmed()
        {
            flpmed.Controls.Clear();

            clinic.conn.Open();
            MySqlCommand cmd = new MySqlCommand("Select count(person_id) from tblpatient_med where person_id = '" + lblid.Text + "'", clinic.conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            cmd = new MySqlCommand("Select * from tblpatient_med where person_id = '" + lblid.Text + "'", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            med[] md = new med[count];

            for (int i = 0; i < count; i++)
            {
                if (dr.Read())
                {
                    md[i] = new med();
                    md[i].lblid.Text = dr[0].ToString();
                    md[i].lblmed.Text = dr[2].ToString();
                    md[i].lblamount.Text = dr[4].ToString();
                    md[i].lblstock.Text = dr[5].ToString();
                    md[i].lblbatch.Text = dr[6].ToString();
                    md[i].lblmedid.Text = dr[7].ToString();

                    medic += dr[2].ToString() + ",";


        
                        flpmed.Controls.Add(md[i]);
                }
            }

            clinic.conn.Close();
        }


        public void cancel()
        {
            clinic.conn.Open();

            String ammount1 = "", amount2 = "", stock = "", medid = "", expdate = "";
            int total;
            int stoc;

            MySqlCommand bilang = new MySqlCommand("Select count(person_id) from tblpatient_med where person_id = '" + id + "' and Status   = ''", clinic.conn);
            int count = Convert.ToInt32(bilang.ExecuteScalar());

            for(int i = 0; i<count; i++)
            {
                MySqlCommand cmd3 = new MySqlCommand("Select * from tblpatient_med where person_id = '" + id + "' and Status   = ''", clinic.conn);
                MySqlDataReader dr3 = cmd3.ExecuteReader();

                if (dr3.Read())
                {
                    amount2 = dr3[4].ToString();
                    stock = dr3[5].ToString();
                    expdate = dr3[6].ToString();
                    medid = dr3[7].ToString();
                }
                dr3.Close();


                MySqlCommand cmd2 = new MySqlCommand("Select productstocks.consumed from uniqueproductlist INNER JOIN productstocks where uniqueproductlist.code = productstocks.code and productstocks.code = '" + medid + "' and productstocks.expiry_date = '" + expdate + "'", clinic.conn);
                MySqlDataReader dr = cmd2.ExecuteReader();

                if (dr.Read())
                {
                    ammount1 = dr[0].ToString();
                }
                dr.Close();

                total = Convert.ToInt32(ammount1) - Convert.ToInt32(amount2);
                stoc = Convert.ToInt32(stock) + Convert.ToInt32(amount2);

                MySqlCommand cmd1 = new MySqlCommand("Update productstocks set consumed = '" + total + "', stocks = '" + stoc + "' where  code = '" + medid + "' and expiry_date = '" + expdate + "'", clinic.conn);
                cmd1.ExecuteNonQuery();

                MySqlCommand cmd = new MySqlCommand("Delete from tblpatient_med where person_id = '" + id + "' and Status   = ''", clinic.conn);
                cmd.ExecuteNonQuery();
            }

            clinic.conn.Close();
        }

    }
}
