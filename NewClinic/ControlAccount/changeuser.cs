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
using FontAwesome.Sharp;

namespace NewClinic.ControlAccount
{
    public partial class changeuser : Form
    {
        public static String id = Main.id;

        // declare the connection string
        string connectionString = "server=localhost;user id=root;password=;database=nclinic1;sslMode=none";

        // declare the connection object
        MySqlConnection connection;

        string enab1 = "onpass";
        string enab2 = "onpass";
        string enab3 = "onpass";

        public changeuser()
        {
            InitializeComponent();
        }

        public string OldPassword
        {
            get { return txtoldpass.Text; }
        }

        public string NewPassword
        {
            get { return txtnewpass.Text; }
        }

        private void changeaccount_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection(connectionString);
            DisplayDataInTextBoxes();
            onpass();
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
            command.Parameters.AddWithValue("@id", id); // Set the parameter value to the id of the row you want to retrieve

            // Execute the query and retrieve the results
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                // Use the reader to populate the textboxes with the retrieved data
                txttype.Text = reader.GetString("Usertype");
                txtid.Text = reader.GetString("person_id");
                txtname.Text = reader.GetString("Full_Name");
                txtcontact.Text = reader.GetString("Contact");
                txtemail.Text = reader.GetString("Email");
                txtusername.Text = reader.GetString("Username");
                txtpas.Text = reader.GetString("Password");
            }

            // Close the connection and release any resources
            reader.Close();
            command.Dispose();
            connection.Close();
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            string oldPassword = txtoldpass.Text;
            string newPassword = txtnewpass.Text;
            string confirmPassword = txtconfirmpass.Text;

            // Check if new password and confirm password match
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New password and confirm password do not match.");
                return;
            }

            // Get the user ID from the retrieved data (assuming the first column is user ID)
            int userId = Convert.ToInt32(txtid.Text);

            // Check if the old password is correct (assuming the second column is password)
            string password = txtpas.Text;
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
                        txtoldpass.Clear();
                        txtnewpass.Clear();
                        txtconfirmpass.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update password.");
                    }
                }
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Enabled = true;
                }
            }
            txttype.Enabled = false;
            txtid.Enabled = false;
            iconButton2.Enabled = true;
            iconButton3.Enabled = false;
            txtpas.Enabled = false;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user id=root;password=;database=nclinic1;sslMode=none";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                string query = "UPDATE tblacc SET Full_Name=@fname, Contact=@contact, Email=@email, Username=@uname WHERE person_id=@id";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@fname", txtname.Text);
                    command.Parameters.AddWithValue("@contact", txtcontact.Text);
                    command.Parameters.AddWithValue("@email", txtemail.Text);
                    command.Parameters.AddWithValue("@uname", txtusername.Text); 
                    command.Parameters.AddWithValue("@id", Convert.ToInt32(txtid.Text));
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data updated successfully.");
                        txtname.Enabled = false;
                        txtcontact.Enabled = false;
                        txtemail.Enabled = false;
                        txtusername.Enabled = false;
                        iconButton3.Enabled = true;
                    }


                    else
                    {
                        MessageBox.Show("Failed to update data.");
                    }

                }

            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Enabled = false;
                }
            }
            iconButton3.Enabled = true;
            iconButton2.Enabled = false;
        }

        void onpass()
        {
            txtoldpass.UseSystemPasswordChar = true;
            txtnewpass.UseSystemPasswordChar = true;
            txtconfirmpass.UseSystemPasswordChar = true;
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            if (enab1 == "offpass")
            {
                enab1 = "onpass";
                btold.IconChar = IconChar.EyeSlash;
                txtoldpass.UseSystemPasswordChar = true;

            }
            else
            {
                enab1 = "offpass";
                btold.IconChar = IconChar.Eye;
                txtoldpass.UseSystemPasswordChar = false;
            }
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            if (enab2 == "offpass")
            {
                enab2 = "onpass";
                btnew.IconChar = IconChar.EyeSlash;
                txtnewpass.UseSystemPasswordChar = true;

            }
            else
            {
                enab2 = "offpass";
                btnew.IconChar = IconChar.Eye;
                txtnewpass.UseSystemPasswordChar = false;
            }
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            if (enab3 == "offpass")
            {
                enab3 = "onpass";
                btcon.IconChar = IconChar.EyeSlash;
                txtconfirmpass.UseSystemPasswordChar = true;

            }
            else
            {
                enab3 = "offpass";
                btcon.IconChar = IconChar.Eye;
                txtconfirmpass.UseSystemPasswordChar = false;
            }
        }

        private void txtcontact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}
