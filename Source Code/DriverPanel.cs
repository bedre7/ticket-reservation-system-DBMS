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
    public partial class DriverPanel : UserControl
    {
        OdbcConnection connection = new OdbcConnection("DSN=PostgreSQL35W");
        public DriverPanel()
        {
            InitializeComponent();
            FillComboBox("SELECT DISTINCT \"name\" FROM \"City\" ORDER BY \"name\" ASC", cityComboBox);
            FillBusComboBox();
            string queryy = "SELECT * FROM \"Driver\"";
            FillTable(queryy, dgvDriver);
            FillTable(queryy, dgvDriver2);
        }

        private void InsertToTable(string query)
        {

        }
        private void addDriverBtn_Click(object sender, EventArgs e)
        {
            if (cityComboBox.SelectedIndex == -1 || districtComboBox.SelectedIndex == -1 || busComboBox.Text == "" || nameBox.Text == "" || surnameBox.Text == "" || salaryBox.Text == "" || phoneBox.Text == "")
            {
                MessageBox.Show("Please fill in all boxes", "Adding Driver Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string query;
                query = "INSERT INTO \"District\"(\"name\") VALUES('"
                    + districtComboBox.GetItemText(districtComboBox.SelectedItem) + "')";
                connection.Open();
                OdbcCommand command = new OdbcCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();

                int districtNo = BringID("SELECT \"districtNo\" FROM \"District\" WHERE \"name\" = '"
                    + districtComboBox.GetItemText(districtComboBox.SelectedItem) + "' ");

                query = "INSERT INTO \"Driver\"(\"name\", \"surname\", \"salary\", \"plateNo\", \"company\" ) VALUES('"
                   + nameBox.Text + "' , '" + surnameBox.Text + "' , '" + Convert.ToInt32(salaryBox.Text) + "' , '" +
                   busComboBox.GetItemText(busComboBox.SelectedItem)  + "' , '" + 1 + "' ); ";

                connection.Open();
                command = new OdbcCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();

                query = "INSERT INTO \"ContactInformation\"(\"phoneNo\", \"email\", \"districtNo\", \"company\" ) VALUES('"
                    + phoneBox.Text + "' , '" + nameBox.Text + "' , '" + districtNo + "' , '" + 1 + "' );";

                connection.Open();
                command = new OdbcCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();

                int contactID = BringID("SELECT \"contactID\" FROM \"ContactInformation\" WHERE \"phoneNo\" = '"
                    + phoneBox.Text + "' ");

                query = "UPDATE \"Driver\" SET \"contact\" = " + contactID + "WHERE \"name\" =  '" + nameBox.Text + "';";
                connection.Open();
                command = new OdbcCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Driver has been added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                query = "SELECT * FROM \"Driver\"";
                FillTable(query, dgvDriver);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally { connection.Close(); }
        }

        private void cityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string search = "SELECT \"districtNo\" FROM \"City\" WHERE \"name\"='" + cityComboBox.GetItemText(cityComboBox.SelectedItem) + "'";
            int count = CountResultRows(search);
            string query = "";
            List<int> districts = new List<int>();
            for (int i = 0; i < count; i++)
                districts = BringDistricts(search);
            districtComboBox.Items.Clear(); 

            foreach (int i in districts)
            {    
                query = "select \"Name\" FROM searchDistricts(" + i + ")";
                FillComboBox(query, districtComboBox);
            }
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
        private int CountResultRows(string query)
        {
            int count = 0;
            try
            {
                connection.Open();
                OdbcCommand command = new OdbcCommand(query, connection);
                OdbcDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    count++;
                }
                reader.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally { connection.Close(); }
            return count;
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
            finally { connection.Close(); }
            return id;
        }
        List<int> BringDistricts(string query)
        {
            List<int> districts = new List<int>();
            try
            {
                connection.Open();
                OdbcCommand command = new OdbcCommand(query, connection);
                OdbcDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    districts.Add(Convert.ToInt32(reader[0].ToString()));
                }
                reader.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally { connection.Close(); }
            return districts;
        }

        private void FillBusComboBox()
        {
            string search = "SELECT * FROM bringAvailableBuses();";
            try
            {
                connection.Open();
                OdbcCommand command = new OdbcCommand(search, connection);
                OdbcDataReader reader = command.ExecuteReader();
                string queryResult = ""; 

                if (reader.Read())
                {
                    queryResult = reader[0].ToString();
                }
                reader.Close();
                string[] lines = queryResult.Split(
                     new string[] { Environment.NewLine },
                       StringSplitOptions.None);

                foreach(string line in lines)
                    if(line != "")
                        busComboBox.Items.Add(line);
                
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
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

        private void dgvDriver2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
                dgvDriver2.Rows[e.RowIndex].Selected = true;

            DriverIDBox.Text = dgvDriver2.Rows[e.RowIndex].Cells[0].Value.ToString();
            updNameBox.Text = dgvDriver2.Rows[e.RowIndex].Cells[1].Value.ToString();
            updSnameBox.Text = dgvDriver2.Rows[e.RowIndex].Cells[2].Value.ToString();
            newSalaryBox.Text = dgvDriver2.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            int driverID = Convert.ToInt32(DriverIDBox.Text);
            int salary = Convert.ToInt32(newSalaryBox.Text);
            try
            {
                string query = "UPDATE \"Driver\" SET \"salary\" = " + salary + "WHERE \"driverID\" =  " + driverID + ";";
                connection.Open();
                OdbcCommand command = new OdbcCommand(query, connection);
                command.ExecuteNonQuery();
                string queryy = "SELECT * FROM \"Driver\"";
                MessageBox.Show("Salary has been updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillTable(queryy, dgvDriver2);
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            finally { connection.Close(); }
        }

        private void CleanBtn_Click(object sender, EventArgs e)
        {
            cityComboBox.SelectedIndex = -1;
            districtComboBox.SelectedIndex = -1;
            cityComboBox.SelectedIndex = -1;
            districtComboBox.SelectedIndex = -1;
            busComboBox.Text = "";
            nameBox.Text = "";
            surnameBox.Text = "";
            salaryBox.Text = "";
            phoneBox.Text = "";
        }

        private void CleanButton2_Click(object sender, EventArgs e)
        {
            DriverIDBox.Text = "";
            updNameBox.Text = "";
            updSnameBox.Text = "";
            newSalaryBox.Text = "";
        }
    }
}