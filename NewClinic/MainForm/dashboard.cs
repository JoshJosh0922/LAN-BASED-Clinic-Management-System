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
using System.Globalization;
using FontAwesome.Sharp;

namespace NewClinic.MainForm
{
    public partial class dashboard : Form
    {
        int startweek, endweek;
        int startweek2, endweek2;
        public static IconButton btn = new IconButton();
        public string name = Main.name , usertype = Main.usertype;

        public dashboard()
        {
            InitializeComponent();
        }

        void activeButton(object sender)
        {
            if (sender != null)
            {
                if (btn != (IconButton)sender)
                {
                    disable();
                    btn = (IconButton)sender;
                    btn.BackColor = Color.FromArgb(30, 90, 150);
                    btn.FlatAppearance.BorderColor = Color.White;
                    datashow(btn.Text);
                }
            }
        }

        void disable()
        {
            if (btn != null)
            {
                btn.BackColor = Color.FromArgb(0, 58, 107);
                btn.FlatAppearance.BorderColor = Color.White;
            }
        }

        void datashow(String cc)
        {
            flpmed.Controls.Clear();
            switch (cc)
            {
                case "Out of Stock":
                    outstack();
                    break;
                case "Critical Stock":
                    crit();
                    break;
            }
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            loadalldata();
        }

        void loadalldata()
        {
            loadpatient();
            picker.SelectedIndex = 0;
            loadfinding();
            acc();
            med();
            iconButton1.PerformClick();

            lblname.Text = name;
            lblusertype.Text = usertype.ToUpper();
        }

        void loadpatient()
        {
            if (clinic.conn.State == ConnectionState.Open)
            {
                clinic.conn.Close();
            }

            flpatient.Controls.Clear();

            clinic.conn.Open();
            

            MySqlCommand cmd1 = new MySqlCommand("Select count(person_id) from tblogbook where date_in = '" + DateTime.Today.ToString("yyyy-MM-dd") + "'", clinic.conn);
            int count = Convert.ToInt32(cmd1.ExecuteScalar());


            MySqlCommand cmd = new MySqlCommand("Select name, date_in, time_in, time_out, reason from tblogbook where date_in = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' ORDER BY TIME_OUT asc, TIME_IN", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            ControlDashboard.listview[] ls = new ControlDashboard.listview[count];

            for(int i = 0; i<count; i++)
            {
                while (dr.Read())
                {
                    ls[i] = new ControlDashboard.listview();
                    ls[i].lblname.Text = dr[0].ToString();
                    ls[i].lbldate.Text = dr[1].ToString();
                    ls[i].lblin.Text = dr[2].ToString();
                    ls[i].lblout.Text = dr[3].ToString();
                    ls[i].lblreason.Text = dr[4].ToString();

                    if (flpatient.Controls.Count < 0)
                    {
                        flpatient.Controls.Clear();
                    }
                    else
                        flpatient.Controls.Add(ls[i]);
                }
            }

            clinic.conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (picker.SelectedItem)
            {
                case "Weekly":
                    lblvisit.Text = "Weekly Visitors";
                    loaddonutWeek();
                    Loadbargraphweek();
                    break;
                case "Monthly":
                    lblvisit.Text = "Monthly Visitors";
                    loadbargrapMonth();
                    loaddonutMonth();
                    break;
            }
        }

        public void loadbargrapMonth()
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }

