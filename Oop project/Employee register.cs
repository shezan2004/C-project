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

namespace Oop_project
{
    public partial class employeeRegister: Form
    {
        public employeeRegister()
        {
            InitializeComponent();
        }

        private void usernameTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void confirmPasswordLabel_Click(object sender, EventArgs e)
        {
            confirmPasswordTextBox.Focus();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string userName = nameTextbox.Text.Trim();
            string password = passwordTextBox.Text.Trim();
            int serviceId = -1; // default invalid

            if (plumberRadioButton.Checked)
                serviceId = 1;
            else if (electricianRadioButton.Checked)
                serviceId = 2;
            else if (houseShifting.Checked)
                serviceId = 3;
            else if (applianceRadioButton.Checked)
                serviceId = 4;

            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password) || serviceId == -1)
            {
                MessageBox.Show("All fields must be filled out and a service must be selected.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "data source=LAPTOP-8DQCEBU3\\SQLEXPRESS; database=oop project; integrated security=SSPI";

            string checkQuery = "SELECT COUNT(*) FROM employeeTable WHERE name = @Name";
            string insertQuery = "INSERT INTO employeeTable (name, password, type, serviceId) VALUES (@username, @password, @type, @serviceId)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                using (SqlCommand checkCmd = new SqlCommand(checkQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@Name", userName);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Employee already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                using (SqlCommand insertCmd = new SqlCommand(insertQuery, connection))
                {
                    insertCmd.Parameters.AddWithValue("@username", userName);
                    insertCmd.Parameters.AddWithValue("@password", password);
                    insertCmd.Parameters.AddWithValue("@type", "emp");
                    insertCmd.Parameters.AddWithValue("@serviceId", serviceId);

                    int rowsAffected = insertCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Employee profile created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        adminPanel ap2=new adminPanel();
                        ap2.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create employee profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void employeeRegister_Load(object sender, EventArgs e)
        {

        }

        private void plumberRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void electricianRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void applianceRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameTextbox.Focus();
        }

        private void houseShifting_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void passwordLabel_Click(object sender, EventArgs e)
        {
            passwordTextBox.Focus();
        }

        private void usernameLabel_Click(object sender, EventArgs e)
        {

        }

        private void nameTextbox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(nameTextbox.Text) == false)
            {
                nameLabel.Hide();
            }
            if (String.IsNullOrEmpty(nameTextbox.Text) == true)
            {
                nameLabel.Show();
            }
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(passwordTextBox.Text) == false)
            {
                passwordLabel.Hide();
            }
            if (String.IsNullOrEmpty(passwordTextBox.Text) == true)
            {
                passwordLabel.Show();
            }
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
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            adminPanel am7=new adminPanel();
            am7.Show();
            this.Hide();
        }
    }
}
