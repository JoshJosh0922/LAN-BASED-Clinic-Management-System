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

namespace NewClinic.ControlAdd
{
    public partial class MedicalProfile : UserControl
    {
        public String condition = "";
        int check = 0, uncheck = 0;
        public static string id = "";

        public MedicalProfile()
        {
            InitializeComponent();
        }

        private void MedicalProfile_Load(object sender, EventArgs e)
        {
            if (ControlProfile.ProfileForm.id != "")
            {
                id = ControlProfile.ProfileForm.id;
                medicH(id);
            }
        }

        public void getcheck()
        {
            foreach (Control cc in s.Controls)
            {
                //MessageBox.Show("" + cc);
                if (cc is CheckBox)
                {
                    CheckBox cb = (CheckBox)cc;
                    if (cb.Checked)
                    {
                        pother.Enabled = true;
                        checkbox1(cb);
                        //MessageBox.Show("Hey" + cb.Name.Equals("cb1") +  " " + condition);
                    }
                }
            }
        }

        void checkbox1(CheckBox cb)
        {
            switch (cb.Name)
            {
                case "cb1":
                    condition = lb1.Text + "!" + condition;
                    break;
                case "cb2":
                    condition = lb2.Text + "!" + condition;
                    break;
                case "cb3":
                    condition = lb3.Text + "!" + condition;
                    break;
                case "cb4":
                    condition = lb4.Text + "!" + condition;
                    break;
                case "cb5":
                    condition = lb5.Text + "!" + condition;
                    break;
                case "cb6":
                    condition = lb6.Text + "!" + condition;
                    break;
                case "cb7":
                    condition = lb7.Text + "!" + condition;
                    break;
                case "cb8":
                    condition = lb8.Text + "!" + condition;
                    break;
                case "cb9":
                    condition = lb9.Text + "!" + condition;
                    break;
                case "cb10":
                    condition = lb10.Text + "!" + condition;
                    break;
                case "cb11":
                    condition = lb11.Text + "!" + condition;
                    break;
                case "cb12":
                    condition = lb12.Text + "!" + condition;
                    break;
                case "cb13":
                    condition = lb13.Text + "!" + condition;
                    break;
                case "cb14":
                    condition = lb14.Text + "!" + condition;
                    break;
                case "cb15":
                    condition = lb15.Text + "!" + condition;
                    break;
            }

            //-------------------CoboBox 16-36

            switch (cb.Name)
            {
                case "cb16":
                    condition = lb16.Text + "!" + condition;
                    break;
                case "cb17":
                    condition = lb17.Text + "!" + condition;
                    break;
                case "cb18":
                    condition = lb18.Text + "!" + condition;
                    break;
                case "cb19":
                    condition = lb19.Text + "!" + condition;
                    break;
                case "cb20":
                    condition = lb20.Text + "!" + condition;
                    break;
                case "cb21":
                    condition = lb21.Text + "!" + condition;
                    break;
                case "cb22":
                    condition = lb22.Text + "!" + condition;
                    break;
                case "cb23":
                    condition = lb23.Text + "!" + condition;
                    break;
                case "cb24":
                    condition = lb24.Text + "!" + condition;
                    break;
                case "cb25":
                    condition = lb25.Text + "!" + condition;
                    break;
                case "cb26":
                    condition = lb26.Text + "!" + condition;
                    break;
                case "cb27":
                    condition = lb27.Text + "!" + condition;
                    break;
                case "cb28":
                    condition = lb28.Text + "!" + condition;
                    break;
                case "cb29":
                    condition = lb29.Text + "!" + condition;
                    break;
                case "cb30":
                    condition = lb30.Text + "!" + condition;
                    break;
                case "cb31":
                    condition = lb31.Text + "!" + condition;
                    break;
                case "cb32":
                    condition = lb32.Text + "!" + condition;
                    break;
                case "cb33":
                    condition = lb33.Text + "!" + condition;
                    break;
                case "cb34":
                    condition = lb34.Text + "!" + condition;
                    break;
                case "cb35":
                    condition = lb35.Text + "!" + condition;
                    break;
                case "cb36":
                    condition = lb36.Text + "!" + condition;
                    break;
            }
        }

        //-----------------------------------------------------------------------------Check box Properties 2-------------------------------------------

        private void checkb2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkb2.Checked)
            {
                checkb1.Checked = false;
                pallergic.Enabled = false;
            }
            else if (checkb2.Checked == false)
            {
                checkb1.Checked = true;
                pallergic.Enabled = true;
            }
        }

        private void checkb4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkb4.Checked)
            {
                checkb3.Checked = false;
                pparent.Enabled = false;
            }
            else if (checkb4.Checked == false)
            {
                checkb3.Checked = true;
                pparent.Enabled = true;
            }
        }

        private void checkb1_OnChange(object sender, EventArgs e)
        {

            if (checkb1.Checked)
            {
                checkb2.Checked = false;
                pallergic.Enabled = true;
            }
            else if (checkb1.Checked == false)
            {
                checkb2.Checked = true;
                pallergic.Enabled = false;
            }
        }

        private void checkb3_OnChange(object sender, EventArgs e)
        {
            if (checkb3.Checked)
            {
                checkb4.Checked = false;
                pparent.Enabled = true;
            }
            else if (checkb1.Checked == false)
            {
                checkb4.Checked = true;
                pparent.Enabled = false;
            }
        }

        public void clear()
        {
            cb1.Checked = false;
            cb2.Checked = false;
            cb3.Checked = false;
            cb4.Checked = false;
            cb5.Checked = false;
            cb6.Checked = false;
            cb7.Checked = false;
            cb8.Checked = false;
            cb9.Checked = false;
            cb10.Checked = false;
            cb11.Checked = false;
            cb12.Checked = false;
            cb13.Checked = false;
            cb14.Checked = false;
            cb15.Checked = false;
            cb16.Checked = false;
            cb17.Checked = false;
            cb18.Checked = false;
            cb19.Checked = false;
            cb20.Checked = false;
            cb21.Checked = false;
            cb22.Checked = false;
            cb23.Checked = false;
            cb24.Checked = false;
            cb25.Checked = false;
            cb26.Checked = false;
            cb27.Checked = false;
            cb28.Checked = false;
            cb29.Checked = false;
            cb30.Checked = false;
            cb31.Checked = false;
            cb32.Checked = false;
            cb33.Checked = false;
            cb34.Checked = false;
            cb35.Checked = false;
            cb36.Checked = false;
            checkb1.Checked = false;
            checkb2.Checked = false;
            checkb3.Checked = false;
            checkb4.Checked = false;
            rt1.Clear();
            rt2.Clear();
            rt3.Clear();

        }

        public void clear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void cb1_CheckedChanged(object sender, EventArgs e)
        {
            select();
            if (uncheck != 36)
            {
                pother.Enabled = true;
                uncheck = 0;
            }
            else
            {

                pother.Enabled = false;
            }
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox1.Checked)
            {
                pother.Enabled = true;
            }
            else
            {
                pother.Enabled = false;
            }
        }

        void select()
        {
            foreach (Control cc in s.Controls)
            {
                if (cc is CheckBox)
                {
                    CheckBox cb = (CheckBox)cc;
                    if (cb.Checked == false)
                    {
                        uncheck = ++uncheck;
                    }
                }
            }
        }


        public void setcheck(String desease)
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
                    setcheck(word[i]);
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
