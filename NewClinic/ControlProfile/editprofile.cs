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

namespace NewClinic.ControlProfile
{
    public partial class editprofile : UserControl
    {
        public static IconButton btn = new IconButton();
        public static string gender = "", camid = "0";
        
        public editprofile()
        {
            InitializeComponent();
        }

        private void editprofile_Load(object sender, EventArgs e)
        {
            cbdept_SelectionChangeCommitted(sender, e);
        }

        public void datasearch(String idno)
        {
            clinic.conn.Open();
            String categor = "";
            MySqlCommand cmd = new MySqlCommand("Select * from tblprofile Where Person_id = '" + idno + "'", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                txtid.Text = dr[0].ToString();
                txtfname.Text = dr[1].ToString();
                txtmname.Text = dr[2].ToString();
                txtlname.Text = dr[3].ToString();
                txtsuffix.Text = dr[4].ToString();

                //For gender
                if (dr[5].ToString() == "MALE" | dr[5].ToString() == "male")
                {
                    activeButton(MALE);
                }
                else
                {
                    activeButton(FEMALE);
                }

                txtbplace.Text = dr[6].ToString();

                //Get date
                String[] date = dr[7].ToString().Replace(" ", "").Split('/');
                int day = int.Parse(date[0]), month = int.Parse(date[1]), yr = int.Parse(date[2]);
                bday.Value = new DateTime(yr, month, day);
                agecal(dr[7].ToString());

                cbnatio.Text = dr[8].ToString();
                cbblood.Text = dr[9].ToString();
                txtaddr.Text = dr[10].ToString();
                txtemail.Text = dr[11].ToString();
                txtcnumber.txtnumber.Text = dr[12].ToString().Replace("+63", "");
                txttype.Text = dr[13].ToString();
                categor = dr[13].ToString();

                try
                {
                    if (dr[14].ToString() != "")
                    {
                        byte[] im = (byte[])dr[14];
                        MemoryStream ms = new MemoryStream(im);                        
                        ProfilePic.Image = Image.FromStream(ms);
                    }
                    else
                    {
                        
                        ProfilePic.Image = Properties.Resources.e7a5cf5c9e;
                    }


                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }

            }
            clinic.conn.Close();
            getsec(idno);
            emergenc(idno);
        }

        void emergenc(String id)
        {
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }
            clinic.conn.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from tblpemc where person_id = '" + id + "'", clinic.conn);
            MySqlDataReader dr1 = cmd.ExecuteReader();

            while (dr1.Read())
            {
                String[] name = dr1[1].ToString().Split(',');

                txtecfname.Text = name[1];
                txteclname.Text = name[0];
                cbrelation.Text = dr1[2].ToString();
                txtecnumber.txtnumber.Text = dr1[3].ToString().Replace("+63", "");
            }
            clinic.conn.Close();
        }

        //Calculation Age
        public void agecal(String year)
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

        //------------------------------------Gender Button-------------------------------------------

        public void activeButton(object sender)
        {
            if (sender != null)
            {
                if (btn != (IconButton)sender)
                {
                    disable();
                    btn = (IconButton)sender;
                    btn.BackColor = Color.FromArgb(30, 90, 150);
                    btn.ForeColor = Color.White;
                    gender = btn.Text;
                    //btn.FlatAppearance.BorderColor = Color.FromArgb(30, 90, 150);
                }
            }
        }

        void disable()
        {
            if (btn != null)
            {
                btn.BackColor = Color.White;
                btn.ForeColor = Color.FromArgb(30, 90, 150);
                btn = null;
            }
        }

        private void Male_Click(object sender, EventArgs e)
        {
            activeButton(sender);
        }

        private void Female_Click(object sender, EventArgs e)
        {
            activeButton(sender);
        }

