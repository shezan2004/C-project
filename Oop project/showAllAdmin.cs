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
    public partial class showAllAdmin: Form
    {
        public showAllAdmin()
        {
            InitializeComponent();
            LoadData();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Name == "pending")
                    column.ReadOnly = false;
                else
                    column.ReadOnly = true;
            }

        }
        private string connectionString = "Data Source=LAPTOP-8DQCEBU3\\SQLEXPRESS;Initial Catalog=oop project;Integrated Security=True";

        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT name, serviceid, date, address, mobileNo, pending FROM payment2";


                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;

                 
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void showAllAdmin_Load(object sender, EventArgs e)
        {

        }




        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)dataGridView1.DataSource;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    foreach (DataRow row in dt.Rows)
                    {
                        if (row.RowState == DataRowState.Modified)
                        {
                            string query = "UPDATE payment2 SET pending = @pending WHERE name = @name AND date = @date";

                            using (SqlCommand cmd = new SqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@pending", row["pending"]);
                                cmd.Parameters.AddWithValue("@name", row["name"]);
                                cmd.Parameters.AddWithValue("@date", row["date"]);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

                MessageBox.Show("Changes saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message);
            }

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            adminPanel am9=new adminPanel();
            am9.Show();
            this.Hide();
        }
    }
}
