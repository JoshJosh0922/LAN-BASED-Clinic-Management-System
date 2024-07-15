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
    public partial class CategoryUnitEdit : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter da = new MySqlDataAdapter();
        MySqlDataReader dr;
        DataTable dt = new DataTable();
        string sql;
        int result;

        public CategoryUnitEdit()
        {
            InitializeComponent();
        }

        private void CategoryUnitEdit_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user id=root;password=;database=nclinic1;sslMode=none";
            conn.Close();
            conn.Open();

            sql = "SELECT * FROM `unit` WHERE id = '" + label1.Text + "'";
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtCode.Text = Convert.ToString(dt.Rows[0]["unit"]);
                txtName.Text = Convert.ToString(dt.Rows[0]["unit_name"]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dial = MessageBox.Show("Are you sure you want to cancel?", "Cancel", MessageBoxButtons.YesNo);
            if (dial == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            sql = "UPDATE `unit` SET `unit_name`='" + txtName.Text + "',`unit`='" + txtCode.Text + "' where id = '" + label1.Text + "'";
            cmd = new MySqlCommand(sql, conn);
            result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("Updated Successfully!");
                Form1 mast = (Form1)Application.OpenForms["Form1"];
                mast.btnCat.PerformClick();
                this.Close();
            }
        }
    }
}
