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
using System.Xml.Linq;

namespace Oop_project
{
    public partial class userLoginForm: Form
    {
        public userLoginForm()
        {
            InitializeComponent();
        }
        string username;
        string password;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void usernameTextbox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(usernameTextbox.Text)==false) {
                usernameLabel.Hide();
            }
            if (String.IsNullOrEmpty(usernameTextbox.Text) == true)
            {
                usernameLabel.Show();
            }
            username=usernameTextbox.Text.Trim();

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
            if (String.IsNullOrEmpty(passwordTextbox.Text) == false)
            {
                passwordLabel.Hide();
            }
            if (String.IsNullOrEmpty(passwordTextbox.Text) == true)
            {
                passwordLabel.Show();
            }
            password = passwordTextbox.Text.Trim();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(usernameTextbox.Text) || String.IsNullOrEmpty(usernameTextbox.Text)) 
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string connectionString = "data source=LAPTOP-8DQCEBU3\\SQLEXPRESS; database=oop project; integrated security=SSPI";

            /*COLLATE SQL_Latin1_General_CP1_CS_AS this part compared password with databse in a case sensitive, accennt sensitive manner*/


            string query = "SELECT COUNT(*) FROM userid WHERE name = @id AND password COLLATE SQL_Latin1_General_CP1_CS_AS = @password";
            /*select count (*) compared given value with databse, if there is a match it will return 1 and if
            there are more than 1 match it will return greater number*/

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", username);
                    command.Parameters.AddWithValue("@password", password);

                    connection.Open();

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        userMenu um = new userMenu(usernameTextbox.Text);
                        um.Show();


                    }
                    else
                    {
                        MessageBox.Show("Invalid Id or Name.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(usernameTextbox.Text) || String.IsNullOrEmpty(usernameTextbox.Text))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string connectionString = "data source=LAPTOP-8DQCEBU3\\SQLEXPRESS; database=oop project; integrated security=SSPI";

            /*COLLATE SQL_Latin1_General_CP1_CS_AS this part compared password with databse in a case sensitive, accennt sensitive manner*/


            string query = "SELECT COUNT(*) FROM userid WHERE name = @id AND password COLLATE SQL_Latin1_General_CP1_CS_AS = @password";
            /*select count (*) compared given value with databse, if there is a match it will return 1 and if
            there are more than 1 match it will return greater number*/

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", username);
                    command.Parameters.AddWithValue("@password", password);

                    connection.Open();

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        userMenu umenu=new userMenu(username);
                        umenu.Show();

                        this.Hide();


                    }
                    else
                    {
                        MessageBox.Show("Invalid Id or Name.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void createAccountLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            userSignupForm userSignupForm = new userSignupForm();  
            userSignupForm.Show();
            this.Hide();
        }

        private void userButton_Click(object sender, EventArgs e)
        {

        }

        private void usernameLabel_Click(object sender, EventArgs e)
        {
            usernameTextbox.Focus();
        }

        private void passwordLabel_Click(object sender, EventArgs e)
        {
            passwordTextbox.Focus();
        }

        private void userLoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
