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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Oop_project
{
    public partial class employeeLoginForm: Form
    {
        public employeeLoginForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void usernameTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginLabel_Click(object sender, EventArgs e)
        {


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void userButton_Click(object sender, EventArgs e)
        {
            userLoginForm userLoginForm1 = new userLoginForm();
            userLoginForm1.Show();
            this.Hide();
        }

        private void employeeLoginForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string username = usernameTextbox.Text.Trim();
            string password = passwordTextbox.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "data source=LAPTOP-8DQCEBU3\\SQLEXPRESS; database=oop project; integrated security=SSPI";
            string query = "SELECT type FROM employeeTable WHERE name = @name AND password COLLATE SQL_Latin1_General_CP1_CS_AS = @password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", username);
                    command.Parameters.AddWithValue("@password", password);

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        string userType = result.ToString().Trim(); // remove whitespace

                        if (userType == "emp")
                        {
                            MessageBox.Show("Admin login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            adminPanel adminPanel = new adminPanel();
                            this.Hide();
                            adminPanel.Show();
                        }
                        else if (userType == "admin")
                        {
                            MessageBox.Show("Admin login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            adminPanel adminPanel = new adminPanel();
                            this.Hide();
                            adminPanel.Show();
                        }
                        else
                        {
                            MessageBox.Show("Unknown user type.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void usernameLabel_Click(object sender, EventArgs e)
        {
            usernameTextbox.Focus();
        }

        private void passwordLabel_Click(object sender, EventArgs e)
        {
            passwordTextbox.Focus();
        }

        private void usernameTextbox_TextChanged_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(usernameTextbox.Text) == false)
            {
                usernameLabel.Hide();
            }
            if (String.IsNullOrEmpty(usernameTextbox.Text) == true)
            {
                usernameLabel.Show();
            }
           
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
        }
    }
}
