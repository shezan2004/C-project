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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Oop_project
{
    public partial class userSignupForm2: Form
    {
        private string gender;
        private string address;
        private string mobileno;
        private string name;
        private string password;
       
        public userSignupForm2(string name,string password)
        {
            InitializeComponent();
            this.name = name;
            this.password=password;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (maleButton.Checked)
            {
                gender = "male";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (femaleButton.Checked)
            {
                gender = "female";
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(gender)||String.IsNullOrEmpty(addressTextbox.Text)|| String.IsNullOrEmpty(mobilenoTextbox.Text))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string connectionString = "data source=LAPTOP-8DQCEBU3\\SQLEXPRESS; database=oop project; integrated security=SSPI";


            string query = "UPDATE userid SET gender = @Gender, mobileno = @Mobileno, address = @Address WHERE name = @Name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@Mobileno", mobileno);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Name", name);

                    /* command.Parameters.AddWithValue("@Address", address);*/

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Profile creation complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void addressTextbox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(addressTextbox.Text))
            {
                addressLabel.Show();
            }
            else
            {
                addressLabel.Hide();
            }

            address = addressTextbox.Text;
        }



        private void addressLabel_Click(object sender, EventArgs e)
        {
            addressTextbox.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(mobilenoTextbox.Text) == true)
            {
                mobilenoLabel.Show();
            }
            else
                mobilenoLabel.Hide();
            mobileno = mobilenoTextbox.Text;
        }

        private void mobilenoLabel_Click(object sender, EventArgs e)
        {
            mobilenoTextbox.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(gender) || String.IsNullOrEmpty(addressTextbox.Text) || String.IsNullOrEmpty(mobilenoTextbox.Text))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string connectionString = "data source=LAPTOP-8DQCEBU3\\SQLEXPRESS; database=oop project; integrated security=SSPI";


            string query = "UPDATE userid SET gender = @Gender, mobileno = @Mobileno, address = @Address WHERE name = @Name and password=@Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Gender", gender);
                    command.Parameters.AddWithValue("@Mobileno", mobileno);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Password", password);

                    /* command.Parameters.AddWithValue("@Address", address);*/

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Profile creation complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
