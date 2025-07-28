using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oop_project
{
    public partial class ElectricalServiceDashboard: Form
    {
        public ElectricalServiceDashboard(string name)
        {
            InitializeComponent();
            this.name = name;
        }
        int hours;
        private string name;

        private void ElectricalServiceDashboard_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string connectionString = "data source=LAPTOP-8DQCEBU3\\SQLEXPRESS; database=oop project; integrated security=SSPI";
            DateTime dateFromPicker = dateTimePicker1.Value;
            this.Hide();
            address f2 = new address(name, dateFromPicker, 2);
            f2.Show();
        }

        private void hourComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            hours = (hourComboBox.SelectedIndex) + 1;
            amountLabel.Text = "৳ " + (hours * 300).ToString();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            userMenu um2 = new userMenu(this.name);
            um2.Show();
            this.Hide();
        }
    }
}
