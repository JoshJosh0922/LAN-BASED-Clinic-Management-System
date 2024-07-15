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
    public partial class ListEdit : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter da = new MySqlDataAdapter();
        MySqlDataReader dr;
        DataTable dt = new DataTable();
        string sql;
        int result;

        public ListEdit()
        {
            InitializeComponent();
        }

        private void ListEdit_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user id=root;password=;database=inventory;sslMode=none";
            conn.Close();
            conn.Open();

            DataTable dt1 = new DataTable();
            sql = "SELECT * FROM `unit`";
            cmd = new MySqlCommand(sql, conn);
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt1);
            cboUnit.DataSource = dt1;
            cboUnit.DisplayMember = "unit";

            DataTable dt2 = new DataTable();
            sql = "SELECT * FROM `category`";
            cmd = new MySqlCommand(sql, conn);
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt2);
            cboCat.DataSource = dt2;
            cboCat.DisplayMember = "name";

            sql = "Select uniqueproductlist.code, uniqueproductlist.name, uniqueproductlist.unit, uniqueproductlist.category, uniqueproductlist.description, productstocks.batch, productstocks.consumed, productstocks.stocks, DATE_FORMAT(productstocks.date_received, '%b %e, %Y') as received, DATE_FORMAT(productstocks.expiry_date, '%b %e, %Y') as expiry from productstocks INNER JOIN uniqueproductlist on productstocks.code = uniqueproductlist.code where productstocks.code = '" + txtCode.Text + "'";
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string a = "200 mg";
                string[] b = a.Split(' ');
                string c = b[0];
                string d = b[1];
                txtName.Text = Convert.ToString(dt.Rows[0]["name"]);
                txtUnit.Text = c;
                txtDesc.Text = Convert.ToString(dt.Rows[0]["description"]);
                cboUnit.Text = d;
                cboCat.Text = Convert.ToString(dt.Rows[0]["category"]);
                cboUnit.Text = d;
            }
            dt.Clear();

            sql = "SELECT count(*) as counts FROM `productstocks` WHERE code = '" + txtCode.Text + "'";
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt);
            //dt.Load(dr);
            if (dt.Rows.Count > 0)
            {
                flpList.Controls.Clear();
                var count = dt.Rows[0]["counts"];
                int datacount = Convert.ToInt32(count);
                for (int i = 0; i < datacount; i++)
                {
                    items();
                }
            }
            dt.Clear();
        }

        Panel pnl;
        string namePnl;
        int countPnl;
        //Button delete;
        Label consumed, stock, received, expiry;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dial = MessageBox.Show("Are you sure you want to cancel?", "Cancel", MessageBoxButtons.YesNo);
            if (dial == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string a = txtName.Text;
            string b = txtUnit.Text;
            string c = cboUnit.Text;
            string d = b + " " + c;
            string f = cboCat.Text;
            string g = txtDesc.Text;
            sql = "UPDATE `uniqueproductlist` SET `name`='" + a + "',`unit`='" + d + "',`category`='" + f + "',`description`='" + g + "' WHERE code = '" + txtCode.Text + "'";
            cmd = new MySqlCommand(sql, conn);
            result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("Updated Successfully!");
                this.Close();
            }
        }

        ComboBox batch;
        public void items()
        {
            pnl = new Panel()
            {
                Size = new Size(892, 45),
                Location = new Point(0, 0),
                BackColor = Color.White,
                Name = "pnl" + (countPnl + 1)
            };
            flpList.Controls.Add(pnl);
            namePnl = pnl.Name;
            countPnl += 1;

            consumed = new Label();
            stock = new Label();
            received = new Label();
            expiry = new Label();
            //delete = new Button();
            batch = new ComboBox();

            sql = "Select uniqueproductlist.code, uniqueproductlist.name, uniqueproductlist.unit, uniqueproductlist.category, uniqueproductlist.description, productstocks.batch, productstocks.consumed, productstocks.stocks, DATE_FORMAT(productstocks.date_received, '%M %e, %Y') as received, DATE_FORMAT(productstocks.expiry_date, '%M %e, %Y') as expiry from productstocks INNER JOIN uniqueproductlist on productstocks.code = uniqueproductlist.code where productstocks.code = '" + txtCode.Text + "'";
            cmd = new MySqlCommand(sql, conn);
            da.SelectCommand = cmd;
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
            cmd.ExecuteNonQuery();
                int datacount = flpList.Controls.Count;
                //MessageBox.Show(Convert.ToString(datacount));
                for (int i = 0; i <= datacount; i++)
                {
                    batch.Size = new Size(149, 29);
                    batch.Location = new Point(11,8);
                    batch.DropDownStyle = ComboBoxStyle.DropDownList;
                    batch.Font = new Font("Segoe UI", 12);
                    batch.ForeColor = Color.Black;
                    DataTable dt2 = new DataTable();
                    sql = "SELECT * FROM `batch` where code = '" + Convert.ToString(dt.Rows[i]["batch"]) + "'"; 
                    cmd = new MySqlCommand(sql, conn);
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    da.SelectCommand = cmd;
                    da.Fill(dt2);
                    batch.DataSource = dt2;
                    batch.DisplayMember = "code";
                    batch.Text = Convert.ToString(dt.Rows[i]["batch"]);
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(batch);
                        }
                    }

                    consumed.AutoSize = false;
                    consumed.Size = new Size(78, 29);
                    consumed.Location = new Point(192, 8);
                    consumed.Font = new Font("Segoe UI", 12);
                    consumed.ForeColor = Color.Black;
                    consumed.Text = Convert.ToString(dt.Rows[i]["consumed"]);
                    consumed.TextAlign = ContentAlignment.MiddleLeft;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(consumed);
                        }
                    }

                    stock.AutoSize = false;
                    stock.Size = new Size(78, 29);
                    stock.Location = new Point(345, 8);
                    stock.Font = new Font("Segoe UI", 12);
                    stock.ForeColor = Color.Black;
                    stock.Text = Convert.ToString(dt.Rows[i]["stocks"]);
                    stock.TextAlign = ContentAlignment.MiddleLeft;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(stock);
                        }
                    }

                    received.AutoSize = false;
                    received.Size = new Size(192, 29);
                    received.Location = new Point(470, 8);
                    received.Font = new Font("Segoe UI", 12);
                    received.ForeColor = Color.Black;
                    received.Text = Convert.ToString(dt.Rows[i]["received"]);
                    received.TextAlign = ContentAlignment.MiddleLeft;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(received);
                        }
                    }

                    expiry.AutoSize = false;
                    expiry.Size = new Size(192, 29);
                    expiry.Location = new Point(689, 8);
                    expiry.Font = new Font("Segoe UI", 12);
                    expiry.ForeColor = Color.Black;
                    expiry.Text = Convert.ToString(dt.Rows[i]["expiry"]);
                    expiry.TextAlign = ContentAlignment.MiddleLeft;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(expiry);
                        }
                    }

                    //delete.Size = new Size(33, 29);
                    //delete.Location = new Point(843, 8);
                    //delete.BackgroundImage = Properties.Resources.del2;
                    //delete.BackgroundImageLayout = ImageLayout.Center;
                    //delete.FlatStyle = FlatStyle.Flat;
                    //delete.FlatAppearance.BorderSize = 0;
                    //delete.Name = "btn" + (countPnl);
                    //delete.Tag = dt.Rows[i]["code"];
                    //delete.Cursor = Cursors.Hand;
                    //delete.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
                    //delete.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
                    //foreach (Control c1 in flpList.Controls)
                    //{
                    //    if (c1.Name == namePnl)
                    //    {
                    //        c1.Controls.Add(delete);
                    //    }
                    //}
                }
            }
        }
    }
}
