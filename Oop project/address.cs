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
    public partial class address: Form

    {
        private string userName;
        private DateTime selectedDate;
        private int ServiceId;
        public address(string name, DateTime date, int serviceId)
        {
            InitializeComponent();
            userName = name;
            selectedDate = date;
            ServiceId = serviceId;
        }

        private void address_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            PlumbingServiceDashboard f1 = new PlumbingServiceDashboard(userName);
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "data source=LAPTOP-8DQCEBU3\\SQLEXPRESS; database=oop project; integrated security=SSPI";
            string address = richTextBox1.Text.Trim();
            string mobileNo = textBox1.Text.Trim();

            // Check if any field is empty
            if (string.IsNullOrWhiteSpace(userName))
            {
                MessageBox.Show("User name is missing!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(mobileNo))
            {
                MessageBox.Show("Please enter both address and mobile number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO payment2 (name, serviceId, address, mobileNo, date) VALUES (@name, @serviceId, @address, @mobileNo, @date)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add all required parameters
                    command.Parameters.AddWithValue("@name", userName);
                    command.Parameters.AddWithValue("@serviceId", ServiceId);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@mobileNo", mobileNo);
                    command.Parameters.AddWithValue("@date", selectedDate);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Proceed to payment!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        payment p1 = new payment(userName);
                        p1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Failed to insert the record.", "Insert Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
