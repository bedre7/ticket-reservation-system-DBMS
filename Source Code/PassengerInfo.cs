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
    public partial class PassengerInfo : Form
    {
        OdbcConnection connection = new OdbcConnection("DSN=PostgreSQL35W");
        public int TripID = 0;
        public int contactID = 0;
        public int userID = 0;
        public int passengerID = 0;
        public int ticketID = 0;
        public int discountID = 0;
        public int reservationID = 0;
        public int price = 0;
        public int finalPrice = 0;
        public string departureDate;
        public PassengerInfo()
        {
            InitializeComponent();
        }
        public PassengerInfo(int tripID, string date)
        {
            InitializeComponent();
            TripLabel.Text = tripID.ToString();            
            TripID = tripID;
            departureDate = date;
            DisplayPrice();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FinishBtn_Click(object sender, EventArgs e)
        {
           
            if (EmailBox.Text == "" || PhoneBox.Text == "" || NameBox.Text == "" || SurnameBox.Text == "")
            {
                MessageBox.Show("Please fill in all boxes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
            Random rand = new Random();
            List<int> seats = new List<int>();
            for(int i = 1; i <= 20; i++)
                seats.Add(rand.Next(10));

            try
            {
                string query;
                query = "INSERT INTO \"ContactInformation\"(\"phoneNo\", \"email\") VALUES('"
                    + PhoneBox.Text + "' , '" + EmailBox.Text + "@ " + "')";
                ExecuteQuery(query);

                query = "SELECT \"contactID\" FROM \"ContactInformation\" WHERE \"phoneNo\" = '" + PhoneBox.Text + "'" +
                    "AND \"email\" = '" + EmailBox.Text + "@ " + "';";
                contactID = ExecuteQueryAndGetValue(query);
                
                query = "SELECT \"userID\" FROM \"Users\" WHERE \"status\" = 'Active';";
                userID = ExecuteQueryAndGetValue(query);

                query = "INSERT INTO \"Passenger\"(\"name\", \"surname\", \"birthDate\", \"contact\", \"userID\") VALUES('"
                    + NameBox.Text + "' , '" + SurnameBox.Text + "' , '" + BirthdatePicker.Text + "' , " + contactID + " , " + userID + ");";
                
                ExecuteQuery(query);

                query = "SELECT \"passengerID\" FROM \"Passenger\" WHERE \"contact\" = " + contactID + ";";
                passengerID = ExecuteQueryAndGetValue(query);

                string birthdate = BirthdatePicker.Value.ToString("yyyy-MM-dd");
                query = "SELECT * FROM getDiscountID(DATE '" + birthdate + "');";
                discountID = ExecuteQueryAndGetValue(query);

                query = "SELECT * FROM calculatePrice(" + price + ", DATE '" + birthdate + "');";
                finalPrice = ExecuteQueryAndGetValue(query);

                query = "INSERT INTO \"Reservation\"(\"journeyDate\", \"seatNo\", \"passengerID\", \"tripID\", \"ticketID\", \"discount\") VALUES('"
                    + departureDate + "' , " + seats[0] + " , '" + passengerID + "' , " + TripID + " , " + ticketID + " , " + discountID + ");";

                ExecuteQuery(query);

                query = "SELECT \"reservationID\" FROM \"Reservation\" WHERE \"tripID\" = " + TripID + 
                    " AND \"passengerID\" = " + passengerID + ";";
                reservationID = ExecuteQueryAndGetValue(query);

                query = "INSERT INTO \"Payment\"(\"amount\", \"passenger\", \"reservation\") VALUES('"
                    + finalPrice + "' , '" + passengerID + "' , '" + reservationID  + "');";
                ExecuteQuery(query);

                this.Close();
                MessageBox.Show("Your ticket has been booked!\n\n Ticket Fare : " + finalPrice.ToString() + "₺", "Bon Voyage!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally {       connection.Close();       }

                
        }
        private int ExecuteQueryAndGetValue(string query)
        {
            int value = 0;
            connection.Open();
            OdbcCommand command = new OdbcCommand(query, connection);
            OdbcDataReader reader = command.ExecuteReader();
            if (reader.Read())
                value = Convert.ToInt32(reader[0]);
            reader.Close();
            connection.Close();
            return value;
        }
        private void DisplayPrice()
        {
            string query = "SELECT \"ticketID\", \"price\" FROM \"Ticket\" INNER JOIN \"Trip\" ON \"trip\" = \"tripID\"" +
                    "WHERE \"trip\" = " + TripID + ";";
            connection.Open();
            OdbcCommand command = new OdbcCommand(query, connection);
            OdbcDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                ticketID = Convert.ToInt32(reader[0]);
                price = Convert.ToInt32(reader[1]);
                priceBox.Text = price.ToString() + "₺";
            }
            reader.Close();
            connection.Close();
        }
        private string GetBirthdate(string date)
        {
            string BirthDate = "";
            string queryy = "SELECT to_date('" + date + "','dd-mm-yyyy');";
            connection.Open();
            OdbcCommand command = new OdbcCommand(queryy, connection);
            OdbcDataReader reader = command.ExecuteReader();
            if (reader.Read())
                BirthDate = reader[0].ToString();
            reader.Close();
            connection.Close();
            return BirthDate;
        }
        private void ExecuteQuery(string query)
        {
            try
            {              
                connection.Open();
                OdbcCommand command = new OdbcCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally { connection.Close(); }
        }
    }
}
