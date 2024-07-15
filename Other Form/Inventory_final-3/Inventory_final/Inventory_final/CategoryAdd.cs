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
    public partial class CategoryAdd : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter da = new MySqlDataAdapter();
        MySqlDataReader dr;
        DataTable dt = new DataTable();
        string sql;
        int result;

        public CategoryAdd()
        {
            InitializeComponent();
        }


        private void CategoryAdd_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user id=root;password=;database=nclinic1;sslMode=none";
            conn.Close();
            conn.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtDesc.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                sql = "INSERT INTO `category`(`name`, `description`) VALUES  ('" + txtName.Text + "','" + txtDesc.Text + "')";
                cmd = new MySqlCommand(sql, conn);
                result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Data Inserted");
                    Form1 mast = (Form1)Application.OpenForms["Form1"];
                    mast.btnCat.PerformClick();
                    this.Close();
                }
            }
        }
    }
}
