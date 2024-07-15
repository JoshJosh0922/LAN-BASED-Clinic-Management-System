using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;
using WindowsFormsApp11;
using BCrypt.Net;



namespace WindowsFormsApp11
{


    public partial class Form1 : Form
    {
        // declare the connection string
        string connectionString = "server=localhost;user id=root;password=;database=nclinic1;sslMode=none";

        // declare the connection object
        MySqlConnection connection;
        public string OldPassword
        {
            get { return textBox8.Text; }
        }

        public string NewPassword
        {
            get { return textBox9.Text; }
        }

        public Form1()
        {
            InitializeComponent();
        }
        private MySqlConnection conn;



        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection(connectionString);
            DisplayDataInTextBoxes();




        }
        private void Form1_Load()
        {
            conn = new MySqlConnection();
            try
            {
                conn.ConnectionString = "server=localhost;user id=root;password=;database=nclinic1;sslMode=none";
                conn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            conn.Close();

        }
        void name()
        {

        }


        private void DisplayDataInTextBoxes()
        {
            // Create a connection to the MySQL database
            string connectionString = "server=localhost;user id=root;password=;database=nclinic1;sslMode=none";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            // Create a SQL query that retrieves the data you want to display
            string query = "SELECT * FROM tblacc WHERE person_id = @id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", 1); // Set the parameter value to the id of the row you want to retrieve

            // Execute the query and retrieve the results
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                // Use the reader to populate the textboxes with the retrieved data
                textBox1.Text = reader.GetString("Usertype");
                textBox7.Text = reader.GetString("person_id");
                textBox2.Text = reader.GetString("Full_Name");
                textBox3.Text = reader.GetString("Contact");
                textBox4.Text = reader.GetString("Email");
                textBox5.Text = reader.GetString("Username");
                textBox6.Text = reader.GetString("Password");
            }

            // Close the connection and release any resources
            reader.Close();
            command.Dispose();
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string oldPassword = textBox8.Text;
            string newPassword = textBox9.Text;
            string confirmPassword = textBox10.Text;

            // Check if new password and confirm password match
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New password and confirm password do not match.");
                return;
            }

            // Get the user ID from the retrieved data (assuming the first column is user ID)
            int userId = Convert.ToInt32(textBox7.Text);

            // Check if the old password is correct (assuming the second column is password)
            string password = textBox6.Text;
            if (oldPassword != password)
            {
                MessageBox.Show("Old password is incorrect.");
                return;
            }
            // Check if the new password and confirm password textboxes are not blank
            if (string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("New password and confirm password fields cannot be blank.");
                return;
            }


            // Update the password in the database
            string connectionString = "server=localhost;user id=root;password=;database=nclinic1;sslMode=none";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE tblacc SET Password=@password WHERE person_id=@id";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@password", newPassword);
                    command.Parameters.AddWithValue("@id", userId);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Password updated successfully.");
                        // Clear the textboxes
                        textBox8.Clear();
                        textBox9.Clear();
                        textBox10.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update password.");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Enabled = true;
                }
            }
            textBox1.Enabled = false;
            textBox7.Enabled = false;
            button5.Enabled = true;
            button3.Enabled = false;
            textBox6.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user id=root;password=;database=nclinic1;sslMode=none";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
              
                    string query = "UPDATE tblacc SET Full_Name=@fname, Contact=@contact, Email=@email, Username=@uname WHERE person_id=@id";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@fname", textBox2.Text);
                        command.Parameters.AddWithValue("@contact", textBox3.Text);
                        command.Parameters.AddWithValue("@email", textBox4.Text);
                        command.Parameters.AddWithValue("@uname", textBox5.Text);
                        command.Parameters.AddWithValue("@id", Convert.ToInt32(textBox7.Text));
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data updated successfully.");
                            textBox2.Enabled = false;
                            textBox3.Enabled = false;
                            textBox4.Enabled = false;
                            textBox5.Enabled = false;
                            button3.Enabled = true;
                        }


                        else
                        {
                            MessageBox.Show("Failed to update data.");
                        }
                        
                    }
                    
                }
            }
        

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Enabled = false;
                }
            }
            button3.Enabled = true;
            button5.Enabled = false;
        }
    }
}
