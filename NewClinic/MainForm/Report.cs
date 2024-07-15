using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace NewClinic.MainForm
{
    public partial class Report : Form
    {
        StringFormat strFormat; //Used to format the grid rows.
        ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
        int iCellHeight = 0; //Used to get/set the datagridview cell height
        int iTotalWidth = 0; //
        int iRow = 0;//Used as counter
        bool bFirstPage = false; //Used to check whether we are printing first page
        bool bNewPage = false;// Used to check whether we are printing a new page
        int iHeaderHeight = 0; //Used for the header height

        public static string rp = "";
        public static DataTable dt;
        String searcher = "", searchdate = "", sorted = "", ptype = "", selectstock = "";

        public static string usertype = Main.usertype, id = Main.id, name = Main.name, pass = Main.pass;

        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            cbattended.Text = Main.name;
            dtgridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            use(sender, e);
        }

        //user restriction

        void use(object sender, EventArgs e)
        {
            bool good = false;

            clinic.conn.Open();
            

            MySqlCommand cmd = new MySqlCommand("Select * from tblacc where person_id = '" + id + "' and Full_Name = '" + name + "' and password = '" + pass + "'", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                //MessageBox.Show(id + " " + name + " " + pass + " " + usertype);
                good = true;
            }


            //MessageBox.Show("he " + id + " " + name + " " + pass);
            if (good == true)
            {
                switch (usertype)
                {
                    case "Admin":
                    case "Administrator":
                    case "admin":
                    case "administrator":
                    case "superadmin":
                        rbinventory.Visible = true;
                        rbadmission.Checked = true;
                        rbadmission.Checked = true;
                        rbadmission_CheckedChanged(sender, e);
                        break;
                    case "nurse":
                    case "Nurse":
                        rblog.Location = new Point(rbinventory.Location.X, rbinventory.Location.Y);
                        rbadmission_CheckedChanged(sender, e);
                        break;
                    case "inventory":
                    case "Inventory":
                        rbinventory_CheckedChanged(sender, e);
                        rbinventory.Checked = true;
                        rbinventory.Visible = true;
                        rbinventory.Location = new Point(rbadmission.Location.X, rbadmission.Location.Y);

                        rbadmission.Visible = false;
                        rblog.Visible = false;
                        break;
                }
            }

            clinic.conn.Close();
        }

        //Filter

        void search()
        {
            if (rblog.Checked)
            {
                searcher = "and tblogbook.Person_id = '" + txtsearch.Text + "' or tblogbook.Person_ID = tblprofile.Person_ID and tblprofile.fname = '" + txtsearch.Text + "' or tblogbook.Person_ID = tblprofile.Person_ID and tblprofile.lname = '" + txtsearch.Text + "'";
            }else if (rbadmission.Checked)
            {
                searcher = "and tblogbook.Person_id = '" + txtsearch.Text + "' or tblogbook.Person_ID = tbladmission.Person_ID and tblogbook.name like '" + txtsearch.Text + "%'";
            }else if (rbinventory.Checked)
            {
                searcher = "and productstocks.code like '" + txtsearch.Text + "%' " + selectstock + " or productstocks.code = uniqueproductlist.code and batch like '" + txtsearch.Text + "%' " + selectstock + " or productstocks.code = uniqueproductlist.code and name like '" + txtsearch.Text + "%' " + selectstock;
            }

        }

        void datesearch()
        {
            if (rbadmission.Checked | rblog.Checked)
            {
                searchdate = "and Date_in BETWEEN '" + startdate.Value.ToString("yyyy-MM-dd") + "' and '" + enddate.Value.ToString("yyyy-MM-dd") + "'";
            }else if (rbinventory.Checked)
            {
                searchdate = "and productstocks.date_received between '" + startdate.Value.ToString("yyyy-MM-dd") + "' and '" + enddate.Value.ToString("yyyy-MM-dd") + "'";
            }
        }

        void sort()
        {
            if (rblog.Checked | rbadmission.Checked)
            {
                switch (cbsort.SelectedIndex)
                {
                    case 0:
                        sorted = "Order by tblogbook.Person_ID";
                        break;
                    case 1:
                        sorted = "Order by tblogbook.name";
                        break;
                    case 2:
                        sorted = "Order by tblogbook.Date_in";
                        break;
                    case 3:
                        sorted = "Order by tblogbook.Patient_Type";
                        break;
                }
            }
            else if (rbinventory.Checked)
            {
                switch (cbsort.Text)
                {
                    case "Code":
                        sorted = "ORDER by productstocks.Code";
                        break;
                    case "Batch":
                        sorted = "ORDER by productstocks.batch";
                        break;
                    case "Name":
                        sorted = "ORDER by uniqueproductlist.name";
                        break;
                    case "Highest Stock":
                        sorted = "ORDER by productstocks.stocks Desc";
                        break;
                    case "Lowest Stock":
                        sorted = "ORDER by productstocks.stocks Asc";
                        break;
                }
            }
        }

        void type()
        {
            String gs = "", jh = "", sh = "", c = "", e = "";
            if (cbgs.Checked)
            {
                gs = cbgs.Text;
            }

            if (cbjh.Checked)
            {
                jh = cbjh.Text;
            }

            if (cbsh.Checked)
            {
                sh = cbsh.Text;
            }

            if (cbc.Checked)
            {
                c = cbc.Text;
            }

            if (cbe.Checked)
            {
                e = cbe.Text;
            }

            if (rbadmission.Checked)
            {
                ptype = "and tbladmission.patient_type in ('" + gs + "','" + jh + "','" + sh + "','" + c + "','" + e + "')";
            }
            else if (rblog.Checked)
            {
                ptype = "and tblogbook.patient_type in ('" + gs + "','" + jh + "','" + sh + "','" + c + "','" + e + "')";
            }
        }

        void select()
        {
           

            if (rboos.Checked && rbcs.Checked && rboh.Checked)
            {
                selectstock = "";
            }
            else if (rboos.Checked && rbcs.Checked)
            {
                selectstock = "and productstocks.stocks >= 0 AND productstocks.stocks <= 5";
            }
            else if (rbcs.Checked && rboh.Checked)
            {
                selectstock = "and productstocks.stocks > 0";
            }
            else if (rboos.Checked && rboh.Checked)
            {
                selectstock = "and productstocks.stocks = 0 or productstocks.code = uniqueproductlist.code and productstocks.stocks > 5";
            }
            else 
            {
                if (rboos.Checked)
                {
                    selectstock = "and productstocks.stocks = 0";
                }
                else if (rbcs.Checked)
                {
                    selectstock = "and productstocks.stocks > 0 AND productstocks.stocks <= 5";
                }
                else if (rboh.Checked)
                {
                    selectstock = "and productstocks.stocks > 5";
                }
            }
        }

        private void cbsearch_CheckedChanged(object sender, EventArgs e)
        {
            if (cbsearch.Checked != false)
            {
                txtsearch.Enabled = true;
            }
            else
            {
                iconButton4_Click(sender, e);
                txtsearch.Enabled = false;
                txtsearch.Text = "";
                searcher = "";
            }
        }

        private void cbdate_CheckedChanged(object sender, EventArgs e)
        {
            if (cbdate.Checked != false)
            {
                startdate.Enabled = true;
                enddate.Enabled = true;
            }
            else
            {
                searchdate = "";
                startdate.Enabled = false;
                enddate.Enabled = false;
                iconButton4_Click(sender, e);
                startdate.Value = DateTime.Today;
                enddate.Value = DateTime.Today;
            }
        }

        private void cbsortby_CheckedChanged(object sender, EventArgs e)
        {
            if (cbsortby.Checked != false)
            {
                cbsort.Enabled = true;
            }
            else
            {
                sorted = "";
                cbsort.Enabled = false;
                cbsort.SelectedIndex = -1;
                iconButton4_Click(sender, e);
            }
        }

        private void rbselect_CheckedChanged(object sender, EventArgs e)
        {
            if (cbselect.Checked)
            {
                rboos.Enabled = true;
                rbcs.Enabled = true;
                rboh.Enabled = true;
            }
            else
            {
                iconButton4_Click(sender, e);
                selectstock = "";
                foreach (Control cc in pselect.Controls)
                {
                    if (cc is RadioButton)
                    {
                        RadioButton rb = (RadioButton)cc;

                        rb.Checked = false;
                        rb.Enabled = false;
                    }
                }
                foreach (Control cc in pselect.Controls)
                {
                    if (cc is CheckBox)
                    {
                        CheckBox rb = (CheckBox)cc;
                        if (rb.Name != "cbselect")
                        {
                            rb.Checked = false;
                            rb.Enabled = false;
                        }
                    }
                }
            }
        }

        private void cbfor_CheckedChanged(object sender, EventArgs e)
        {
            if (cbfor.Checked == false)
            {
                foreach (Control cc in flptype.Controls)
                {
                    if (cc is CheckBox)
                    {
                        CheckBox c = (CheckBox)cc;

                        c.Checked = false;
                        c.AutoCheck = false;
                    }
                }

                iconButton4_Click(sender, e);
            }
            else
            {
                ptype = "";
                foreach (Control cc in flptype.Controls)
                {
                    if (cc is CheckBox)
                    {
                        CheckBox c = (CheckBox)cc;

                        c.AutoCheck = true;
                    }
                }
            }
        }

        void logbook()
        {
            if (cbsearch.Checked == true)
            {
                search();
            }
            else
            {
                searcher = "";
            }

            if (cbdate.Checked == true)
            {
                datesearch();
            }
            else
            {
                searchdate = "";
            }

            if (cbsortby.Checked == true)
            {
                sort();
            }
            else
            {
                sorted = "";
            }

            if (cbfor.Checked)
            {
                type();
            }
            else
            {
                foreach (Control cc in flptype.Controls)
                {
                    if (cc is CheckBox)
                    {
                        CheckBox c = (CheckBox)cc;

                        c.Checked = false;
                    }
                }
                ptype = "";
            }

            clinic.conn.Open();
            String query = "Select tblogbook.Date_in as Date, tblogbook.Time_in, tblogbook.Time_out, tblogbook.Person_ID as ID, tblogbook.Name as 'Name of Sudent', tblogbook.Division as 'Section/Position', tblogbook.patient_type, tblogbook.Reason, tblogbook.Assessment, tblogbook.Intervention, tblogbook.Medicine, tblogbook.Nurse from tblogbook inner join tblprofile on tblogbook.Person_ID = tblprofile.Person_ID " + searcher + " " + ptype + " " + searchdate + " " + sorted;
            //String query = "Select tblogbook.Date_in as Date, tblogbook.Time_in, tblogbook.Time_out, tblogbook.Person_ID as ID, tblogbook.Name as 'Name of Sudent', tblogbook.Division as 'Section/Position', tblogbook.patient_type, tblogbook.Reason, tblogbook.Assessment, tblogbook.Intervention, tblogbook.Medicine, tblogbook.Nurse, /*tblogbook.Signature*/ from tblogbook inner join tblprofile on tblogbook.Person_ID = tblprofile.Person_ID " + searcher + " " + ptype + " " + searchdate + " " + sorted;
            //String query = "SELECT tblogbook.Date_in as Date, tblogbook.Time_in, tblogbook.Time_out, tblogbook.Person_ID as ID, tblogbook.Name as 'Name Of Sudent', tblogbook.Division as 'Section/Department', tblogbook.Reason, tblogbook.Assessment, tblogbook.Intervention, tblogbook.Medicine, tblogbook.Nurse, tblogbook.Signature FROM `tblogbook` inner JOIN tblprofile on tblogbook.Person_ID = tblprofile.Person_ID and Date_in BETWEEN '2023-03-01' and '2023-03-31'" ;
            //MessageBox.Show(query);
            MySqlDataAdapter da = new MySqlDataAdapter(query, clinic.conn);
            dt = new DataTable();
            da.Fill(dt);

            dtgridview.DataSource = dt;
            clinic.conn.Close();

            if (dtgridview.Rows.Count > 0)
            {
                dtgridview.Columns[1].Width = 65;
                dtgridview.Columns[2].Width = 65;
                dtgridview.Columns[4].Width = 300;
                dtgridview.Columns[9].Width = 100;
                dtgridview.Columns[10].Width = 200;
                dtgridview.Columns[11].Width = 100;
            }
        }

        void admissio()
        {
            if (cbsearch.Checked == true)
            {
                search();
            }
            else
            {
                searcher = "";
            }

            if (cbdate.Checked == true)
            {
                datesearch();
            }
            else
            {
                searchdate = "";
            }

            if (cbsortby.Checked == true)
            {
                sort();
            }
            else
            {
                sorted = "";
            }

            if (cbfor.Checked)
            {
                type();
            }
            else
            {
                foreach (Control cc in flptype.Controls)
                {
                    if (cc is CheckBox)
                    {
                        CheckBox c = (CheckBox)cc;

                        c.Checked = false;
                    }
                }
                ptype = "";
            }


            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }

            String queryadd = "SELECT tbladmission.person_id, tblogbook.name, tblogbook.division as 'Section/Position', tblogbook.Date_in, tblogbook.Time_in, tblogbook.Time_out, tblogbook.Nurse as 'Attended by', tblogbook.patient_type FROM tblogbook inner JOIN tbladmission on tblogbook.Person_ID = tbladmission.Person_ID " + searcher + " " + ptype + " " + searchdate + " " + sorted;

            clinic.conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(queryadd, clinic.conn);
            dt = new DataTable();
            da.Fill(dt);

            dtgridview.DataSource = dt;
            clinic.conn.Close();

            if (dtgridview.Rows.Count > 0)
            {
                //dtgridview.Columns[1].Width = 65;
                //dtgridview.Columns[2].Width = 65;
                //dtgridview.Columns[4].Width = 300;
                //dtgridview.Columns[9].Width = 100;
                //dtgridview.Columns[10].Width = 200;
                //dtgridview.Columns[11].Width = 100;
            }
            clinic.conn.Close();
        }   

        void inventory()
        {
            if (cbsearch.Checked == true)
            {
                search();
            }
            else
            {
                searcher = "";
            }

            if (cbdate.Checked == true)
            {
                datesearch();
            }
            else
            {
                searchdate = "";
            }

            if (cbsortby.Checked == true)
            {
                sort();
            }
            //else
            //{
            //    sorted = "";
            //}

            if (cbselect.Checked)
            {
                select();
            }
            else
            {
                foreach (Control cc in pselect.Controls)
                {
                    if (cc is CheckBox)
                    {
                        CheckBox rb = (CheckBox)cc;
                        if (rb.Name != "cbselect")
                        {
                            rb.Checked = false;
                            rb.Enabled = false;
                        }
                    }
                }
                selectstock = "";
            }


            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }

            String queryadd = "SELECT productstocks.code, productstocks.batch, uniqueproductlist.name, uniqueproductlist.unit, productstocks.consumed, productstocks.stocks, productstocks.date_received, productstocks.expiry_date, uniqueproductlist.category FROM `productstocks` INNER JOIN uniqueproductlist on productstocks.code = uniqueproductlist.code " + searcher + " " + selectstock + " " + searchdate + " " + sorted;

            clinic.conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(queryadd, clinic.conn);
            dt = new DataTable();
            da.Fill(dt);

            dtgridview.DataSource = dt;
            clinic.conn.Close();

            if (dtgridview.Rows.Count > 0)
            {
                //dtgridview.Columns[1].Width = 65;
                //dtgridview.Columns[2].Width = 65;
                //dtgridview.Columns[4].Width = 300;
                //dtgridview.Columns[9].Width = 100;
                //dtgridview.Columns[10].Width = 200;
                //dtgridview.Columns[11].Width = 100;
            }
            clinic.conn.Close();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            if (rbadmission.Checked)
            {
                admissio();
            }
            else if (rblog.Checked)
            {
                logbook();
            }
            else if (rbinventory.Checked)
            {
                inventory();
            }
        }


        //Code For printing
        private void iconButton3_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printPreviewDialog1.Document = printDocument1;
            printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.ShowDialog();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            cbsearch.Checked = false;
            cbdate.Checked = false;
            cbfor.Checked = false;
            cbsortby.Checked = false;
            cbselect.Checked = false;
            dtgridview.DataSource = null;
            iconButton4_Click(sender, e);
            rp = "";
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            PrintDocument pd = printDocument1;
            pd.DefaultPageSettings.Landscape = true;
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Tabloid", 1100, 1700);
            pd = printDocument1;
            printPreviewDialog1.Document = pd;
            printPreviewDialog1.ShowDialog();
        }

        private void rblog_CheckedChanged(object sender, EventArgs e)
        {
            cbsort.Items.Clear();
            String[] a = { "ID", "Full.Name", "Date", "Patient Type" };
            if (rblog.Checked)
            {
                for(int i = 0; i < a.Length; i++)
                {
                    cbsort.Items.Add(a[i]);
                }
                rp = "LogBook";
                psearch.Visible = true;
                pdate.Visible = true;
                preport.Visible = true;
                psort.Visible = true;
                pselect.Visible = false;
                iconButton4_Click(sender, e);

                searcher = ""; searchdate = ""; sorted = ""; ptype = ""; selectstock = "";
                clearcheck();
            }
        }

        private void rbinventory_CheckedChanged(object sender, EventArgs e)
        {
            cbsort.Items.Clear();
            String[] a = { "Code", "Name", "Batch", "Highest Stock", "Lowest Stock" };
            if (rbinventory.Checked)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    cbsort.Items.Add(a[i]);
                }
                rp = "Inventory";
                dtgridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                psearch.Visible = true;
                pdate.Visible = true;
                pselect.Location = new Point(preport.Location.X, preport.Location.Y);
                pselect.Visible = true;
                preport.Visible = false;
                psort.Visible = true;
                iconButton4_Click(sender, e);

                searcher = ""; searchdate = ""; sorted = ""; ptype = ""; selectstock = "";
                clearcheck();
            }
        }

        private void rbadmission_CheckedChanged(object sender, EventArgs e)
        {
            cbsort.Items.Clear();
            String[] a = { "Person ID", "Name", "Date", "Patient Type"};
            if (rbadmission.Checked)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    cbsort.Items.Add(a[i]);
                }
                dtgridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                rp = "Admission";
                psearch.Visible = true;
                pdate.Visible = true;
                pselect.Visible = false;
                preport.Visible = true;
                psort.Visible = true;
                iconButton4_Click(sender, e);

                searcher = ""; searchdate = "";  sorted = "";  ptype = ""; selectstock = "";
                clearcheck();
            }

        }
        private void clearcheck()
        {

            foreach (Control cc in flptype.Controls)
            {
                if (cc is CheckBox)
                {
                    CheckBox cb = (CheckBox)cc;
                    if (cb.Checked)
                    {
                        if (cb.Name != "cbfor")
                        {
                            ptype = "";
                            cb.Checked = false;
                            cbfor.Checked = false;
                        }
                        else
                        {
                            cb.Checked = false;
                        }
                    }
                }
            }

            foreach (Control cc in pselect.Controls)
            {
                CheckBox cb = (CheckBox)cc;
                if (cb.Checked)
                {
                    if (cb.Name != "cbselect")
                    {
                        cb.Checked = false;
                        cb.Enabled = false;
                    }
                }
            }
        }

        private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                // Calculating Total Widths
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dtgridview.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dtgridview.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                                       (double)iTotalWidth * (double)iTotalWidth *
                                       ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Save width and height of headres
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= dtgridview.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dtgridview.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;
                    //Check whether the current page settings allow more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Image Header

                            if (rbadmission.Checked)
                            {
                                Bitmap bt = Properties.Resources.Admission2;
                                e.Graphics.DrawImage(bt, (printDocument1.DefaultPageSettings.PaperSize.Height / 2) - 100, 10, 275, 70);
                            }
                            else if (rbinventory.Checked)
                            {
                                Bitmap bt = Properties.Resources.Logbook2;
                                e.Graphics.DrawImage(bt, (printDocument1.DefaultPageSettings.PaperSize.Height / 2) - 100, 10, 275, 80);
                            }
                            else if (rblog.Checked)
                            {
                                Bitmap bt = Properties.Resources.Logbook2;
                                e.Graphics.DrawImage(bt, (printDocument1.DefaultPageSettings.PaperSize.Height / 2) - 100, 10, 275, 80);
                            }

                            //e.Graphics.DrawImage(bt, (Properties.Resources.aaa.Width / 2) - 25, 10, 275, 80);
                            //e.Graphics.DrawImage(bt, (Properties.Resources.aaa.Width / 2)-125, 10, 200, 60);

                            //Draw Header
                            e.Graphics.DrawString(rp, new Font(dtgridview.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
                                    e.Graphics.MeasureString(rp, new Font(dtgridview.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Footer
                            e.Graphics.DrawString("Prepared By: ", new Font(dtgridview.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Bottom +
                                    e.Graphics.MeasureString("Logbook", new Font(dtgridview.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width - 13);

                            //Draw Footer name
                            e.Graphics.DrawString(cbattended.Text, new Font(dtgridview.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + 95, e.MarginBounds.Bottom +
                                    e.Graphics.MeasureString("Logbook", new Font(dtgridview.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
                            //Draw Date
                            e.Graphics.DrawString(strDate, new Font(dtgridview.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new Font(dtgridview.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Logbook", new Font(new Font(dtgridview.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dtgridview.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, 97, 150)),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                                    new SolidBrush(Color.White),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font,
                                            new SolidBrush(Cel.InheritedStyle.ForeColor),
                                            new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin,
                                            (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount],
                                    iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));

                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }

                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            //PrintDialog printDialog = new PrintDialog();
            //printDialog.Document = printDocument1;
            //printDialog.UseEXDialog = true;

            ////Get the document
            //if (DialogResult.OK == printDialog.ShowDialog())
            //{
            //    printDocument1.DocumentName = "Test Page Print";
            //    printDocument1.DefaultPageSettings.Landscape = true;
            //    printDocument1.Print();
            //}

            //FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            //// set the initial folder
            //folderBrowserDialog.SelectedPath = @"C:\";

            //// show the dialog and check if the user clicked OK
            //if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            //{
            //    // the user clicked OK, do something with the selected folder
            //    string selectedFolder = folderBrowserDialog.SelectedPath;
            //    // ...
            //}

            if (txtname.Text.Replace(" ", "") != "" && cbattended.Text != "" && dtgridview.RowCount != 0)
            {
                PrintDocument pd = printDocument1;
                pd.DefaultPageSettings.Landscape = true;
                PrintDialog dp = new PrintDialog();
                dp.Document = pd;
                DialogResult userResp = dp.ShowDialog();
                if (userResp == DialogResult.OK)
                {
                    pd.PrinterSettings.PrintToFile = true;
                    SaveFileDialog pdfSaveDialog = new SaveFileDialog();
                    pdfSaveDialog.FileName = txtname.Text;
                    pdfSaveDialog.Filter = "PDF File|*.pdf";
                    userResp = pdfSaveDialog.ShowDialog();
                    if (userResp != DialogResult.Cancel)
                    {
                        pd.PrinterSettings.PrintFileName = pdfSaveDialog.FileName;
                        printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Tabloid", 1100, 1700);
                        pd = printDocument1;
                        pd.Print();
                    }
                }
            }
            else
            {
                MessageBox.Show("To export a report, you must input a report name, specify who prepared it, and ensure that there is data available!", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
