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
    public partial class ListAddNewProduct : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter da = new MySqlDataAdapter();
        MySqlDataReader dr;
        DataTable dt = new DataTable();
        string sql;
        int result;


        public ListAddNewProduct()
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

        private void ListAddNewProduct_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user id=root;password=;database=nclinic1;sslMode=none";
            conn.Close();
            conn.Open();

            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();

            sql = "SELECT * FROM `unit`";
            cmd = new MySqlCommand(sql, conn);
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt1);
            DataRow rowUnit = dt1.NewRow();
            rowUnit[1] = " ";
            dt1.Rows.Add(rowUnit);
            cboUnit.DataSource = dt1;
            cboUnit.DisplayMember = "unit";
            var last = cboUnit.Items.Count - 1;
            cboUnit.SelectedIndex = last;

            sql = "SELECT * FROM `batch`";
            cmd = new MySqlCommand(sql, conn);
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt2);
            cboBatch.DataSource = dt2;
            cboBatch.DisplayMember = "name";

            sql = "SELECT * FROM `category`";
            cmd = new MySqlCommand(sql, conn);
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt3);
            cboCat.DataSource = dt3;
            cboCat.DisplayMember = "name";
        }

        private void btnDec_Click(object sender, EventArgs e)
        {
            int a = 1;
            int b = Convert.ToInt32(txtStock.Text);
            if (b > a)
            {
                int c = b - a;
                txtStock.Text = Convert.ToString(c);
            }
        }

        private void btnInc_Click(object sender, EventArgs e)
        {
            int a = 1;
            int b = Convert.ToInt32(txtStock.Text);
            int c = b + a;
            txtStock.Text = Convert.ToString(c);
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            sql = "SELECT count(*) as counts FROM `uniqueproductlist` WHERE code = '" + txtCode.Text + "'";
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                int count = Convert.ToInt32(dt.Rows[0]["counts"]);
                if (count > 0)
                {
                    MessageBox.Show("Product already exists.", "Failed", MessageBoxButtons.OK);
                }
                else if (count == 0)
                {
                    if (txtCode.Text != "" && txtName.Text != "")
                    {
                        sql = "INSERT INTO `uniqueproductlist`(`code`, `name`, `unit`, `category`, `description`) VALUES ('" + txtCode.Text + "','" + txtName.Text + "','" + txtUnit.Text + " " + cboUnit.Text + "','" + cboCat.Text + "','" + txtDesc.Text + "')";
                        cmd = new MySqlCommand(sql, conn);
                        result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            sql = "select code as ucode, DATE_FORMAT(date_received, '%Y-%m-%d') as received from batch where name = '" + cboBatch.Text + "'";
                            cmd = new MySqlCommand(sql, conn);
                            cmd.ExecuteNonQuery();
                            da.SelectCommand = cmd;
                            da.Fill(dt2);
                            //dt.Load(dr);
                            if (dt2.Rows.Count > 0)
                            {
                                var a = dt2.Rows[0]["received"];
                                var b = expiry.Value.Date.ToString("yyyy-MM-dd");
                                var c = dt2.Rows[0]["ucode"];
                                sql = "INSERT INTO `productstocks`(`code`, `consumed`, `stocks`, `batch`, `date_received`, `expiry_date`) VALUES ('" + txtCode.Text + "','" + "0" + "','" + txtStock.Text + "','" + c + "','" + a + "','" + b + "')";
                                cmd = new MySqlCommand(sql, conn);
                                result = cmd.ExecuteNonQuery();
                                if (result > 0)
                                {
                                    MessageBox.Show("Data Inserted");
                                    Inventory mast = (Inventory)Application.OpenForms["Inventory"];
                                    mast.btnList.PerformClick();
                                    this.Close();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please fill all required fields.");
                    }
                }
            }
            dt.Clear();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            txtCode.Clear();
            txtName.Clear();
            txtUnit.Clear();
            txtDesc.Clear();
            txtStock.Text = "1";
            var last = cboUnit.Items.Count - 1;
            cboUnit.SelectedIndex = last;
            expiry.Value = DateTime.Now;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}
