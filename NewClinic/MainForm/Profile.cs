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

namespace NewClinic.MainForm
{
    public partial class Profile : Form
    {
        //----Selecting Data
        public static String data = "Select Person_id, concat(Lname, ' ', Fname, ' ', Mname) Fullname, Lname, fname, Suffix, gender, bday, patient_type from tblprofile Order by Patient_type",
            datacount = "Select count(Person_id) from tblprofile";

        //----Passing Data
        public static String id, catego;

        public static String usertype = Main.usertype;

        public Profile()
        {
            InitializeComponent();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            loadData();
        }

        public void loadData()
        {
            if (textBox3.Text == "")
                data = "Select Person_id, concat(Lname, ' ', Fname, ' ', Mname) Fullname, Lname, fname, Suffix, gender, bday, patient_type from tblprofile Order by Patient_type";
            datacount = "Select count(Person_id) from tblprofile";
            loadaLL();
        }

        //---Show Data---
        public void loadaLL()
        {
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }

            //-------Elem Data
            flpdata.Controls.Clear();
            clinic.conn.Open();

            int count = new int();

            MySqlCommand cmd = new MySqlCommand(data, clinic.conn);

            MySqlCommand bilang1 = new MySqlCommand(datacount, clinic.conn);
            count = Convert.ToInt32(bilang1.ExecuteScalar()) + count;

            MySqlDataReader dr = cmd.ExecuteReader();

            ControlProfile.viewprofile[] Profile1 = new ControlProfile.viewprofile[count];

            for (int i = 0; i < Profile1.Length; i++)
            {
                while (dr.Read())
                {
                    Profile1[i] = new ControlProfile.viewprofile();
                    Profile1[i].lblid.Text = dr[0].ToString();

                    if (dr[4].ToString() != "")
                    {
                        Profile1[i].lblname.Text = dr[1].ToString() + " " + dr[4].ToString();
                    }
                    else
                    {
                        Profile1[i].lblname.Text = dr[1].ToString() + ".";
                    }

                    if (usertype != "Admin" && usertype != "Administrator" && usertype != "admin" && usertype != "superadmin")
                    {
                        Profile1[i].btnedit.Visible = false;
                        Profile1[i].btndel.Visible = false;
                        Profile1[i].btnview.Location = new Point(Profile1[i].btndel.Location.X, Profile1[i].btndel.Location.Y);
                    }
                    //else if (usertype != "superadmin" | usertype "Superadmin":)
                    //{
                    //    Profile1[i].btnedit.Visible = false;
                    //    Profile1[i].btndel.Visible = false;
                    //    Profile1[i].btnview.Location = new Point(Profile1[i].btndel.Location.X, Profile1[i].btndel.Location.Y);
                    //}

                    Profile1[i].btnedit.Click += new EventHandler(editview);
                    Profile1[i].lblgender.Text = dr[5].ToString();
                    Profile1[i].agecal(dr[6].ToString());
                    Profile1[i].lbltype.Text = dr[7].ToString();
                    Profile1[i].btnview.Click += new EventHandler(showform);
                    Profile1[i].btndel.Click += new EventHandler(reloadata);

                    if (flpdata.Controls.Count < 0)
                    {
                        flpdata.Controls.Clear();
                    }
                    else
                        flpdata.Controls.Add(Profile1[i]);
                }
            }
            clinic.conn.Close();
            //load();
        }

        void reloadata(Object sender, EventArgs e)
        {
            Profile_Load(sender, e);
        }

        void editview(Object sender, EventArgs e)
        {
            ControlProfile.editform ed = new ControlProfile.editform();
            (this.Owner as Main).Enabled = false;
            ed.Closed += new EventHandler(closeform);
            ed.Show();
        }

        //---Form Close
        public void closeform(object sender, EventArgs e)
        {
            (this.Owner as Main).Enabled = true;
            (this.Owner as Main).Focus();
        }

        //---Form Show
        public void showform(object sender, EventArgs e)
        {
            id = ControlProfile.viewprofile.id;
            clinic.actionuser("View Profile of ID " + id, Main.id, Main.name, DateTime.Now.ToShortTimeString(), DateTime.Today.ToShortDateString());
            catego = ControlProfile.viewprofile.category;
            ControlProfile.ProfileForm vp2 = new ControlProfile.ProfileForm();
            (this.Owner as Main).Enabled = false;
            vp2.Closed += new EventHandler(closeform);
            vp2.Show();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            clinic.actionuser("Add New Student", Main.id, Main.name, DateTime.Now.ToShortTimeString(), DateTime.Today.ToShortDateString());
            AddProfile add = new AddProfile();
            (this.Owner as Main).Enabled = false;
            add.Closed += new EventHandler(reload);
            add.Show();
        }

        void reload(object sender, EventArgs e)
        {
            (this.Owner as Main).Enabled = true;
            (this.Owner as Main).Focus();
            loadData();
        }


        //-------------------------------FetchDAta---------------------------

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            fetch(textBox3.Text);
        }

        void fetch(String search)
        {
            data = "Select Person_id, concat(Lname, ' ', Fname, ' ', Mname) Fullname, Lname, fname, Suffix, gender, bday, patient_type from tblprofile where Person_id like '" + search + "%' or lname like '" + search + "%' or fname like '" + search + "%'";
            datacount = "Select count(Person_id) from tblprofile where Person_id like '" + search + "%' or lname like '" + search + "%' or fname like '" + search + "%'";
            loadaLL();
        }

    }
}
