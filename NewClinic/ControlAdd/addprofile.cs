using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//My libraries
using MySql.Data.MySqlClient;
using FontAwesome.Sharp;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO;

namespace NewClinic.ControlAdd
{
    public partial class addprofile : UserControl
    {
        public string gender = "", course = "", id = "", person = "";
        public static IconButton btn = new IconButton();

        //Section / Course / Dept / Position

        public static String track = "", strand = "", Dept = "", course2 = "", category, camid = "0";


        public addprofile()
        {
            InitializeComponent();
        }

        private void addprofile_Load(object sender, EventArgs e)
        {
            cbcategory.SelectedIndex = 0;
            cbcategory_SelectionChangeCommitted(sender, e);
            activeButton(Male);
        }


        private void cbcategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadCOMBO(sender, e);
        }

        void loadCOMBO(object sender, EventArgs e)
        {
            category = cbcategory.SelectedItem + "";
            switch (cbcategory.SelectedItem)
            {
                case "Grade School":
                case "Junior High":
                    panelBEMD.TabIndex = 3;

                    txtid.MaxLength = 12;

                    lblid.Text = "*LRN:";

                    displayBED();

                    panelBEMD.Visible = true;
                    panelBEMD.Location = new Point(pcollege.Location.X, pcollege.Location.Y);

                    pcollege.Visible = false;
                    panelsenior.Visible = false;
                    break;
                case "Senior High":
                    panelsenior.TabIndex = 3;

                    txtid.MaxLength = 12;

                    lblid.Text = "*LRN:";
                    loadsenior();
                    panelsenior.Visible = true;
                    panelsenior.Location = new Point(pcollege.Location.X, pcollege.Location.Y);

                    pcollege.Visible = false;
                    panelBEMD.Visible = false;
                    break;
                case "College":
                    pcollege.TabIndex = 3;

                    txtid.MaxLength = 10;

                    lblid.Text = "*Student ID:";
                    loadcollege();
                    pcollege.Visible = true;

                    panelsenior.Visible = false;
                    panelBEMD.Visible = false;
                    break;
                case "Employee":
                    txtid.MaxLength = 10;

                    lblid.Text = "*Employee ID:";
                    displayEMP();
                    panelBEMD.Visible = true;
                    panelBEMD.Location = new Point(pcollege.Location.X, pcollege.Location.Y);

                    pcollege.Visible = false;
                    panelsenior.Visible = false;
                    break;
            }
        }

        //----Employeeee Position
        void displayEMP()
        {
            cbBEDEMP.DataSource = null;
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }
            clinic.conn.Open();
            MySqlDataAdapter da1 = new MySqlDataAdapter("Select distinct(Position) from tbladdemp", clinic.conn);
            DataTable dt1 = new DataTable();

            cbBEDEMP.DisplayMember = "Position";
            lblBEDEMP.Text = "Position:";
            da1.Fill(dt1);
            cbBEDEMP.DataSource = dt1;
            cbBEDEMP.SelectedIndex = -1;

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
            MySqlDataAdapter da = new MySqlDataAdapter("Select distinct(Grade_Sec) from tbladdsecbed where Dep = '" + cbcategory.Text + "'", clinic.conn);
            DataTable dt = new DataTable();

