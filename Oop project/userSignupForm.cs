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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Oop_project
{
    public partial class userSignupForm: Form
    {
        public userSignupForm()
        {
            InitializeComponent();
        }
        string userName;
        string email;
        string password;
        string confirmPassword;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void usernameTextbox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(usernameTextbox.Text) == false)
            {
                usernameLabel.Hide();
            }
            if (String.IsNullOrEmpty(usernameTextbox.Text) == true)
            {
                usernameLabel.Show();
            }
            userName = usernameTextbox.Text.Trim();
        }

        private void loginLabel_Click(object sender, EventArgs e)
        {
            

        }

        private void label2_Click(object sender, EventArgs e)
        {
            employeeLoginForm Employeelogin = new employeeLoginForm();
            Employeelogin.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void passwordTextbox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(emailTextBox.Text) == false)
            {
                emailLabel.Hide();
            }
            if (String.IsNullOrEmpty(emailTextBox.Text) == true)
            {
                emailLabel.Show();
            }
            email= emailTextBox.Text.Trim();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string connectionString = "data source=LAPTOP-8DQCEBU3\\SQLEXPRESS; database=oop project; integrated security=SSPI";

            /*string id = textBox1.Text.Trim();
            string name = textBox2.Text.Trim();
            string age = textBox3.Text.Trim();
            string address = textBox4.Text.Trim();*/

            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            /*if (!int.TryParse(age, out int parsedAge))
            {
                MessageBox.Show("Age must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }*/
            string checkQuery = "select count(*) from userid where name=@Name";

            string query = "INSERT INTO userid (name, email,password) VALUES (@username, @email, @password)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(checkQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", usernameTextbox.Text);


                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Profile already exist!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
            }



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", userName);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", password);

                    /* command.Parameters.AddWithValue("@Address", address);*/

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Profile created successfully! Provide some more information", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        userSignupForm2 signupForm2 = new userSignupForm2(usernameTextbox.Text, passwordTextBox.Text);
                        signupForm2.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create the profile. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string connectionString = "data source=LAPTOP-8DQCEBU3\\SQLEXPRESS; database=oop project; integrated security=SSPI";

            /*string id = textBox1.Text.Trim();
            string name = textBox2.Text.Trim();
            string age = textBox3.Text.Trim();
            string address = textBox4.Text.Trim();*/

            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            /*if (!int.TryParse(age, out int parsedAge))
            {
                MessageBox.Show("Age must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }*/
            string checkQuery = "select count(*) from userid where name=@Name";

            string query = "INSERT INTO userid (name, email,password) VALUES (@username, @email, @password)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(checkQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", usernameTextbox.Text);


                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Profile already exist!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
            }



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", userName);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@password", password);

                    /* command.Parameters.AddWithValue("@Address", address);*/

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Profile created successfully! Provide some more information", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        userSignupForm2 signupForm2 = new userSignupForm2(usernameTextbox.Text, passwordTextBox.Text);
                        signupForm2.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create the profile. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void createAccountLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void userButton_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void usernameLabel_Click(object sender, EventArgs e)
        {
            usernameTextbox.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            emailTextBox.Focus();
        }

        private void passwordLabel_Click(object sender, EventArgs e)
        {
            passwordTextBox.Focus();
        }

        private void confirmPasswordLabel_Click(object sender, EventArgs e)
        {
            confirmPasswordTextBox.Focus();
        }

        private void passwordTextbox_TextChanged_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(passwordTextBox.Text) == false)
            {
                passwordLabel.Hide();
            }
            if (String.IsNullOrEmpty(passwordTextBox.Text) == true)
            {
                passwordLabel.Show();
            }
            password=passwordTextBox.Text;
        }

        private void confirmPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(confirmPasswordTextBox.Text) == false)
            {
                confirmPasswordLabel.Hide();
            }
            if (String.IsNullOrEmpty(confirmPasswordTextBox.Text) == true)
            {
                confirmPasswordLabel.Show();
            }
            confirmPassword=confirmPasswordTextBox.Text;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }
    }
}
