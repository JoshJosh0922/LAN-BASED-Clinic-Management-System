using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewClinic.ControlProfile
{
    public partial class viewMedicProfi : Form
    {
        public static string id;

        public viewMedicProfi()
        {
            InitializeComponent();
        }

        private void viewMedicProfi_Load(object sender, EventArgs e)
        {
            panel2.Size = new Size(mediprofile1.Width, mediprofile1.Height);
            mediprofile1.Location = new Point(0, 0);
            id = ControlProfile.listmedicprofi.id;
            profile1.showdata(id);
            mediprofile1.medicH(id);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrintPageHandler1(object sender, PrintPageEventArgs e)
        {
            Bitmap bt = Properties.Resources.HEALTHRECORD;
            e.Graphics.DrawImage(bt, e.MarginBounds.Left + 300, 10, 325, 80);

            Bitmap bp2 = new Bitmap(profile1.Width, profile1.Height);
            profile1.Visible = true;
            profile1.DrawToBitmap(bp2, new Rectangle(0, 0, profile1.Width, profile1.Height));
            e.Graphics.DrawImage(bp2, e.MarginBounds.Left + 10, e.MarginBounds.Top, profile1.Width, profile1.Height);

            float startX = e.MarginBounds.Left - 40;
            float startY = e.MarginBounds.Top + profile1.Height;

            Bitmap deseases = new Bitmap(mediprofile1.s.Width, mediprofile1.s.Height);
            mediprofile1.s.DrawToBitmap(deseases, new Rectangle(0, 0, mediprofile1.s.Width, mediprofile1.s.Height));
            e.Graphics.DrawImage(deseases, e.MarginBounds.Left + 10, e.MarginBounds.Top + profile1.Height , mediprofile1.s.Width, mediprofile1.s.Height);


            Bitmap bt3 = new Bitmap(mediprofile1.panel1.Width, mediprofile1.panel1.Height);
            mediprofile1.panel1.DrawToBitmap(bt3, new Rectangle(0, 0, mediprofile1.panel1.Width, mediprofile1.panel1.Height));
            e.Graphics.DrawImage(bt3, e.MarginBounds.Left -25, e.MarginBounds.Top + profile1.Height + mediprofile1.s.Height -5, mediprofile1.panel1.Width, mediprofile1.panel1.Height);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            PrintDocument pd = printDocument1;
            printPreviewDialog1.Document = pd;
            //printDocument1.DefaultPageSettings.Landscape = true;
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Tabloid", 1100, 1700);
            printDocument1.PrintPage += new PrintPageEventHandler(PrintPageHandler1);
            //printDoc.Print();
            printPreviewDialog1.ShowDialog();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            //PrintDocument pd = printDocument1;
            PrintDialog dp = new PrintDialog();
            dp.Document = printDocument1;
            DialogResult userResp = dp.ShowDialog();
            if (userResp == DialogResult.OK)
            {
                printDocument1.PrinterSettings.PrintToFile = true;
                SaveFileDialog pdfSaveDialog = new SaveFileDialog();
                pdfSaveDialog.Filter = "PDF File|*.pdf";
                userResp = pdfSaveDialog.ShowDialog();
                if (userResp != DialogResult.Cancel)
                {
                    printDocument1.PrinterSettings.PrintFileName = pdfSaveDialog.FileName;
                    printDocument1.PrintPage += new PrintPageEventHandler(PrintPageHandler1);
                    printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Tabloid", 1100, 1700);
                    printDocument1.Print();
                }
            }
        }

    }
}
