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
    public partial class ListEdit : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter da = new MySqlDataAdapter();
        MySqlDataReader dr;
        DataTable dt = new DataTable();
        string sql;
        int result;

        Panel pnl;
        string namePnl;
        int countPnl;
        //Button delete;
        Label consumed, stock, received, expiry;

        ComboBox batch;


        public ListEdit()
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

        private void ListEdit_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user id=root;password=;database=nclinic1;sslMode=none";
            conn.Close();
            conn.Open();

            DataTable dt1 = new DataTable();
            //sql = "SELECT * FROM `unit`";
            //cmd = new MySqlCommand(sql, conn);
            //cmd.CommandText = sql;
            //cmd.ExecuteNonQuery();
            //da.SelectCommand = cmd;
            //da.Fill(dt1);
            //cboUnit.DataSource = dt1;
            //cboUnit.DisplayMember = "unit";

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
                string a = Convert.ToString(dt.Rows[0]["unit"]);
                string c;
                string d;
                if (a != "")
                {
                    string[] b = a.Split(' ');
                    c = b[0];
                    d = b[1];
                }
                else
                {
                     c = "";
                    d = "";
                }
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

        private void txtUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
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

        private void iconButton5_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Replace(" ", "") != "" || txtName.Text.Replace(" ", "") != "" || txtUnit.Text.Replace(" ", "") != "" || cboUnit.Text.Replace(" ", "") != "" || cboCat.Text.Replace(" ", "") != "")
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
                    Inventory mast = (Inventory)Application.OpenForms["Inventory"];
                    mast.btnList.PerformClick();
                    this.Close();
                }
            }
        }

        public void items()
        {
            pnl = new Panel()
            {
                Size = new Size(1190, 45),
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
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                int datacount = flpList.Controls.Count;
                //MessageBox.Show(Convert.ToString(datacount));
                for (int i = 0; i <= datacount; i++)
                {
                    batch.Size = new Size(149, 29);
                    batch.Location = new Point(11, 8);
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
                    consumed.Location = new Point(311, 8);
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
                    stock.Location = new Point(521, 8);
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
                    received.Location = new Point(735, 8);
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
                    expiry.Location = new Point(1009, 8);
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
