﻿using System;
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
    public partial class viewpadmission : UserControl
    {
        public static int id = 0;
        public string id2 = "";

        public viewpadmission()
        {
            InitializeComponent();
        }

        private void viewpadmission_Load(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            id = int.Parse(lblid.Text);
        }
    }
}
