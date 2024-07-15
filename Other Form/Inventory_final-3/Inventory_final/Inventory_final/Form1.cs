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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            pnlPages.Controls.Clear();
            List list = new List();
            list.Dock = DockStyle.Fill;
            list.TopLevel = false;
            list.TopMost = true;
            this.pnlPages.Controls.Add(list);
            list.Show();
            btnList.ForeColor = Color.Blue;
            btnBatch.ForeColor = Color.Black;
            btnCat.ForeColor = Color.Black;
            btnArchive.ForeColor = Color.Black;
            panel1.Location = new Point(12, 67);
        }

        private void btnBatch_Click(object sender, EventArgs e)
        {
            pnlPages.Controls.Clear();
            Batch batch = new Batch();
            batch.Dock = DockStyle.Fill;
            batch.TopLevel = false;
            batch.TopMost = true;
            this.pnlPages.Controls.Add(batch);
            batch.Show();
            btnList.ForeColor = Color.Black;
            btnBatch.ForeColor = Color.Blue;
            btnCat.ForeColor = Color.Black;
            btnArchive.ForeColor = Color.Black;
            panel1.Location = new Point(172, 67);
        }

        private void btnCat_Click(object sender, EventArgs e)
        {
            pnlPages.Controls.Clear();
            Category cat = new Category();
            cat.Dock = DockStyle.Fill;
            cat.TopLevel = false;
            cat.TopMost = true;
            this.pnlPages.Controls.Add(cat);
            cat.Show();
            btnList.ForeColor = Color.Black;
            btnBatch.ForeColor = Color.Black;
            btnCat.ForeColor = Color.Blue;
            btnArchive.ForeColor = Color.Black;
            panel1.Location = new Point(332, 67);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnList.PerformClick();
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
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
            btnArchive.ForeColor = Color.Blue;
            panel1.Location = new Point(492, 67);
        }
    }
}
