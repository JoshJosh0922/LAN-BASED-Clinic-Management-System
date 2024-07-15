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

namespace NewClinic.ControlLogbook
{
    public partial class insertmed : UserControl
    {
        public String med = "", stock = "", id = "", expdate = "";
        public string ammount = "", sta = "", consumed = "";
        public static String idno = Arrive.id;
        public insertmed()
        {
            InitializeComponent();
        }

        private void insertmed_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        void loaddata()
        {
            clinic.conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("Select distinct(uniqueproductlist.name) from uniqueproductlist INNER JOIN productstocks where uniqueproductlist.code = productstocks.code and productstocks.stocks >= 1 GROUP by productstocks.code desc", clinic.conn);
            DataTable dt1 = new DataTable();

            cbmed.DisplayMember = "name";
            da.Fill(dt1);
            cbmed.DataSource = dt1;
            cbmed.SelectedIndex = -1;
            clinic.conn.Close();
        }

        private void cbmed_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbmed.Text != "")
            {
                med = cbmed.Text;
                getd(cbmed.Text);
                txtamount_TextChanged(sender, e);
                txtamount.Text = 1 + "";
            }
        }

        void getd(String name)
        {
            clinic.conn.Open();
            MySqlCommand cmd = new MySqlCommand("Select uniqueproductlist.name, uniqueproductlist.unit, uniqueproductlist.category, productstocks.expiry_date, productstocks.stocks,  productstocks.code, productstocks.consumed from uniqueproductlist INNER JOIN productstocks where uniqueproductlist.code = productstocks.code and uniqueproductlist.name = '" + name + "' and productstocks.stocks > 0 ORDER by productstocks.expiry_date ASC limit 1", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                btnInc.Enabled = true;
                btnDec.Enabled = true;
                txtamount.ReadOnly = false;
                txtmessur.Text = dr[1].ToString();
                txtype.Text = dr[2].ToString();
                txtstocks.Text = dr[4].ToString();
                stock = dr[4].ToString();
                id = dr[5].ToString();
                consumed = dr[6].ToString();
                expdate = dr[3].ToString();
            }

            clinic.conn.Close();
        }

        private void txtbp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void btnInc_Click(object sender, EventArgs e)
        {
            if (txtamount.Text == "")
            {
                txtamount.Text = "1";
            }
            else
            {
                if (Convert.ToInt32(txtstocks.Text) > 0)
                {
                    double a = 1;
                    double b = Convert.ToInt32(txtamount.Text);
                    double c = b + a;
                    txtamount.Text = Convert.ToString(c);
                }
            }
        }

        private void btnDec_Click(object sender, EventArgs e)
        {
            if (txtamount.Text != "")
            {
                double a = 1;
                double b = Convert.ToInt32(txtamount.Text);
                if (b >= a)
                {
                    double c = b - a;
                    txtamount.Text = Convert.ToString(c);
                }
            }

        }
        private void txtamount_TextChanged(object sender, EventArgs e)
        {
            if (txtamount.Text != "")
            {
                if (Convert.ToDouble(txtamount.Text) > Convert.ToDouble(stock))
                {
                    MessageBox.Show("There is no more stock!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtamount.Text = "0";
                }
                else
                {
                    if (txtamount.Text == "0")
                    {
                        txtstocks.Text = stock;
                    }
                    else if (txtamount.Text != "")
                    {
                        double res = double.Parse(stock) - double.Parse(txtamount.Text);
                        if (res >= 0)
                        {
                            txtstocks.Text = res.ToString();
                            ammount = txtamount.Text;
                        }
                        else
                        {
                            txtstocks.Text = 0 + "";
                        }
                    }
                    else
                    {
                        txtstocks.Text = stock;
                    }
                }
            }
        }

        private void txtstocks_TextChanged(object sender, EventArgs e)
        {
            sta = txtstocks.Text;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Parse(expdate);

            //lblbdate.Text = dt.ToString("MMMM dd, yyyy");

            MessageBox.Show(txtamount.Text + " " + stock + " " + id + " " + dt.ToString("yyyy-MM-dd"));
        }

        private void iconButton1_MouseEnter(object sender, EventArgs e)
        {
            iconButton1.IconColor = Color.LightCoral;
            iconButton1.IconSize = 35;
        }

        private void iconButton1_MouseLeave(object sender, EventArgs e)
        {
            iconButton1.IconColor = Color.Firebrick;
            iconButton1.IconSize = 30;
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Dispose();
        }

        public void saved(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Parse(expdate.ToString());
            clinic.conn.Open();

            int con = Convert.ToInt32(consumed) + Convert.ToInt32(txtamount.Text);

            MySqlCommand cmd = new MySqlCommand("Insert into tblpatient_med values('" + "" + "','" + idno + "','" + med + "','" + DateTime.Today.ToShortDateString() + "','" + txtamount.Text + "','" + txtstocks.Text + "','" + dt.ToString("yyyy-MM-dd") + "','" + id + "','')", clinic.conn);
            cmd.ExecuteNonQuery();


            MySqlCommand cmd1 = new MySqlCommand("Update productstocks set consumed = '" + con + "', stocks = '" + sta + "' where  code = '" + id + "' and expiry_date = '" + dt.ToString("yyyy-MM-dd") + "'", clinic.conn);
            cmd1.ExecuteNonQuery();

            //MessageBox.Show("Successfuly Save", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clinic.conn.Close();
        }

    }
}
