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

namespace NewClinic.ControlAccount
{
    public partial class listacc : Form
    {
        public static string bilangacc = "Select count(person_id) from tblacc WHERE not UserType = 'superadmin' and NOT UserType = 'Admin'";
        public static string acc = "Select * from tblacc WHERE not UserType = 'superadmin' and NOT UserType = 'Admin'";

        public listacc()
        {
            InitializeComponent();
        }

        private void listacc_Load(object sender, EventArgs e)
        {
            load();
        }

        void load()
        {
            flplist.Controls.Clear();
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }
            clinic.conn.Open();
            MySqlCommand cmd = new MySqlCommand(bilangacc, clinic.conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            cmd = new MySqlCommand(acc, clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            ControlAccount.lisacc[] ac = new lisacc[count];

            for (int i = 0; i < count; i++)
            {
                if (dr.Read())
                {
                    if (dr[6].ToString() != "Admin" | dr[6].ToString() != "Administration")
                    {
                        ac[i] = new lisacc();
                        ac[i].lblid.Text = dr[0].ToString();
                        ac[i].lblname.Text = dr[1].ToString();
                        ac[i].lblcontact.Text = dr[2].ToString();
                        ac[i].lblemail.Text = dr[3].ToString();
                        ac[i].lblusername.Text = dr[4].ToString();
                        ac[i].lblpass.Text = dr[5].ToString();
                        ac[i].lbltype.Text = dr[6].ToString();
                        ac[i].btnedit.Click += new EventHandler(showform);
                        ac[i].btndel.Click += new EventHandler(doable);

                        if (flplist.Controls.Count < 0)
                        {
                            flplist.Controls.Clear();
                        }
                        else
                            flplist.Controls.Add(ac[i]);
                    }
                }
            }

            clinic.conn.Close();
        }

        void showform(object sender, EventArgs e)
        {
            editacc ad = new editacc();
            this.Enabled = false;
            ad.Show();
            ad.Closed += new EventHandler(doable);
        }

        void doable(object sender, EventArgs e)
        {
            this.Enabled = true;
            load();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtsearch.Text != "")
            {
                bilangacc = "Select count(person_id) from tblacc where not UserType = 'superadmin' and NOT UserType = 'Admin' and person_id like '" + txtsearch.Text + "%' or not UserType = 'superadmin' and NOT UserType = 'Admin' and Full_name like '" + txtsearch.Text +"%'";
                acc = "Select * from tblacc where not UserType = 'superadmin' and NOT UserType = 'Admin' and person_id like '" + txtsearch.Text + "%' or not UserType = 'superadmin' and NOT UserType = 'Admin' and Full_name like '" + txtsearch.Text + "%'";
            }
            else
            {
                bilangacc = "Select count(person_id) from tblacc WHERE not UserType = 'superadmin' and NOT UserType = 'Admin'";
                acc = "Select * from tblacc WHERE not UserType = 'superadmin' and NOT UserType = 'Admin'";

    }
    load();
        }
    }
}
