using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
using System.IO;
using MaterialSkin.Controls;
using System.Runtime.InteropServices;
using System.Drawing.Printing;

namespace NewClinic.ControlProfile
{
    public partial class viewadmilog : Form
    {
        public static String id = "", type;
        //public static String id = "197812612831", lgb = "9", type = "";
        int select = 0;

        public viewadmilog()
        {
            InitializeComponent();
        }

        [System.ComponentModel.Browsable(false)]
        public int DeviceDpi { get; }

        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWmd, int wMsg, int wParam, int lParam);

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void iconButton4_MouseHover(object sender, EventArgs e)
        {
            iconButton4.IconColor = Color.LightCoral;
        }

        private void iconButton4_MouseLeave(object sender, EventArgs e)
        {
            iconButton4.IconColor = Color.White;
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            iconButton4.IconColor = Color.Red;
            this.Close();
        }

        private void viewadmilog_Load(object sender, EventArgs e)
        {
            //iconButton1_Click(sender, e);
            load();
        }

        void load()
        {
            profile1.showdata(ProfileForm.id);
            //admision1.showdata(lgb);
            //logbook1.showdata(lgb);

            if (cbshow.Checked)
            {
                id = ProfileForm.id;
            }
            else
            {
                id = listadmission.id;
            }

            showdata(id);
        }

