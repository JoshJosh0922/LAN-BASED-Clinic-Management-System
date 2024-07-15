using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace NewClinic.ControlDashboard
{
    public partial class listdesease : Form
    {
        String bilang = "Select Count(ID) total from tblfindings ", query = "Select deseases_name, Count(deseases_name) total, Patient_type from tblfindings group by deseases_name, Patient_Type order by total desc ";

        public listdesease()
        {
            InitializeComponent();
        }

        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWmd, int wMsg, int wParam, int lParam);

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void listdesease_Load(object sender, EventArgs e)
        {
            showdata();
            comboBox1.SelectedIndex = 2;
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            iconButton3.IconColor = Color.Red;
            this.Close();
        }
        private void iconButton3_MouseHover(object sender, EventArgs e)
        {
            iconButton3.IconColor = Color.LightCoral;
        }

        private void iconButton3_MouseLeave(object sender, EventArgs e)
        {
            iconButton3.IconColor = Color.White;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox2.Text.Replace(" ", "") != "")
            {
                switch (comboBox2.SelectedIndex)
                {
                    case 1:
                        switch (comboBox1.SelectedIndex)
                        {
                            case 0:
                                bilang = "Select Count(ID) total from tblfindings where patient_type = '" + comboBox2.Text + "'";
                                query = "Select deseases_name, Count(deseases_name) total, Patient_type from tblfindings where patient_type = '" + comboBox2.Text + "' group by deseases_name, Patient_Type order by deseases_name Asc ";
                                break;
                            case 2:
                                bilang = "Select Count(ID) total from tblfindings where patient_type = '" + comboBox2.Text + "'";
                                query = "Select deseases_name, Count(deseases_name) total, Patient_type from tblfindings where patient_type = '" + comboBox2.Text + "' group by deseases_name, Patient_Type order by total Asc ";
                                break;
                            case 3:
                                bilang = "Select Count(ID) total from tblfindings where patient_type = '" + comboBox2.Text + "'";
                                query = "Select deseases_name, Count(deseases_name) total, Patient_type from tblfindings where patient_type = '" + comboBox2.Text + "' group by deseases_name, Patient_Type order by total desc ";
                                break;
                            case 1:
                                bilang = "Select Count(ID) total from tblfindings where patient_type = '" + comboBox2.Text + "'";
                                query = "Select deseases_name, Count(deseases_name) total, Patient_type from tblfindings where patient_type = '" + comboBox2.Text + "' group by deseases_name, Patient_Type order by Patient_Type";
                                break;
                        }
                        break;
                    case 2:
                        switch (comboBox1.SelectedIndex)
                        {
                            case 0:
                                bilang = "Select Count(ID) total from tblfindings where patient_type = '" + comboBox2.Text + "'";
                                query = "Select deseases_name, Count(deseases_name) total, Patient_type from tblfindings where patient_type = '" + comboBox2.Text + "' group by deseases_name, Patient_Type order by deseases_name Asc ";
                                break;
                            case 2:
                                bilang = "Select Count(ID) total from tblfindings where patient_type = '" + comboBox2.Text + "'";
                                query = "Select deseases_name, Count(deseases_name) total, Patient_type from tblfindings where patient_type = '" + comboBox2.Text + "' group by deseases_name, Patient_Type order by total Asc ";
                                break;
                            case 3:
                                bilang = "Select Count(ID) total from tblfindings where patient_type = '" + comboBox2.Text + "'";
                                query = "Select deseases_name, Count(deseases_name) total, Patient_type from tblfindings where patient_type = '" + comboBox2.Text + "' group by deseases_name, Patient_Type order by total desc ";
                                break;
                            case 1:
                                bilang = "Select Count(ID) total from tblfindings where patient_type = '" + comboBox2.Text + "'";
                                query = "Select deseases_name, Count(deseases_name) total, Patient_type from tblfindings where patient_type = '" + comboBox2.Text + "' group by deseases_name, Patient_Type order by Patient_Type";
                                break;
                        }
                        break;
                    case 3:
                        switch (comboBox1.SelectedIndex)
                        {
                            case 0:
                                bilang = "Select Count(ID) total from tblfindings where patient_type = '" + comboBox2.Text + "'";
                                query = "Select deseases_name, Count(deseases_name) total, Patient_type from tblfindings where patient_type = '" + comboBox2.Text + "' group by deseases_name, Patient_Type order by deseases_name Asc ";
                                break;
                            case 2:
                                bilang = "Select Count(ID) total from tblfindings where patient_type = '" + comboBox2.Text + "'";
                                query = "Select deseases_name, Count(deseases_name) total, Patient_type from tblfindings where patient_type = '" + comboBox2.Text + "' group by deseases_name, Patient_Type order by total Asc ";
                                break;
                            case 3:
                                bilang = "Select Count(ID) total from tblfindings where patient_type = '" + comboBox2.Text + "'";
                                query = "Select deseases_name, Count(deseases_name) total, Patient_type from tblfindings where patient_type = '" + comboBox2.Text + "' group by deseases_name, Patient_Type order by total desc ";
                                break;
                            case 1:
                                bilang = "Select Count(ID) total from tblfindings where patient_type = '" + comboBox2.Text + "'";
                                query = "Select deseases_name, Count(deseases_name) total, Patient_type from tblfindings where patient_type = '" + comboBox2.Text + "' group by deseases_name, Patient_Type order by Patient_Type";
                                break;
                        }
                        break;
                    case 4:
                        switch (comboBox1.SelectedIndex)
                        {
                            case 0:
                                bilang = "Select Count(ID) total from tblfindings where patient_type = '" + comboBox2.Text + "'";
                                query = "Select deseases_name, Count(deseases_name) total, Patient_type from tblfindings where patient_type = '" + comboBox2.Text + "' group by deseases_name, Patient_Type order by deseases_name Asc ";
                                break;
                            case 2:
                                bilang = "Select Count(ID) total from tblfindings where patient_type = '" + comboBox2.Text + "'";
                                query = "Select deseases_name, Count(deseases_name) total, Patient_type from tblfindings where patient_type = '" + comboBox2.Text + "' group by deseases_name, Patient_Type order by total Asc ";
                                break;
                            case 3:
                                bilang = "Select Count(ID) total from tblfindings where patient_type = '" + comboBox2.Text + "'";
                                query = "Select deseases_name, Count(deseases_name) total, Patient_type from tblfindings where patient_type = '" + comboBox2.Text + "' group by deseases_name, Patient_Type order by total desc ";
                                break;
                            case 1:
                                bilang = "Select Count(ID) total from tblfindings where patient_type = '" + comboBox2.Text + "'";
                                query = "Select deseases_name, Count(deseases_name) total, Patient_type from tblfindings where patient_type = '" + comboBox2.Text + "' group by deseases_name, Patient_Type order by Patient_Type";
                                break;
                        }
                        break;
                    case 5:
                        switch (comboBox1.SelectedIndex)
                        {
                            case 0:
                                bilang = "Select Count(ID) total from tblfindings where patient_type = '" + comboBox2.Text + "'";
                                query = "Select deseases_name, Count(deseases_name) total, Patient_type from tblfindings where patient_type = '" + comboBox2.Text + "' group by deseases_name, Patient_Type order by deseases_name Asc ";
                                break;
                            case 2:
                                bilang = "Select Count(ID) total from tblfindings where patient_type = '" + comboBox2.Text + "'";
                                query = "Select deseases_name, Count(deseases_name) total, Patient_type from tblfindings where patient_type = '" + comboBox2.Text + "' group by deseases_name, Patient_Type order by total Asc ";
                                break;
                            case 3:
                                bilang = "Select Count(ID) total from tblfindings where patient_type = '" + comboBox2.Text + "'";
                                query = "Select deseases_name, Count(deseases_name) total, Patient_type from tblfindings where patient_type = '" + comboBox2.Text + "' group by deseases_name, Patient_Type order by total desc ";
                                break;
                            case 1:
                                bilang = "Select Count(ID) total from tblfindings where patient_type = '" + comboBox2.Text + "'";
                                query = "Select deseases_name, Count(deseases_name) total, Patient_type from tblfindings where patient_type = '" + comboBox2.Text + "' group by deseases_name, Patient_Type order by Patient_Type";
                                break;
                        }
                        break;
                }
            }
            else
            {
                bilang = "Select Count(ID) total from tblfindings ";
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        query = "Select deseases_name, Count(deseases_name) total, Patient_type from tblfindings group by deseases_name, Patient_Type order by deseases_name Asc ";
                        break;
                    case 2:
                        query = "Select deseases_name, Count(deseases_name) total, Patient_type from tblfindings group by deseases_name, Patient_Type order by total Asc ";
                        break;
                    case 3:
                        query = "Select deseases_name, Count(deseases_name) total, Patient_type from tblfindings group by deseases_name, Patient_Type order by total desc ";
                        break;
                    case 1:
                        query = "Select deseases_name, Count(deseases_name) total, Patient_type from tblfindings group by deseases_name, Patient_Type order by Patient_Type";
                        break;
                }
            }
            
            showdata();
        }

        void showdata()
        {
            flpgs.Controls.Clear();
            clinic.conn.Open();

            MySqlCommand cmdbilang = new MySqlCommand(bilang, clinic.conn);
            int count = Convert.ToInt32(cmdbilang.ExecuteScalar());

            MySqlCommand cmd = new MySqlCommand(query, clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            ControlDashboard.listdeseases[] ld = new ControlDashboard.listdeseases[count];

            for (int i = 0; i < ld.Length; i++)
            {
                if (dr.Read())
                {
                    ld[i] = new ControlDashboard.listdeseases();
                    //ld[i].lblcount.Text = (i + 1) + "";
                    ld[i].lblname.Text = dr[0].ToString().ToUpperInvariant();
                    ld[i].lblcount.Text = dr[1].ToString();
                    ld[i].lbltype.Text = dr[2].ToString();

                    if (flpgs.Controls.Count < 0)
                    {
                        flpgs.Controls.Clear();
                    }
                    else
                        flpgs.Controls.Add(ld[i]);
                }
            }

            clinic.conn.Close();
        }
    }
}
