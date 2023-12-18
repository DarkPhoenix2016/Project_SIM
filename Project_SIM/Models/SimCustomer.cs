using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace Project_SIM.Models
{
    public class SimCustomer
    {
        private MySqlConnection sqlConnection;
        private MySqlDataReader reader;

        public SimCustomer()
        {
            sqlConnection = new MySqlConnection(SqlConnectionClass.GetConnectionString());
        }

        public bool Register(string fullName, string username, string loyaltyNumber, string password)
        {
            MySqlTransaction transaction = null;

            try
            {
                // Hash the password and get salt
                string hashedPassword = Authenticator.HashPassword(password);

                // Open connection and begin transaction
                sqlConnection.Open();
                transaction = sqlConnection.BeginTransaction();

                // Insert the new user account
                string queryAddUserAccount = $"INSERT INTO `users`(`Username`, `PasswordHash`, `FullName`, `AccessLevel`)" +
                    $"VALUES ('{username}','{hashedPassword}','{fullName}','Customer')";

                // ExecuteNonQuery is used for non-query commands (INSERT, UPDATE, DELETE)
                new MySqlCommand(queryAddUserAccount, sqlConnection, transaction).ExecuteNonQuery();

                // Insert the new customer account
                string queryAddCustomerAccount = $"INSERT INTO `customers`(`UserID`, `LoyaltyNumber`, `LoyaltyPoints`)" +
                    $"VALUES (LAST_INSERT_ID(),'{loyaltyNumber}','0')";

                // ExecuteNonQuery is used for non-query commands (INSERT, UPDATE, DELETE)
                new MySqlCommand(queryAddCustomerAccount, sqlConnection, transaction).ExecuteNonQuery();

                // Commit the transaction
                transaction.Commit();

                // Display success message box
                MessageBox.Show("Customer registration successful.");

                return true;
            }
            catch (MySqlException ex)
            {
                // Roll back the transaction in case of an exception
                MessageBox.Show($"Error registering customer: {ex.Message}");
                transaction?.Rollback();
                return false;
            }
            finally
            {
                // Close connection
                sqlConnection.Close();
            }
        }

        public bool IsAvailable(string loyaltyNumber)
        {
            string query = $"SELECT COUNT(*) FROM customers WHERE LoyaltyNumber = '{loyaltyNumber}';";
            sqlConnection.Open();

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count <= 0)
                    {
                        Console.WriteLine($"Loyalty number '{loyaltyNumber}' is already in use.");
                        return false;
                    }
                    else
                    {
                        Console.WriteLine($"Loyalty number '{loyaltyNumber}' is available.");
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error executing query: {ex.Message}");
            }
            finally
            {
                sqlConnection.Close();
            }

            // Return false in case of an error or if loyalty number is not available
            return false;
        }

        public Customer Select(string loyaltyNumber)
        {
            string query = $"SELECT * FROM customer_details WHERE LoyaltyNumber = '{loyaltyNumber}';";
            sqlConnection.Open();

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                {
                    reader = cmd.ExecuteReader();

                    if (reader != null && reader.HasRows)
                    {
                        reader.Read(); // Read the first row

                        Customer customer = new Customer
                        {
                            UserID = Convert.ToInt32(reader["UserID"]),
                            Username = reader["Username"].ToString(),
                            AccessLevel = reader["AccessLevel"].ToString(),
                            FullName = reader["FullName"].ToString(),
                            CustomerID = Convert.ToInt32(reader["CustomerID"]),
                            LoyaltyNumber = reader["LoyaltyNumber"].ToString(),
                            LoyaltyPoints = Convert.ToInt32(reader["LoyaltyPoints"])
                        };

                        Console.WriteLine($"Customer found: {customer.FullName}");
                        return customer;
                    }
                    else
                    {
                        Console.WriteLine($"No matching customer found: {query}");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error executing query: {ex.Message}");
            }
            finally
            {
                sqlConnection.Close();
            }

            return null; // Return null if no customer is found
        }


        public bool Update()
        {
            // Implement your update logic here
            return false;
        }

        public bool Delete()
        {
            // Implement your delete logic here
            return false;
        }

        public class Customer
        {
            public int UserID { get; set; }
            public string Username { get; set; }
            public string AccessLevel { get; set; }
            public string FullName { get; set; }
            public int CustomerID { get; set; }
            public string LoyaltyNumber { get; set; }
            public int LoyaltyPoints { get; set; }
        }
    }
    

}
