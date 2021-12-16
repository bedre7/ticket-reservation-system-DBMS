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
    public partial class DiscountPanel : UserControl
    {
        OdbcConnection connection = new OdbcConnection("DSN=PostgreSQL35W");
        public DiscountPanel()
        {
            InitializeComponent();
            string queryy = "SELECT * FROM \"Discount\"";
            FillTable(queryy, dgvDiscount);
            FillDiscountComboBox();
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

        private void updateDiscBtn_Click(object sender, EventArgs e)
        {
            if(discComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the type", "Updating Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string type = discComboBox.GetItemText(discComboBox.SelectedItem);
            double discountRate = Convert.ToDouble(newDiscUpdown.Value) / 100;
            try
            {
                string query = "UPDATE \"Discount\" SET \"discountRate\" = " + discountRate + "WHERE \"name\" =  '" + type + "';";
                connection.Open();
                OdbcCommand command = new OdbcCommand(query, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Discount Rate has been updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string queryy = "SELECT * FROM \"Discount\"";
                FillTable(queryy, dgvDiscount);
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            finally { connection.Close(); }
        }
        private void FillDiscountComboBox()
        {
            string query = "SELECT \"name\" FROM \"Discount\" ORDER BY \"name\" ASC";
            try
            {
                connection.Open();
                OdbcCommand command = new OdbcCommand(query, connection);
                OdbcDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    discComboBox.Items.Add(reader[0].ToString());
                }
                reader.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            finally { connection.Close(); }
        }
    }
}
