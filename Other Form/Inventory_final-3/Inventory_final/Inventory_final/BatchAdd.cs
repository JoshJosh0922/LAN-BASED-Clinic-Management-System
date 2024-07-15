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
    public partial class BatchAdd : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter da = new MySqlDataAdapter();
        MySqlDataReader dr;
        DataTable dt = new DataTable();
        string sql;
        int result;

        public BatchAdd()
        {
            InitializeComponent();
        }

        private void BatchAdd_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user id=root;password=;database=nclinic1;sslMode=none";
            conn.Close();
            conn.Open();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtCode.Clear();
            txtName.Clear();
            txtDesc.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                var a = received.Value.Date.ToString("yyyy-MM-dd");
                var b = expiry.Value.Date.ToString("yyyy-MM-dd");
                sql = "INSERT INTO `batch`(`code`, `name`, `description`, `date_received`, `expiry_date`) VALUES ('" + txtCode.Text + "','" + txtName.Text + "','" + txtDesc.Text + "','" + a + "','" + b + "')";
                cmd = new MySqlCommand(sql, conn);
                result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Data Inserted");
                    Form1 mast = (Form1)Application.OpenForms["Form1"];
                    mast.btnBatch.PerformClick();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please fill al required fields.");
                }
            }
        }
    }
}
