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
using FontAwesome.Sharp;


namespace inventory
{
    public partial class List : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter da = new MySqlDataAdapter();
        MySqlDataReader dr;
        DataTable dt = new DataTable();
        string sql;
        int result;

        CheckBox chk;
        Button btndrop, btnEdit, delete;

        Panel pnl, pnlStatus;
        string namePnl;
        int countPnl;

        Label nodata, code, nameNunit, category, batch, consumed, stock, expiry;

        Button bt = new Button();
        public static IconButton btn = new IconButton();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (pnlAdd.Visible == false)
            {
                pnlAdd.Visible = true;
            }
            else if (pnlAdd.Visible == true)
            {
                pnlAdd.Visible = false;
            }
        }

        void activeButton(object sender)
        {
            if (sender != null)
            {
                if (btn != (IconButton)sender || btn == (IconButton)sender)
                {
                    disable();
                    btn = (IconButton)sender;
                    btn.BackColor = Color.FromArgb(40, 80, 150);
                    btn.FlatAppearance.BorderColor = Color.White;
                    show(btn.Name);
                }
            }
        }

        void disable()
        {
            if (btn != null)
            {
                btn.BackColor = Color.FromArgb(40, 97, 150);
                btn.FlatAppearance.BorderColor = Color.White;
            }
        }
        void show(object sender)
        {
            switch (sender)
            {
                case "iconButton2":
                    if (Application.OpenForms.OfType<ListAddProduct>().Count() == 1)
                        Application.OpenForms.OfType<ListAddProduct>().First().Close();

                    if (Application.OpenForms.OfType<ListAddNewProduct>().Count() == 1)
                        Application.OpenForms.OfType<ListAddNewProduct>().First().Close();

                    ListAddProduct addProd = new ListAddProduct();
                    addProd.Show();
                    addProd.Focus();
                    //(this.Owner as Main).Enable = false;
                    addProd.Closed += new EventHandler(able);
                    break;
                case "iconButton3":
                    if (Application.OpenForms.OfType<ListAddNewProduct>().Count() == 1)
                        Application.OpenForms.OfType<ListAddNewProduct>().First().Close();

                    if (Application.OpenForms.OfType<ListAddProduct>().Count() == 1)
                        Application.OpenForms.OfType<ListAddProduct>().First().Close();

                    ListAddNewProduct addNew = new ListAddNewProduct();
                    addNew.Show();
                    addNew.Focus();
                    //(this.Owner as Main).Enable = false;
                    addNew.Closed += new EventHandler(able);
                    break;

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                List_Load(sender, e);
            }
        }

        void able(object sender, EventArgs e)
        {
            disable();
            pnlAdd.Visible = false;

            //(this.Owner as Main).Enable = true;
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            activeButton(sender);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            activeButton(sender);
        }


        public List()
        {
            InitializeComponent();
        }

        private void List_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user id=root;password=;database=nclinic1;sslMode=none";
            conn.Close();
            conn.Open();

            sql = "select count(*) as counts from `uniqueproductlist`";
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

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                flpList.Controls.Clear();
                sql = "SELECT count(id) as count FROM `uniqueproductlist` where code = '" + txtSearch.Text + "' || name = '" + txtSearch.Text + "' || category = '" + txtSearch.Text + "'";
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

        public void items()
        {
            pnl = new Panel()
            {
                Size = new Size(1453, 54),
                Location = new Point(0, 0),
                BackColor = Color.WhiteSmoke,
                Name = "pnl" + (countPnl + 1)
            };
            flpList.Controls.Add(pnl);
            namePnl = pnl.Name;
            countPnl += 1;

            btndrop = new Button();
            chk = new CheckBox();
            nameNunit = new Label();
            code = new Label();
            batch = new Label();
            category = new Label();
            consumed = new Label();
            stock = new Label();
            expiry = new Label();
            btnEdit = new Button();
            delete = new Button();

            DataTable dt1 = new DataTable();
            sql = "SELECT COUNT(t2.code) as counts, t1.code, t1.name, t1.unit, t1.category, t2.batch, sum(t2.consumed) as totalconsumed, SUM(t2.stocks) as totalstocks, DATE_FORMAT(t2.expiry_date, '%b %e, %Y') as expiry FROM uniqueproductlist as t1 LEFT join productstocks as t2 on t1.code = t2.code group by t1.code order by t1.id";
            //sql = "select *, count(*) as count from uniqueproductlist";
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                int datacount = flpList.Controls.Count;
                // MessageBox.Show(Convert.ToString(datacount));
                for (int i = 0; i < datacount; i++)
                {
                    nameNunit.AutoSize = false;
                    nameNunit.Size = new Size(221, 34);
                    nameNunit.Location = new Point(37, 10);
                    nameNunit.Font = new Font("Segoe UI Variable", 10);
                    nameNunit.ForeColor = Color.Black;
                    nameNunit.Text = Convert.ToString(dt1.Rows[i]["name"]) + " " + Convert.ToString(dt1.Rows[i]["unit"]);
                    nameNunit.TextAlign = ContentAlignment.MiddleLeft;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(nameNunit);
                        }
                    }

                    code.AutoSize = false;
                    code.Size = new Size(115, 34);
                    code.Location = new Point(288, 10);
                    code.Font = new Font("Segoe UI Variable", 10);
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

                    batch.AutoSize = false;
                    batch.Size = new Size(100, 34);
                    batch.Location = new Point(491, 10);
                    batch.Font = new Font("Segoe UI Variable", 10);
                    batch.ForeColor = Color.Black;
                    batch.Text = Convert.ToString(dt1.Rows[i]["batch"]);
                    batch.TextAlign = ContentAlignment.MiddleLeft;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(batch);
                        }
                    }

                    category.AutoSize = false;
                    category.Size = new Size(157, 34);
                    category.Location = new Point(644, 10);
                    category.Font = new Font("Segoe UI Variable", 10);
                    category.ForeColor = Color.Black;
                    category.Text = Convert.ToString(dt1.Rows[i]["category"]);
                    category.TextAlign = ContentAlignment.MiddleCenter;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(category);
                        }
                    }


                    consumed.AutoSize = false;
                    consumed.Size = new Size(68, 34);
                    consumed.Location = new Point(877, 10);
                    consumed.Font = new Font("Segoe UI Variable", 10);
                    consumed.ForeColor = Color.Black;
                    consumed.Text = Convert.ToString(dt1.Rows[i]["totalconsumed"]);
                    consumed.TextAlign = ContentAlignment.MiddleCenter;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(consumed);
                        }
                    }

                    stock.AutoSize = false;
                    stock.Size = new Size(68, 34);
                    stock.Location = new Point(1040, 10);
                    stock.Font = new Font("Segoe UI Variable", 10);
                    stock.ForeColor = Color.Black;
                    stock.Text = Convert.ToString(dt1.Rows[i]["totalstocks"]);
                    stock.TextAlign = ContentAlignment.MiddleCenter;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(stock);
                        }
                    }

                    expiry.AutoSize = false;
                    expiry.Size = new Size(144, 34);
                    expiry.Location = new Point(1162, 13);
                    expiry.Font = new Font("Segoe UI Variable", 10);
                    expiry.ForeColor = Color.Black;
                    expiry.Text = Convert.ToString(dt1.Rows[i]["expiry"]);
                    expiry.TextAlign = ContentAlignment.MiddleCenter;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(expiry);
                        }
                    }

                    btnEdit.Size = new Size(33, 33);
                    btnEdit.Location = new Point(1324, 13);
                    btnEdit.BackgroundImage = Properties.Resources.edit5;
                    btnEdit.BackgroundImageLayout = ImageLayout.Center;
                    btnEdit.FlatStyle = FlatStyle.Flat;
                    btnEdit.FlatAppearance.BorderSize = 0;
                    btnEdit.Name = "btn" + (countPnl);
                    btnEdit.Tag = dt1.Rows[i]["code"];
                    btnEdit.Cursor = Cursors.Hand;
                    btnEdit.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
                    btnEdit.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(btnEdit);
                        }
                    }

                    delete.Size = new Size(33, 33);
                    delete.Location = new Point(1396, 10);
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
            btnEdit.Click += new EventHandler(this.btnEdit_Click);
            delete.Click += new EventHandler(this.delete_click);
        }

        public void searchedItem()
        {
            pnl = new Panel()
            {
                Size = new Size(1453, 54),
                Location = new Point(0, 0),
                BackColor = Color.WhiteSmoke,
                Name = "pnl" + (countPnl + 1)
            };
            flpList.Controls.Add(pnl);
            namePnl = pnl.Name;
            countPnl += 1;

            btndrop = new Button();
            chk = new CheckBox();
            nameNunit = new Label();
            code = new Label();
            batch = new Label();
            category = new Label();
            consumed = new Label();
            stock = new Label();
            expiry = new Label();
            btnEdit = new Button();
            delete = new Button();

            DataTable dt1 = new DataTable();

            sql = "Select uniqueproductlist.code, uniqueproductlist.name, uniqueproductlist.unit, uniqueproductlist.category, productstocks.batch, sum(productstocks.consumed) as totalconsumed, SUM(productstocks.stocks) as totalstocks, DATE_FORMAT(productstocks.expiry_date, '%b %e, %Y') as expiry from productstocks INNER JOIN uniqueproductlist on productstocks.code = uniqueproductlist.code where uniqueproductlist.code = '" + txtSearch.Text + "' || uniqueproductlist.name = '" + txtSearch.Text + "' || uniqueproductlist.category = '" + txtSearch.Text + "' group by uniqueproductlist.code order by uniqueproductlist.id";
            //sql = "select *, count(*) as count from uniqueproductlist";
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                int datacount = flpList.Controls.Count;
                // MessageBox.Show(Convert.ToString(datacount));
                for (int i = 0; i < datacount; i++)
                {
                    nameNunit.AutoSize = false;
                    nameNunit.Size = new Size(221, 34);
                    nameNunit.Location = new Point(37, 10);
                    nameNunit.Font = new Font("Segoe UI Variable", 10);
                    nameNunit.ForeColor = Color.Black;
                    nameNunit.Text = Convert.ToString(dt1.Rows[i]["name"]) + " " + Convert.ToString(dt1.Rows[i]["unit"]);
                    nameNunit.TextAlign = ContentAlignment.MiddleLeft;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(nameNunit);
                        }
                    }

                    code.AutoSize = false;
                    code.Size = new Size(115, 34);
                    code.Location = new Point(288, 10);
                    code.Font = new Font("Segoe UI Variable", 10);
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

                    batch.AutoSize = false;
                    batch.Size = new Size(100, 34);
                    batch.Location = new Point(491, 10);
                    batch.Font = new Font("Segoe UI Variable", 10);
                    batch.ForeColor = Color.Black;
                    batch.Text = Convert.ToString(dt1.Rows[i]["batch"]);
                    batch.TextAlign = ContentAlignment.MiddleLeft;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(batch);
                        }
                    }

                    category.AutoSize = false;
                    category.Size = new Size(157, 34);
                    category.Location = new Point(644, 10);
                    category.Font = new Font("Segoe UI Variable", 10);
                    category.ForeColor = Color.Black;
                    category.Text = Convert.ToString(dt1.Rows[i]["category"]);
                    category.TextAlign = ContentAlignment.MiddleCenter;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(category);
                        }
                    }


                    consumed.AutoSize = false;
                    consumed.Size = new Size(68, 34);
                    consumed.Location = new Point(877, 10);
                    consumed.Font = new Font("Segoe UI Variable", 10);
                    consumed.ForeColor = Color.Black;
                    consumed.Text = Convert.ToString(dt1.Rows[i]["totalconsumed"]);
                    consumed.TextAlign = ContentAlignment.MiddleCenter;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(consumed);
                        }
                    }

                    stock.AutoSize = false;
                    stock.Size = new Size(68, 34);
                    stock.Location = new Point(1040, 10);
                    stock.Font = new Font("Segoe UI Variable", 10);
                    stock.ForeColor = Color.Black;
                    stock.Text = Convert.ToString(dt1.Rows[i]["totalstocks"]);
                    stock.TextAlign = ContentAlignment.MiddleCenter;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(stock);
                        }
                    }

                    expiry.AutoSize = false;
                    expiry.Size = new Size(144, 34);
                    expiry.Location = new Point(1162, 13);
                    expiry.Font = new Font("Segoe UI Variable", 10);
                    expiry.ForeColor = Color.Black;
                    expiry.Text = Convert.ToString(dt1.Rows[i]["expiry"]);
                    expiry.TextAlign = ContentAlignment.MiddleCenter;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(expiry);
                        }
                    }

                    btnEdit.Size = new Size(33, 33);
                    btnEdit.Location = new Point(1324, 13);
                    btnEdit.BackgroundImage = Properties.Resources.edit5;
                    btnEdit.BackgroundImageLayout = ImageLayout.Center;
                    btnEdit.FlatStyle = FlatStyle.Flat;
                    btnEdit.FlatAppearance.BorderSize = 0;
                    btnEdit.Name = "btn" + (countPnl);
                    btnEdit.Tag = dt1.Rows[i]["code"];
                    btnEdit.Cursor = Cursors.Hand;
                    btnEdit.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
                    btnEdit.FlatAppearance.MouseDownBackColor = Color.Gainsboro;
                    foreach (Control c1 in flpList.Controls)
                    {
                        if (c1.Name == namePnl)
                        {
                            c1.Controls.Add(btnEdit);
                        }
                    }

                    delete.Size = new Size(33, 33);
                    delete.Location = new Point(1396, 10);
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
            btnEdit.Click += new EventHandler(this.btnEdit_Click);
            delete.Click += new EventHandler(this.delete_click);
        }

        void btnEdit_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<ListEdit>().Count() == 1)
                Application.OpenForms.OfType<ListEdit>().First().Close();

            var a = (sender as Button).Tag;
            string g = Convert.ToString(a);

            ListEdit le = new ListEdit();
            le.txtCode.Text = g;
            //(this.Owner as Main).Enable = false;
            //le.Closed += new EventHandler(able);
            le.Show(this);
        }

        void delete_click(object sender, EventArgs e)
        {
            var a = (sender as Button).Tag;
            string g = Convert.ToString(a);

            DialogResult dial = MessageBox.Show("Are you sure you want to delete this item?", "Delete", MessageBoxButtons.YesNo);
            if (dial == DialogResult.Yes)
            {
                sql = "INSERT INTO `archiveuniqueproductlist` SELECT * from uniqueproductlist where code = '" + g + "'";
                cmd = new MySqlCommand(sql, conn);
                result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    sql = "DELETE FROM `uniqueproductlist` WHERE  code = '" + g + "'";
                    cmd = new MySqlCommand(sql, conn);
                    result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        //MessageBox.Show("Data Deleted");
                        //Form1 mast = (Form1)Application.OpenForms["Form1"];
                        //mast.btnList.PerformClick();
                        //this.Close();
                    }
                }

                sql = "INSERT INTO `archiveproductstocks` SELECT * from productstocks where code = '" + g + "'";
                cmd = new MySqlCommand(sql, conn);
                result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    sql = "DELETE FROM `productstocks` WHERE  code = '" + g + "'";
                    cmd = new MySqlCommand(sql, conn);
                    result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Data Deleted");
                        Inventory mast = (Inventory)Application.OpenForms["Inventory"];
                        mast.btnList.PerformClick();
                        this.Close();
                    }
                }
            }
        }

    }
}
