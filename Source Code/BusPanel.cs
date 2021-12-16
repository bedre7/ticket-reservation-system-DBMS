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
    public partial class BusPanel : UserControl
    {
        public BusPanel()
        {
            InitializeComponent();
            string query = "SELECT * FROM \"Bus\"";
            FillTable(query, dgvBus);
            seatsUpDown.Maximum = 20;
            seatsUpDown.Minimum = 0;
        }
        OdbcConnection connection = new OdbcConnection("DSN=PostgreSQL35W");
        private void addBusBtn_Click(object sender, EventArgs e)
        {
            if (plateBox.Text == "" || brandBox.Text == "" || modelBox.Text == "")
            {
                MessageBox.Show("Please fill all boxes", "Adding bus Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                int seats = Convert.ToInt32(seatsUpDown.Value) != 0 ? Convert.ToInt32(seatsUpDown.Value) : 20;
                string query = "INSERT INTO \"Bus\" ( \"plateNo\", \"brandName\", \"model\", \"numberOfSeats\", \"company\") " +
                "VALUES('" + Convert.ToInt32(plateBox.Text) + "', '" + brandBox.Text + "', '" + modelBox.Text + "', '" + seats + "', '" + 1 + "')";
                connection.Open();
                OdbcCommand command = new OdbcCommand(query, connection);
                command.ExecuteNonQuery();
                

                plateBox.Text = brandBox.Text = modelBox.Text = "";
    
                MessageBox.Show("Bus has been added Successfully!", "Add Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string query2 = "SELECT * FROM \"Bus\"";
                FillTable(query2, dgvBus);
            }
            catch (Exception error)
            {
                MessageBox.Show("This plate number already exists!", "Adding bus Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
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

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM \"Bus\" WHERE \"brandName\" LIKE '%" + searchBusBox.Text + "%'";
            FillTable(query, dgvBus);
        }

        private void plateBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
