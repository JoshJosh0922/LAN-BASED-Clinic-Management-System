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

namespace NewClinic.ControlReport
{
    public partial class viewreport : Form
    {
        public viewreport()
        {
            InitializeComponent();
        }

        private void viewreport_Load(object sender, EventArgs e)
        {
            clinic.conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("Select * from tblogbook", clinic.conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            clinic.conn.Close();
        }

    }
}
