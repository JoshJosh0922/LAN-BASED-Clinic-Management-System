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
    public partial class Batch : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        MySqlDataReader dr;
        DataTable dt;
        string sql;
        int result;

        public Batch()
        {
            InitializeComponent();
        }

        private void Batch_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user id=root;password=;database=nclinic1;sslMode=none";
            conn.Close();
            conn.Open();

            dt = new DataTable();
            da = new MySqlDataAdapter();

            sql = "select count(*) as count from `batch`";
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt);
            //dt.Load(dr);
            if (dt.Rows.Count > 0)
            {
                flpList.Controls.Clear();
                var count = dt.Rows[0]["count"];
                int datacount = Convert.ToInt32(count);
                for (int i = 0; i < datacount; i++)
                {
                    items();
                }
            }
            dt.Clear();
        }

        Panel pnl, pnlStatus;
        string namePnl;
        int countPnl;
        Label code, name, received, expiry;
        CheckBox chk;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<BatchAdd>().Count() == 1)
                Application.OpenForms.OfType<BatchAdd>().First().Close();

            BatchAdd addba = new BatchAdd();
            addba.Show();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                flpList.Controls.Clear();
                sql = "SELECT count(id) as count FROM `batch` where code = '" + txtSearch.Text + "' || name = '" + txtSearch.Text + "'";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    object a = dt.Rows[0]["count"];
                    int b = Convert.ToInt32(a);
                    //MessageBox.Show(Convert.ToString(b));
                    for (int i = 0; i < b; i++)
                    {
                        searchedItem();
                    }
                }
            }
            dt.Clear();
        }

        Button delete, edit;
        public void items()
        {
            pnl = new Panel()
            {
                Size = new Size(1326, 50),
                Location = new Point(0, 0),
                Margin = new Padding(0, 0, 0, 5),
                BackColor = Color.WhiteSmoke,
                Name = "pnl" + (countPnl + 1)
            };
            flpList.Controls.Add(pnl);
            namePnl = pnl.Name;
            countPnl += 1;

            code = new Label();
            name = new Label();
            received = new Label();
            expiry = new Label();
            edit = new Button();
            delete = new Button();

            DataTable dt1 = new DataTable();

            sql = "SELECT *, DATE_FORMAT(date_received, '%b %e, %Y') as received, DATE_FORMAT(expiry_date, '%b %e, %Y') as expiry FROM `batch`";
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                int datacount = flpList.Controls.Count;
                //MessageBox.Show(Convert.ToString(datacount));
                for (int i = 0; i < datacount; i++)
                {
                    code.AutoSize = false;
                    code.Size = new Size(177, 34);
                    code.Location = new Point(16, 8);
                    code.Font = new Font("Segoe UI", 12);
                    code.ForeColor = Color.Black;
                    code.Text = Convert.ToString(dt1.Rows[i]["code"]);
                    code.TextAlign = ContentAlignment.MiddleLeft;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(code);
                        }
                    }

                    name.AutoSize = false;
                    name.Size = new Size(246, 34);
                    name.Location = new Point(241, 8);
                    name.Font = new Font("Segoe UI", 12);
                    name.ForeColor = Color.Black;
                    name.Text = Convert.ToString(dt1.Rows[i]["name"]);
                    name.TextAlign = ContentAlignment.MiddleLeft;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(name);
                        }
                    }

                    received.AutoSize = false;
                    received.Size = new Size(246, 34);
                    received.Location = new Point(535, 8);
                    received.Font = new Font("Segoe UI", 12);
                    received.ForeColor = Color.Black;
                    received.Text = Convert.ToString(dt1.Rows[i]["received"]);
                    received.TextAlign = ContentAlignment.MiddleLeft;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(received);
                        }
                    }

                    expiry.AutoSize = false;
                    expiry.Size = new Size(246, 34);
                    expiry.Location = new Point(866, 8);
                    expiry.Font = new Font("Segoe UI", 12);
                    expiry.ForeColor = Color.Black;
                    expiry.Text = Convert.ToString(dt1.Rows[i]["expiry"]);
                    expiry.TextAlign = ContentAlignment.MiddleLeft;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(expiry);
                        }
                    }

                    edit.Size = new Size(33, 33);
                    edit.Location = new Point(1200, 8);
                    edit.BackgroundImage = Properties.Resources.edit5;
                    edit.BackgroundImageLayout = ImageLayout.Center;
                    edit.FlatStyle = FlatStyle.Flat;
                    edit.FlatAppearance.BorderSize = 0;
                    edit.Name = "btn" + (countPnl);
                    edit.Tag = dt1.Rows[i]["code"];
                    edit.Cursor = Cursors.Hand;
                    edit.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
                    edit.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(edit);
                        }
                    }

                    delete.Size = new Size(33, 33);
                    delete.Location = new Point(1255, 8);
                    delete.BackgroundImage = Properties.Resources.del2;
                    delete.BackgroundImageLayout = ImageLayout.Center;
                    delete.FlatStyle = FlatStyle.Flat;
                    delete.FlatAppearance.BorderSize = 0;
                    delete.Name = "btn" + (countPnl);
                    delete.Tag = dt1.Rows[i]["code"];
                    delete.Cursor = Cursors.Hand;
                    delete.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
                    delete.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(delete);
                        }
                    }
                }
            }
            edit.Click += new EventHandler(this.edit_click);
            delete.Click += new EventHandler(this.delete_click);
        }

        public void searchedItem()
        {
            pnl = new Panel()
            {
                Size = new Size(1170, 54),
                Location = new Point(0, 0),
                Margin = new Padding(0, 0, 0, 5),
                BackColor = Color.WhiteSmoke,
                Name = "pnl" + (countPnl + 1)
            };
            flpList.Controls.Add(pnl);
            namePnl = pnl.Name;
            countPnl += 1;

            code = new Label();
            name = new Label();
            received = new Label();
            expiry = new Label();
            edit = new Button();
            delete = new Button();


            sql = "SELECT *, DATE_FORMAT(date_received, '%b %e, %Y') as received, DATE_FORMAT(expiry_date, '%b %e, %Y') as expiry FROM `batch` where code = '" + txtSearch.Text + "' || name = '" + txtSearch.Text + "'";
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
                    code.AutoSize = false;
                    code.Size = new Size(177, 34);
                    code.Location = new Point(16, 8);
                    code.Font = new Font("Segoe UI", 12);
                    code.ForeColor = Color.Black;
                    code.Text = Convert.ToString(dt.Rows[i]["code"]);
                    code.TextAlign = ContentAlignment.MiddleLeft;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(code);
                        }
                    }

                    name.AutoSize = false;
                    name.Size = new Size(246, 34);
                    name.Location = new Point(211, 8);
                    name.Font = new Font("Segoe UI", 12);
                    name.ForeColor = Color.Black;
                    name.Text = Convert.ToString(dt.Rows[i]["name"]);
                    name.TextAlign = ContentAlignment.MiddleLeft;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(name);
                        }
                    }

                    received.AutoSize = false;
                    received.Size = new Size(246, 34);
                    received.Location = new Point(474, 8);
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
                    expiry.Size = new Size(246, 34);
                    expiry.Location = new Point(739, 8);
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

                    edit.Size = new Size(33, 33);
                    edit.Location = new Point(1044, 8);
                    edit.BackgroundImage = Properties.Resources.edit5;
                    edit.BackgroundImageLayout = ImageLayout.Center;
                    edit.FlatStyle = FlatStyle.Flat;
                    edit.FlatAppearance.BorderSize = 0;
                    edit.Name = "btn" + (countPnl);
                    edit.Tag = dt.Rows[i]["code"];
                    edit.Cursor = Cursors.Hand;
                    edit.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
                    edit.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(edit);
                        }
                    }

                    delete.Size = new Size(33, 33);
                    delete.Location = new Point(1098, 8);
                    delete.BackgroundImage = Properties.Resources.del2;
                    delete.BackgroundImageLayout = ImageLayout.Center;
                    delete.FlatStyle = FlatStyle.Flat;
                    delete.FlatAppearance.BorderSize = 0;
                    delete.Name = "btn" + (countPnl);
                    delete.Tag = dt.Rows[i]["id"];
                    delete.Cursor = Cursors.Hand;
                    delete.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
                    delete.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(delete);
                        }
                    }

                    edit.Click += new EventHandler(this.edit_click);
                    delete.Click += new EventHandler(this.delete_click);
                }
            }
        }

        void edit_click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<BatchEdit>().Count() == 1)
                Application.OpenForms.OfType<BatchEdit>().First().Close();

            var a = (sender as Button).Tag;
            string g = Convert.ToString(a);

            BatchEdit editbatch = new BatchEdit();
            editbatch.txtCode.Text = g;
            editbatch.Show();
        }

        void delete_click(object sender, EventArgs e)
        {
            var a = (sender as Button).Tag;
            string g = Convert.ToString(a);

            DialogResult dial = MessageBox.Show("Are you sure you want to delete this item?", "Delete", MessageBoxButtons.YesNo);
            if (dial == DialogResult.Yes)
            {
                sql = "Select count(productstocks.code) as counts from productstocks INNER JOIN batch on productstocks.batch = batch.code where productstocks.batch = '" + g + "'";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    int count = Convert.ToInt32(dt.Rows[0]["counts"]);
                    if (count > 0)
                    {
                        MessageBox.Show("Unable to delete batch. The batch contains stocks.", "Deletion failed", MessageBoxButtons.OK);
                    }
                    else if (count == 0)
                    {
                        sql = "INSERT INTO `archivebatch` SELECT * from batch where code = '" + g + "'";
                        cmd = new MySqlCommand(sql, conn);
                        result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            sql = "DELETE FROM `batch` WHERE code = '" + g + "'";
                            cmd = new MySqlCommand(sql, conn);
                            result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Data Deleted");
                                Form1 mast = (Form1)Application.OpenForms["Form1"];
                                mast.btnBatch.PerformClick();
                                this.Close();
                            }
                        }
                    }
                }

            }
        }
    }
}