            int count = 0, count2 = 0;
            clinic.conn.Open();
            for (int i = 1; i <= 12; i++)
            {
                //MessageBox.Show(DateTime.Today.Year + " " + DateTimeFormatInfo.CurrentInfo.GetMonthName(i).ToString() + " " + DateTime.DaysInMonth(DateTime.Today.Year, i).ToString());

                MySqlCommand cmd = new MySqlCommand("Select count(lb_id) from tblogbook where Patient_type = 'Grade School' and date_in between '" + DateTime.Today.Year + "-" + i.ToString("00") + "-" + "01" + "' and '" + DateTime.Today.Year + "-" + i.ToString("00") + "-" + DateTime.DaysInMonth(DateTime.Today.Year, i) + "' or "
                    + "Patient_type = 'Junior High' and date_in between '" + DateTime.Today.Year + "-" + i.ToString("00") + "-" + "01" + "' and '" + DateTime.Today.Year + "-" + i.ToString("00") + "-" + DateTime.DaysInMonth(DateTime.Today.Year, i) + "' or " +
                    "Patient_type = 'Senior High' and date_in between '" + DateTime.Today.Year + "-" + i.ToString("00") + "-" + "01" + "' and '" + DateTime.Today.Year + "-" + i.ToString("00") + "-" + DateTime.DaysInMonth(DateTime.Today.Year, i) + "' or " +
                    "Patient_type = 'College' and date_in between '" + DateTime.Today.Year + "-" + i.ToString("00") + "-" + "01" + "' and '" + DateTime.Today.Year + "-" + i.ToString("00") + "-" + DateTime.DaysInMonth(DateTime.Today.Year, i) + "'", clinic.conn);
                count = Convert.ToInt32(cmd.ExecuteScalar());

                DateTime dt12 = DateTime.Parse(DateTime.Today.Year + "-" + i.ToString("00") + "-" + 1, CultureInfo.CurrentCulture);

                //MessageBox.Show(dt12.ToString("MMM"));
                chart1.Series["Student"].Points.AddXY("" + dt12.ToString("MMM") + "", count);
                chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;

                MySqlCommand cmd2 = new MySqlCommand("Select count(lb_id) from tblogbook where Patient_type = 'Grade School' and date_in between '" + DateTime.Today.Year + "-" + i.ToString("00") + "-" + "01" + "' and '" + DateTime.Today.Year + "-" + i.ToString("00") + "-" + DateTime.DaysInMonth(DateTime.Today.Year, i) + "'", clinic.conn);
                count2 = Convert.ToInt32(cmd2.ExecuteScalar());

                chart1.Series["Employee"].Points.AddXY("" + dt12.ToString("MMM") + "", count2);
            }
            clinic.conn.Close();
        }

        public void loaddonutMonth()
        {
            int Stud = 0, Emp = 0;
            foreach (var series in donut1.Series)
            {
                series.Points.Clear();
            }
            clinic.conn.Open();
            for (int i = 1; i <= 12; i++)
            {
               
                MySqlCommand cmd = new MySqlCommand("Select count(lb_id) from tblogbook where patient_type = 'Grade School' and date_in between '" + DateTime.Today.Year + "-" + i.ToString("00") + "-" + "01" + "' and '" + DateTime.Today.Year + "-" + i.ToString("00") + "-" + DateTime.DaysInMonth(DateTime.Today.Year, i) + "' or " +
                            "patient_type = 'Junior High' and date_in  between '" + DateTime.Today.Year + "-" + i.ToString("00") + "-" + "01" + "' and '" + DateTime.Today.Year + "-" + i.ToString("00") + "-" + DateTime.DaysInMonth(DateTime.Today.Year, i) + "' or " +
                            "patient_type = 'Senior High' and date_in between '" + DateTime.Today.Year + "-" + i.ToString("00") + "-" + "01" + "' and '" + DateTime.Today.Year + "-" + i.ToString("00") + "-" + DateTime.DaysInMonth(DateTime.Today.Year, i) + "' or " +
                            "patient_type = 'College' and date_in  between '" + DateTime.Today.Year + "-" + i.ToString("00") + "-" + "01" + "' and '" + DateTime.Today.Year + "-" + i.ToString("00") + "-" + DateTime.DaysInMonth(DateTime.Today.Year, i) + "'", clinic.conn);
                Int32 count1 = Convert.ToInt32(cmd.ExecuteScalar());

                Stud += count1;

                MySqlCommand cmd2 = new MySqlCommand("Select count(lb_id) from tblogbook where Patient_type = 'Grade School' and date_in between '" + DateTime.Today.Year + "-" + i.ToString("00") + "-" + "01" + "' and '" + DateTime.Today.Year + "-" + i.ToString("00") + "-" + DateTime.DaysInMonth(DateTime.Today.Year, i) + "'", clinic.conn);
                Int32 count2 = Convert.ToInt32(cmd2.ExecuteScalar());

                Emp += count2;
            }
            



            donut1.Series["patient"].Points.AddXY("" + Stud, Stud);
            donut1.Series["patient"].Points.AddXY("" + Emp, Emp);
            clinic.conn.Close();
        }

        public void Loadbargraphweek()
        {
            DayOfWeek hey1 = DateTime.Today.DayOfWeek;
            int daystill1 = hey1 - DayOfWeek.Monday;
            DateTime current1 = DateTime.Now.AddDays(-daystill1 - startweek);

            DateTime dt1 = new DateTime(current1.Day);
            //MessageBox.Show(current1.ToShortDateString() + " " + current1.Day + "/" + current1.Month);

            DayOfWeek hey = DateTime.Today.DayOfWeek;
            int daystill = hey - DayOfWeek.Saturday;
            DateTime current = DateTime.Now.AddDays(-daystill - endweek);


            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }

