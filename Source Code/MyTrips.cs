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
    public partial class MyTrips : UserControl
    {
        OdbcConnection connection = new OdbcConnection("DSN=PostgreSQL35W");
        public MyTrips()
        {
            InitializeComponent();
            FillTable();
        }
        private void FillTable()
        {
            string query = "SELECT \"Passenger\".\"name\", \"Passenger\".\"surname\", \"departure\", \"destination\", \"journeyDate\"  FROM \"Passenger\" " +
                            "INNER JOIN \"Users\" ON \"Users\".\"userID\" = \"Passenger\".\"userID\" " +
                            "INNER JOIN \"Reservation\" ON \"Reservation\".\"passengerID\" = \"Passenger\".\"passengerID\"" +
                            "INNER JOIN \"Trip\" ON \"Trip\".\"tripID\" = \"Reservation\".\"tripID\" " +
                            "INNER JOIN \"Route\" ON \"Route\".\"routeID\" = \"Trip\".\"route\"";

            dgvMyTrips.Font = new Font("Century Gothic", 12);

            try
            {
                OdbcDataAdapter dadapter = new OdbcDataAdapter();
                dadapter.SelectCommand = new OdbcCommand(query, connection);
                DataTable table = new DataTable();
                dadapter.Fill(table);

                dgvMyTrips.DataSource = table;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            FillTable();
        }
    }
}
