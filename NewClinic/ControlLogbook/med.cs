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
    public partial class med : UserControl
    {

        public med()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            del(lblid.Text);
            this.Controls.Clear();
            this.Dispose();
        }

        private void med_Load(object sender, EventArgs e)
        {

        }

        private void iconButton1_MouseEnter(object sender, EventArgs e)
        {
            iconButton1.IconColor = Color.LightCoral;
            iconButton1.IconSize = 30;
        }

        private void iconButton1_MouseLeave(object sender, EventArgs e)
        {
            iconButton1.IconColor = Color.Firebrick;
            iconButton1.IconSize = 25;
        }

        public void del(String id)
        {
            clinic.conn.Open();
           
            String ammount = "";
            int total;
            int stoc;

            MySqlCommand cmd2 = new MySqlCommand("Select productstocks.consumed from uniqueproductlist INNER JOIN productstocks where uniqueproductlist.code = productstocks.code and productstocks.code = '" + lblmedid.Text + "' and productstocks.expiry_date = '" + lblbatch.Text + "'", clinic.conn);
            MySqlDataReader dr = cmd2.ExecuteReader();

            if (dr.Read())
            {
                ammount = dr[0].ToString();
            }
            dr.Close();

            total = Convert.ToInt32(ammount) - Convert.ToInt32( lblamount.Text);
            stoc = Convert.ToInt32(lblstock.Text) + Convert.ToInt32(lblamount.Text);

            MySqlCommand cmd1 = new MySqlCommand("Update productstocks set consumed = '" + total + "', stocks = '" + stoc + "' where  code = '" + lblmedid.Text + "' and expiry_date = '" + lblbatch.Text + "'", clinic.conn);
            cmd1.ExecuteNonQuery();

            MySqlCommand cmd = new MySqlCommand("Delete from tblpatient_med where id = '" + id + "'", clinic.conn);
            cmd.ExecuteNonQuery();
            clinic.conn.Close();
        }
    }
}
