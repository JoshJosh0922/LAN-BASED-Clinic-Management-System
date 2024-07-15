using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_final
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

        private void ListAddNewProduct_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user id=root;password=;database=inventory;sslMode=none";
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

        private void btnSave_Click(object sender, EventArgs e)
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
                        sql = "INSERT INTO `uniqueproductlist`(`code`, `name`, `unit`, `category`, `description`) VALUES ('" + txtCode.Text + "','" + txtName.Text + "','" + txtUnit.Text + cboUnit.Text + "','" + cboCat.Text + "','" + txtDesc.Text + "')";
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
                                    Form1 mast = (Form1)Application.OpenForms["Form1"];
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

        private void button2_Click(object sender, EventArgs e)
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
    }
}
