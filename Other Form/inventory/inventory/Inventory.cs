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

namespace inventory
{
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnList.PerformClick();
        }

        public void btnList_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.SetColumn(panel1, 0);
            tableLayoutPanel1.SetRow(panel1, 1);

            pnlPages.Controls.Clear();
            List list = new List();
            list.Dock = DockStyle.Fill;
            list.TopLevel = false;
            list.TopMost = true;
            this.pnlPages.Controls.Add(list);
            list.Show();
            btnList.ForeColor = Color.FromArgb(0, 58, 108);
            btnBatch.ForeColor = Color.Black;
            btnCat.ForeColor = Color.Black;
            btnArchive.ForeColor = Color.Black;
        }

        public void btnBatch_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.SetColumn(panel1, 1);
            tableLayoutPanel1.SetRow(panel1, 1);

            pnlPages.Controls.Clear();
            Batch batch = new Batch();
            batch.Dock = DockStyle.Fill;
            batch.TopLevel = false;
            batch.TopMost = true;
            this.pnlPages.Controls.Add(batch);
            batch.Show();
            btnList.ForeColor = Color.Black;
            btnBatch.ForeColor = Color.FromArgb(0, 58, 108);
            btnCat.ForeColor = Color.Black;
            btnArchive.ForeColor = Color.Black;
            //tableLayoutPanel1.SetColumnSpan(panel1,2);
            //tableLayoutPanel1.SetRowSpan(panel1, 1);
            

        }

        public void btnCat_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.SetColumn(panel1, 2);
            tableLayoutPanel1.SetRow(panel1, 1);

            pnlPages.Controls.Clear();
            Category cat = new Category();
            cat.Dock = DockStyle.Fill;
            cat.TopLevel = false;
            cat.TopMost = true;
            this.pnlPages.Controls.Add(cat);
            cat.Show();
            btnList.ForeColor = Color.Black;
            btnBatch.ForeColor = Color.Black;
            btnCat.ForeColor = Color.FromArgb(0, 58, 108);
            btnArchive.ForeColor = Color.Black;
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.SetColumn(panel1, 3);
            tableLayoutPanel1.SetRow(panel1, 1);

            pnlPages.Controls.Clear();
            Archive arc = new Archive();
            arc.Dock = DockStyle.Fill;
            arc.TopLevel = false;
            arc.TopMost = true;
            this.pnlPages.Controls.Add(arc);
            arc.Show();
            btnList.ForeColor = Color.Black;
            btnBatch.ForeColor = Color.Black;
            btnCat.ForeColor = Color.Black;
            btnArchive.ForeColor = Color.FromArgb(0, 58, 108);
        }

    }
}
