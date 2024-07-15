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


namespace NewClinic.ControlAdmission
{
    public partial class AdmissionForm : Form
    {
        public static String id, categories, Flogbook_id, nurse_name = "", logbook_id;

        public AdmissionForm()
        {
            InitializeComponent();
        }

        private void AdmissionForm_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        void loaddata()
        {
            id = MainForm.admission.id;
            //id = "2020-54987";
            categories = MainForm.admission.categories;
            logbook_id = MainForm.admission.logbook_id;
            datasearch(id);
            showdata();
            getsig();
        }

        //--Find Profile

        void datasearch(String idno)
        {
            clinic.conn.Open();

            MySqlCommand cmd = new MySqlCommand("Select * from tblprofile Where Person_id = '" + idno + "'", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtid.Text = dr[0].ToString();
                txtname.Text = dr[3].ToString() + ", " + dr[1].ToString() + " " + dr[2].ToString() + ". " + dr[4].ToString();
                txtsex.Text = dr[5].ToString();
                agecal(dr[7].ToString());
                txtbirth.Text = dr[7].ToString();
                txtbplace.Text = dr[6].ToString();
                txtnumber.Text = dr[2].ToString();
                txtaddre.Text = dr[0].ToString();
                txtemail.Text = dr[1].ToString();
                txtnation.Text = dr[8].ToString();
                txtblood.Text = dr[9].ToString();
                txttype.Text = dr[13].ToString();


                try
                {
                    byte[] im = (byte[])dr[4];
                    MemoryStream ms = new MemoryStream(im);
                    pic.Image = Image.FromStream(ms);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }


            }
            clinic.conn.Close();
            emergenc();
            searchdepartment(idno, txttype.Text);
        }

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
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtfullname.Text = dr[1].ToString();
                txtno.Text = dr[3].ToString();
            }
            clinic.conn.Close();
        }

        public void getsig()
        {
            clinic.conn.Open();
            MySqlCommand cmd = new MySqlCommand("Select signature, nurse from tblogbook where Person_Id = '" + txtid.Text + "' and date_in = '" + DateTime.Today.ToString("yyyy-MM-dd") + "'", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                //MessageBox.Show(txtid.Text +" hehe " + d);
                nurse_name = dr[1].ToString();
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
            clinic.conn.Close();
        }

        void searchdepartment(String idno, String type)
        {
            clinic.conn.Open();

            switch (type)
            {
                case "Grade School":
                case "Junior High":
                    categoriespanel(1);
                    MySqlCommand cmd = new MySqlCommand("Select * from tblsgrades_junior where person_id = '" + idno + "'", clinic.conn);
                    MySqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lbldep.Text = "Grade and Section";
                        txtdep.Text = dr[1].ToString();
                    }
                    break;
                case "Senior High":
                    categoriespanel(2);
                    MySqlCommand cmd2 = new MySqlCommand("Select * from tblssenior where person_id = '" + idno + "'", clinic.conn);
                    MySqlDataReader dr2 = cmd2.ExecuteReader();

                    while (dr2.Read())
                    {
                        lbldep.Text = "Track - Strand:";
                        txtdep.Text = dr2[1].ToString() + " - " + dr2[2].ToString();

                        lblcourse.Text = "Section:";
                        txtcourse.Text = dr2[3].ToString();
                    }
                    break;
                case "College":
                    MySqlCommand cmd3 = new MySqlCommand("Select * from tblscollege where person_id = '" + idno + "'", clinic.conn);
                    MySqlDataReader dr3 = cmd3.ExecuteReader();

                    while (dr3.Read())
                    {
                        txtdep.Text = dr3[1].ToString();
                        txtcourse.Text = dr3[2].ToString();
                        txtsection.Text = dr3[2].ToString() + " " + dr3[3].ToString() + dr3[4].ToString();
                    }
                    break;
                case "Employee":
                    categoriespanel(1);
                    MySqlCommand cmd4 = new MySqlCommand("Select * from tblsemp where person_id = '" + idno + "'", clinic.conn);
                    MySqlDataReader dr4 = cmd4.ExecuteReader();

                    while (dr4.Read())
                    {
                        lbldep.Text = "Position:";
                        txtdep.Text = dr4[2].ToString();
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
                    lblcourse.Visible = false;
                    txtcourse.Visible = false;

                    lblsec.Visible = false;
                    txtsection.Visible = false;

                    lbltype.Location = new Point(lblcourse.Location.X, lblcourse.Location.Y);
                    txttype.Location = new Point(txtcourse.Location.X, txtcourse.Location.Y);
                    break;
                case 2:
                    lblsec.Visible = false;
                    txtsection.Visible = false;

                    lbltype.Location = new Point(lblsec.Location.X, lblsec.Location.Y);
                    txttype.Location = new Point(txtsection.Location.X, txtsection.Location.Y);
                    break;
            }
        }

        //---Close Button

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
            clinic.actionuser("Close Admission Form ", Main.id, Main.name, DateTime.Now.ToShortTimeString(), DateTime.Today.ToShortDateString());
            this.Close();
        }

        void reload(object sender, EventArgs e)
        {
            this.Enabled = true;
            //this.Close();

        }

        //--Add New Admission
        private void iconButton1_Click_(object sender, EventArgs e)
        {
            clinic.actionuser("Add new Admission Form in ID " + txtid.Text, Main.id, Main.name, DateTime.Now.ToShortTimeString(), DateTime.Today.ToShortDateString());
            ControlAdmission.miniadmission md = new ControlAdmission.miniadmission();
            md.Owner = this;
            md.Closed += new EventHandler(reload);
            this.Enabled = false;
            md.Show();

        }

        void clos(object o, EventArgs e)
        {
            this.Enabled = true;
            //showdata();
        }

        void showform(object o, EventArgs e)
        {
            ControlAdmission.Viewingform vd = new ControlAdmission.Viewingform();
            vd.Owner = this;
            this.Enabled = false;
            vd.Closed += new EventHandler(clos);
            vd.Show();
        }

        public void showdata()
        {
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }
            clinic.conn.Open();
            flp.Controls.Clear();
            //String bilang = "Select count(Admi_id) from tbladmission where person_id = '" + txtid.Text + "' ORDER BY str_to_date(`date_in`, '%d/%m/%Y') DESC", query = "Select date_in, time_in, complaint, attended, admission_id from tbladmission  where person_id = '" + txtid.Text + "' ORDER BY str_to_date(`date_in`, '%d/%m/%Y') DESC";
            //String bilang = "Select count(Admission_id) from admission ORDER BY str_to_date(`date_in`, '%d/%m/%Y') DESC", query = "Select date_in, time_in, complaint, attended from admission ORDER BY str_to_date(`date_in`, '%d/%m/%Y') DESC";

            //String querybilang = "Select count(lb_id) from tblogbook where not EXISTS(SELECT * from tbladmission where tblogbook.lb_ID = tbladmission.Lb_ID) and person_id = '" + txtid.Text + "' Order by str_to_date(date_in, '%d/%m/%Y') Desc",
            //    query = "Select lb_id, date_in, Time_in, Reason, Nurse  from tblogbook where not EXISTS(SELECT * from tbladmission where tblogbook.lb_ID = tbladmission.Lb_ID) and person_id = '" + txtid.Text + "' order by str_to_date(date_in, '%Y-%m-%d') Desc";

            String querybilang = "SELECT count(DISTINCT(tblogbook.Lb_id)) from tblogbook inner JOIN tbladmission on tbladmission.Lb_ID = tblogbook.Lb_id where tblogbook.person_id = '" + txtid.Text + "'",
                    query = "SELECT tblogbook.Lb_id, tblogbook.Date_in, tblogbook.Time_in, tblogbook.Reason, tblogbook.Nurse from tblogbook inner JOIN tbladmission on tbladmission.Lb_ID = tblogbook.Lb_id where tblogbook.person_id = '" + txtid.Text + "' order by date_in Desc";


            MySqlCommand cmdbilang = new MySqlCommand(querybilang, clinic.conn);
            int count = Convert.ToInt32(cmdbilang.ExecuteScalar());

            lblcount.Text = "Number of Records: " + count;

            MySqlCommand cmd = new MySqlCommand(query, clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            ControlAdmission.smalladmission[] sm = new ControlAdmission.smalladmission[count];


            for (int i = 0; i < count; i++)
            {
                while (dr.Read())
                {
                    sm[i] = new ControlAdmission.smalladmission();
                    sm[i].lbldate.Text = dr[1].ToString();
                    sm[i].lbltime.Text = dr[2].ToString();
                    sm[i].lblreason.Text = dr[3].ToString().Replace("|", ",");
                    sm[i].lblattended.Text = dr[4].ToString();
                    sm[i].lblid.Text = dr[0].ToString();

                    sm[i].iconButton1.Click += new EventHandler(showform);

                    if (flp.Controls.Count < 0)
                    {
                        flp.Controls.Clear();
                    }
                    else
                        flp.Controls.Add(sm[i]);
                }

            }

            if (count == 0)
            {

                Label lb = new Label();
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.Text = "No Records Yet!";
                lb.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lb.ForeColor = Color.DarkGray;
                lb.BringToFront();
                lb.Dock = DockStyle.Fill;
                p2.Controls.Add(lb);
                p2.Visible = true;
                flp.Visible = false;
            }

            clinic.conn.Close();
        }

    }
}
