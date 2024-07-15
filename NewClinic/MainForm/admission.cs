using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//My Library
using MySql.Data.MySqlClient;
using FontAwesome.Sharp;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO;

namespace NewClinic.MainForm
{
    public partial class admission : Form
    {

        //public static String log = "SELECT * FROM tblogbook where not EXISTS(SELECT * from tbladmission where tblogbook.lb_ID = tbladmission.Lb_ID) and time_out = '' and date_in = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' Order by Time_in Desc";
        public static String log = "SELECT * FROM tblogbook where not EXISTS(SELECT * from tbladmission where tblogbook.lb_ID = tbladmission.Lb_ID) and time_out = '' Order by Time_in Desc";
        //public static String logbilang = "SELECT count(person_id) FROM tblogbook where not EXISTS(SELECT * from tbladmission where tblogbook.lb_ID = tbladmission.lb_ID) and time_out = '' and date_in = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' Order by Time_in Desc";
        public static String logbilang = "SELECT count(person_id) FROM tblogbook where not EXISTS(SELECT * from tbladmission where tblogbook.lb_ID = tbladmission.lb_ID) and time_out = '' Order by Time_in Desc";


        public static String id, categories, logbook_id, nurse_name;

        public admission()
        {
            InitializeComponent();
        }

        private void admission_Load(object sender, EventArgs e)
        {
           
            populatelogbook();
            search("");
        }

        //----------------------------------------------------------------------------------Show data in logbook-------------------------------------------

        public void doable(object sender, EventArgs e)
        {
            (this.Owner as Main).Enabled = true;
            (this.Owner as Main).Focus();
            populatelogbook();
        }

        //New Code for admission
        public void select(object sender, EventArgs e)
        {
            id = ControlAdmission.select1.id;
            categories = ControlAdmission.select1.category;
            logbook_id = ControlAdmission.select1.logbookid;

            (this.Owner as Main).Enabled = false;

            clinic.actionuser("Select ID " + id, Main.id, Main.name, DateTime.Now.ToShortTimeString(), DateTime.Today.ToShortDateString());

            ControlAdmission.AdmissionForm add = new ControlAdmission.AdmissionForm();

            add.Show();
            add.Closed += new EventHandler(doable);
        }

        public void populatelogbook()
        {
            try
            {
                if (clinic.conn.State == ConnectionState.Open)
                {
                    clinic.conn.Close();
                }
                clinic.conn.Open();


                int count = new int();
                MySqlCommand cmd2 = new MySqlCommand(logbilang, clinic.conn);
                count = Convert.ToInt32(cmd2.ExecuteScalar());

                MySqlCommand cmd = new MySqlCommand(log, clinic.conn);
                MySqlDataReader rs = cmd.ExecuteReader();

                int size = (count);

                ControlAdmission.select1[] profiles = new ControlAdmission.select1[size];

                if (count == 0)
                {
                    Label lb = new Label();
                    lb.TextAlign = ContentAlignment.MiddleCenter;
                    lb.Text = "No Record Found!";
                    lb.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lb.ForeColor = Color.DarkGray;
                    lb.BringToFront();
                    lb.Dock = DockStyle.Fill;
                    pcontainer.Controls.Add(lb);
                    flplogbook.Visible = false;
                }

                flplogbook.Controls.Clear();
                for (int i = 0; i < profiles.Length; i++)
                {

                    while (rs.Read())
                    {

                        profiles[i] = new ControlAdmission.select1();
                        profiles[i].lb = rs[0].ToString();
                        profiles[i].lblid.Text = rs[1].ToString();
                        profiles[i].lblname.Text = rs[2].ToString();
                        profiles[i].lbldate.Text = rs[4].ToString();
                        profiles[i].lblin.Text = rs[5].ToString();
                        profiles[i].lblreason.Text = rs[10].ToString();
                        profiles[i].lblmedic.Text = rs[11].ToString();
                        profiles[i].lblcatego.Text = rs[13].ToString();
                        profiles[i].lblattended.Text = rs[12].ToString();

                        profiles[i].iconButton1.Click += new EventHandler(select);

                        if (flplogbook.Controls.Count < 0)
                        {
                            flplogbook.Controls.Clear();
                        }
                        else
                            flplogbook.Controls.Add(profiles[i]);
                    }
                }



                clinic.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalit Input!\n\n" + ex.Message, "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtsearch.Clear();
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            search(txtsearch.Text);
        }

        void search(String search)
        {
            if (search != "")
            {
                log = "SELECT * FROM tblogbook WHERE NOT EXISTS (SELECT * FROM tbladmission WHERE tbladmission.Person_id = tblogbook .Person_Id) and Person_Id like '%" + search + "%' and time_out = '' and date_in = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' " +
                    "or NOT EXISTS (SELECT * FROM tbladmission WHERE tbladmission.Person_id = tblogbook .Person_Id) and Name like '%" + search + "%' and time_out = '' and date_in = '" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
                logbilang = "SELECT count(lb_id) FROM tblogbook  WHERE NOT EXISTS (SELECT * FROM tbladmission WHERE tbladmission.Person_id = tblogbook .Person_Id) and Person_Id like '%" + search + "%' and time_out = '' and date_in = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' " +
                    "or NOT EXISTS (SELECT * FROM tbladmission WHERE tbladmission.Person_id = tblogbook .Person_Id) and Name like '%" + search + "%' and time_out = '' and date_in = '" + DateTime.Today.ToString("yyyy-MM-dd") + "'";


            }
            else
            {
                log = "SELECT* FROM tblogbook  where not EXISTS(SELECT* from tbladmission where tblogbook .lb_id = tbladmission.lb_id) and time_out = '' and date_in = '" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
                logbilang = "SELECT count(person_id) FROM tblogbook  where not EXISTS(SELECT* from tbladmission where tblogbook .lb_id = tbladmission.lb_id) and time_out = '' and date_in = '" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
            }
            populatelogbook();
        }

    }
}