        private void cbdept_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (txttype.Text)
            {
                case "Grade School":
                case "Junior High":
                    //displayBED();
                    break;
                case "Senior High":
                    //displayTrack();
                    displayStrand();
                    cbcourse.SelectedIndex = -1;
                    cbsec.SelectedIndex = -1;
                    break;
                case "College":
                    displaycourse(cbdept.Text);
                    cbcourse.SelectedIndex = -1;
                    cbyr.SelectedIndex = -1;
                    //calyr();
                    break;
                case "Employee":
                    //displayEMP();
                    break;
            }
        }

        private void cbcourse_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (txttype.Text)
            {
                case "Grade School":
                case "Junior High":
                    displayBED();
                    break;
                case "Senior High":
                    displayGradSec();
                    cbsec.SelectedIndex = -1;
                    break;
                case "College":
                    calyr(cbcourse.Text);
                    cbyr.SelectedIndex = -1;
                    break;
                case "Employee":
                    displayEMP();
                    break;
            }
        }

        //------------------------DIsplay Course and Section----------------------------

        void getsec(String id)
        {

            MySqlCommand cmd = new MySqlCommand();

            switch (txttype.Text)
            {
                case "Grade School":
                case "Junior High":

                    lbldep.Text = "Grade and Section:";

                    lblcourse.Visible = false;
                    cbcourse.Visible = false;

                    lblyr.Visible = false;
                    cbyr.Visible = false;

                    lblsec.Visible = false;
                    cbsec.Visible = false;

                    lbltype.Location = new Point(lblcourse.Location.X, lblcourse.Location.Y);
                    txttype.Location = new Point(cbcourse.Location.X, cbcourse.Location.Y);

                    displayBED();

                    clinic.conn.Open();

                    cmd = new MySqlCommand("Select * from tblsgrades_junior where person_id = '" + id + "'", clinic.conn);
                    MySqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        cbdept.Text = dr[1].ToString();
                    }

                    break;
                case "Senior High":

                    lbldep.Text = "Track:";
                    lblcourse.Text = "Strand:";
                    lblsec.Text = "Grade and Section:";

                    lblyr.Visible = false;
                    cbyr.Visible = false;

                    lblsec.Location = new Point(lblyr.Location.X, lblyr.Location.Y);
                    cbsec.Location = new Point(cbyr.Location.X, cbyr.Location.Y);



                    clinic.conn.Open();

                    cmd = new MySqlCommand("Select * from tblssenior where person_id = '" + id + "'", clinic.conn);
                    MySqlDataReader dr1 = cmd.ExecuteReader();

                    while (dr1.Read())
                    {
                        cbdept.Text = dr1[1].ToString();
                        cbcourse.Text = dr1[2].ToString();
                        cbsec.Text = dr1[3].ToString();
                    }
                    clinic.conn.Close();
                    displayTrack();
                    displayStrand();
                    displayGradSec();
                    break;
                case "College":

                    String dept = "", course = "";
                    int yr = 0;

                    clinic.conn.Open();
                    cmd = new MySqlCommand("Select * from tblscollege where person_id = '" + id + "'", clinic.conn);
                    MySqlDataReader dr2 = cmd.ExecuteReader();

                    while (dr2.Read())
                    {
                        if (dr2[1].ToString() != "")
                        {
                            cbdept.Text = dr2[1].ToString();
                            cbcourse.Text = dr2[2].ToString();



                            dept = dr2[1].ToString();
                            course = dr2[2].ToString();

                            yr = Convert.ToInt32(dr2[3].ToString()) - 1;

                            cbsec.Text = dr2[4].ToString();
                        }


                    }
                    clinic.conn.Close();

                    displaydep();
                    displaycourse(dept);
                    calyr(course);

                    if (dept == "")
                    {
                        cbdept.SelectedIndex = -1;
                    }
                    else if (yr > -1)
                    {
                        cbyr.SelectedIndex = yr;
                    }


                    break;
                case "Employee":
                    lbldep.Text = "Position:";

                    lblcourse.Visible = false;
                    cbcourse.Visible = false;

                    lblyr.Visible = false;
                    cbyr.Visible = false;

                    lblsec.Visible = false;
                    cbsec.Visible = false;

                    lbltype.Location = new Point(lblcourse.Location.X, lblcourse.Location.Y);
                    txttype.Location = new Point(cbcourse.Location.X, cbcourse.Location.Y);

                    displayEMP();

                    clinic.conn.Open();

                    cmd = new MySqlCommand("Select * from tblsemp where person_id = '" + id + "'", clinic.conn);
                    MySqlDataReader dr3 = cmd.ExecuteReader();

                    while (dr3.Read())
                    {
                        cbdept.Text = dr3[1].ToString();
                    }
                    clinic.conn.Close();
                    break;
            }


        }

        //----Employeeee Position
        void displayEMP()
        {
            cbdept.DataSource = null;
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }
            clinic.conn.Open();
            MySqlDataAdapter da1 = new MySqlDataAdapter("Select distinct(Position) from tbladdemp", clinic.conn);
            DataTable dt1 = new DataTable();

            cbdept.DisplayMember = "Position";
            lbldep.Text = "Position:";
            da1.Fill(dt1);
            cbdept.DataSource = dt1;
            //cbdept.SelectedIndex = -1;

            clinic.conn.Close();
        }

        //-----BED Grade And Section
        void displayBED()
        {
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }
            clinic.conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("Select distinct(Grade_Sec) from tbladdsecbed where Dep = '" + txttype.Text + "'", clinic.conn);
            DataTable dt = new DataTable();

            cbdept.DisplayMember = "Grade_Sec";
            lbldep.Text = "Grade and Section:";
            da.Fill(dt);
            cbdept.DataSource = dt;
            //cbdept.SelectedIndex = -1;
            clinic.conn.Close();
        }

        //----------Senior

        void displayTrack()
        {
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }
            clinic.conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("Select distinct(Track) from tbladdsecsenior", clinic.conn);
            DataTable dt = new DataTable();

            cbdept.DisplayMember = "Track";
            da.Fill(dt);
            cbdept.DataSource = dt;
            //cbdept.SelectedIndex = -1;
            clinic.conn.Close();
        }

        void displayStrand()
        {
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }
            clinic.conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("Select distinct(Strand) from tbladdsecsenior where track = '" + cbdept.Text + "'", clinic.conn);
            DataTable dt = new DataTable();

            cbcourse.DisplayMember = "Strand";
            da.Fill(dt);
            cbcourse.DataSource = dt;
            //cbcourse.SelectedIndex = -1;
            clinic.conn.Close();
        }

        void displayGradSec()
        {
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }
            clinic.conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("Select distinct(Grade_Sec) from tbladdsecsenior where Strand = '" + cbcourse.Text + "'", clinic.conn);
            DataTable dt = new DataTable();

            cbsec.DisplayMember = "Grade_Sec";
            da.Fill(dt);
            cbsec.DataSource = dt;
            //cbsec.SelectedIndex = -1;
            clinic.conn.Close();
        }

        //---------------College
        void displaydep()
        {
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }
            clinic.conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("Select distinct(Dept) from tbladdcollege", clinic.conn);
            DataTable dt = new DataTable();

            cbdept.DisplayMember = "Dept";
            da.Fill(dt);
            cbdept.DataSource = dt;
            //cbdept.SelectedIndex = -1;
            clinic.conn.Close();
        }

        void displaycourse(String dept)
        {
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }
            clinic.conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("Select distinct(course) from tbladdcollege where Dept = '" + dept + "'", clinic.conn);
            DataTable dt = new DataTable();

            cbcourse.DisplayMember = "course";
            da.Fill(dt);
            cbcourse.DataSource = dt;
            clinic.conn.Close();
        }

        void calyr(String course)
        {
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }

            int count = 0;

            cbyr.Items.Clear();

            clinic.conn.Open();
            MySqlCommand cmd = new MySqlCommand("Select yr from tbladdcollege where course = '" + course + "'", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                count = int.Parse(dr[0].ToString());
            }

            if (count > 0)
            {
                for (int i = 1; i <= count; i++)
                {
                    cbyr.Items.Add(i);
                }
            }
            clinic.conn.Close();
        }

        private void bday_ValueChanged(object sender, EventArgs e)
        {
            int today, dob, total;
            today = DateTime.Today.Year;
            dob = bday.Value.Year;

            if (bday.Value.Date.ToShortDateString() != DateTime.Today.ToShortDateString())
            {
                if (DateTime.Today.Month != bday.Value.Month)
                {
                    total = ((today - dob) - 1);

                    if (total > 0)
                    {
                        txtage.Text = "" + total;
                    }
                    else
                    {
                        MessageBox.Show("Invalid Age Number!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        bday.Value = DateTime.Today;
                    }
                }
                else
                {
                    if (DateTime.Today.Day > bday.Value.Day)
                    {
                        total = (today - dob);

                        if (total > 0)
                        {
                            txtage.Text = "" + total;
                        }
                        else
                        {
                            MessageBox.Show("Invalid Age Number!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            bday.Value = DateTime.Today;
                        }
                    }
                    else if (DateTime.Today.Day == bday.Value.Day)
                    {
                        total = (today - dob);

                        if (total > 0)
                        {
                            txtage.Text = "" + total;
                        }
                        else
                        {
                            MessageBox.Show("Invalid Age Number!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            bday.Value = DateTime.Today;
                        }
                    }
                    else if (DateTime.Today.Day != bday.Value.Day)
                    {
                        total = ((today - dob) - 1);

                        if (total > 0)
                        {
                            txtage.Text = "" + total;
                        }
                        else
                        {
                            MessageBox.Show("Invalid Age Number!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            bday.Value = DateTime.Today;
                        }
                    }
                }
            }
        }

        public void iconButton4_Click(object sender, EventArgs e)
        {
            bool check = false;
            switch (txttype.Text)
            {
                case "Grade School":
                    if (cbdept.Text == "")
                    {
                        MessageBox.Show("Please fill out the Important fields in Grade & Section! ", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        check = true;
                    }
                    break;
                case "Employee":
                    if (cbdept.Text == "")
                    {
                        MessageBox.Show("Please fill out the Important fields in Employee Position! ", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        check = true;
                    }
                    break;
                case "Junior High":
                    if (cbdept.Text == "")
                    {
                        MessageBox.Show("Please fill out the Important fields in Grade & Section! ", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        check = true;
                    }
                    break;
                case "Senior High":
                    if (cbdept.Text == "" || cbcourse.Text == "" || cbsec.Text == "")
                    {
                        MessageBox.Show("Please fill out the Important fields in Track, Strand, and Grade & Section! ", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        check = true;
                    }
                    break;
                case "College":
                    if (cbdept.Text == "" || cbcourse.Text == "" || cbyr.Text == "" || cbsec.Text == "")
                    {
                        MessageBox.Show("Please fill out the Important fields in College Department, Course, Year, and Section! ", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        check = true;
                    }
                    break;
                default:
                    MessageBox.Show("Please choose a Category!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }


            if (check == true)
            {
                if (txtfname.Text.Replace(" ", "") == "" || txtlname.Text.Replace(" ", "") == "" || gender == "" || cbnatio.Text == "" ||
                    txtage.Text.Replace(" ", "") == "" || txtbplace.Text.Replace(" ", "") == "" || txtaddr.Text.Replace(" ", "") == "")
                {
                    MessageBox.Show("Please fill out the Important fields!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (txtcnumber.txtcontact.Replace("+", "").Replace(" ", "") == "" || txtecnumber.txtcontact.Replace("+", "").Replace(" ", "") == "")
                    {
                        MessageBox.Show("Please fill out the Contact Information!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (bday.Value.ToShortDateString() == DateTime.Today.ToShortDateString())
                        {
                            MessageBox.Show("Please select correct Birth Date!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (txtecfname.Text.Replace(" ", "") == "" || txteclname.Text.Replace(" ", "") == "" || cbrelation.Text == "")
                            {
                                MessageBox.Show("Please fill out the Important fields in Emergency Contact!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                save();
                            }
                        }
                    }
                }
            }
        }

        public void save()
        {
            MemoryStream ms = new MemoryStream();
            byte[] im = ms.ToArray();

            if (ProfilePic.Image != null)
            {
                ProfilePic.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                im = ms.ToArray();
            }

            clinic.conn.Open();
            //MySqlCommand cmd = new MySqlCommand("Insert into tblprofile values('" + txtid.Text + "','" + txtfname.Text + "','" + txtmname.Text + "','" + txtlname.Text + "','" +
            //    txtsuffix.Text + "','" + gender + "','" + txtbplace.Text + "','" + bday.Value.ToShortDateString() + "','" + cbnatio.SelectedItem + "','" + cbblood.SelectedItem + "','" +
            //    txtaddr.Text + "','" + txtemail.Text + "','" + txtcnumber.txtcontact + "','" + txttype.Text + "', @img)", clinic.conn);
            //cmd.Parameters.AddWithValue("@img", im);
            //cmd.ExecuteNonQuery();


            MySqlCommand cmd = new MySqlCommand("Update tblprofile set fname = '" + txtfname.Text + "', mname = '" + txtmname.Text + "', lname = '" + txtlname.Text + "', suffix = '" +
                txtsuffix.Text + "', gender = '" + gender + "', place_birt = '" + txtbplace.Text + "', bday = '" + bday.Value.ToShortDateString() + "', nationality = '" + cbnatio.Text
                + "', blood_type = '" + cbblood.Text + "', address = '" + txtaddr.Text + "', email = '" + txtemail.Text + "', contact = '" + txtcnumber.txtcontact + "', patient_type = '"
                + txttype.Text + "', pic = @img where person_id = '" + txtid.Text + "'", clinic.conn);
            cmd.Parameters.AddWithValue("@img", im);
            int count = cmd.ExecuteNonQuery();

            if (count > 0)
            {
                MessageBox.Show("Successfully Save!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            clinic.conn.Close();
            savedep(txttype.Text);
            saveEC();
        }

        void savedep(String category)
        {
            clinic.conn.Open();

            MySqlCommand cmd = new MySqlCommand();

            switch (category)
            {
                case "Grade School":
                case "Junior High":
                    //cmd = new MySqlCommand("Insert into tblsgrades_junior values('" + txtid.Text + "','" + cbdept.Text + "','" + category + "')", clinic.conn);
                    cmd = new MySqlCommand("Update tblsgrades_junior set grade_sec = '" + cbdept.Text + "' where person_id = '" + txtid.Text + "'", clinic.conn);
                    break;
                case "Senior High":
                    //cmd = new MySqlCommand("Insert into tblssenior values('" + txtid.Text + "','" + cbdept.Text + "','" + cbcourse.Text + "','" + cbsec.Text + "')", clinic.conn);
                    cmd = new MySqlCommand("update tblssenior set track = '" + cbdept.Text + "', strand = '" + cbcourse.Text + "', section = '" + cbsec.Text + "' where person_id = '" + txtid.Text + "'", clinic.conn);
                    break;
                case "College":
                    //cmd = new MySqlCommand("Insert into tblscollege values('" + txtid.Text + "','" + cbdept.Text + "','" + cbcourse.Text + "','" + cbcourse.Text + " " + cbyr.Text + cbsec.Text + "')", clinic.conn);
                    cmd = new MySqlCommand("update tblscollege set Dept = '" + cbdept.Text + "', Course = '" + cbcourse.Text + "', YR = '" + cbyr.Text + "', section = '" + cbsec.Text + "' where person_Id = '" + txtid.Text + "'", clinic.conn);
                    break;
                case "Employee":
                    //cmd = new MySqlCommand("Insert into tblsemp values('" + txtid.Text + "','" + "" + "','" + cbdept.Text + "')", clinic.conn);
                    cmd = new MySqlCommand("update tblsemp set Position = '" + cbdept.Text + "' where person_id = '" + txtid.Text + "'", clinic.conn);
                    break;
            }

            int count = cmd.ExecuteNonQuery();

            //if (count > 0)
            //{
            //    MessageBox.Show("Save COurse");
            //}

            if (count == 0)
            {
                switch (category)
                {
                    case "Grade School":
                    case "Junior High":
                        cmd = new MySqlCommand("Insert into tblsgrades_junior values('" + txtid.Text + "','" + cbdept.Text + "','" + category + "')", clinic.conn);
                        break;
                    case "Senior High":
                        cmd = new MySqlCommand("Insert into tblssenior values('" + txtid.Text + "','" + cbdept.Text + "','" + cbcourse.Text + "','" + cbsec.Text + "')", clinic.conn);
                        break;
                    case "College":
                        cmd = new MySqlCommand("Insert into tblscollege values('" + txtid.Text + "','" + cbdept.Text + "','" + cbcourse.Text + "','" + cbyr.Text + "','" + cbsec.Text + "')", clinic.conn);
                        break;
                    case "Employee":
                        cmd = new MySqlCommand("Insert into tblsemp values('" + txtid.Text + "','" + "" + "','" + cbdept.Text + "')", clinic.conn);
                        break;
                }
                cmd.ExecuteNonQuery();
            }

            clinic.conn.Close();
        }

        void saveEC()
        {
            clinic.conn.Open();
            MySqlCommand cmd = new MySqlCommand("Update tblpemc Set fullname = '" + txteclname.Text + ", " + txtecfname.Text +
                "', Relation = '" + cbrelation.Text + "', Contact = '" + txtecnumber.txtcontact + "' where person_id = '" + txtid.Text + "'", clinic.conn);
            int count = cmd.ExecuteNonQuery();

            //if (count > 0)
            //{
            //    MessageBox.Show("SAve perent");
            //}
            clinic.conn.Close();
        }

        //Camera Input

        private void iconButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Open Image";
            op.Filter = "All Files(*.*)|*.*|PNG Image|*.png|JPEG Image|*.jpg; *.jpeg; *.jfif";
            if (op.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ProfilePic.Image = Image.FromFile(op.FileName);
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ProfilePic.Image = NewClinic.Properties.Resources.e7a5cf5c9e;
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ControlCamera.Camera cr = new ControlCamera.Camera();
            camid = "2";
            cr.Owner = ControlProfile.editform.ActiveForm;
            cr.Closed += new EventHandler(doget);
            cr.Show();
        }

        public void doget(object sender, EventArgs e)
        {
            if (ControlCamera.Camera.img != null)
            {
                ProfilePic.Image = ControlCamera.Camera.img;
            }
        }

        private void iconButton4_Click_1(object sender, EventArgs e)
        {
            if (ProfilePic.Image != null)
            {
                MessageBox.Show("You Have Image");
            }
            else if (ProfilePic.Image == null)
            {
                MessageBox.Show("You Dont Have Image");
            }
        }

    }
}