            cbBEDEMP.DisplayMember = "Grade_Sec";
            lblBEDEMP.Text = "Grade and Section:";
            da.Fill(dt);
            cbBEDEMP.DataSource = dt;
            cbBEDEMP.SelectedIndex = -1;
            clinic.conn.Close();
        }

        //-----Senior High

        private void cbStrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayStrand();
        }
        private void cbStrand_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            displayGradSec();
        }


        void loadsenior()
        {
            if (cbtrack.Text != "")
            {
                displayStrand();
                if (cbStrand.Text != "")
                {
                    displayGradSec();
                }
            }
            else
            {
                displayTrack();
                if (cbtrack.Text != "")
                {
                    displayStrand();
                    if (cbStrand.Text != "")
                    {
                        displayGradSec();
                    }
                }
            }

        }
        void displayTrack()
        {
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }
            clinic.conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("Select distinct(Track) from tbladdsecsenior", clinic.conn);
            DataTable dt = new DataTable();

            cbtrack.DisplayMember = "Track";
            da.Fill(dt);
            cbtrack.DataSource = dt;
            cbtrack.SelectedIndex = -1;
            clinic.conn.Close();
        }

        void displayStrand()
        {
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }
            clinic.conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("Select distinct(Strand) from tbladdsecsenior where track = '" + cbtrack.Text + "'", clinic.conn);
            DataTable dt = new DataTable();

            cbStrand.DisplayMember = "Strand";
            da.Fill(dt);
            cbStrand.DataSource = dt;
            cbStrand.SelectedIndex = -1;
            clinic.conn.Close();
        }

        void displayGradSec()
        {
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }
            clinic.conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("Select distinct(Grade_Sec) from tbladdsecsenior where Strand = '" + cbStrand.Text + "'", clinic.conn);
            DataTable dt = new DataTable();

            cbGrade.DisplayMember = "Grade_Sec";
            da.Fill(dt);
            cbGrade.DataSource = dt;
            cbGrade.SelectedIndex = -1;
            clinic.conn.Close();
        }

        //-----College
        private void cbdep_SelectedIndexChanged(object sender, EventArgs e)
        {
            displaycourse();
        }

        private void cbcourse_SelectionChangeCommitted(object sender, EventArgs e)
        {
            calyr();
        }

        void loadcollege()
        {
            displaydep();
        }

        void displaydep()
        {
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }
            clinic.conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("Select distinct(Dept) from tbladdcollege", clinic.conn);
            DataTable dt = new DataTable();

            cbdep.DisplayMember = "Dept";
            da.Fill(dt);
            cbdep.DataSource = dt;
            cbdep.SelectedIndex = -1;
            clinic.conn.Close();
        }

        void displaycourse()
        {
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }
            clinic.conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("Select distinct(course) from tbladdcollege where Dept = '" + cbdep.Text + "'", clinic.conn);
            DataTable dt = new DataTable();

            cbcourse.DisplayMember = "course";
            da.Fill(dt);
            cbcourse.DataSource = dt;
            cbcourse.SelectedIndex = -1;
            clinic.conn.Close();
        }

        void calyr()
        {
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }

            int count = 0;

            clinic.conn.Open();
            MySqlCommand cmd = new MySqlCommand("Select yr from tbladdcollege where course = '" + cbcourse.Text + "'", clinic.conn);
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

        //------------------------------------Gender Button-------------------------------------------

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

        //Add New Section / Course / Strand

        //Track
        private void iconButton4_Click(object sender, EventArgs e)
        {
            //Dept = "";
            //course2 = "";
            //Dept = cbtrack.Text;
            Addcollege addc = new Addcollege();
            addc.Owner = MainForm.AddProfile.ActiveForm;
            MainForm.AddProfile.ActiveForm.Enabled = false;
            addc.iconButton1.Click += new EventHandler(loadCOMBO);
            addc.Show();
        }

        //Strand
        private void iconButton5_Click(object sender, EventArgs e)
        {
            Dept = "";
            course2 = "";
            Dept = cbtrack.Text;
            course2 = cbStrand.Text;
            Addcollege addc = new Addcollege();
            addc.Owner = MainForm.AddProfile.ActiveForm;
            MainForm.AddProfile.ActiveForm.Enabled = false;
            addc.iconButton1.Click += new EventHandler(loadCOMBO);
            addc.Show();
        }

        //Section
        private void iconButton6_Click(object sender, EventArgs e)
        {
            Dept = "";
            course2 = "";
            Dept = cbtrack.Text;
            course2 = cbStrand.Text;
            Addcollege addc = new Addcollege();
            addc.Owner = MainForm.AddProfile.ActiveForm;
            MainForm.AddProfile.ActiveForm.Enabled = false;
            addc.iconButton1.Click += new EventHandler(loadCOMBO);
            addc.Show();
        }

        //BED / EMP
        private void iconButton11_Click(object sender, EventArgs e)
        {
            AddBEMD add = new AddBEMD();
            add.Owner = MainForm.AddProfile.ActiveForm;
            MainForm.AddProfile.ActiveForm.Enabled = false;
            add.iconButton1.Click += new EventHandler(loadCOMBO);
            add.Show();
        }

        //Dept
        private void iconButton8_Click(object sender, EventArgs e)
        {
            //Dept = "";
            //course2 = "";
            //Dept = cbdep.Text;
            Addcollege addc = new Addcollege();
            addc.Owner = MainForm.AddProfile.ActiveForm;
            MainForm.AddProfile.ActiveForm.Enabled = false;
            addc.iconButton1.Click += new EventHandler(loadCOMBO);
            addc.Show();
        }

        //Course
        private void iconButton9_Click(object sender, EventArgs e)
        {
            Dept = "";
            course2 = "";
            Dept = cbdep.Text;
            course2 = cbcourse.Text;
            Addcollege addc = new Addcollege();
            addc.Owner = MainForm.AddProfile.ActiveForm;
            MainForm.AddProfile.ActiveForm.Enabled = false;
            addc.iconButton1.Click += new EventHandler(loadCOMBO);
            addc.Show();
        }

        private void txtage_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        //------Bdate
        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            int today, dob, total;
            today = DateTime.Today.Year;
            dob = dtp.Value.Year;

            if (dtp.Value.Date.ToShortDateString() != DateTime.Today.ToShortDateString())
            {
                if (DateTime.Today.Month != dtp.Value.Month)
                {
                    total = ((today - dob) - 1);

                    if (total > 0)
                    {
                        txtage.Text = "" + total;
                    }
                    else
                    {
                        MessageBox.Show("Invalid Age Number!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dtp.Value = DateTime.Today;
                    }
                }
                else
                {
                    if (DateTime.Today.Day > dtp.Value.Day)
                    {
                        total = (today - dob);

                        if (total > 0)
                        {
                            txtage.Text = "" + total;
                        }
                        else
                        {
                            MessageBox.Show("Invalid Age Number!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dtp.Value = DateTime.Today;
                        }
                    }
                    else if (DateTime.Today.Day == dtp.Value.Day)
                    {
                        total = (today - dob);

                        if (total > 0)
                        {
                            txtage.Text = "" + total;
                        }
                        else
                        {
                            MessageBox.Show("Invalid Age Number!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dtp.Value = DateTime.Today;
                        }
                    }
                    else if (DateTime.Today.Day != dtp.Value.Day)
                    {
                        total = ((today - dob) - 1);

                        if (total > 0)
                        {
                            txtage.Text = "" + total;
                        }
                        else
                        {
                            MessageBox.Show("Invalid Age Number!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dtp.Value = DateTime.Today;
                        }
                    }
                }
            }
        }

        //----------------------------------------------Clear Input-------------------------------------------------

        //Clear All

        public void cleared()
        {

            txtid.Clear();
            txtfname.Clear();
            txtmname.Clear();
            txtlname.Clear();
            txtage.Clear();
            txtbplace.Clear();
            txtemail.Clear();
            txtaddr.Clear();
            txtecfname.Clear();

            txteclname.Clear();

            gender = "";
            txtcnumber.txtcontact = "";
            txtcnumber.txtnumber.Text = "";
            txtcontac.txtcontact = "";
            txtcontac.txtnumber.Text = "";

            // Section / Course / Position / Track

            cbBEDEMP.SelectedIndex = -1;
            cbtrack.SelectedIndex = -1;
            cbStrand.SelectedIndex = -1;
            cbGrade.SelectedIndex = -1;
            cbdep.SelectedIndex = -1;
            cbcourse.SelectedIndex = -1;
            cbnatio.SelectedIndex = -1;

            cbyr.SelectedIndex = -1;


            cbrelation.SelectedIndex = -1;
            cbcategory.SelectedIndex = -1;
            cbblood.SelectedIndex = -1;

            dtp.Value = DateTime.Today;
            ProfilePic.Image = Properties.Resources.e7a5cf5c9e;

            disable();
        }

        //---------------------------------------Camera---------------------------------------------

        //Function to get the Picture
        public void doget(object sender, EventArgs e)
        {
            if (ControlCamera.Camera.img != null)
            {
                ProfilePic.Image = ControlCamera.Camera.img;
            }
        }

        private void cbsec_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbcourse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

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
            camid = "1";
            cr.Owner = MainForm.AddProfile.ActiveForm;
            cr.Closed += new EventHandler(doget);
            cr.Show();
        }

        //---Saving

        public void checkif(String category)
        {
            bool check = false;
            switch (category)
            {
                case "Grade School":
                    if (cbBEDEMP.Text == "")
                    {
                        MessageBox.Show("Please fill out the Important fields in Grade & Section! ", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        check = true;
                    }
                    break;
                case "Employee":
                    if (cbBEDEMP.Text == "")
                    {
                        MessageBox.Show("Please fill out the Important fields in Employee Position! ", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        check = true;
                    }
                    break;
                case "Junior High":
                    if (cbBEDEMP.Text == "")
                    {
                        MessageBox.Show("Please fill out the Important fields in Grade & Section! ", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        check = true;
                    }
                    break;
                case "Senior High":
                    if (cbtrack.Text == "" || cbStrand.Text == "" || cbGrade.Text == "")
                    {
                        MessageBox.Show("Please fill out the Important fields in Track, Strand, and Grade & Section! ", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        check = true;
                    }
                    break;
                case "College":
                    if (cbdep.Text == "" || cbcourse.Text == "" || cbyr.Text == "" || cbsec.Text == "")
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
                    if (txtcontac.txtcontact.Replace("+63", "").Replace(" ", "") == "" || txtcnumber.txtcontact.Replace("+63", "").Replace(" ", "") == "")
                    {
                        MessageBox.Show("Please fill out the Contact Information!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (dtp.Value.ToShortDateString() == DateTime.Today.ToShortDateString())
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

            try
            {
                if (ProfilePic.Image != Properties.Resources.e7a5cf5c9e || ProfilePic.Image != null || ProfilePic.BackgroundImage != Properties.Resources.e7a5cf5c9e)
                {
                    ProfilePic.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    im = ms.ToArray();
                }

                try
                {
                    clinic.conn.Open();
                    MySqlCommand cmd = new MySqlCommand("Insert into tblprofile values('" + txtid.Text + "','" + txtfname.Text + "','" + txtmname.Text + "','" + txtlname.Text + "','" + txtsuffix.Text + "','" + gender + "','" + txtbplace.Text + "','" + dtp.Value.ToShortDateString() +
                                "','" + cbnatio.Text + "','" + cbblood.Text + "','" + txtaddr.Text + "','" + txtemail.Text + "','" + txtcnumber.txtcontact + "','" + cbcategory.Text + "', @img )", clinic.conn);
                    cmd.Parameters.AddWithValue("@img", im);
                    cmd.ExecuteNonQuery();

                    clinic.conn.Close();
                    savedep(cbcategory.Text);
                    saveEC();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ". Problem in Student/Employee Insertion!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ". Problem in Image Input!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void savedep(String category)
        {
            try
            {
                clinic.conn.Open();

                MySqlCommand cmd = new MySqlCommand();

                switch (category)
                {
                    case "Grade School":
                    case "Junior High":
                        cmd = new MySqlCommand("Insert into tblsgrades_junior values('" + txtid.Text + "','" + cbBEDEMP.Text + "','" + category + "')", clinic.conn);
                        break;
                    case "Senior High":
                        cmd = new MySqlCommand("Insert into tblssenior values('" + txtid.Text + "','" + cbtrack.Text + "','" + cbStrand.Text + "','" + cbGrade.Text + "')", clinic.conn);
                        break;
                    case "College":
                        cmd = new MySqlCommand("Insert into tblscollege values('" + txtid.Text + "','" + cbdep.Text + "','" + cbcourse.Text + "','" + cbyr.Text + "','" + cbsec.Text + "')", clinic.conn);
                        break;
                    case "Employee":
                        cmd = new MySqlCommand("Insert into tblsemp values('" + txtid.Text + "','" + "" + "','" + cbBEDEMP.Text + "')", clinic.conn);
                        break;
                }

                cmd.ExecuteNonQuery();
                clinic.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "." + "Problem in Department/Section/Position", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        void saveEC()
        {
            try
            {
                clinic.conn.Open();
                MySqlCommand cmd = new MySqlCommand("Insert into tblpemc values('" + txtid.Text + "','" + txteclname.Text + ", " + txtecfname.Text +
                    "','" + cbrelation.Text + "','" + txtcontac.txtcontact + "')", clinic.conn);
                cmd.ExecuteNonQuery();
                clinic.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ". Problem in  Emergency Contact!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

    }
}
