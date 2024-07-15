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

namespace NewClinic.MainForm
{
    public partial class logbook : Form
    {
        //Pass Data to arrive form
        public static string id, categor, date, date2, timein, lb_id;

        //Query for datashow logbook
        public string log = "Select * from tblogbook where date_in = '" + DateTime.Today.ToString("yyyy-MM-dd")+ "' and EXISTS(SELECT * from tblprofile where tblogbook.Person_ID = tblprofile.Person_ID)   order by time_out Asc, Time_in desc";
        public string logbilang = "Select count(person_id) from tblogbook where date_in = '" + DateTime.Today.ToString("yyyy-MM-dd")+ "' and EXISTS(SELECT * from tblprofile where tblogbook.Person_ID = tblprofile.Person_ID)   order by time_out desc";

        //User type
        public static String usertype = Main.usertype;

        public logbook()
        {
            InitializeComponent();
        }

        private void logbook_Load(object sender, EventArgs e)
        {
            showdata();
        }

        void showdata()
        {
            showdata("");

            loaddata();

            //lbline.Height = 2;
            //lbline.Width = 1395;
            //lbline.BorderStyle = BorderStyle.Fixed3D;
            //lbline.Location = new Point(16, 558);
        }

        void showdata(string search)
        {
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }
            clinic.conn.Open();
            list.Items.Clear();
            MySqlCommand cmd = new MySqlCommand("SELECT Person_id, concat(Lname, ' ', Fname, ' ', Mname) Fullname, Lname, fname, Suffix, patient_type FROM tblprofile " +
                    "where Person_id like '" + search + "%' or lname like '" + search + "%' or fname like '" + search + "%' ", clinic.conn);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                list.Items.Add(dr[0].ToString() + ",  " + dr[1].ToString() + ",  " + dr[5].ToString());

            }

            if (list.Items.Count == 0)
            {
                list.Items.Add("No Record found!");
            }

