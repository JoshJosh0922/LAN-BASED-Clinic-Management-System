﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;

namespace inventory
{
    public partial class ListAddProduct : Form
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter da = new MySqlDataAdapter();
        MySqlDataReader dr;
        DataTable dt = new DataTable();
        string sql;
        int result;

        public ListAddProduct()
        {
            InitializeComponent();
        }

        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWmd, int wMsg, int wParam, int lParam);

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        
        private void iconButton1_Click(object sender, EventArgs e)
        {
            iconButton1.IconColor = Color.Coral;
            this.Close();
        }

        private void iconButton3_MouseEnter(object sender, EventArgs e)
        {
            iconButton1.IconColor = Color.Coral;
        }

        private void iconButton3_MouseLeave(object sender, EventArgs e)
        {
            iconButton1.IconColor = Color.White;
        }

        private void ListAddProduct_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user id=root;password=;database=nclinic1;sslMode=none";
            conn.Close();
            conn.Open();

            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            /*            sql = "SELECT DISTINCT code FROM `uniqueproductlist`";
                        cmd = new MySqlCommand(sql, conn);
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                        da.SelectCommand = cmd;
                        da.Fill(dt1);
                        cboCode.DataSource = dt1;
                        cboCode.DisplayMember = "code";
                        cboCode.ValueMember = "code";

            */
            sql = "SELECT name, unit, concat(name, ' ', unit) as full FROM `uniqueproductlist` ";
            cmd = new MySqlCommand(sql, conn);
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt1);
            cboProd.DataSource = dt1;
            cboProd.DisplayMember = "full";

            sql = "SELECT name FROM `batch` ";
            cmd = new MySqlCommand(sql, conn);
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt2);
            cboBatch.DataSource = dt2;
            cboBatch.DisplayMember = "name";
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            DialogResult dial = MessageBox.Show("Are you sure you want to cancel?", "Cancel", MessageBoxButtons.YesNo);
            if (dial == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            sql = "select code from `uniqueproductlist` where concat(name, ' ', unit) = '" + cboProd.Text + "'";
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt4);
            //dt.Load(dr);
            if (dt4.Rows.Count > 0)
            {
                sql = "select code as batchcode, DATE_FORMAT(date_received, '%Y-%m-%d') as received from batch where name = '" + cboBatch.Text + "'";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(dt3);
                //dt.Load(dr);
                if (dt3.Rows.Count > 0)
                {
                    var a = dt3.Rows[0]["received"];
                    var b = expiry.Value.Date.ToString("yyyy-MM-dd");
                    string d = Convert.ToString(dt4.Rows[0]["code"]);
                    string f = Convert.ToString(dt3.Rows[0]["batchcode"]);
                    sql = "INSERT INTO `productstocks`(`code`, batch, stocks, `date_received`, expiry_date) VALUES ('" + d + "','" + f + "','" + txtStock.Text + "','" + a + "','" + b + "')";
                    cmd = new MySqlCommand(sql, conn);
                    result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Data Inserted");
                        this.Close();
                    }
                }
            }
            dt.Clear();
        }

        private void btnInc_Click(object sender, EventArgs e)
        {
            int a = 1;
            int b = Convert.ToInt32(txtStock.Text);
            int c = b + a;
            txtStock.Text = Convert.ToString(c);
        }

        private void btnDec_Click(object sender, EventArgs e)
        {
            int a = 1;
            int b = Convert.ToInt32(txtStock.Text);
            if (b > a)
            {
                int c = b - a;
                txtStock.Text = Convert.ToString(c);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}