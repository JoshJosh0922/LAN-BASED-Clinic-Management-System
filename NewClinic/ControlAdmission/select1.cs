using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewClinic.ControlAdmission
{
    public partial class select1 : UserControl
    {
        public static String id, category, name, logbookid, datein, timein, nurse_name;
        public string lb, nurse_name1;

        public select1()
        {
            InitializeComponent();
        }


        private void select1_Load(object sender, EventArgs e)
        {

        }


        private void iconButton1_Click(object sender, EventArgs e)
        {
            id = lblid.Text;
            category = lblcatego.Text;
            name = lblname.Text;
            logbookid = lb;
            datein = lbldate.Text;
            timein = lblin.Text;
            nurse_name = lblattended.Text;
        }

        
    }
}
