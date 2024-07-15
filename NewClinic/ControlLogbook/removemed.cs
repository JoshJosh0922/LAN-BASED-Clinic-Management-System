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
    public partial class removemed : Form
    {

        public static string remove, newmed;

        public removemed()
        {
            InitializeComponent();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            (this.Owner as Arrive).Enabled = true;
            iconButton1.IconColor = Color.Red;
            this.Close();
        }

        private void iconButton1_MouseHover(object sender, EventArgs e)
        {
            iconButton1.IconColor = Color.LightCoral;
        }

        private void iconButton1_MouseLeave(object sender, EventArgs e)
        {
            iconButton1.IconColor = Color.White;
        }

        private void removemed_Load(object sender, EventArgs e)
        {
            getmed();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            (this.Owner as Arrive).Enabled = true;
            String[] medic = remove.Split(',');

            for (int i = 0; i < medic.Length; i++)
            {
                //MessageBox.Show(medic[i] +  "   =  " + newmed + "    =  " + cbmed.SelectedItem.ToString());
                if (medic[i] != cbmed.SelectedItem.ToString())
                {
                    if (newmed == "")
                    {
                        newmed = medic[i];
                    }
                    else
                    {
                        newmed = newmed + "," + medic[i];
                    }
                    
                    
                }
            }
            this.Close();
            
        }

        void getmed()
        {
            remove = Arrive.medic;

            newmed = "";

            String[] medic = remove.Split(',');

            for (int i = 0; i <medic.Length; i++)
            {
                if (medic[i] != "")
                {
                    cbmed.Items.Add(medic[i]);
                }
            }
        }


    }
}
