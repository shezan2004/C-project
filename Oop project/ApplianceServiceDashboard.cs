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
    public partial class ApplianceServiceDashboard: Form
    {
        public ApplianceServiceDashboard(string name)
        {
            InitializeComponent();
            this.name = name;
        }
        int hours;
        private string name;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DateTime dateFromPicker = dateTimePicker1.Value;
            this.Hide();
            address f2 = new address(name, dateFromPicker, 4);
            f2.Show();
        }

        private void hourComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            hours = (hourComboBox.SelectedIndex) + 1;
            amountLabel.Text = "৳ " + (hours * 300).ToString();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            userMenu um1=new userMenu(this.name);
            um1.Show();
            this.Hide();
        }
    }
    }

