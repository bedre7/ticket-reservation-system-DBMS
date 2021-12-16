using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineBusReservation
{
    public partial class TripPanel : UserControl
    {
        OdbcConnection connection = new OdbcConnection("DSN=PostgreSQL35W");
        public TripPanel()
        {
            InitializeComponent();
            DisplayAll();
        } 
        private void AddTripBtn_Click(object sender, EventArgs e)
        {
            if (fromComboBox.SelectedIndex == -1 || toComboBox.SelectedIndex == -1 || assignComboBox.SelectedIndex == -1 || priceBox.Text == "")
            {
                MessageBox.Show("Please fill in all boxes", "Adding Trip Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string query;
                string departureTime = dateTimePicker1.Value.ToString("hh:mm", CultureInfo.InvariantCulture);
                string arrivalTime = dateTimePicker2.Value.ToString("hh:mm", CultureInfo.InvariantCulture);

                TimeSpan span = TimeSpan.Parse(arrivalTime) - TimeSpan.Parse(departureTime);

                string duration = span.ToString();

                int driverID = Convert.ToInt32(assignComboBox.GetItemText(assignComboBox.SelectedItem));

                int routeID = GetID("SELECT \"routeID\" FROM \"Route\" WHERE \"departure\" = '"
                    + fromComboBox.GetItemText(fromComboBox.SelectedItem)
                    + "' AND \"destination\" = '" + toComboBox.GetItemText(toComboBox.SelectedItem) + "';");
                if (routeID == 0) 
                {
                    MessageBox.Show("No such route was found. Please add the route first", "Adding Trip Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int busPlateNo = GetID("SELECT \"Bus\".\"plateNo\" FROM \"Bus\" " +
                    "INNER JOIN \"Driver\" ON \"Bus\".\"plateNo\" = \"Driver\".\"plateNo\"" +
                    " WHERE \"Driver\".\"driverID\" = '" + assignComboBox.GetItemText(assignComboBox.SelectedItem) + "';");

                query = "INSERT INTO \"Trip\" ( \"departureTime\", \"arrivalTime\", \"travelDuration\", \"bus\", \"driver\", \"route\") " +
                    "VALUES('" + departureTime + "', '" + arrivalTime + "', '" + duration
                    + "', "+ busPlateNo + ", " + driverID + ", " + routeID + ")";

                connection.Open();
                OdbcCommand command = new OdbcCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();

                int tripID = GetID("SELECT \"tripID\" FROM \"Trip\" WHERE \"driver\" = " + driverID + ";");

                query = "INSERT INTO \"Ticket\" (\"price\", \"trip\")" + 
                    "VALUES("+ Convert.ToInt32(priceBox.Text) + ", " + tripID + "); ";

                connection.Open();
                command = new OdbcCommand(query, connection);
                command.ExecuteNonQuery();

                MessageBox.Show("Trip has been added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                query = "SELECT \"tripID\",\"departure\", \"destination\", \"travelDuration\",  \"status\", \"driver\", \"bus\", \"price\" FROM \"Trip\"" +
                            "INNER JOIN \"Ticket\" ON \"Ticket\".\"trip\" = \"Trip\".\"tripID\"" +
                            "INNER JOIN \"Route\" ON \"Route\".\"routeID\" = \"Trip\".\"route\";";
                FillTable(query, dgvTrip);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally { connection.Close(); }
        }
        private void FillTable(string query, DataGridView dv)
        {
            try
            {
                OdbcDataAdapter dadapter = new OdbcDataAdapter();
                dadapter.SelectCommand = new OdbcCommand(query, connection);
                DataTable table = new DataTable();
                dadapter.Fill(table);

                dv.DataSource = table;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
        private void FillComboBox(string query, ComboBox combo)
        {
            try
            {
                connection.Open();
                OdbcCommand command = new OdbcCommand(query, connection);
                OdbcDataReader reader = command.ExecuteReader();

                combo.Items.Clear();
                while (reader.Read())
                {
                        combo.Items.Add(reader[0].ToString());
                }
                reader.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            finally { connection.Close(); }
        }
        int GetID(string query)
        {
            int id = 0;
            try
            {
                connection.Open();
                OdbcCommand command = new OdbcCommand(query, connection);
                OdbcDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    id = Convert.ToInt32(reader[0].ToString());
                }
                reader.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally { connection.Close(); }
            return id;
        }
        private void fromComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillComboBox("SELECT DISTINCT \"name\" FROM \"City\" " +
            "WHERE \"name\" != '" + fromComboBox.GetItemText(fromComboBox.SelectedItem) + "'ORDER BY \"name\" ASC", toComboBox);
        }

        private void priceBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void DeleteTripBtn_Click(object sender, EventArgs e)
        {
            if(deleteTripBox.Text == "")
            {
                MessageBox.Show("Please enter TripID", "Deleting Trip Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int tripId = Convert.ToInt32(deleteTripBox.Text);

            int isPresent = GetID("SELECT \"tripID\" FROM \"Trip\" WHERE \"tripID\" = " + tripId + ";");
            
            string query = "DELETE FROM \"Trip\" WHERE \"tripID\" = " + tripId;
            try
            {
                connection.Open();
                if (isPresent != 0)
                {
                    OdbcCommand command = new OdbcCommand(query, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Trip has been deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    query = "SELECT \"tripID\",\"departure\", \"destination\", \"travelDuration\",  \"status\", \"driver\", \"bus\", \"price\" FROM \"Trip\"" +
                           "INNER JOIN \"Ticket\" ON \"Ticket\".\"trip\" = \"Trip\".\"tripID\"" +
                           "INNER JOIN \"Route\" ON \"Route\".\"routeID\" = \"Trip\".\"route\";";
                    FillTable(query, dgvDelTrip);
                }
                else
                    MessageBox.Show("No such trip was Found", "Deleting Trip Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally { connection.Close(); }
        }

        private void UpdatePriceBtn_Click(object sender, EventArgs e)
        {
            if (updTripIdBox.Text == "" || newPriceBox.Text == "")
            {
                MessageBox.Show("Please fill all boxes", "Updating Trip Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tripId = Convert.ToInt32(updTripIdBox.Text);
            int newPrice = Convert.ToInt32(newPriceBox.Text);
            int isPresent = GetID("SELECT \"tripID\" FROM \"Trip\" WHERE \"tripID\" = " + tripId + ";");

            string query = "UPDATE \"Ticket\" SET \"price\" = " + newPrice + "WHERE \"trip\" =  '" + tripId + "';";
            
            try
            {
                connection.Open();
                if (isPresent != 0)
                {
                    OdbcCommand command = new OdbcCommand(query, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Ticket price has been updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    query = "SELECT \"Trip\".\"tripID\",\"Route\".\"departure\", \"Route\".\"destination\", \"Ticket\".\"price\" FROM \"Trip\" " +
                            "INNER JOIN \"Route\" ON \"Trip\".\"route\" = \"Route\".\"routeID\"" +
                            "INNER JOIN \"Ticket\" ON \"Trip\".\"tripID\" = \"Ticket\".\"trip\";";
                    FillTable(query, dgvUpd);
                }
                else
                    MessageBox.Show("No such trip was Found", "Updating Trip Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally { connection.Close(); }
        }

        private void DisplayAll()
        {
            FillComboBox("SELECT DISTINCT \"name\" FROM \"City\" ORDER BY \"name\" ASC", fromComboBox);
            FillComboBox("SELECT \"driverID\" FROM \"Driver\" WHERE \"status\" = 'Available'", assignComboBox);
            string queryy = "SELECT \"tripID\",\"departure\", \"destination\", \"travelDuration\",  \"status\", \"driver\", \"bus\", \"price\" FROM \"Trip\"" + 
                            "INNER JOIN \"Ticket\" ON \"Ticket\".\"trip\" = \"Trip\".\"tripID\"" + 
                            "INNER JOIN \"Route\" ON \"Route\".\"routeID\" = \"Trip\".\"route\";";

            FillTable(queryy, dgvTrip);
            FillTable(queryy, dgvDelTrip);
            queryy = "SELECT \"Trip\".\"tripID\",\"Route\".\"departure\", \"Route\".\"destination\", \"Ticket\".\"price\" FROM \"Trip\" " +
                       "INNER JOIN \"Route\" ON \"Trip\".\"route\" = \"Route\".\"routeID\"" +
                       "INNER JOIN \"Ticket\" ON \"Trip\".\"tripID\" = \"Ticket\".\"trip\";";
            FillTable(queryy, dgvUpd);
        }
    }
}
