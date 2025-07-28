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
    public partial class searchEmployee: Form
    {
        public searchEmployee()
        {
            InitializeComponent();
        }
        private string connectionString = "Data Source=LAPTOP-8DQCEBU3\\SQLEXPRESS;Initial Catalog=oop project;Integrated Security=True";
        private void LoadSearchResults(string searchText)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();


                    string query = "SELECT name, serviceId FROM employeeTable WHERE name LIKE @search OR serviceId = @id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@search", "%" + searchText + "%");

                        int parsedId;
                        if (int.TryParse(searchText, out parsedId))
                        {
                            command.Parameters.AddWithValue("@id", parsedId);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@id", -1); 
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable results = new DataTable();
                        adapter.Fill(results);

                        dataGridView1.DataSource = results;

                        if (results.Rows.Count == 0)
                        {
                            MessageBox.Show("No matching employee found.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while searching: " + ex.Message);
            }
        }


        private void backButton_Click(object sender, EventArgs e)
        {
            adminPanel adminPanel = new adminPanel();
            adminPanel.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string searchText = searchTextBox.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Please enter a name or service ID to search.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            LoadSearchResults(searchText);
        }
    }
}
