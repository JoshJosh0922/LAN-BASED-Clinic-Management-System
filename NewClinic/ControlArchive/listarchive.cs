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

namespace NewClinic.ControlArchive
{
    public partial class listarchive : UserControl
    {
        public listarchive()
        {
            InitializeComponent();
        }

        private void listarchive_Load(object sender, EventArgs e)
        {

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

        private void iconButton1_Click(object sender, EventArgs e)
        {
            clinic.restor(lblid.Text);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            clinic.conn.Open();
            if (MessageBox.Show("Are you sure you want to permanently delete this ID " + lblid.Text + "?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MySqlCommand cmd3 = new MySqlCommand("Delete from tblarchive where person_id = '" + lblid.Text + "'", clinic.conn);
                int count = cmd3.ExecuteNonQuery();

                if (count > 0)
                {
                    MessageBox.Show("Successfully Deleted!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            clinic.conn.Close();
        }
    }
}
