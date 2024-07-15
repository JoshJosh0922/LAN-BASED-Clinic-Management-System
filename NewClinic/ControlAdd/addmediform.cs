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

namespace NewClinic.ControlAdd
{
    public partial class addmediform : Form
    {
        public static string id = "";

        public addmediform()
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

        private void addmediform_Load(object sender, EventArgs e)
        {
            if (ControlProfile.ProfileForm.id != "")
            {
                id = ControlProfile.ProfileForm.id;
            }

            if(ControlProfile.ProfileForm.status.ToLower() == "update")
            {
                lblstatus.Text = "Update Medical Profile";
            }
            else
            {
                lblstatus.Text = "Add new Medical Profile";
            }
            
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            medicalProfile1.getcheck();
            //MessageBox.Show(medicalProfile1.condition);
            clinic.conn.Open();
            MySqlCommand cmddel = new MySqlCommand("Delete from tblmedic_history where person_id = '" + id + "'", clinic.conn);
            int a = cmddel.ExecuteNonQuery();

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

            string insert = "insert into tblmedic_history values('" + "" + "','" + id + "','" + medicalProfile1.condition + "','" + medicalProfile1.rt3.Text + "','" + medicalProfile1.rt1.Text + "','" + medicalProfile1.rt2.Text + "','" +ee +"','" + DateTime.Today.ToShortDateString() + "')";

            //MessageBox.Show(insert);
            MySqlCommand cmd = new MySqlCommand(insert, clinic.conn);
            int res = cmd.ExecuteNonQuery();

            if (res > 0)
            {
                MessageBox.Show("Successfully Update!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

            clinic.conn.Close();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            id = "";
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

        private void iconButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(id + "");
        }
    }
}