        public void showdata(String idno)
        {
            flp2.Controls.Clear();
            String id;
            clinic.conn.Open();
            int count = 0;

            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader dr;

            if (cbshow.Checked)
            {
                MySqlCommand cmd2 = new MySqlCommand("Select	count(tbladmission.admi_id) from tbladmission inner join tblogbook on tblogbook.Lb_ID = tbladmission.Lb_ID and tbladmission.admi_id = '" + idno + "'" +
                    " or tblogbook.Lb_ID = tbladmission.Lb_ID and tblogbook.lb_id = '" + idno + "' or tblogbook.Lb_ID = tbladmission.Lb_ID and tbladmission.person_id = '" + idno + "'", clinic.conn);
                count = Convert.ToInt32(cmd2.ExecuteScalar());

                cmd = new MySqlCommand("Select	tbladmission.Admi_ID, tbladmission.Lb_ID, tbladmission.Person_ID, tbladmission.Complaint, tbladmission.BP, tbladmission.BT, tbladmission.PR, " +
                    "tbladmission.RR, tbladmission.Height, tbladmission.Weight, tbladmission.Spo2, tbladmission.Mens_period, tbladmission.Nurse, tbladmission.Nurse_note, tbladmission.Patient_type, " +
                    "tbladmission.signature, tblogbook.date_in, tblogbook.time_in, tblogbook.time_out from tbladmission inner join tblogbook on tblogbook.Lb_ID = tbladmission.Lb_ID and tbladmission.admi_id = '" + idno + "'" +
                    " or tblogbook.Lb_ID = tbladmission.Lb_ID and tblogbook.lb_id = '" + idno + "' or tblogbook.Lb_ID = tbladmission.Lb_ID and tbladmission.person_id = '" + idno + "'", clinic.conn);
                dr = cmd.ExecuteReader();
            }
            else
            {
                count = 1;
                cmd = new MySqlCommand("Select tbladmission.Admi_ID, tbladmission.Lb_ID, tbladmission.Person_ID, tbladmission.Complaint, tbladmission.BP, tbladmission.BT, tbladmission.PR, " +
                    "tbladmission.RR, tbladmission.Height, tbladmission.Weight, tbladmission.Spo2, tbladmission.Mens_period, tbladmission.Nurse, tbladmission.Nurse_note, tbladmission.Patient_type, " +
                    "tbladmission.signature, tblogbook.date_in, tblogbook.time_in, tblogbook.time_out from tbladmission inner join tblogbook on tblogbook.Lb_ID = tbladmission.Lb_ID and tbladmission.admi_id = '" + idno + "'" +
                    " or tblogbook.Lb_ID = tbladmission.Lb_ID and tblogbook.lb_id = '" + idno + "' or tblogbook.Lb_ID = tbladmission.Lb_ID and tbladmission.person_id = '" + idno + "'", clinic.conn);
                dr = cmd.ExecuteReader();
            }

            

            admision[] ad = new admision[count];

            for (int i = 0; i<ad.Length; i++)
            {

                if (dr.Read())
                {
                    ad[i] = new admision();
                    //id = dr[1].ToString();
                    String disease = dr[3].ToString();
                    String[] word;
                    word = disease.Split('|');

                    for (int s = 0; s<word.Length; s++)
                    {
                        foreach (Control cb in ad[i].cbpabel.Controls)
                        {
                            if (cb is CheckBox)
                            {
                                CheckBox c = (CheckBox)cb;
                                if (c.Text.ToLower() == word[s].ToLower() | c.Text.ToUpper() == word[s].ToUpper())
                                {
                                    c.Checked = true;
                                }
                                else
                                {
                                    foreach (char w in word[s])
                                    {
                                        if (w == '?')
                                        {
                                            string[] alis = word[s].Split('?');
                                            ad[i].txtother.Text = alis[0];
                                            ad[i].cbother.Checked = true;
                                        }
                                        else if (w == '!')
                                        {
                                            string[] alis = word[s].Split('!');
                                            //MessageBox.Show(alis[0]);
                                            ad[i].txtinjury.Text = alis[0].ToString();
                                            ad[i].cbinjury.Checked = true;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (dr[11].ToString() != "")
                    {
                        ad[i].cbperiod.Checked = true;
                        ad[i].txtdate.Text = dr[11].ToString();
                    }


                    ad[i].txtbp.Text = dr[4].ToString();
                    ad[i].txtbt.Text = dr[5].ToString();
                    ad[i].txtpr.Text = dr[6].ToString();
                    ad[i].txtrr.Text = dr[7].ToString();
                    ad[i].txtht.Text = dr[8].ToString();
                    ad[i].txtwt.Text = dr[9].ToString();
                    ad[i].txtspo.Text = dr[10].ToString();
                    ad[i].txtatendant.Text = dr[12].ToString();
                    ad[i].txtnote.Text = dr[13].ToString();

                    ad[i].lbldate.Text = dr[16].ToString();
                    ad[i].lblin.Text = dr[17].ToString();
                    ad[i].lblout.Text = dr[18].ToString();

                    try
                    {
                        if (dr[15].ToString() != "")
                        {
                            byte[] im = (byte[])dr[15];
                            MemoryStream ms = new MemoryStream(im);
                            ad[i].signa.Image = Image.FromStream(ms);
                        }
                        else
                        {
                            //ad[i].signa.Image = NewClinic.Properties.Resources.;
                        }


                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message);
                    }

                    if (flp2.Controls.Count < 0)
                    {
                        flp2.Controls.Clear();
                    }
                    else
                        flp2.Controls.Add(ad[i]);
                }

            }

            clinic.conn.Close();
        }


        private void PrintPageHandler1(object sender, PrintPageEventArgs e)
        {
            int numColumns = 0;
            int controlWidth = flp2.Controls[0].Width; // assuming all controls have the same width
            int controlHeight = flp2.Controls[0].Height; // assuming all controls have the same width
            int columnwidth = 0;
            int columnheight = 0;


            if (flp2.Width > 0 && controlWidth > 0)
            {
                numColumns = flp2.Width / controlWidth;
                columnwidth = controlWidth;
                columnheight = controlHeight;
            }

            Bitmap bt = Properties.Resources.Admission2;
            e.Graphics.DrawImage(bt, e.MarginBounds.Left + 310, 10, 275, 70);

            Bitmap bp2 = new Bitmap(profile1.Width, profile1.Height);

            profile1.DrawToBitmap(bp2, new Rectangle(0, 0, profile1.Width, profile1.Height));
            e.Graphics.DrawImage(bp2, e.MarginBounds.Left, e.MarginBounds.Top, profile1.Width, profile1.Height);

            float startX = e.MarginBounds.Left - 40;
            float startY = e.MarginBounds.Top + profile1.Height;
            float headerHeight = 0f;

            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font dataFont = new Font("Arial", 12, FontStyle.Regular);

            for (int i = 0; i < numColumns; i++)
            {
                RectangleF headerRect = new RectangleF(startX + (i * columnwidth), startY, columnwidth, 0);
                e.Graphics.DrawString(" ", headerFont, Brushes.Black, headerRect);
            }

            List<UserControl> p = new List<UserControl>();

            foreach (Control cc in flp2.Controls)
            {
                if (cc is UserControl)
                {
                    p.Add((UserControl)cc);
                }
            }

            int controlsPerRow = (flp2.Width - flp2.Margin.Horizontal) / (flp2.Controls[0].Width + flp2.Controls[0].Margin.Horizontal);
            int numRows2 = (int)Math.Ceiling((double)flp2.Controls.Count / controlsPerRow);

            for (int row = 0; row < numRows2; row++)
            {
                if (row == 2)
                {
                    if (select < p.Count)
                    {
                        e.HasMorePages = true; 
                        break;
                    }
                    else
                    {
                        e.HasMorePages = false;
                    }
                }
                else
                {

                    for (int col = 0; col < numColumns; col++)
                    {
                        if (select < p.Count)
                        {
                            UserControl pp = (UserControl)p[select];
                            select += 1;
                            Bitmap bp = new Bitmap(pp.Width, pp.Height);
                            pp.DrawToBitmap(bp, new Rectangle(0, 0, columnwidth, columnheight));
                            //Pen pen = new Pen(Color.Black, 5);

                            //e.Graphics.DrawRectangle(pen, startX + (col * columnwidth), startY + headerHeight + (row * columnwidth), controlWidth, columnheight);

                            e.Graphics.DrawImage(bp, startX + (col * columnwidth), startY + headerHeight + (row * columnheight), columnwidth, columnheight);

                        }
                    }
                }
            }

            //select = 0;
        }


        private void iconButton1_Click_1(object sender, EventArgs e)
        {

            load();
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

        private void iconButton2_Click_1(object sender, EventArgs e)
        {
            select = 0;

            PrintDocument pd = printDocument1;
            printPreviewDialog1.Document = pd;
            //printDocument1.DefaultPageSettings.Landscape = true;
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Tabloid", 1100, 1700);
            printDocument1.PrintPage += new PrintPageEventHandler(PrintPageHandler1);
            //printDoc.Print();
            printPreviewDialog1.ShowDialog();
            pd.Dispose();
        }

        private void cbshow_CheckedChanged(object sender, EventArgs e)
        {
            if (cbshow.Checked)
            {
                load();
            }
            else
            {
                load();
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            //// Set the PrintPage event handler
            //printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Tabloid", 1100, 1700);
            //printDocument1.PrintPage += new PrintPageEventHandler(PrintPageHandler1);


            //// Print the document
            //printDocument1.Print();

            //clinic.actionuser("Add New Student", Main.id, Main.name, DateTime.Now.ToShortTimeString(), DateTime.Today.ToShortDateString());
        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
            // Set the PrintPage event handler
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Tabloid", 1100, 1700);
            printDocument1.PrintPage += new PrintPageEventHandler(PrintPageHandler1);


            // Print the document
            printDocument1.Print();

            //clinic.actionuser("Add New Student", Main.id, Main.name, DateTime.Now.ToShortTimeString(), DateTime.Today.ToShortDateString());
        }

    }
}
