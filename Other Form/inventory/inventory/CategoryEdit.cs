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
using System.Runtime.InteropServices;

namespace inventory
{
    public partial class CategoryEdit : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter da = new MySqlDataAdapter();
        MySqlDataReader dr;
        DataTable dt = new DataTable();
        string sql;
        int result;

        public CategoryEdit()
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

        private void iconButton1_Click(object sender, EventArgs e)
        {
            iconButton1.IconColor = Color.Coral;
            this.Close();
        }

        private void iconButton3_MouseEnter(object sender, EventArgs e)
        {
            iconButton1.IconColor = Color.Coral;
        }

        private void iconButton3_MouseLeave(object sender, EventArgs e)
        {
            iconButton1.IconColor = Color.White;
        }

        private void CategoryEdit_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user id=root;password=;database=nclinic1;sslMode=none";
            conn.Close();
            conn.Open();

            sql = "SELECT * FROM `category` WHERE id = '" + label1.Text + "'";
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtDesc.Text = Convert.ToString(dt.Rows[0]["description"]);
                txtName.Text = Convert.ToString(dt.Rows[0]["name"]);
            }
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            sql = "UPDATE `category` SET `name`='" + txtName.Text + "',`description`='" + txtDesc.Text + "' where id = '" + label1.Text + "'";
            cmd = new MySqlCommand(sql, conn);
            result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("Updated Successfully!");
                Inventory mast = (Inventory)Application.OpenForms["Inventory"];
                mast.btnCat.PerformClick();
                this.Close();
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            DialogResult dial = MessageBox.Show("Are you sure you want to cancel?", "Cancel", MessageBoxButtons.YesNo);
            if (dial == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
