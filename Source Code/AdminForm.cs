using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineBusReservation
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void manageButtons(Button current)
        {
            SidePanel.Height = current.Height;
            SidePanel.Top = current.Top;
            current.BackColor = Color.FromArgb(78, 86, 105);
            foreach (Control c in panel1.Controls.OfType<Button>().ToList())
            {
                if(c != current)
                  c.BackColor = Color.FromArgb(56, 62, 76);
            }
        }
        private void homeButton_Click(object sender, EventArgs e)
        {
            manageButtons(homeButton);
        }

        private void tripsButton_Click(object sender, EventArgs e)
        {
            manageButtons(tripsButton);
            tripPanel1.BringToFront();
        }

        private void routesButton_Click(object sender, EventArgs e)
        {
            manageButtons(routesButton);
            routePanel1.BringToFront();
        }

        private void busButton_Click(object sender, EventArgs e)
        {
            manageButtons(busButton);
            busPanel1.BringToFront();
        }

        private void driversButton_Click(object sender, EventArgs e)
        {
            manageButtons(driversButton);
            driverPanel1.BringToFront();
        }

        private void discountsButton_Click(object sender, EventArgs e)
        {
            manageButtons(discountsButton);
            discountPanel1.BringToFront();
        }
    }
}
