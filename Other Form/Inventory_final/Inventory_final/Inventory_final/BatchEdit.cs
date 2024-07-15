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
    public partial class BatchEdit : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter da = new MySqlDataAdapter();
        MySqlDataReader dr;
        DataTable dt = new DataTable();
        string sql;
        int result;

        public BatchEdit()
        {
            InitializeComponent();
        }

        private void BatchEdit_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user id=root;password=;database=inventory;sslMode=none";
            conn.Close();
            conn.Open();

            //dt = new DataTable();
            //da = new MySqlDataAdapter();

            sql = "SELECT * FROM `batch` WHERE code = '" + txtCode.Text + "'";
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtName.Text = Convert.ToString(dt.Rows[0]["name"]);
                txtDesc.Text = Convert.ToString(dt.Rows[0]["description"]);
                received.Value = Convert.ToDateTime(dt.Rows[0]["date_received"]);
                var a = dt.Rows[0]["expiry_date"];
                if (!(string.IsNullOrEmpty(a.ToString())))
                {
                    expiry.Checked = true;
                    expiry.Value = Convert.ToDateTime(a);
                }
            }
            dt.Clear();

            sql = "SELECT count(code) as counts FROM `productstocks` WHERE batch = '" + txtCode.Text + "'";
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt);
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
        Label name, stocks, date;
        //Button delete;
        public void items()
        {
            pnl = new Panel()
            {
                Size = new Size(683, 47),
                Location = new Point(0, 0),
                Margin = new Padding(0, 0, 0, 5),
                BackColor = Color.WhiteSmoke,
                Name = "pnl" + (countPnl + 1)
            };
            flpList.Controls.Add(pnl);
            namePnl = pnl.Name;
            countPnl += 1;

            name = new Label();
            stocks = new Label();
            date = new Label();
            //delete = new Button();

            sql = "Select uniqueproductlist.name, productstocks.stocks, DATE_FORMAT(productstocks.expiry_date, '%M %e, %Y') as expiry, uniqueproductlist.unit from productstocks INNER JOIN uniqueproductlist on productstocks.code = uniqueproductlist.code where batch = '" + txtCode.Text + "'";
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
                    name.AutoSize = false;
                    name.Size = new Size(223, 29);
                    name.Location = new Point(14, 8);
                    name.Font = new Font("Segoe UI", 12);
                    name.ForeColor = Color.Black;
                    name.Text = Convert.ToString(dt.Rows[i]["name"]) + " " + Convert.ToString(dt.Rows[i]["unit"]);
                    name.TextAlign = ContentAlignment.MiddleLeft;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(name);
                        }
                    }

                    stocks.AutoSize = false;
                    stocks.Size = new Size(136, 29);
                    stocks.Location = new Point(264, 8);
                    stocks.Font = new Font("Segoe UI", 12);
                    stocks.ForeColor = Color.Black;
                    stocks.Text = Convert.ToString(dt.Rows[i]["stocks"]);
                    stocks.TextAlign = ContentAlignment.MiddleCenter;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(stocks);
                        }
                    }

                    date.AutoSize = false;
                    date.Size = new Size(187, 29);
                    date.Location = new Point(481, 8);
                    date.Font = new Font("Segoe UI", 12);
                    date.ForeColor = Color.Black;
                    date.Text = Convert.ToString(dt.Rows[i]["expiry"]);
                    date.TextAlign = ContentAlignment.MiddleLeft;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(date);
                        }
                    }

                    //delete.Size = new Size(33, 33);
                    //delete.Location = new Point(617, 7);
                    //delete.BackgroundImage = Properties.Resources.del2;
                    //delete.BackgroundImageLayout = ImageLayout.Center;
                    //delete.FlatStyle = FlatStyle.Flat;
                    //delete.FlatAppearance.BorderSize = 0;
                    //delete.Name = "btn" + (countPnl);
                    //delete.Tag = dt.Rows[i]["id"];
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var a = received.Value.Date.ToString("yyyy-MM-dd");
            var b = expiry.Value.Date.ToString("yyyy-MM-dd");
            sql = "UPDATE `batch` SET `name`='" + txtName.Text + "',`description`='" + txtDesc.Text + "',`date_received`='" + a + "',`expiry_date`='" + b +"' WHERE code = '" + txtCode.Text + "'";
            cmd = new MySqlCommand(sql, conn);
            result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("Updated Successfully!");
                Form1 mast = (Form1)Application.OpenForms["Form1"];
                mast.btnBatch.PerformClick();
                this.Close();
            }
        }

    }
}
