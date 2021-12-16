using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineBusReservation
{
    public partial class PassengerForm : Form
    {
        OdbcConnection connection = new OdbcConnection("DSN=PostgreSQL35W");
        public PassengerForm()
        {
            InitializeComponent();
            passengerHome1.BringToFront();
            WelcomeUser();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            connection.Open();
            string query = "UPDATE \"Users\" SET \"status\" = 'Passive' WHERE \"status\" = 'Active'";
            OdbcCommand command = new OdbcCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
            this.Close();   
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            manageButtons(HomeBtn);
            passengerHome1.BringToFront();
        }

        private void MyTripsBtn_Click(object sender, EventArgs e)
        {
            manageButtons(MyTripsBtn);
            myTrips1.BringToFront();
        }
        private void manageButtons(Button current)
        {
            SidePanel.Height = current.Height;
            SidePanel.Top = current.Top;
            current.BackColor = Color.FromArgb(204, 103, 90);
            foreach (Control c in panel1.Controls.OfType<Button>().ToList())
            {
                if (c != current)
                    c.BackColor = Color.FromArgb(56, 62, 76);
            }
        }
        private void WelcomeUser()
        {
            string query = "SELECT \"username\" FROM \"Users\" WHERE \"status\" = 'Active';";
            connection.Open();
            OdbcCommand command = new OdbcCommand(query, connection);
            OdbcDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                welcomeLable.Text = "Welcome " + reader[0].ToString() + "!";
            }
            reader.Close();
            connection.Close();
        }
    }
}
