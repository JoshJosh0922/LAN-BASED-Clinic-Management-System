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

namespace NewClinic.ControlAccount
{
    public partial class action : Form
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

        public static string rp = "User Action";

        public static string query = "Select * from tblaction_user";

        public action()
        {
            InitializeComponent();
        }

        private void action_Load(object sender, EventArgs e)
        {
            showdata();
        }

        void showdata()
        {
            dtgrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }
            clinic.conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(query, clinic.conn);
            DataTable dt;
            dt = new DataTable();
            da.Fill(dt);
            dtgrid.DataSource = dt;
            clinic.conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtsearch.Text.Replace(" ", "") != "")
            {
                query = "Select * from tblaction_user where user_id like '" + txtsearch.Text + "' or username like '" + txtsearch.Text + "'";
                showdata();
            }
            else
            {
                query = "Select * from tblaction_user";
                showdata();
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
                foreach (DataGridViewColumn dgvGridCol in dtgrid.Columns)
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
                    foreach (DataGridViewColumn GridCol in dtgrid.Columns)
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
                while (iRow <= dtgrid.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dtgrid.Rows[iRow];
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


                            //e.Graphics.DrawImage(bt, (Properties.Resources.aaa.Width / 2) - 25, 10, 275, 80);
                            //e.Graphics.DrawImage(bt, (Properties.Resources.aaa.Width / 2)-125, 10, 200, 60);

                            //Draw Header
                            e.Graphics.DrawString(rp, new Font(dtgrid.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top -
                                    e.Graphics.MeasureString(rp, new Font(dtgrid.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Footer
                            e.Graphics.DrawString("Prepared By: ", new Font(dtgrid.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Bottom +
                                    e.Graphics.MeasureString("Logbook", new Font(dtgrid.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width - 13);

                            //Draw Footer name
                            e.Graphics.DrawString(Main.name, new Font(dtgrid.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + 95, e.MarginBounds.Bottom +
                                    e.Graphics.MeasureString("Logbook", new Font(dtgrid.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
                            //Draw Date
                            e.Graphics.DrawString(strDate, new Font(dtgrid.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new Font(dtgrid.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Logbook", new Font(new Font(dtgrid.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dtgrid.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(60,50,104)),
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

        private void iconButton1_Click(object sender, EventArgs e)
        {
            PrintDocument pd = printDocument1;
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Tabloid", 1100, 1700);
            pd = printDocument1;
            printPreviewDialog1.Document = pd;
            printPreviewDialog1.ShowDialog();
        }

        private void iconButton5_Click(object sender, EventArgs e)
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
                //pdfSaveDialog.FileName = txtname.Text;
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
    }
}
