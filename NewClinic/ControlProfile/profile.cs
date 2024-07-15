using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace NewClinic.ControlProfile
{
    public partial class profile : UserControl
    {
        public profile()
        {
            InitializeComponent();
        }

        private void profile_Load(object sender, EventArgs e)
        {

        }

        public void showdata(String id)
        {
            clinic.conn.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from tblprofile where person_id = '" + id + "'", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txtid.Text = dr[0].ToString();

                if (dr[4].ToString() != "")
                {
                    txtname.Text = dr[3].ToString() + ", " + dr[1].ToString() + " " + dr[2].ToString() + "., " + dr[4].ToString();
                }
                else if (dr[2].ToString() != "")
                {
                    txtname.Text = dr[3].ToString() + ", " + dr[1].ToString() + " " + dr[2].ToString() + ".";
                }
                else
                {
                    txtname.Text = dr[3].ToString() + ", " + dr[1].ToString() + " " + dr[2].ToString();
                }

                txtsex.Text = dr[5].ToString();

                txtbdate.Text = dr[7].ToString();
                //txtbdate.Text = dr[7].ToString();

                txtnumber.Text = dr[12].ToString();
                txtaddres.Text = dr[10].ToString();
                txtnatio.Text = dr[8].ToString();
                txtblood.Text = dr[9].ToString();
                txttype.Text = dr[13].ToString();


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
            searchdepartment(id, txttype.Text);
        }

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
                        txttype.Location = new Point(txtcourse.Location.X, txtcourse.Location.Y);
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
                        txttype.Location = new Point(txtsec.Location.X, txtsec.Location.Y);
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
                        txttype.Location = new Point(1076, 341);
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
                        txttype.Location = new Point(txtcourse.Location.X, txtcourse.Location.Y);
                    }
                    break;
            }

            clinic.conn.Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
