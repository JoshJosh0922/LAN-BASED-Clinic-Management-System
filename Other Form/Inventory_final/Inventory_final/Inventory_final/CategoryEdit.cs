﻿using MySql.Data.MySqlClient;
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
    public partial class CategoryEdit : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter da = new MySqlDataAdapter();
        MySqlDataReader dr;
        DataTable dt = new DataTable();
        string sql;
        int result;

        public CategoryEdit()
        {
            InitializeComponent();
        }

        private void CategoryEdit_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user id=root;password=;database=inventory;sslMode=none";
            conn.Close();
            conn.Open();

            sql = "SELECT * FROM `category` WHERE id = '" + label1.Text + "'";
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtDesc.Text = Convert.ToString(dt.Rows[0]["description"]);
                txtName.Text = Convert.ToString(dt.Rows[0]["name"]);
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
            sql = "UPDATE `category` SET `name`='" + txtName.Text + "',`description`='" + txtDesc.Text + "' where id = '" + label1.Text + "'";
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