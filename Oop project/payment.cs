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
    public partial class payment: Form
    {
        string name;
        public payment(string name)
        {
            InitializeComponent();
            this.name = name;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            confirmation c1 = new confirmation(name);
            c1.Show();
        }

        private void payment_Load(object sender, EventArgs e)
        {

        }
    }
}
