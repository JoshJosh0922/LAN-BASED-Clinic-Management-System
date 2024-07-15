using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//My Libraries
using MySql.Data.MySqlClient;
using FontAwesome.Sharp;
using System.IO;

namespace NewClinic.ControlProfile
{
    public partial class ProfileForm : Form
    {

        public static IconButton btn = new IconButton();
        public static string id = "", lgid, status;

        public ProfileForm()
        {
            InitializeComponent();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        void loaddata()
        {
            activeButton(iconButton1);
            //filelist(lblid.Text);
            filelist();
            id = viewprofile.id;
            mediclist();
            datasearch(id);
        }

        void datasearch(String idno)
        {
            clinic.conn.Open();

            MySqlCommand cmd = new MySqlCommand("Select * from tblprofile Where Person_id = '" + idno + "'", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lblid.Text = dr[0].ToString();

                if (dr[4].ToString() != "")
                {
                    lblname.Text = dr[3].ToString() + ", " + dr[1].ToString() + " " + dr[2].ToString() + "., " + dr[4].ToString();
                }
                else if (dr[2].ToString() != "")
                {
                    lblname.Text = dr[3].ToString() + ", " + dr[1].ToString() + " " + dr[2].ToString() + ".";
                }
                else
                {
                    lblname.Text = dr[3].ToString() + ", " + dr[1].ToString() + " " + dr[2].ToString();
                }

                lblsex.Text = dr[5].ToString();
                agecal(dr[7].ToString());
                DateTime dt = DateTime.Parse(dr[7].ToString());

                lblbdate.Text = dt.ToString("MMMM dd, yyyy");
                //lblbdate.Text = dr[7].ToString();

                lblnumber.Text = dr[12].ToString();
                lbladdress.Text = dr[10].ToString();
                lblemail.Text = dr[11].ToString();
                lblnatio.Text = dr[8].ToString();
                lblblood.Text = dr[9].ToString();
                lbltype.Text = dr[13].ToString();


                try
                {
                    if (dr[14].ToString() != "")
                    {
                        byte[] im = (byte[])dr[14];
                        MemoryStream ms = new MemoryStream(im);
                        Profilepic.Image = Image.FromStream(ms);
                    }
                    else
                    {
                        Profilepic.Image = NewClinic.Properties.Resources.e7a5cf5c9e;
                    }


                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }


            }
            clinic.conn.Close();
            emergenc();
            searchdepartment(idno, lbltype.Text);
            showdata(idno);
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
                        lblage.Text = "" + total;
                    }
                }
                else
                {
                    if (DateTime.Today.Day > day)
                    {
                        total = (today - dob);

                        if (total > 0)
                        {
                            lblage.Text = "" + total;
                        }
                    }
                    else if (DateTime.Today.Day == day)
                    {
                        total = (today - dob);

                        if (total > 0)
                        {
                            lblage.Text = "" + total;
                        }
                    }
                    else if (DateTime.Today.Day != day)
                    {
                        total = ((today - dob) - 1);

                        if (total > 0)
                        {
                            lblage.Text = "" + total;
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
            MySqlCommand cmd = new MySqlCommand("Select * from tblpemc where person_id = '" + lblid.Text + "'", clinic.conn);
            MySqlDataReader dr1 = cmd.ExecuteReader();

            while (dr1.Read())
            {
                lblpname.Text = dr1[1].ToString();
                lblpnumber.Text = dr1[3].ToString();
                lblprelation.Text = dr1[2].ToString();
            }
            clinic.conn.Close();
        }

        //-----Search Student Course/GradeSec/Position
        void searchdepartment(String idno, String type)
        {
            clinic.conn.Open();

            switch (type)
            {
                case "Grades School":
                case "Junior High":
                    categoriespanel(1);
                    MySqlCommand cmd1 = new MySqlCommand("Select * from tblsgrades_junior where person_id = '" + idno + "'", clinic.conn);
                    MySqlDataReader dr1 = cmd1.ExecuteReader();

                    while (dr1.Read())
                    {
                        lbldep1.Text = "Grade and Section:";
                        lbldep.Text = dr1[1].ToString();

                        lbltype1.Location = new Point(lblcourse1.Location.X, lblcourse1.Location.Y);
                        lbltype.Location = new Point(lblcourse.Location.X, lblcourse.Location.Y);
                    }
                    break;
                case "Senior High":
                    MySqlCommand cmd2 = new MySqlCommand("Select * from tblssenior where person_id = '" + idno + "'", clinic.conn);
                    MySqlDataReader dr2 = cmd2.ExecuteReader();

                    while (dr2.Read())
                    {
                        lbldep1.Text = "Track:";
                        lbldep.Text = dr2[1].ToString();

                        lblcourse1.Text = "Strand:";
                        lblcourse.Text = dr2[2].ToString();

                        lblyr1.Text = "Section: ";
                        lblyr.Text = dr2[3].ToString();
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
                        lbldep.Text = dr4[1].ToString();

                        lbltype1.Location = new Point(lblcourse1.Location.X, lblcourse1.Location.Y);
                        lbltype.Location = new Point(lblcourse.Location.X, lblcourse.Location.Y);
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
                    lbltype1.Location = new Point(lblyr1.Location.X, lblyr1.Location.Y);
                    lbltype.Location = new Point(lblyr.Location.X, lblyr.Location.Y);

                    lblyr1.Visible = false;
                    lblyr.Visible = false;
                    lblcourse1.Visible = false;
                    lblcourse.Visible = false;
                    break;
            }
        }

        //----Button Effects
        void activeButton(object sender)
        {
            if (sender != null)
            {
                if (btn != (IconButton)sender)
                {
                    disable();
                    btn = (IconButton)sender;
                    btn.BackColor = Color.FromArgb(30, 90, 150);
                    btn.ForeColor = Color.White;
                    //btn.FlatAppearance.BorderColor = Color.FromArgb(30, 90, 150);

                    showpanel(btn);
                }
            }
           
        }

        void disable()
        {
            if (btn != null)
            {
                btn.ForeColor = Color.FromArgb(0, 58, 107);
                btn.BackColor = Color.White;
                btn.FlatAppearance.BorderColor = Color.White;
            }
        }

        //----Show Panel
        void showpanel(IconButton bt)
        {
            dshow();
            switch (bt.Name)
            {
                case "iconButton1":
                    una.Visible = true;
                    una.Size = new Size(1112, 431);
                    una.Location = new Point(0, 59);
                    una.BringToFront();
                    filelist();
                    break;
                case "iconButton2":
                    dalawa.Visible = true;
                    dalawa.Size = new Size(1112, 431);
                    dalawa.Location = new Point(0, 59);
                    dalawa.BringToFront();
                    filelist();
                    mediclist();
                    break;
                case "iconButton3":
                    tatlo.Visible = true;
                    tatlo.Size = new Size(1112, 431);
                    tatlo.Location = new Point(0, 59);
                    tatlo.BringToFront();
                    filelist();
                    break;
            }

        }

        void dshow()
        {
            switch (btn.Name)
            {
                case "iconButton1":
                    una.Visible = false;
                    una.Size = new Size(325, 188);
                    break;
                case "iconButton2":

                    dalawa.Visible = false;
                    dalawa.Size = new Size(325, 188);
                    break;
                case "iconButton3":
                    tatlo.Visible = false;
                    tatlo.Size = new Size(325, 188);
                    break;
            }
        }

        //----Button View the records

        private void iconButton1_Click(object sender, EventArgs e)
        {
            activeButton(sender);
            showdata(lblid.Text);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            activeButton(sender);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            activeButton(sender);
        }

        //----------------------------------------X Button------------------
        private void iconButton4_MouseHover(object sender, EventArgs e)
        {
            iconButton4.IconColor = Color.LightCoral;
        }

        private void iconButton4_MouseLeave(object sender, EventArgs e)
        {
            iconButton4.IconColor = Color.White;
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            id = "";
            iconButton4.IconColor = Color.Red;
            this.Close();
        }

        //---Admission DATA

        public void showdata(String id)
        {
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }
            clinic.conn.Open();
            unaflp.Controls.Clear();

            String querybilang = "SELECT count(DISTINCT(tblogbook.Lb_id)) from tblogbook inner JOIN tbladmission on tbladmission.Lb_ID = tblogbook.Lb_id where tblogbook.person_id = '" + id + "'and tbladmission.Lb_id = tblogbook.Lb_id",
                    query = "SELECT tblogbook.Lb_id, tblogbook.Date_in, tblogbook.Time_in, tblogbook.Reason, tblogbook.Nurse from tblogbook inner JOIN tbladmission on tbladmission.Lb_ID = tblogbook.Lb_id where tblogbook.person_id = '" + id + "' and tbladmission.Lb_id = tblogbook.Lb_id order by date_in /*str_to_date(date_in, '%d/%m/%Y')*/ Desc";


            MySqlCommand cmdbilang = new MySqlCommand(querybilang, clinic.conn);
            int count = Convert.ToInt32(cmdbilang.ExecuteScalar());

            lblcount.Text = "Number of Records: " + count;

            MySqlCommand cmd = new MySqlCommand(query, clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            listadmission[] sm = new listadmission[count];

            for (int i = 0; i < count; i++)
            {
                unaflp.Visible = true;
                while (dr.Read())
                {
                    sm[i] = new listadmission();
                    sm[i].lbldate.Text = dr[1].ToString();
                    sm[i].lbltime.Text = dr[2].ToString();
                    sm[i].lblreason.Text = dr[3].ToString().Replace("|", ",");
                    sm[i].lblattended.Text = dr[4].ToString();
                    sm[i].lblid.Text = dr[0].ToString();

                    sm[i].iconButton1.Click += new EventHandler(showrec);

                    if (unaflp.Controls.Count < 0)
                    {
                        unaflp.Controls.Clear();
                    }
                    else
                        unaflp.Controls.Add(sm[i]);
                }

            }

            clinic.conn.Close();

            if (count == 0)
            {
                Label lb = new Label();
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.Text = "No Record Found!";
                lb.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lb.ForeColor = Color.DarkGray;
                lb.BringToFront();
                lb.Dock = DockStyle.Fill;
                lb.BringToFront();
                unahold.Controls.Add(lb);
                unahold.BringToFront();
                unaflp.Visible = false;
            }
        }

        void showrec(object o, EventArgs e)
        {
            viewadmilog md = new viewadmilog();
            this.Enabled = false;
            md.Owner = this;
            md.Closed += new EventHandler(doable);
            md.Show();           
        }

        void doable(object o, EventArgs e)
        {
            this.Enabled = true;
            filelist();
            mediclist();
            showdata(lblid.Text);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        //--Show FIle

        void filelist()
        {
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }
            clinic.conn.Open();
            tatloflp.Controls.Clear();

            string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            MySqlCommand cmdbilang = new MySqlCommand("Select Count(person_id) from tblpatien_file where person_id = '" + lblid.Text + "'", clinic.conn);
            int count = Convert.ToInt32(cmdbilang.ExecuteScalar());

            lblfile.Text = "Number of File's: " + count;

            MySqlCommand cmd = new MySqlCommand("Select File_Name, Date_Create, Document, no from tblpatien_file where person_id = '" + lblid.Text + "'", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            ControlFile.showfile[] sm = new ControlFile.showfile[count];

            for (int i = 0; i < count; i++)
            {
                tatloflp.Visible = true;
                while (dr.Read())
                {
                    sm[i] = new ControlFile.showfile();
                    sm[i].lblid.Text = dr[3].ToString();
                    byte[] datafile = (byte[])dr[2];
                    decimal size = ((int)datafile.Length) / 1024;
                    int mag = (int)Math.Log(datafile.Length, 1024);
                    sm[i].lblfilename.Text = dr[0].ToString();
                    sm[i].lbldate.Text = dr[1].ToString();
                    sm[i].lblsize.Text = size.ToString("f") + " " + SizeSuffixes[mag];
                    if (tatloflp.Controls.Count < 0)
                    {
                        tatloflp.Controls.Clear();
                    }
                    else
                        tatloflp.Controls.Add(sm[i]);
                }

            }

            clinic.conn.Close();

            if (count == 0)
            {
                Label lb = new Label();
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.Text = "No File Found!";
                lb.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lb.ForeColor = Color.DarkGray;
                lb.BringToFront();
                lb.Dock = DockStyle.Fill;
                tatlop.Controls.Add(lb);
                tatlop.BringToFront();
                tatloflp.Visible = false;
            }

            clinic.conn.Close();
        }

        //---Medic Profile

        void mediclist()
        {
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }
            clinic.conn.Open();
            dalawaflp.Controls.Clear();

            MySqlCommand cmdbilang = new MySqlCommand("Select Count(person_id) from tblmedic_history where person_id = '" + lblid.Text + "'", clinic.conn);
            int count1 = Convert.ToInt32(cmdbilang.ExecuteScalar());

            lblmed.Text = "Number of Medical Profile: " + count1;

            

            String aa = "Select Date_Create, person_Id from tblmedic_history where person_id = '" + lblid.Text + "'";


            MySqlCommand cmd = new MySqlCommand(aa, clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            ControlProfile.listmedicprofi[] sm = new ControlProfile.listmedicprofi[count1];

            for (int i = 0; i < sm.Length; i++)
            {
                dalawaflp.Visible = true;
                if (dr.Read())
                {
                    sm[i] = new ControlProfile.listmedicprofi();
                    sm[i].lbldate.Text = dr[0].ToString();
                    sm[i].lblno.Text = (i + 1) +"";
                    sm[i].lblpersonid.Text = dr[1].ToString();

                    sm[i].btnview.Click += new EventHandler(showmed);

                    if (dalawaflp.Controls.Count < 0)
                    {
                        dalawaflp.Controls.Clear();
                    }
                    else
                        dalawaflp.Controls.Add(sm[i]);
                }

            }

            clinic.conn.Close();
            if (count1 > 0)
            {
                linkmedic.Text = "Update";
                status = "update";
            }
            else
            {
                linkmedic.Text = "Add";
                status = "add";
            }

            if (count1 == 0)
            {
                Label lb = new Label();
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.Text = "No Medical Information Found!";
                lb.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lb.ForeColor = Color.DarkGray;
                lb.BringToFront();
                lb.Dock = DockStyle.Fill;
                pdalawa.Controls.Add(lb);
                dalawaflp.Visible = false;
            }

            clinic.conn.Close();
        }

        void showmed(object sender, EventArgs e)
        {
            viewMedicProfi vmp = new viewMedicProfi();
            this.Enabled = false;
            vmp.Owner = this;
            vmp.Show();
            vmp.Closed += new EventHandler(doable);
        }

        private void linkmedic_LinkClicked(object sender, EventArgs e)
        {
            
            ControlAdd.addmediform md = new ControlAdd.addmediform();
            id = lblid.Text;
            md.Owner = this;
            this.Enabled = false;
            md.Show();
            md.Closed += new EventHandler(doable);
            md.Closed += new EventHandler(iconButton0_Click);
            activeButton(iconButton2);
        }

        private void linkupload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ControlFile.addfileform add = new ControlFile.addfileform();
            add.Owner = this;
            this.Enabled = false;
            add.Show();
            add.Closed += new EventHandler(doable);
            activeButton(iconButton3);
        }

        private void iconButton0_Click(object sender, EventArgs e)
        {
            clinic.actionuser("Update Medical Record in ID " + lblid.Text, Main.id, Main.name, DateTime.Now.ToShortTimeString(), DateTime.Today.ToShortDateString());
        }
    }
}
