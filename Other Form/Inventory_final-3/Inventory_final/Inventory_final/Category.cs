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
    public partial class Category : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter da = new MySqlDataAdapter();
        MySqlDataReader dr;
        DataTable dt = new DataTable();
        string sql;
        int result;

        public Category()
        {
            InitializeComponent();
        }

        private void Category_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user id=root;password=;database=nclinic1;sslMode=none";
            conn.Close();
            conn.Open();

            sql = "select count(*) as count from `category`";
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt);
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

            DataTable dt1 = new DataTable();

            sql = "select count(*) as count from `unit`";
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                flp1.Controls.Clear();
                var count1 = dt1.Rows[0]["count"];
                int datacount1 = Convert.ToInt32(count1);
                for (int i = 0; i < datacount1; i++)
                {
                    items2();
                }
            }
            dt1.Clear();
        }

        Panel pnlwh, pnl1;
        string namePnl, namePnl1;
        int countPnl, countPnl1;
        Label code, name, code1, name1, unit;

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                flpList.Controls.Clear();
                sql = "SELECT count(id) as count FROM `category` where id = '" + txtSearch.Text + "' || name = '" + txtSearch.Text + "'";
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

        private void btnAddUnit_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<CategoryUnitAdd>().Count() == 1)
                Application.OpenForms.OfType<CategoryUnitAdd>().First().Close();

            CategoryUnitAdd unitadd = new CategoryUnitAdd();
            unitadd.Show();
        }

        private void txtSearch2_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataTable dt1 = new DataTable();
            if (e.KeyChar == (char)Keys.Enter)
            {
                flp1.Controls.Clear();
                sql = "SELECT count(id) as count FROM `unit` where id = '" + txtSearch2.Text + "' || unit_name = '" + txtSearch2.Text + "' || unit = '" + txtSearch2.Text + "'";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(dt1);
                if (dt1.Rows.Count > 0)
                {
                    object a = dt1.Rows[0]["count"];
                    int b = Convert.ToInt32(a);
                    //MessageBox.Show(Convert.ToString(b));
                    for (int i = 0; i < b; i++)
                    {
                        searchedItem2();
                    }
                }
            }
            dt1.Clear();
        }

        Button delete, edit, delete1, edit1;
        public void items()
        {
            pnlwh = new Panel()
            {
                Size = new Size(552, 50),
                Location = new Point(0, 0),
                Margin = new Padding(0, 0, 0, 5),
                BackColor = Color.WhiteSmoke,
                Name = "pnl" + (countPnl + 1)
            };
            flpList.Controls.Add(pnlwh);
            namePnl = pnlwh.Name;
            countPnl += 1;

            code = new Label();
            name = new Label();
            edit = new Button();
            delete = new Button();

            DataTable dt2 = new DataTable();

            sql = "SELECT * from `category`";
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                int datacount = flpList.Controls.Count;
                //MessageBox.Show(Convert.ToString(datacount));
                for (int i = 0; i < datacount; i++)
                {
                    code.AutoSize = false;
                    code.Size = new Size(90, 34);
                    code.Location = new Point(16, 8);
                    code.Font = new Font("Segoe UI", 12);
                    code.ForeColor = Color.Black;
                    code.Text = Convert.ToString(dt2.Rows[i]["id"]);
                    code.TextAlign = ContentAlignment.MiddleLeft;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(code);
                        }
                    }

                    name.AutoSize = false;
                    name.Size = new Size(267, 34);
                    name.Location = new Point(158, 8);
                    name.Font = new Font("Segoe UI", 12);
                    name.ForeColor = Color.Black;
                    name.Text = Convert.ToString(dt2.Rows[i]["name"]);
                    name.TextAlign = ContentAlignment.MiddleLeft;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(name);
                        }
                    }

                    edit.Size = new Size(33, 33);
                    edit.Location = new Point(446, 8);
                    edit.BackgroundImage = Properties.Resources.edit5;
                    edit.BackgroundImageLayout = ImageLayout.Center;
                    edit.FlatStyle = FlatStyle.Flat;
                    edit.FlatAppearance.BorderSize = 0;
                    edit.Name = "btn" + (countPnl);
                    edit.Tag = dt2.Rows[i]["id"];
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
                    delete.Location = new Point(499, 8);
                    delete.BackgroundImage = Properties.Resources.del2;
                    delete.BackgroundImageLayout = ImageLayout.Center;
                    delete.FlatStyle = FlatStyle.Flat;
                    delete.FlatAppearance.BorderSize = 0;
                    delete.Name = "btn" + (countPnl);
                    delete.Tag = dt2.Rows[i]["id"];
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

        public void items2()
        {
            DataTable dt1 = new DataTable();

            pnl1 = new Panel()
            {
                Size = new Size(552, 50),
                Location = new Point(0, 0),
                Margin = new Padding(0, 0, 0, 5),
                BackColor = Color.WhiteSmoke,
                Name = "pnl" + (countPnl + 1)
            };
            flp1.Controls.Add(pnl1);
            namePnl1 = pnl1.Name;
            countPnl1 += 1;

            code1 = new Label();
            name1 = new Label();
            unit = new Label();
            edit1 = new Button();
            delete1 = new Button();


            sql = "SELECT * FROM `unit`";
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                int datacount = flp1.Controls.Count;
                //MessageBox.Show(Convert.ToString(datacount));
                for (int i = 0; i < datacount; i++)
                {
                    code1.AutoSize = false;
                    code1.Size = new Size(90, 34);
                    code1.Location = new Point(16, 8);
                    code1.Font = new Font("Segoe UI", 12);
                    code1.ForeColor = Color.Black;
                    code1.Text = Convert.ToString(dt1.Rows[i]["id"]);
                    code1.TextAlign = ContentAlignment.MiddleLeft;
                    foreach (Control c1 in flp1.Controls)
                    {
                        if (c1.Name == namePnl1)
                        {
                            c1.Controls.Add(code1);
                        }
                    }

                    name1.AutoSize = false;
                    name1.Size = new Size(156, 34);
                    name1.Location = new Point(127, 8);
                    name1.Font = new Font("Segoe UI", 12);
                    name1.ForeColor = Color.Black;
                    name1.Text = Convert.ToString(dt1.Rows[i]["unit_name"]);
                    name1.TextAlign = ContentAlignment.MiddleLeft;
                    foreach (Control c1 in flp1.Controls)
                    {
                        if (c1.Name == namePnl1)
                        {
                            c1.Controls.Add(name1);
                        }
                    }

                    unit.AutoSize = false;
                    unit.Size = new Size(100, 34);
                    unit.Location = new Point(308, 8);
                    unit.Font = new Font("Segoe UI", 12);
                    unit.ForeColor = Color.Black;
                    unit.Text = Convert.ToString(dt1.Rows[i]["unit"]);
                    unit.TextAlign = ContentAlignment.MiddleLeft;
                    foreach (Control c1 in flp1.Controls)
                    {
                        if (c1.Name == namePnl1)
                        {
                            c1.Controls.Add(unit);
                        }
                    }

                    edit1.Size = new Size(33, 33);
                    edit1.Location = new Point(446, 8);
                    edit1.BackgroundImage = Properties.Resources.edit5;
                    edit1.BackgroundImageLayout = ImageLayout.Center;
                    edit1.FlatStyle = FlatStyle.Flat;
                    edit1.FlatAppearance.BorderSize = 0;
                    edit1.Name = "btn" + (countPnl);
                    edit1.Tag = dt1.Rows[i]["id"];
                    edit1.Cursor = Cursors.Hand;
                    edit1.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
                    edit1.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
                    foreach (Control c1 in flp1.Controls)
                    {
                        if (c1.Name == namePnl1)
                        {
                            c1.Controls.Add(edit1);
                        }
                    }

                    delete1.Size = new Size(33, 33);
                    delete1.Location = new Point(499, 8);
                    delete1.BackgroundImage = Properties.Resources.del2;
                    delete1.BackgroundImageLayout = ImageLayout.Center;
                    delete1.FlatStyle = FlatStyle.Flat;
                    delete1.FlatAppearance.BorderSize = 0;
                    delete1.Name = "btn" + (countPnl);
                    delete1.Tag = dt1.Rows[i]["id"];
                    delete1.Cursor = Cursors.Hand;
                    delete1.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
                    delete1.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
                    foreach (Control c1 in flp1.Controls)
                    {
                        if (c1.Name == namePnl1)
                        {
                            c1.Controls.Add(delete1);
                        }
                    }
                }
            }
            edit1.Click += new EventHandler(this.edit1_click);
            delete1.Click += new EventHandler(this.delete1_click);
        }

        public void searchedItem()
        {
            pnlwh = new Panel()
            {
                Size = new Size(552, 50),
                Location = new Point(0, 0),
                Margin = new Padding(0, 0, 0, 5),
                BackColor = Color.WhiteSmoke,
                Name = "pnl" + (countPnl + 1)
            };
            flpList.Controls.Add(pnlwh);
            namePnl = pnlwh.Name;
            countPnl += 1;

            code = new Label();
            name = new Label();
            edit = new Button();
            delete = new Button();

            DataTable dt2 = new DataTable();

            sql = "SELECT * from `category` where id = '" + txtSearch.Text + "' || name = '" + txtSearch.Text + "'";
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {
                int datacount = flpList.Controls.Count;
                for (int i = 0; i <= datacount; i++)
                {
                    code.AutoSize = false;
                    code.Size = new Size(90, 34);
                    code.Location = new Point(16, 8);
                    code.Font = new Font("Segoe UI", 12);
                    code.ForeColor = Color.Black;
                    code.Text = Convert.ToString(dt2.Rows[i]["id"]);
                    
                    code.TextAlign = ContentAlignment.MiddleLeft;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(code);
                        }
                    }

                    name.AutoSize = false;
                    name.Size = new Size(267, 34);
                    name.Location = new Point(158, 8);
                    name.Font = new Font("Segoe UI", 12);
                    name.ForeColor = Color.Black;
                    name.Text = Convert.ToString(dt2.Rows[i]["name"]);
                    name.TextAlign = ContentAlignment.MiddleLeft;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(name);
                        }
                    }

                    edit.Size = new Size(33, 33);
                    edit.Location = new Point(446, 8);
                    edit.BackgroundImage = Properties.Resources.edit5;
                    edit.BackgroundImageLayout = ImageLayout.Center;
                    edit.FlatStyle = FlatStyle.Flat;
                    edit.FlatAppearance.BorderSize = 0;
                    edit.Name = "btn" + (countPnl);
                    edit.Tag = dt2.Rows[i]["id"];
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
                    delete.Location = new Point(499, 8);
                    delete.BackgroundImage = Properties.Resources.del2;
                    delete.BackgroundImageLayout = ImageLayout.Center;
                    delete.FlatStyle = FlatStyle.Flat;
                    delete.FlatAppearance.BorderSize = 0;
                    delete.Name = "btn" + (countPnl);
                    delete.Tag = dt2.Rows[i]["id"];
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

        public void searchedItem2()
        {
            DataTable dt1 = new DataTable();

            pnl1 = new Panel()
            {
                Size = new Size(552, 50),
                Location = new Point(0, 0),
                Margin = new Padding(0, 0, 0, 5),
                BackColor = Color.WhiteSmoke,
                Name = "pnl" + (countPnl + 1)
            };
            flp1.Controls.Add(pnl1);
            namePnl1 = pnl1.Name;
            countPnl1 += 1;

            code1 = new Label();
            name1 = new Label();
            unit = new Label();
            edit1 = new Button();
            delete1 = new Button();


            sql = "SELECT * FROM `unit` where id = '" + txtSearch2.Text + "' || unit_name = '" + txtSearch2.Text + "' || unit = '" + txtSearch2.Text + "'";
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                int datacount = flp1.Controls.Count;
                //MessageBox.Show(Convert.ToString(datacount));
                for (int i = 0; i < datacount; i++)
                {
                    code1.AutoSize = false;
                    code1.Size = new Size(90, 34);
                    code1.Location = new Point(16, 8);
                    code1.Font = new Font("Segoe UI", 12);
                    code1.ForeColor = Color.Black;
                    code1.Text = Convert.ToString(dt1.Rows[i]["id"]);
                    code1.TextAlign = ContentAlignment.MiddleLeft;
                    foreach (Control c1 in flp1.Controls)
                    {
                        if (c1.Name == namePnl1)
                        {
                            c1.Controls.Add(code1);
                        }
                    }

                    name1.AutoSize = false;
                    name1.Size = new Size(156, 34);
                    name1.Location = new Point(127, 8);
                    name1.Font = new Font("Segoe UI", 12);
                    name1.ForeColor = Color.Black;
                    name1.Text = Convert.ToString(dt1.Rows[i]["unit_name"]);
                    name1.TextAlign = ContentAlignment.MiddleLeft;
                    foreach (Control c1 in flp1.Controls)
                    {
                        if (c1.Name == namePnl1)
                        {
                            c1.Controls.Add(name1);
                        }
                    }

                    unit.AutoSize = false;
                    unit.Size = new Size(100, 34);
                    unit.Location = new Point(308, 8);
                    unit.Font = new Font("Segoe UI", 12);
                    unit.ForeColor = Color.Black;
                    unit.Text = Convert.ToString(dt1.Rows[i]["unit"]);
                    unit.TextAlign = ContentAlignment.MiddleLeft;
                    foreach (Control c1 in flp1.Controls)
                    {
                        if (c1.Name == namePnl1)
                        {
                            c1.Controls.Add(unit);
                        }
                    }

                    edit1.Size = new Size(33, 33);
                    edit1.Location = new Point(446, 8);
                    edit1.BackgroundImage = Properties.Resources.edit5;
                    edit1.BackgroundImageLayout = ImageLayout.Center;
                    edit1.FlatStyle = FlatStyle.Flat;
                    edit1.FlatAppearance.BorderSize = 0;
                    edit1.Name = "btn" + (countPnl);
                    edit1.Tag = dt1.Rows[i]["id"];
                    edit1.Cursor = Cursors.Hand;
                    edit1.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
                    edit1.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
                    foreach (Control c1 in flp1.Controls)
                    {
                        if (c1.Name == namePnl1)
                        {
                            c1.Controls.Add(edit1);
                        }
                    }

                    delete1.Size = new Size(33, 33);
                    delete1.Location = new Point(499, 8);
                    delete1.BackgroundImage = Properties.Resources.del2;
                    delete1.BackgroundImageLayout = ImageLayout.Center;
                    delete1.FlatStyle = FlatStyle.Flat;
                    delete1.FlatAppearance.BorderSize = 0;
                    delete1.Name = "btn" + (countPnl);
                    delete1.Tag = dt1.Rows[i]["id"];
                    delete1.Cursor = Cursors.Hand;
                    delete1.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
                    delete1.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
                    foreach (Control c1 in flp1.Controls)
                    {
                        if (c1.Name == namePnl1)
                        {
                            c1.Controls.Add(delete1);
                        }
                    }
                }
            }
            edit1.Click += new EventHandler(this.edit1_click);
            delete1.Click += new EventHandler(this.delete1_click);
        }


        void edit_click(object sender, EventArgs e)
        {
            {
                if (Application.OpenForms.OfType<CategoryEdit>().Count() == 1)
                    Application.OpenForms.OfType<CategoryEdit>().First().Close();

                var a = (sender as Button).Tag;
                string g = Convert.ToString(a);

                CategoryEdit cat = new CategoryEdit();
                cat.label1.Text = g;
                cat.Show();
            }
        }

        void edit1_click(object sender, EventArgs e)
        {
            {
                if (Application.OpenForms.OfType<CategoryUnitEdit>().Count() == 1)
                    Application.OpenForms.OfType<CategoryUnitEdit>().First().Close();

                var a = (sender as Button).Tag;
                string g = Convert.ToString(a);

                CategoryUnitEdit unit = new CategoryUnitEdit();
                unit.label1.Text = g;
                unit.Show();
            }
        }

        void delete_click(object sender, EventArgs e)
        {
            var a = (sender as Button).Tag;
            string g = Convert.ToString(a);

            DialogResult dial = MessageBox.Show("Are you sure you want to delete this item?", "Delete", MessageBoxButtons.YesNo);
            if (dial == DialogResult.Yes)
            {
                sql = "DELETE FROM `category` WHERE id = '" + g + "'";
                cmd = new MySqlCommand(sql, conn);
                result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Data Deleted");
                    Form1 fr = new Form1();
                    fr.Show();
                    fr.btnCat.PerformClick();
                }
            }
        }

        void delete1_click(object sender, EventArgs e)
        {
            {
                var a = (sender as Button).Tag;
                string g = Convert.ToString(a);

                DialogResult dial = MessageBox.Show("Are you sure you want to delete this item?", "Delete", MessageBoxButtons.YesNo);
                if (dial == DialogResult.Yes)
                {
                    sql = "DELETE FROM `unit` WHERE id = '" + g + "'";
                    cmd = new MySqlCommand(sql, conn);
                    result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Data Deleted");
                        Form1 mast = (Form1)Application.OpenForms["Form1"];
                        mast.btnCat.PerformClick();
                        this.Close();
                    }
                }
            }
        }

            private void btnAddCat_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<CategoryAdd>().Count() == 1)
                Application.OpenForms.OfType<CategoryAdd>().First().Close();

            CategoryAdd catadd = new CategoryAdd();
            catadd.Show();
        }
    }
}
