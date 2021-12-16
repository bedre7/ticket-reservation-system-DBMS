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
    public partial class RoutePanel : UserControl
    {
        OdbcConnection connection = new OdbcConnection("DSN=PostgreSQL35W");
        public RoutePanel()
        {
            InitializeComponent();
            FillComboBox("SELECT DISTINCT \"name\" FROM \"City\" ORDER BY \"name\" ASC", depComboBox);
            FillComboBox("SELECT DISTINCT \"name\" FROM \"City\" ORDER BY \"name\" ASC", destComboBox);
            string query4 = "SELECT * FROM \"Route\"";
            FillTable(query4, dgvRoute);
        }

        private void addRouteBtn_Click(object sender, EventArgs e)
        {
            if (depComboBox.SelectedIndex == -1 || destComboBox.SelectedIndex == -1 || distBox.Text == "" || station1Box.Text == "" || station2Box.Text == "")
            {
                MessageBox.Show("Please fill in all boxes", "Adding Route Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string query1 = "INSERT INTO \"Station\" ( \"name\", \"location\") " +
                    "VALUES('" + station1Box.Text + "', '" + depComboBox.GetItemText(depComboBox.SelectedItem)+ "')";
                string query2 = "INSERT INTO \"Station\" ( \"name\", \"location\") " +
                    "VALUES('" + station2Box.Text + "', '" + destComboBox.GetItemText(destComboBox.SelectedItem) + "')";
                AddStation(query1);
                AddStation(query2);

                int stationID = BringID("SELECT \"stationID\" FROM \"Station\" WHERE \"location\" = '" + destComboBox.GetItemText(destComboBox.SelectedItem) + "' ");

                string query3 = "INSERT INTO \"Route\" ( \"departure\", \"destination\", \"distance\", \"station\" ) " +
                    "VALUES('" + depComboBox.GetItemText(depComboBox.SelectedItem) + "', '" + destComboBox.GetItemText(destComboBox.SelectedItem)
                    + "', '" + distBox.Text +  "Km" + "', '" + stationID + "')";

                connection.Open();
                OdbcCommand command = new OdbcCommand(query3, connection);
                command.ExecuteNonQuery();

                MessageBox.Show("Route and station has been added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string query4 = "SELECT * FROM \"Route\"";
                FillTable(query4, dgvRoute);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally {   connection.Close();     }
        }
        private void AddStation(string query)
        {
            try
            {
                connection.Open();
                OdbcCommand command = new OdbcCommand(query, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            finally { connection.Close(); }
        }
        private void FillComboBox(string query, ComboBox combo)
        {
            try
            {
                connection.Open();
                OdbcCommand command = new OdbcCommand(query, connection);
                OdbcDataReader reader = command.ExecuteReader();

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
            
        int BringID(string query)
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
            finally {   connection.Close();     }
            return id;
        }

        private void distBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
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
    }
}
