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

namespace NewClinic.MainForm
{
    public partial class Archive : Form
    {
        public static string query = "Select * from tblarchive", querybilang = "Select count(id) from tblarchive";

        public Archive()
        {
            InitializeComponent();
        }

        private void Archive_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        void loaddata()
        {
            flparchive.Controls.Clear();

            clinic.conn.Open();
            MySqlCommand bilang = new MySqlCommand(querybilang, clinic.conn);
            int coutn = Convert.ToInt32(bilang.ExecuteScalar());

            MySqlCommand cmd = new MySqlCommand(query, clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            ControlArchive.listarchive[] vp = new ControlArchive.listarchive[coutn];

            for (int i = 0; i < coutn; i++)
            {
                if (dr.Read())
                {
                    vp[i] = new ControlArchive.listarchive();
                    vp[i].lblid.Text = dr[1].ToString();
                    if (dr[5].ToString() != "")
                    {
                        vp[i].lblname.Text = dr[4].ToString() + ", " + dr[2].ToString() + " " + dr[3].ToString() + ". " + dr[5].ToString() + "."; 
                    }
                    else if(dr[3].ToString() != "")
                    {
                        vp[i].lblname.Text = dr[4].ToString() + ", " + dr[2].ToString() + " " + dr[3].ToString() + ". ";
                    }
                    else
                    {
                        vp[i].lblname.Text = dr[4].ToString() + ", " + dr[2].ToString() + " ";
                    }

                    vp[i].lblgender.Text = dr[6].ToString();
                    vp[i].agecal(dr[8].ToString());
                    vp[i].lbltype.Text = dr[14].ToString();
                    vp[i].btndel.Click += new EventHandler(reload);
                    vp[i].btnrestore.Click += new EventHandler(reload);

                    if (flparchive.Controls.Count < 0)
                    {
                        flparchive.Controls.Clear();
                    }
                    else
                        flparchive.Controls.Add(vp[i]);
                }
            }

            if (coutn == 0)
            {
                Label lb = new Label();
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.Text = "No Record Yet";
                lb.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lb.ForeColor = Color.DarkGray;
                lb.BringToFront();
                lb.Dock = DockStyle.Fill;
                pcontainer.Controls.Add(lb);
                flparchive.Visible = false;
            }
            clinic.conn.Close();
        }

        void reload(object sender, EventArgs e)
        {
            Archive_Load(sender, e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            fetch(textBox1.Text);
        }

        void fetch(String search)
        {
            if (search != "")
            {
                query = "Select * from tblarchive where Person_id like '" + search + "%' or lname like '" + search + "%' or fname like '" + search + "%'";
                querybilang = "Select count(id) from tblarchive where Person_id like '" + search + "%' or lname like '" + search + "%' or fname like '" + search + "%'";
                loaddata();
            }
            else
            {
                query = "Select * from tblarchive";
                querybilang = "Select count(id) from tblarchive";
                loaddata();
            }
           
        }
    }
}
