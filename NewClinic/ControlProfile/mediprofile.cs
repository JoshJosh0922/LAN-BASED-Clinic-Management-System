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

namespace NewClinic.ControlProfile
{
    public partial class mediprofile : UserControl
    {
        public mediprofile()
        {
            InitializeComponent();
        }

        private void mediprofile_Load(object sender, EventArgs e)
        {

        }

        public void check(String desease)
        {
            switch (desease)
            {
                case "Asthma":
                    cb1.Checked = true;
                    break;
                case "Blood Disorder":
                    cb2.Checked = true;
                    break;
                case "Cancer/Tumor":
                    cb3.Checked = true;
                    break;
                case "Chickenpox":
                    cb4.Checked = true;
                    break;
                case "Chronic Cough":
                    cb5.Checked = true;
                    break;
                case "Dengue Fever":
                    cb6.Checked = true;
                    break;
                case "Depression":
                    cb7.Checked = true;
                    break;
                case "Diabetes Mellitus":
                    cb8.Checked = true;
                    break;
                case "Dizziness":
                    cb9.Checked = true;
                    break;
                case "Far trouble or deafness":
                    cb10.Checked = true;
                    break;
                case "Endocrine Disorders":
                    cb11.Checked = true;
                    break;
                case "Fainting Spells":
                    cb12.Checked = true;
                    break;
                case "Fracture/Dislocation":
                    cb13.Checked = true;
                    break;
                case "Frequent Headache":
                    cb14.Checked = true;
                    break;
                case "Head or neck injury":
                    cb15.Checked = true;
                    break;
                case "Heart trouble":
                    cb16.Checked = true;
                    break;
                case "Hernia":
                    cb17.Checked = true;
                    break;
                case "High blood pressure":
                    cb18.Checked = true;
                    break;
                case "Hospitalization":
                    cb19.Checked = true;
                    break;
                case "Kidney or Bladder trouble":
                    cb20.Checked = true;
                    break;
                case "Liver, Gall bladder Disease/Jaundice":
                    cb21.Checked = true;
                    break;
                case "Malaria":
                    cb22.Checked = true;
                    break;
                case "Mental Disorder":
                    cb23.Checked = true;
                    break;
                case "Nose or Throat trouble":
                    cb24.Checked = true;
                    break;
                case "Operation":
                    cb25.Checked = true;
                    break;
                case "Other Lung Diseases":
                    cb26.Checked = true;
                    break;
                case "Rheumatic Fever":
                    cb27.Checked = true;
                    break;
                case "Rheumatism, Joint or Back trouble":
                    cb28.Checked = true;
                    break;
                case "Seizure/Epilepsy":
                    cb29.Checked = true;
                    break;
                case "Sexuality transmitted disease":
                    cb30.Checked = true;
                    break;
                case "Skin problem":
                    cb31.Checked = true;
                    break;
                case "Stomach pan or Ulcer":
                    cb32.Checked = true;
                    break;
                case "Trachoma or other eye trouble":
                    cb33.Checked = true;
                    break;
                case "Tropical disease":
                    cb34.Checked = true;
                    break;
                case "Typhoid or Paratyphoid fever":
                    cb35.Checked = true;
                    break;
                case "Tuberculosis":
                    cb36.Checked = true;
                    break;

            }
        }

        public void medicH(String idno)
        {
            clinic.conn.Open();
            MySqlCommand cmd = new MySqlCommand("Select person_id, Diseases, Other, Allergy, Medic_Condition from tblmedic_history where No = '" + idno + "' or person_id = '" + idno + "'", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                String disease = dr[1].ToString() + "";
                String[] word;
                word = disease.Split('!');

                for (int i = 0; i < word.Length; i++)
                {
                    //MessageBox.Show(word[i]);
                    check(word[i]);
                }

                if (word.Length > 0)
                {
                    rt3.Text = dr[2].ToString();
                }
                else if (dr[2].ToString().Replace(" ", "") != "")
                {
                    rt3.Text = dr[2].ToString();
                }

                if (dr[3].ToString() != "")
                {
                    rt1.Text = dr[3].ToString();
                    checkb1.Checked = true;
                }
                else
                {
                    checkb2.Checked = true;
                }

                if (dr[4].ToString() != "")
                {
                    rt2.Text = dr[4].ToString();
                    checkb3.Checked = true;
                }
                else
                {
                    checkb4.Checked = true;
                }
            }

            clinic.conn.Close();
        }

    }
}
