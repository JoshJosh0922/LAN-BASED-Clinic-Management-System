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

namespace NewClinic.ControlProfile
{
    public partial class viewprofile : UserControl
    {
        public static String id, category;

        public viewprofile()
        {
            InitializeComponent();
        }

        private void viewprofile_Load(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            id = lblid.Text;
            category = lbltype.Text;
        }

        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btndel_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand();

            if (MessageBox.Show("Are you sure you want to delete this ID " + lblid.Text + "?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clinic.insertArchive(lblid.Text);

                clinic.conn.Open();

                cmd = new MySqlCommand("Delete from tblprofile where person_id = '" + lblid.Text + "'", clinic.conn);
                int count1 = cmd.ExecuteNonQuery();

                //switch (lbltype.Text)
                //{
                //    case "Grade School":
                //    case "Junior High":
                //        cmd = new MySqlCommand("Delete from tblsgrades_junior where person_id = '" + lblid.Text + "'", clinic.conn);
                //        break;
                //    case "Senior High":
                //        cmd = new MySqlCommand("Delete from tblssenior where person_id = '" + lblid.Text + "'", clinic.conn);
                //        break;
                //    case "College":
                //        cmd = new MySqlCommand("Delete from tblscollege where person_id = '" + lblid.Text + "'", clinic.conn);
                //        break;
                //    case "Employee":
                //        cmd = new MySqlCommand("Delete from tblsemp where person_id = '" + lblid.Text + "'", clinic.conn);
                //        break;
                //}
                //int count2 = cmd.ExecuteNonQuery();

                //cmd = new MySqlCommand("Delete from tblpemc where person_id = '" + lblid.Text + "'", clinic.conn);
                //int count3 = cmd.ExecuteNonQuery();

                //cmd = new MySqlCommand("Delete from tblmedic_history where person_id = '" + lblid.Text + "'", clinic.conn);
                //int count4 = cmd.ExecuteNonQuery();

                //if (count1 > 0 || count2 > 0 || count3 > 0 || count4 > 0)
                clinic.conn.Close();
                if (count1 > 0)
                {
                    clinic.actionuser("Delete Profile of ID " + id, Main.id, Main.name, DateTime.Now.ToShortTimeString(), DateTime.Today.ToShortDateString());
                    MessageBox.Show("Successfully Deleted!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
           
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            id = lblid.Text;
            clinic.actionuser("Edit Profile of ID " + id, Main.id, Main.name, DateTime.Now.ToShortTimeString(), DateTime.Today.ToShortDateString());
        }

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
    }
}
