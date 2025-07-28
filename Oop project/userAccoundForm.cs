using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oop_project
{
    public partial class userAccoundForm: Form
    {
        private string name;

        private void LoadUserData()
        {
            string connectionString = "data source=LAPTOP-8DQCEBU3\\SQLEXPRESS; database=oop project; integrated security=SSPI";
            string query = "SELECT password, email, mobileno, address FROM userid WHERE name = @Name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            passwordTextbox.Text = reader["password"].ToString().Trim();
                            emailTextbox.Text = reader["email"].ToString().Trim();
                            mobilenoTextbox.Text = reader["mobileno"].ToString().Trim();
                            addressTextbox.Text = reader["address"].ToString().Trim();
                        }
                    }
                }
            }
        }


        public userAccoundForm(string name)
        {
            InitializeComponent();
            this.name = name;
            welcomeLabel.Text = "Welcome " + name;
            LoadUserData();
        }

        private void userAccoundForm_Load(object sender, EventArgs e)
        {

        }

        private void maleButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void femaleButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void welcomeLabel_Click(object sender, EventArgs e)
        {
           
        }


        private void label1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(passwordTextbox.Text) || String.IsNullOrEmpty(addressTextbox.Text) || String.IsNullOrEmpty(mobilenoTextbox.Text))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string connectionString = "data source=LAPTOP-8DQCEBU3\\SQLEXPRESS; database=oop project; integrated security=SSPI";


            string query = "UPDATE userid SET password = @Password, email=@Email , mobileno = @Mobileno, address = @Address WHERE name = @Name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Password", passwordTextbox.Text);
                    command.Parameters.AddWithValue("@Mobileno", mobilenoTextbox.Text);
                    command.Parameters.AddWithValue("@Address", addressTextbox.Text);
                    command.Parameters.AddWithValue("@Email", emailTextbox.Text);

                     command.Parameters.AddWithValue("@name", name);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Profile update complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        userLoginForm loginform = new userLoginForm();
                        loginform.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create the profile. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(passwordTextbox.Text) || String.IsNullOrEmpty(addressTextbox.Text) || String.IsNullOrEmpty(mobilenoTextbox.Text))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string connectionString = "data source=LAPTOP-8DQCEBU3\\SQLEXPRESS; database=oop project; integrated security=SSPI";


            string query = "UPDATE userid SET password = @Password, email=@Email , mobileno = @Mobileno, address = @Address WHERE name = @Name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Password", passwordTextbox.Text);
                    command.Parameters.AddWithValue("@Mobileno", mobilenoTextbox.Text);
                    command.Parameters.AddWithValue("@Address", addressTextbox.Text);
                    command.Parameters.AddWithValue("@Email", emailTextbox.Text);

                    command.Parameters.AddWithValue("@name", name);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Profile update complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        userLoginForm loginform = new userLoginForm();
                        loginform.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create the profile. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            userMenu um5 = new userMenu(name);
            um5.Show();
            this.Hide();
        }
    }
}