            //DateTime dt = new DateTime(current.Day);


            //MessageBox.Show ( DateTimeFormatInfo.CurrentInfo.GetMonthName(current1.Month).ToUpper() + " " + current1.Day + " - " + current.Day + " / " + current.Year);



            for (int i = current1.Day; i <= current.Day; i++)
            {
                if (clinic.conn.State == ConnectionState.Open)
                {
                    clinic.conn.Close();
                }
                clinic.conn.Open();

                double day = i, month1 = current1.Month, yr = current1.Year;

                

                MySqlCommand cmd = new MySqlCommand("Select count(lb_id) from tblogbook where patient_type = 'Grade School' and date_in = '" + current1.Year + "-" + current1.Month.ToString("00") + "-" + i.ToString("00") + "' or " +
                    "patient_type = 'Junior High' and date_in  = '" + current1.Year + "-" + current1.Month.ToString("00") + "-" + i.ToString("00") + "' OR patient_type = 'Senior High' and date_in  = '" + current1.Year + "-" + current1.Month.ToString("00") + "-" + i.ToString("00") + "' or " +
                    "patient_type = 'College' and date_in = '" + current1.Year + "-" + current1.Month.ToString("00") + "-" +  i.ToString("00") + "'", clinic.conn);
                Int32 count1 = Convert.ToInt32(cmd.ExecuteScalar());

                //listBox1.Items.Add(day + "/" + month1 + "/" + yr + "  -----  " + count1);

                DateTime dt12 = DateTime.Parse(current1.Year + "-" + current1.Month + "-" + i, CultureInfo.CurrentCulture);

                chart1.Series["Student"].Points.AddXY("" + dt12.ToString("dddd") + "", count1);


                MySqlCommand cmd2 = new MySqlCommand("Select count(lb_id) from tblogbook where patient_type = '" + "Employee" + "' and date_in = '" + current1.Year + "-" + current1.Month.ToString("00") + "-" + i.ToString("00") + "'", clinic.conn);
                Int32 count2 = Convert.ToInt32(cmd2.ExecuteScalar());


                DateTime dt13 = DateTime.Parse(current1.Year + "-" + current1.Month + "-" + i, CultureInfo.CurrentCulture);

                chart1.Series["Employee"].Points.AddXY("" + dt13.ToString("dddd") + "", count2);
                clinic.conn.Close();
            }

        }

        public void loaddonutWeek()
        {
            DayOfWeek hey1 = DateTime.Today.DayOfWeek;
            int daystill1 = hey1 - DayOfWeek.Monday;
            DateTime current1 = DateTime.Now.AddDays(-daystill1 - startweek);

            DateTime dt1 = new DateTime(current1.Day);
            //MessageBox.Show(current1.ToShortDateString() + " " + current1.Day + "/" + current1.Month);

            DayOfWeek hey = DateTime.Today.DayOfWeek;
            int daystill = hey - DayOfWeek.Saturday;
            DateTime current = DateTime.Now.AddDays(-daystill - endweek);

            //DateTime dt = new DateTime(current.Day);
            foreach (var series in donut1.Series)
            {
                series.Points.Clear();
            }

            //MessageBox.Show(DateTimeFormatInfo.CurrentInfo.GetMonthName(current1.Month).ToUpper() + " " + current1.Day + " - " + current.Day + " / " + current.Year);

            int Stud = 0, Emp = 0;

            for (int i = current1.Day; i <= current.Day; i++)
            {
                if (clinic.conn.State == ConnectionState.Open)
                {
                    clinic.conn.Close();
                }
                clinic.conn.Open();

                double day = i, month1 = current1.Month, yr = current1.Year;



                MySqlCommand cmd = new MySqlCommand("Select count(lb_id) from tblogbook where patient_type = 'Grade School' and date_in = '" + current1.Year + "-" + current1.Month.ToString("00") + "-" + i.ToString("00") + "' or " +
                    "patient_type = 'Junior High' and date_in  = '" + current1.Year + "-" + current1.Month.ToString("00") + "-" + i.ToString("00") + "' OR patient_type = 'Senior High' and date_in  = '" + current1.Year + "-" + current1.Month.ToString("00") + "-" + i.ToString("00") + "' or " +
                    "patient_type = 'College' and date_in = '" + current1.Year + "-" + current1.Month.ToString("00") + "-" + i.ToString("00") + "'", clinic.conn);
                Int32 count1 = Convert.ToInt32(cmd.ExecuteScalar());

                //listBox1.Items.Add(day + "/" + month1 + "/" + yr + "  -----  " + count1);

                //DateTime dt12 = DateTime.Parse(i + "/" + current1.Month + "/" + current1.Year, CultureInfo.CurrentCulture);

                //chart1.Series["Student"].Points.AddXY("" + dt12.ToString("dddd") + "", count1);

                Stud += count1; 

                MySqlCommand cmd2 = new MySqlCommand("Select count(lb_id) from tblogbook where patient_type = '" + "Employee" + "' and date_in = '" + current1.Year + "-" + current1.Month.ToString("00") + "-" + i.ToString("00") + "'", clinic.conn);
                Int32 count2 = Convert.ToInt32(cmd2.ExecuteScalar());


                //DateTime dt13 = DateTime.Parse(i + "/" + current1.Month + "/" + current1.Year, CultureInfo.CurrentCulture);

                //chart1.Series["Employee"].Points.AddXY("" + dt13.ToString("dddd") + "", count2);

                Emp += count2;

                clinic.conn.Close();
            }

            donut1.Series["patient"].Points.AddXY("" + Stud, Stud);
            donut1.Series["patient"].Points.AddXY("" + Emp, Emp);

        }

        void loadfinding()
        {
            clinic.conn.Open();
            MySqlCommand cmd = new MySqlCommand();

            cmd = new MySqlCommand("Select count(id) from tblfindings where deseases_name = 'Cough' or deseases_name = 'cough' or deseases_name = 'COUGH' or deseases_name = 'ubo' or deseases_name = 'Ubo' or deseases_name = 'UBO'", clinic.conn);
            int Cough = Convert.ToInt32(cmd.ExecuteScalar());
            lblcought.Text = Cough.ToString("00");

            cmd = new MySqlCommand("Select count(id) from tblfindings where deseases_name = 'Cold' or deseases_name = 'cold' or deseases_name = 'COLD' or deseases_name = 'sipon' or deseases_name = 'Sipon' or deseases_name = 'SIPON'", clinic.conn);
            int Cold = Convert.ToInt32(cmd.ExecuteScalar());
            lblcold.Text = Cold.ToString("00");

            cmd = new MySqlCommand("Select count(id) from tblfindings where deseases_name = 'Allergy' or deseases_name = 'allergy' or deseases_name = 'ALLERGY'", clinic.conn);
            int Allergy = Convert.ToInt32(cmd.ExecuteScalar());
            lblallergy.Text = Allergy.ToString("00");

            cmd = new MySqlCommand("Select count(id) from tblfindings where deseases_name = 'Toothache' or deseases_name = 'toothache' or deseases_name = 'Toothache'", clinic.conn);
            int Toothache = Convert.ToInt32(cmd.ExecuteScalar());
            lbltooth.Text = Toothache.ToString("00");

            clinic.conn.Close();
        }

        void doable (object sender, EventArgs e)
        {
            (this.Owner as Main).Enabled = true;
            (this.Owner as Main).Focus();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ControlDashboard.listdesease ld = new ControlDashboard.listdesease();
            (this.Owner as Main).Enabled = false;
            ld.Show();
            ld.Closed += new EventHandler(doable);
            clinic.actionuser("Click " + linkLabel1.Text, Main.id, Main.name, DateTime.Now.ToShortTimeString(), DateTime.Today.ToShortDateString());
        }

        //Account Show

        void acc()
        {
            flpstuff.Controls.Clear();
            clinic.conn.Open();
            MySqlCommand cmd = new MySqlCommand("Select count(no) from tbllogin where date_in = '" + DateTime.Today.ToShortDateString() + "'", clinic.conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            cmd = new MySqlCommand("Select distinct(Full_name) from tbllogin where date_in = '" + DateTime.Today.ToShortDateString() + "'", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            ControlDashboard.listuser[] ls = new ControlDashboard.listuser[count];

            for (int i = 0; i<count; i++)
            {
                if (dr.Read())
                {
                    ls[i] = new ControlDashboard.listuser();
                    ls[i].lblname.Text = dr[0].ToString();

                    if (flpstuff.Controls.Count < 0)
                    {
                        flpstuff.Controls.Clear();
                    }
                    else
                        flpstuff.Controls.Add(ls[i]);
                }
            }
            clinic.conn.Close();
        }

        void med()
        {
            
            clinic.conn.Open();
            MySqlCommand cmd = new MySqlCommand("Select count(uniqueproductlist.name) from uniqueproductlist INNER JOIN productstocks where uniqueproductlist.code = productstocks.code ORDER by productstocks.consumed DESC limit 5", clinic.conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            //cmd = new MySqlCommand("Select uniqueproductlist.name, productstocks.consumed from uniqueproductlist INNER JOIN productstocks where uniqueproductlist.code = productstocks.code ORDER by productstocks.consumed Group by uniqueproductlist.name DESC LIMIT 5", clinic.conn);
            cmd = new MySqlCommand("Select uniqueproductlist.name, sum(productstocks.consumed) as 'Consumed' from uniqueproductlist INNER JOIN productstocks where uniqueproductlist.code = productstocks.code and productstocks.consumed > 0 Group by uniqueproductlist.name ORDER by consumed DESC LIMIT 5", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            for (int i = 0; i < count; i++)
            {
                if (dr.Read())
                {
                    donut2.Series["med"].Points.Add(Convert.ToInt32(dr[1].ToString()));
                    donut2.Series["med"].Points[i].AxisLabel = dr[0].ToString();
                    donut2.Series["med"].Points[i].LegendText = dr[0].ToString();
                    donut2.Series["med"].Points[i].Label = dr[1].ToString();

                }
            }

            clinic.conn.Close();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            activeButton(sender);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            activeButton(sender);
        }

        void outstack()
        {
            clinic.conn.Open();
            MySqlCommand cmd = new MySqlCommand("Select count(uniqueproductlist.code) from uniqueproductlist INNER JOIN productstocks where uniqueproductlist.code = productstocks.code and productstocks.stocks = '0'", clinic.conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            cmd = new MySqlCommand("Select uniqueproductlist.code, uniqueproductlist.name, productstocks.expiry_date, productstocks.stocks from uniqueproductlist INNER JOIN productstocks where uniqueproductlist.code = productstocks.code and productstocks.stocks = '0'", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            ControlDashboard.listoutstack[] os = new ControlDashboard.listoutstack[count];

            for(int i = 0; i < count; i++)
            {
                if (dr.Read())
                {
                    flpmed.Visible = true;
                    os[i] = new ControlDashboard.listoutstack();
                    os[i].lblcode.Text = dr[0].ToString();
                    os[i].lblname.Text = dr[1].ToString();
                    os[i].lbldexp.Text = Convert.ToDateTime(dr[2]).ToShortDateString();
                    os[i].lblcount.Text = dr[3].ToString();

                    if (flpmed.Controls.Count < 0)
                    {
                        flpmed.Controls.Clear();
                    }
                    else
                        flpmed.Controls.Add(os[i]);
                }
            }

            if (count == 0)
            {
                Label lb = new Label();
                lb.Font = new System.Drawing.Font("Segoe UI Variable Display semi Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lb.ForeColor = Color.Gray;
                lb.Dock = DockStyle.Fill;
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.Text = "No Data yet!";
                bc.Controls.Add(lb);
                flpmed.Visible = false;
            }
            clinic.conn.Close();
        }

        void crit()
        {
            clinic.conn.Open();
            MySqlCommand cmd = new MySqlCommand("Select count(uniqueproductlist.code) from uniqueproductlist INNER JOIN productstocks where uniqueproductlist.code = productstocks.code and productstocks.stocks > 0 and productstocks.stocks <= 5 ORDER by productstocks.stocks Asc limit 5", clinic.conn);
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            cmd = new MySqlCommand("Select uniqueproductlist.code, uniqueproductlist.name, productstocks.expiry_date, productstocks.stocks from uniqueproductlist INNER JOIN productstocks where uniqueproductlist.code = productstocks.code  and productstocks.stocks > 0 and productstocks.stocks <= 5 ORDER by productstocks.stocks Asc limit 5", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            ControlDashboard.listoutstack[] os = new ControlDashboard.listoutstack[count];

            for (int i = 0; i < count; i++)
            {
                if (dr.Read())
                {
                    flpmed.Visible = true;
                    os[i] = new ControlDashboard.listoutstack();
                    os[i].lblcode.Text = dr[0].ToString();
                    os[i].lblname.Text = dr[1].ToString();
                    os[i].lbldexp.Text = Convert.ToDateTime(dr[2]).ToShortDateString();
                    os[i].lblcount.Text = dr[3].ToString();

                    if (flpmed.Controls.Count < 0)
                    {
                        flpmed.Controls.Clear();
                    }
                    else
                        flpmed.Controls.Add(os[i]);
                }
            }
            if (count == 0)
            {
                Label lb = new Label();
                lb.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lb.ForeColor = Color.Gray;
                lb.Dock = DockStyle.Fill;
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.Text = "No Data yet!";
                bc.Controls.Add(lb);
                flpmed.Visible = false;
            }
            clinic.conn.Close();
        }
    }
}
