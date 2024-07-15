using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewClinic.ControlLogbook
{
    public partial class views : UserControl
    {
        public static string discharge = "", id, catego, lgid, time_out = "";
        public string lgid2 = "";

        public views()
        {
            InitializeComponent();
        }

        private void views_Load(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            discharge = "out";
            lgid = lgid2;
            id = lblid.Text;
            time_out = lblout.Text;
            catego = lblcatego.Text;
        }

        private void iconedit_Click(object sender, EventArgs e)
        {
            discharge = "Edit";
            lgid = lgid2;
            id = lblid.Text;
            catego = lblcatego.Text;
        }
    }
}
