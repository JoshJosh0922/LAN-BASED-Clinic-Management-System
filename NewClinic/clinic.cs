using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace NewClinic
{
    class clinic
    {
        public static String server = "", id = "", pass = "";
        public static MySqlConnection conn2;

        public static MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password=; database=nclinic1");



        //public static void Connect(String ConnectionString)
        //{
        //    try
        //    {
        //        conn2.Open();
        //        MySqlCommand cmd = new MySqlCommand("Select * from  tblserver where num = '" + ConnectionString + "'", conn2);
        //        MySqlDataReader dr = cmd.ExecuteReader();

        //        if (dr.Read())
        //        {
        //            MessageBox.Show("gee");
        //            id = dr[1].ToString();
        //            server = dr[2].ToString();
        //            pass = dr[3].ToString();

        //            conn = new MySqlConnection("server=" + server + ";user id=" + id + ";password=" + "" + "; database=nclinic1");
        //        }
        //        else
        //        {
        //            server = "localhost";
        //            id = "root";
        //            pass = "";

        //            conn = new MySqlConnection("server=" + server + ";user id=" + id + ";password=" + "" + "; database=nclinic1");
        //        }
        //        conn2.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error connection to server: " + ex.Message);
        //    }
        //}

        //Old Connection

        public static void connec()
        {
            try
            {
                conn2.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from  tblserver", conn2);
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    server = dr[1].ToString();
                    id = dr[2].ToString();
                    pass = dr[3].ToString();
                }
                
                    server = "localhost";
                    id = "root";
                    pass = "";

                conn2.Close();

                string connectionString = "server=" + server + ";user id=" + id + ";password=" + "" + "; database=nclinic1";
                conn = new MySqlConnection(connectionString);


                //MessageBox.Show("Function created successfully. " + " " + connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connection to server: " + ex.Message);
            }
        }

        public static void connec2(String id2)
        {
            try
            {
                conn2.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from  tblserver where num = '" + id2 + "'", conn2);
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    server = dr[1].ToString();
                    id = dr[2].ToString();
                    pass = dr[3].ToString();
                }

                if (server.Replace(" ", "") == "" && id.Replace(" ", "") == "" && pass.Replace(" ", "") == "")
                {
                    server = "localhost";
                    id = "root";
                    pass = "";

                    
                }
                conn2.Close();

                string connectionString = "server=" + server + ";user id=" + id + ";password=" + "" + "; database=nclinic1";
                conn = new MySqlConnection(connectionString);


                //MessageBox.Show("Function created successfully. " + " " + connectionString + " 09" + id2);
                MessageBox.Show("Connection created successfully. ", "Clinic System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connection to server: " + ex.Message);
            }
        }



        //public static MySqlConnection conn = new MySqlConnection("server=" +server+ ";user id=" +id+ ";password=" +pass+ "; database=nclinic1");
        //public static MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password=; database=nclinic1");

        public static  void actionuser(String _action, String userID, String Username, String _Time, String _Date)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Insert into tblaction_user values('" + "" + "','" + userID + "','" + Username + "','" + _action + "','" + _Time + "','" + _Date + "')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Archive COde

        public static void insertArchive(String id)
        {
            if(conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            String personID = "", fname = "", lname = "", mname = "", suffix = "", gender = "", bplace = "", bday = "", natio = "", blood = "", addres = "", email = "", contact = "", Patient_type = "";
            byte[] pic = null;

            clinic.conn.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from tblprofile where person_id = '" + id + "'", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                personID = dr[0].ToString();
                fname = dr[1].ToString();
                mname = dr[2].ToString();
                lname = dr[3].ToString();
                suffix = dr[4].ToString();
                gender = dr[5].ToString();
                bplace = dr[6].ToString();
                bday = dr[7].ToString();
                natio = dr[8].ToString();
                blood = dr[9].ToString();
                addres = dr[10].ToString();
                email = dr[11].ToString();
                contact = dr[12].ToString();
                Patient_type = dr[13].ToString();
                if (dr[14].ToString() != "")
                {
                    pic = (byte[])dr[14];
                }

            }

            dr.Close();

            MySqlCommand cmd2 = new MySqlCommand("Insert into tblArchive values ('', '" + personID + "', '" + fname + "', '" + mname + "', '" + lname + "', '" + suffix + "', '" +
                gender + "', '" + bplace + "', '" + bday + "', '" + natio + "', '" + blood + "', '" + addres + "', '" + email + "', '" + contact + "', '" + Patient_type + "', @img, '"+ DateTime.Today.ToString("yyyy-MM-dd") +"')", conn);
            cmd2.Parameters.AddWithValue("@img", pic);
            cmd2.ExecuteNonQuery();


            clinic.conn.Close();
            
        }

        public static void restor(String id)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }

            String personID = "", fname = "", lname = "", mname = "", suffix = "", gender = "", bplace = "", bday = "", natio = "", blood = "", addres = "", email = "", contact = "", Patient_type = "";
            byte[] pic = null;

            clinic.conn.Open();
            MySqlCommand cmd = new MySqlCommand("Select * from tblarchive where person_id = '" + id + "'", clinic.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                personID = dr[1].ToString();
                fname = dr[2].ToString();
                mname = dr[3].ToString();
                lname = dr[4].ToString();
                suffix = dr[5].ToString();
                gender = dr[6].ToString();
                bplace = dr[7].ToString();
                bday = dr[8].ToString();
                natio = dr[9].ToString();
                blood = dr[10].ToString();
                addres = dr[11].ToString();
                email = dr[12].ToString();
                contact = dr[13].ToString();
                Patient_type = dr[14].ToString();
                if (dr[15].ToString() != "")
                {
                    pic = (byte[])dr[15];
                }

            }

            dr.Close();

            MySqlCommand cmd2 = new MySqlCommand("Insert into tblprofile values('" + personID + "', '" + fname + "', '" + mname + "', '" + lname + "', '" + suffix + "', '" +
                gender + "', '" + bplace + "', '" + bday + "', '" + natio + "', '" + blood + "', '" + addres + "', '" + email + "', '" + contact + "', '" + Patient_type + "', @img)", conn);
            cmd2.Parameters.AddWithValue("@img", pic);
            cmd2.ExecuteNonQuery();

            MySqlCommand cmd3 = new MySqlCommand("Delete from tblarchive where person_id = '" + id + "'", clinic.conn);
            cmd3.ExecuteNonQuery();

            clinic.conn.Close();
        }


       //Medic

        public static string med = "", stock = "", medid = "", expdate = "";
    }
}