            clinic.conn.Close();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if (txtsearchn.Text != "" || txtsearchn.Text.Replace(" ", "") != "")
            {
                panel2.BringToFront();
                panel2.Height = 156;
                showdata(txtsearchn.Text);
                btimeout.Enabled = false;
            }
            else
            {
                panel2.Height = 31;
            }
        }

        //-----------------------------------------------------------Show DATA----------

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list.SelectedItem != null)
            {
                if (list.SelectedItem != "No Record found!")
                {
                    // For clear data //bclear_Click(sender, e);
                    ControlLogbook.views.discharge = "";
                    bura();
                    String[] word;
                    word = list.SelectedItem.ToString().Split(',');

                    datasearch(word[0].ToString());
                    btimein.Enabled = true;
                    txtsearchn.Clear();
                }
            }
        }

        void datasearch(String idno)
        {
            clinic.conn.Open();

            MySqlCommand cmd = new MySqlCommand("Select * from tblprofile Where Person_id = '" + idno + "'", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                //pictureBox1.Image = NewClinic.Properties.Resources.e7a5cf5c9e;
                txtid.Text = dr[0].ToString();

                if (dr[4].ToString() != "")
                {
                    txtname.Text = dr[3].ToString() + ", " + dr[1].ToString() + " " + dr[2].ToString() + " " + dr[4].ToString();
                }
                else
                {
                    txtname.Text = dr[3].ToString() + ", " + dr[1].ToString() + " " + dr[2].ToString() + ".";
                }

                //txtname.Text = dr[3].ToString() + ", " + dr[1].ToString() + " " + dr[2].ToString() + "., " + dr[4].ToString();
                txtsex.Text = dr[5].ToString();
                agecal(dr[7].ToString());
                txtbirth.Text = dr[7].ToString();
                txtbplace.Text = dr[6].ToString();
                txtstudcontact.Text = dr[12].ToString();
                txtaddress.Text = dr[10].ToString();
                txtemail.Text = dr[11].ToString();
                txtnationality.Text = dr[8].ToString();
                txtblood.Text = dr[9].ToString();
                txtcategory.Text = dr[13].ToString();


                try
                {
                    byte[] im = (byte[])dr[14];
                    MemoryStream ms = new MemoryStream(im);
                    pictureBox1.Image = Image.FromStream(ms);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }


            }
            clinic.conn.Close();
            emergenc();
            searchdepartment(idno, txtcategory.Text);
            // Selected Row id showtimein(idno);
        }

        //Calculation Age
        void agecal(String year)
        {
            String[] word;
            word = year.Split('/');

            int today, dob, total, day, month;
            today = DateTime.Today.Year;
            dob = int.Parse(word[2].ToString());
            day = int.Parse(word[0].ToString());
            month = int.Parse(word[1].ToString());

            if (year != DateTime.Today.ToShortDateString())
            {
                if (DateTime.Today.Month != month)
                {
                    total = ((today - dob) - 1);

                    if (total > 0)
                    {
                        txtage.Text = "" + total;
                    }
                }
                else
                {
                    if (DateTime.Today.Day > day)
                    {
                        total = (today - dob);

                        if (total > 0)
                        {
                            txtage.Text = "" + total;
                        }
                    }
                    else if (DateTime.Today.Day == day)
                    {
                        total = (today - dob);

                        if (total > 0)
                        {
                            txtage.Text = "" + total;
                        }
                    }
                    else if (DateTime.Today.Day != day)
                    {
                        total = ((today - dob) - 1);

                        if (total > 0)
                        {
                            txtage.Text = "" + total;
                        }
                    }
                }
            }
        }

        void emergenc()
        {
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }
            clinic.conn.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from tblpemc where person_id = '" + txtid.Text + "'", clinic.conn);
            MySqlDataReader dr1 = cmd.ExecuteReader();

            while (dr1.Read())
            {
                txtname2.Text = dr1[1].ToString();
                txtcontact.Text = dr1[3].ToString();
                txtrelationship.Text = dr1[2].ToString();
            }
            clinic.conn.Close();
        }

        //--Show Time In and Time out
        void showtimein(string id4)
        {
            clinic.conn.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from tblogbook where lb_id = '" + id4 + "'", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                timer1.Stop();
                txtdate.Text = dr[4].ToString();
                txtin.Text = dr[5].ToString();
                if (dr[7].ToString() != "")
                {
                    //btimeout.Enabled = false;
                    txtout.Text = dr[7].ToString();
                    txtout.Visible = true;
                    lblout.Visible = true;
                    cbtime.Visible = false;
                }
            }
            clinic.conn.Close();
        }


        //-----Search Student Course/GradeSec/Position
        void searchdepartment(String idno, String type)
        {
            clinic.conn.Open();

            switch (type)
            {
                case "Grade School":
                case "Junior High":
                    MySqlCommand cmd1 = new MySqlCommand("Select * from tblsgrades_junior where person_id = '" + idno + "'", clinic.conn);
                    MySqlDataReader dr1 = cmd1.ExecuteReader();

                    while (dr1.Read())
                    {
                        lbldep.Text = "Grade and Section:";
                        txtdep.Text = dr1[1].ToString();

                        //Visible false
                        txtcourse.Visible = false;
                        lblcourse.Visible = false;

                        lblsec.Visible = false;
                        txtsec.Visible = false;

                        lbltype.Location = new Point(lblcourse.Location.X, lblcourse.Location.Y);
                        txtcategory.Location = new Point(txtcourse.Location.X, txtcourse.Location.Y);
                    }
                    break;
                case "Senior High":
                    MySqlCommand cmd2 = new MySqlCommand("Select * from tblssenior where person_id = '" + idno + "'", clinic.conn);
                    MySqlDataReader dr2 = cmd2.ExecuteReader();

                    while (dr2.Read())
                    {
                        lbldep.Text = "Track - Strand:";
                        txtdep.Text = dr2[1].ToString() + " - " + dr2[2].ToString();

                        lblcourse.Visible = true;
                        txtcourse.Visible = true;

                        lblcourse.Text = "Section:";
                        txtcourse.Text = dr2[3].ToString();

                        //Visible false
                        lblsec.Visible = false;
                        txtsec.Visible = false;

                        lbltype.Location = new Point(lblsec.Location.X, lblsec.Location.Y);
                        txtcategory.Location = new Point(txtsec.Location.X, txtsec.Location.Y);
                    }
                    break;
                case "College":
                    MySqlCommand cmd3 = new MySqlCommand("Select * from tblscollege where person_id = '" + idno + "'", clinic.conn);
                    MySqlDataReader dr3 = cmd3.ExecuteReader();

                    while (dr3.Read())
                    {
                        lbldep.Text = "Department:";
                        txtdep.Text = dr3[1].ToString();

                        lblcourse.Visible = true;
                        txtcourse.Visible = true;

                        lblcourse.Text = "Course:";
                        txtcourse.Text = dr3[2].ToString();

                        lblsec.Visible = true;
                        txtsec.Visible = true;

                        lblsec.Text = "Section and Yr:";
                        txtsec.Text = dr3[2].ToString() + " " + dr3[3].ToString() + dr3[4].ToString();

                        lbltype.Location = new Point(1068, 317);
                        txtcategory.Location = new Point(1076, 341);
                    }
                    break;
                case "Employee":
                    MySqlCommand cmd4 = new MySqlCommand("Select * from tblsemp where person_id = '" + idno + "'", clinic.conn);
                    MySqlDataReader dr4 = cmd4.ExecuteReader();

                    while (dr4.Read())
                    {
                        lbldep.Text = "Position:";
                        txtdep.Text = dr4[2].ToString();

                        //Visible false
                        txtcourse.Visible = false;
                        lblcourse.Visible = false;

                        txtsec.Visible = false;
                        txtsec.Visible = false;

                        lbltype.Location = new Point(lblcourse.Location.X, lblcourse.Location.Y);
                        txtcategory.Location = new Point(txtcourse.Location.X, txtcourse.Location.Y);
                    }
                    break;
            }

            clinic.conn.Close();
        }

        //-------------------------------------------Clear------

        void bura()
        {
            //----Profile
            txtid.Clear();
            txtname.Clear();
            txtsex.Clear();
            txtage.Clear();
            txtbirth.Clear();
            txtbplace.Clear();
            txtemail.Clear();
            txtnationality.Clear();
            txtaddress.Clear();
            txtblood.Clear();
            txtdep.Clear();
            txtcourse.Clear();
            txtstudcontact.Clear();
            txtsec.Clear();
            txtcategory.Clear();
            txtname2.Clear();
            txtcontact.Clear();
            txtrelationship.Clear();
            pictureBox1.BackgroundImage = NewClinic.Properties.Resources.e7a5cf5c9e;
            pictureBox1.Image = null;
            cbtime.Checked = true;

            //----Logbook
            lblout.Visible = false;
            txtout.Visible = false;
            cbtime.Visible = true;

            //Button
            btimein.Enabled = false;
            btimeout.Enabled = false;
            timer1.Start();
        }
        private void bclear_Click(object sender, EventArgs e)
        {
            bura();
        }

        //---------------------------------------------Date and TIme---------------------------------

        private void cbtime_CheckedChanged_1(object sender, EventArgs e)
        {
            if (cbtime.Checked == true)
            {
                txtdate.Enabled = false;
                txtin.Enabled = false;
                timer1.Start();
                txtdate.Value = DateTime.Today;
            }
            else
            {
                txtdate.Enabled = true;
                txtin.Enabled = true;
                timer1.Stop();
                txtin.Clear();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //txtdate.Text = DateTime.Today.ToString("yyyy-MM-dd");
            txtin.Text = DateTime.Now.ToShortTimeString();
        }



        //--------------------------------------------Button In and Out---------------------------

        private void btimeout_Click(object sender, EventArgs e)
        {
            checkout(ControlLogbook.views.lgid);
        }

        //Check if time out has a value
        void checkout(String id)
        {
            clinic.conn.Open();
            bool chec = false;

            MySqlCommand cmd = new MySqlCommand("Select * from tblogbook where time_out = '" + "" + "' and lb_id = '" + id + "'", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                chec = true;

            }

            clinic.conn.Close();

            if (chec == true)
            {
                clinic.actionuser("Outpatient of ID " + txtid.Text, Main.id, Main.name, DateTime.Now.ToShortTimeString(), DateTime.Today.ToShortDateString());
                (this.Owner as Main).Enabled = false;
                id = txtid.Text;
                categor = txtcategory.Text;
                ControlLogbook.Arrive arr = new ControlLogbook.Arrive();
                arr.Closed += new EventHandler(reload);
                arr.Show();
            }
            else
            {
                btimeout.Enabled = false;
            }

        }

        private void btimein_Click(object sender, EventArgs e)
        {
            if (txtdate.Text != "" || txtin.Text != "")
            {
                datafortheday(txtid.Text);
            }
            else
            {
                MessageBox.Show("Please enter the date and time the individual arrived in the DATE IN and TIME IN fields.", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        //--Check if the patient is already here
        void datafortheday(String idno)
        {
            clinic.conn.Open();
            bool already = false;

            MySqlCommand cmd = new MySqlCommand("select * from tblogbook where person_id = '" + idno + "' and date_in = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' and time_out = '' ", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                already = true;
            }

            clinic.conn.Close();


            if (already != false)
            {
                MessageBox.Show("The Patient is already Recorded!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                clinic.actionuser("Admitting a Patient ID " + txtid.Text, Main.id, Main.name, DateTime.Now.ToShortTimeString(), DateTime.Today.ToShortDateString());
                (this.Owner as Main).Enabled = false;
                date = txtdate.Text;
                date2 = txtdate.Value.ToString("yyyy-MM-dd");
                timein = txtin.Text;
                id = txtid.Text;
                categor = txtcategory.Text;
                ControlLogbook.Arrive arr = new ControlLogbook.Arrive();
                arr.Closed += new EventHandler(reload);
                arr.Show();
            }
        }

        //-------------Reload Data
        void reload(object s, EventArgs e)
        {
            (this.Owner as Main).Enabled = true;
            (this.Owner as Main).Focus();


            bclear_Click(s, e);
            ControlLogbook.views.discharge = "";
            logbook_Load(s, e);
        }

        private void txtdate_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtdate.Value.ToString("MM")) > Convert.ToInt32(DateTime.Today.ToString("MM")) | Convert.ToInt32(txtdate.Value.ToString("dd")) > Convert.ToInt32(DateTime.Today.ToString("dd")))
            {
                txtdate.Value = DateTime.Today;
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //--------------------------------------------Display data in logbook-------------

        void loaddata()
        {
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }
            clinic.conn.Open();


            flp.Controls.Clear();
            int count = new int();

            MySqlCommand cmd2 = new MySqlCommand(logbilang, clinic.conn);
            count = Convert.ToInt32(cmd2.ExecuteScalar());


            MySqlCommand cmd = new MySqlCommand(log, clinic.conn);
            MySqlDataReader rs = cmd.ExecuteReader();

            int size = (count);

            ControlLogbook.views[] profiles = new ControlLogbook.views[size];

            //MessageBox.Show(count + " " + cmd2.ExecuteScalar());

            for (int i = 0; i < profiles.Length; i++)
            {

                while (rs.Read())
                {

                    profiles[i] = new ControlLogbook.views();
                    profiles[i].lgid2 = rs[0].ToString();
                    profiles[i].lblid.Text = rs[1].ToString();
                    profiles[i].lblname.Text = rs[2].ToString();
                    profiles[i].lbldate.Text = rs[4].ToString();
                    profiles[i].lblin.Text = rs[5].ToString();
                    profiles[i].lblout.Text = rs[7].ToString();
                    profiles[i].lblreason.Text = rs[8].ToString();
                    //profiles[i].lblmedic.Text = rs[10].ToString();
                    profiles[i].lblcatego.Text = rs[13].ToString();

                    if (rs[7].ToString() != "")
                    {
                        //btimeout.Enabled = true;
                        profiles[i].iconedit.Enabled = false;
                    }

                    profiles[i].iconButton1.Click += new EventHandler(getdata);
                    profiles[i].iconedit.Click += new EventHandler(edit);
                    if (flp.Controls.Count < 0)
                    {
                        flp.Controls.Clear();
                    }
                    else
                        flp.Controls.Add(profiles[i]);
                }

            }


            if (size > 0)
            {
                flp.Visible = true;
            }
            else if (txtsearch2.Text != "" && size == 0)
            {
                Label lb = new Label();
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.Text = "No Record Found!";
                lb.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lb.ForeColor = Color.DarkGray;
                lb.Dock = DockStyle.Fill;
                lb.BringToFront();
                pflp.Controls.Add(lb);
                flp.Visible = false;
            }
            else if (size == 0 && txtsearch2.Text == "")
            {
                Label lb = new Label();
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.Text = "No Records Yet!";
                lb.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lb.ForeColor = Color.DarkGray;
                lb.Dock = DockStyle.Fill;
                lb.BringToFront();
                pflp.Controls.Add(lb);
                flp.Visible = false;
            }

            clinic.conn.Close();
        }

        void getdata(object s, EventArgs e)
        {
            bclear_Click(s, e);
            if (ControlLogbook.views.discharge == "out")
            {
                btimein.Enabled = false;

                if (ControlLogbook.views.time_out == "")
                {
                    btimeout.Enabled = true;
                }

                lb_id = ControlLogbook.views.lgid;
                datasearch(ControlLogbook.views.id);
                showtimein(ControlLogbook.views.lgid);
            }
        }
        void edit(object s, EventArgs e)
        {
            (this.Owner as Main).Enabled = false;
            ControlLogbook.Arrive arr = new ControlLogbook.Arrive();
            id = ControlLogbook.views.id;

            clinic.actionuser("Add Medicine in Patient ID " + id, Main.id, Main.name, DateTime.Now.ToShortTimeString(), DateTime.Today.ToShortDateString());
            categor = ControlLogbook.views.catego;
            arr.Closed += new EventHandler(reload);
            arr.Show();
        }

        //-------------------------------------Search Data in logbook------------------

        private void txtsearch2_TextChanged(object sender, EventArgs e)
        {
            if (txtsearch2.Text != "")
            {
                log = "Select * from tblogbook where date_in = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' and person_id like '" + txtsearch2.Text.Replace("'", "") + "%' or name like '%" + txtsearch2.Text.Replace("'", "") + "%' and date_in = '" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
                logbilang = "Select count(person_id) from tblogbook where date_in = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' and person_id like '" + txtsearch2.Text.Replace("'", "") + "%' or name like '%" + txtsearch2.Text.Replace("'", "") + "%' and date_in = '" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
            }
            else
            {
                log = "Select * from tblogbook where date_in = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' order by time_out Asc";
                logbilang = "Select count(person_id) from tblogbook where date_in = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' order by time_out";
            }
            loaddata();
        }
    }
}
