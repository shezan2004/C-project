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
    public partial class adminPanel: Form
    {
        public adminPanel()
        {
            InitializeComponent();
        }

        private void addEmployeeButton_Click(object sender, EventArgs e)
        {
            employeeRegister emreg=new employeeRegister();
            this.Hide();
            emreg.Show();
        }

        private void adminPanel_Load(object sender, EventArgs e)
        {

        }

        private void showAll_Click(object sender, EventArgs e)
        {
            showAllAdmin sa=new showAllAdmin();
            sa.Show();
            this.Hide();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            employeeDelete employeeDelete=new employeeDelete();
            this.Hide();
            employeeDelete.Show();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            searchEmployee searchEmployee = new searchEmployee();
            searchEmployee.Show();
            this.Hide();
        }
    }
}
