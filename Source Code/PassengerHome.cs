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
    public partial class PassengerHome : UserControl
    {
        OdbcConnection connection = new OdbcConnection("DSN=PostgreSQL35W");
        public static int tripID = 0;
        public PassengerHome()
        {
            InitializeComponent();
            FillComboBox("SELECT DISTINCT \"name\" FROM \"City\" ORDER BY \"name\" ASC", fromCBox);
            datePicker1.MinDate = DateTime.Now;
            datePicker1.MaxDate = DateTime.Now.AddDays(25);
        }

        private void SearchTripBtn_Click(object sender, EventArgs e)
        {
            if (fromCBox.SelectedIndex == -1 || toCBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose departure and destination", "Invalid Search", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }  
            string departure = fromCBox.Text;
            string destination = toCBox.Text;
            string query = "SELECT  \"trip\", \"departureTime\", \"travelDuration\", \"arrivalTime\", \"departure\", \"destination\", \"price\" FROM \"Route\"" +
                           "INNER JOIN \"Trip\" ON \"Trip\".\"route\" = \"Route\".\"routeID\"" +
                           "INNER JOIN \"Ticket\" ON \"Trip\".\"tripID\" = \"Ticket\".\"trip\"" +
                           "WHERE \"departure\" = '" + departure + "' AND \"destination\" = '" + destination + "';";

            HandleControls(query);

        }

        private void HandleControls(string query)
        {
            List<Panel> panels = new List<Panel>();
            List<Button> buttons = new List<Button>();
            List<Label> labels = new List<Label>();

            Panel p;
            Button newButton;
            Label IDlabel; 
            Label Info; 
            Label priceLabel; 
            
            try
            {
                connection.Open();
                OdbcCommand command = new OdbcCommand(query, connection);
                OdbcDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    p = new Panel();
                    newButton = new Button();
                    IDlabel = new Label();
                    Info = new Label();
                    priceLabel = new Label();

                    Info.Size = new Size(574, 93);
                    Info.Font = new Font("Century Gothic", 14);
                    p.BackColor = Color.FromArgb(240, 211, 207);

                    newButton.Location = new Point(650, 50);
                    newButton.Font = new Font("Century Gothic", 15);
                    newButton.Size = new Size(140, 40);
                    newButton.BackColor = Color.FromArgb(64, 202, 137);
                    newButton.Cursor = Cursors.Hand;

                    Info.Location = new Point(25, 25);
                    IDlabel.Location = new Point(1, 1);
                    priceLabel.Location = new Point(650, 10);
                    priceLabel.Font = new Font("Century Gothic", 16);

                    p.Size = new Size(flowLayoutPanel2.ClientSize.Width, 110);
                    p.BorderStyle = BorderStyle.Fixed3D;
                    
                    IDlabel.Text = reader[0].ToString();
                    Info.Text = reader[1].ToString() + "       --------       " + "  🕒  " + reader[2].ToString() + " Hrs" +
                    "       --------       " + reader[3].ToString() + "\n\n              " + reader[4].ToString() +
                    "           ----->           " + reader[5].ToString();

                    priceLabel.Text = reader[6].ToString() + " ₺";

                    newButton.Text = "Select";
                     
                    p.Name = "panel" + (flowLayoutPanel2.Controls.Count + 1);                                        
                    p.Controls.Add(newButton);
                    p.Controls.Add(Info);
                    p.Controls.Add(IDlabel);
                    p.Controls.Add(priceLabel);
                    panels.Add(p);
                    labels.Add(IDlabel);
                    buttons.Add(newButton);  
                }
                reader.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                connection.Close();
            }

            flowLayoutPanel2.Controls.Clear();
            foreach (Panel panel in panels)
                flowLayoutPanel2.Controls.Add(panel);

            if (!panels.Any())
                MessageBox.Show("No trip was found mathing your search :(", "No Trip", MessageBoxButtons.OK, MessageBoxIcon.Information);
            

            foreach (Button button in buttons)
            {
                button.Click += (se, ev) => button_Click(se, ev, buttons, labels);              
            }
        }

        private void button_Click(object se, EventArgs ev, List<Button> buttons, List<Label> labels)
        {
            Button button = se as Button;
            int index = buttons.IndexOf(button);
            tripID = Convert.ToInt32(labels[index].Text);
            new PassengerInfo(tripID, datePicker1.Text).ShowDialog();
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

        private void fromCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            toCBox.Items.Clear();
            FillComboBox("SELECT DISTINCT \"name\" FROM \"City\" " +
            "WHERE \"name\" != '" + fromCBox.GetItemText(fromCBox.SelectedItem) + "'ORDER BY \"name\" ASC", toCBox);
        }
    }
}
