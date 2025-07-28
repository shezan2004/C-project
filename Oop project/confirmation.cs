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
    public partial class confirmation: Form
    {
        private string name;
        public confirmation(string name)
        {
            InitializeComponent();
            this.name = name;
        }

        private void confirmation_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Payment Successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            userMenu um = new userMenu(name);
            um.Show();
            this.Hide();
           

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
