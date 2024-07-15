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
    public partial class smalladmission : UserControl
    {
        public static String category = "", adid = "";
        public static int id = 0;
        public String id2 = "", category2 = "", adid2 = "";

        public smalladmission()
        {
            InitializeComponent();
        }

        private void smalladmission_Load(object sender, EventArgs e)
        {
            id = int.Parse(lblid.Text);
            category = category2;
        }
    }
}
