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
    public partial class userMenu: Form
    {
        private string name;
        public userMenu(string name)
        {
            InitializeComponent();
            this.name = name;
        }

        private void applianceButton_Click(object sender, EventArgs e)
        {
            ApplianceServiceDashboard ad = new ApplianceServiceDashboard(name);
            ad.Show();
            this.Hide();
        }

        private void electricalButton_Click(object sender, EventArgs e)
        {
            ElectricalServiceDashboard ed=new ElectricalServiceDashboard(name);
            ed.Show();
            this.Hide();
        }

        private void houseShiftButton_Click(object sender, EventArgs e)
        {
            HouseShiftingDashboard hd = new HouseShiftingDashboard(name);
            hd.Show();
            this.Hide();
        }

        private void plumbingButton_Click(object sender, EventArgs e)
        {
            PlumbingServiceDashboard p1 = new PlumbingServiceDashboard(name);
            p1.Show();
            this.Hide();
        }

        private void userMenu_Load(object sender, EventArgs e)
        {

        }

        private void accountButton_Click(object sender, EventArgs e)
        {
            userAccoundForm userAccoundFor = new userAccoundForm(name);
            userAccoundFor.Show();
            this.Hide();
        }
    }
}
