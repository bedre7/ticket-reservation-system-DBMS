using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace OnlineBusReservation
{
    public partial class Login : Form
    {
        OdbcConnection connection = new OdbcConnection("DSN=PostgreSQL35W");
        public Login()
        {
            InitializeComponent();
        }

        private void closeLogin_Click(object sender, EventArgs e)
        {
            connection.Open();
            string query = "UPDATE \"Users\" SET \"status\" = 'Passive' WHERE \"status\" = 'Active'";
            OdbcCommand command = new OdbcCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
            this.Close();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (logUsernameBox.Text == "" || logPasswordBox.Text == "")
            {
                MessageBox.Show("Please enter username and password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string query = "SELECT * FROM \"Users\" WHERE \"username\" = '" + logUsernameBox.Text + "' and \"password\"= '" + logPasswordBox.Text + "'";
                connection.Open();
                OdbcCommand command = new OdbcCommand(query, connection);
                OdbcDataReader reader = command.ExecuteReader();

                if (reader.Read() == true)
                {
                    if (reader["type"].ToString() == "A")
                    {
                        new AdminForm().Show();
                    }
                    else if (reader["type"].ToString() == "P")
                    {
                        query = "UPDATE \"Users\" SET \"status\" = 'Active' WHERE \"username\" = '" + reader[1].ToString() + "' and \"password\"= '" + reader[2].ToString() + "'";
                        command = new OdbcCommand(query, connection);
                        command.ExecuteNonQuery();
                        new PassengerForm().Show();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password, Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logUsernameBox.Text = "";
                    logPasswordBox.Text = "";
                    logUsernameBox.Focus();
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

        }           
        private void signupBtn_Click(object sender, EventArgs e)
        {
            if (emailBox.Text == "" || usernameBox.Text == "" || passwordBox.Text == "")
            {
                MessageBox.Show("Please fill in all boxes", "Signup Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string query = "INSERT INTO \"Users\" ( \"username\", \"password\", \"email\") " +
                "VALUES('" + usernameBox.Text + "', '" + passwordBox.Text + "', '" + emailBox.Text + "')";
                connection.Open();
                OdbcCommand command = new OdbcCommand(query, connection);              
                command.ExecuteNonQuery();
                

                usernameBox.Text = passwordBox.Text = emailBox.Text = "";

                MessageBox.Show("Your Account has been Successfully Created!", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);                             
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
