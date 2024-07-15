using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using MySql.Data.MySqlClient;
using FontAwesome.Sharp;

namespace NewClinic.MainForm
{
    public partial class AddProfile : Form
    {
        public int count;

        public AddProfile()
        {
            InitializeComponent();
        }

        private void AddProfile_Load(object sender, EventArgs e)
        {
            flpfile.Controls.Clear();
        }

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
            ControlAdd.addprofile.camid = "0";
            clinic.actionuser("Cancel of Create a New Profile ", Main.id, Main.name, DateTime.Now.ToShortTimeString(), DateTime.Today.ToShortDateString());
            this.Close();
        }

        //-----Next Button

        private void iconButton2_Click(object sender, EventArgs e)
        {
            checkif(addprofile1.cbcategory.Text);
        }

        public void checkif(String category)
        {
            bool check = false;
            switch (category)
            {
                case "Grade School":
                    if (addprofile1.cbBEDEMP.Text == "")
                    {
                        MessageBox.Show("Please fill out the Important fields in Grade & Section! ", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        check = true;
                    }
                    break;
                case "Employee":
                    if (addprofile1.cbBEDEMP.Text == "")
                    {
                        MessageBox.Show("Please fill out the Important fields in Employee Position! ", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        check = true;
                    }
                    break;
                case "Junior High":
                    if (addprofile1.cbBEDEMP.Text == "")
                    {
                        MessageBox.Show("Please fill out the Important fields in Grade & Section! ", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        check = true;
                    }
                    break;
                case "Senior High":
                    if (addprofile1.cbtrack.Text == "" || addprofile1.cbStrand.Text == "" || addprofile1.cbGrade.Text == "")
                    {
                        MessageBox.Show("Please fill out the Important fields in Track, Strand, and Grade & Section! ", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        check = true;
                    }
                    break;
                case "College":
                    if (addprofile1.cbdep.Text == "" || addprofile1.cbcourse.Text == "" || addprofile1.cbyr.Text == "" || addprofile1.cbsec.Text == "")
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
                if (addprofile1.txtfname.Text.Replace(" ", "") == "" || addprofile1.txtlname.Text.Replace(" ", "") == "" || addprofile1.gender == "" || addprofile1.cbnatio.Text == "" ||
                    addprofile1.txtage.Text.Replace(" ", "") == "" || addprofile1.txtbplace.Text.Replace(" ", "") == "" || addprofile1.txtaddr.Text.Replace(" ", "") == "")
                {
                    MessageBox.Show("Please fill out the Important fields!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (addprofile1.txtcontac.txtcontact.Replace("+63", "").Replace(" ", "") == "" || addprofile1.txtcnumber.txtcontact.Replace("+63", "").Replace(" ", "") == "")
                    {
                        MessageBox.Show("Please fill out the Contact Information!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (addprofile1.dtp.Value.ToShortDateString() == DateTime.Today.ToShortDateString())
                        {
                            MessageBox.Show("Please select correct Birth Date!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (addprofile1.txtecfname.Text.Replace(" ", "") == "" || addprofile1.txteclname.Text.Replace(" ", "") == "" || addprofile1.cbrelation.Text == "")
                            {
                                MessageBox.Show("Please fill out the Important fields in Emergency Contact!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                pprofile.Visible = false;
                                pmedic.Visible = true;
                                pfile.Visible = true;
                            }
                        }
                    }
                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            addprofile1.cleared();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            medicalProfile1.clear();
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog() { Filter = "All Files(*.*)|*.*|PNG Image|*.png|JPEG Image |*.jpg; *.jpeg; *.jfif; |Text Documents|*.pdf|Text Documents|*.docx|Text Documents|*.doc", ValidateNames = true };

            if (fd.ShowDialog() == DialogResult.OK)
            {
                string filname = fd.FileName;
                ++count;
                ControlFile.addfile[] fw = new ControlFile.addfile[count];
                --count;
                fw[count] = new ControlFile.addfile();
                this.btsave.Click += new EventHandler(fw[count].savedata);
                fw[count].lblid.Text = addprofile1.lblid.Text;
                fw[count].name1 = fd.SafeFileName;
                fw[count].setdata(filname, fd.SafeFileName/*, id*/);
                flpfile.Controls.Add(fw[count]);
                ++count;
            }
        }

        private void btclear_Click(object sender, EventArgs e)
        {
            flpfile.Controls.Clear();
        }

        void remove(object sender, EventArgs e)
        {
            pfile.BringToFront();
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            pprofile.Visible = true;
            pmedic.Visible = false;
            pfile.Visible = false;
        }

        private void btsave_Click(object sender, EventArgs e)
        {
            addprofile1.save();
            medicalProfile1.getcheck();
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }

            clinic.conn.Open();
            String ee = "";

            if (medicalProfile1.cbpe.Checked)
            {
                ee = medicalProfile1.cbpe.Text;
            }
            else if (medicalProfile1.cbanual.Checked)
            {
                ee = medicalProfile1.cbanual.Text;
            }
            else if (medicalProfile1.cbother.Checked)
            {
                ee = medicalProfile1.txtother.Text;
            }

            MySqlCommand cmd = new MySqlCommand("insert into tblmedic_history values('" + "" + "','" + addprofile1.txtid.Text + "','" + medicalProfile1.condition + "','" + medicalProfile1.rt3.Text + "','" 
                + medicalProfile1.rt1.Text + "','" + medicalProfile1.rt2.Text + "','" + ee +"','" +  DateTime.Today.ToShortDateString() + "')", clinic.conn);
            cmd.ExecuteNonQuery();
            clinic.conn.Close();

            clinic.actionuser("Success to Create a New Profile of Profile ID " + addprofile1.txtid.Text, Main.id, Main.name, DateTime.Now.ToShortTimeString(), DateTime.Today.ToShortDateString());
            MessageBox.Show("Successfully save!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void iconButton4_Click_1(object sender, EventArgs e)
        {
            medicalProfile1.clear_Click(sender, e);
        }
    }
}
