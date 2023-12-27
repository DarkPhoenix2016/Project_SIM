using MySql.Data.MySqlClient;
using System;
using System.Windows;

namespace Project_SIM.Models
{
    public class SimCustomer
    {
        private readonly string connectionString;
        private MySqlConnection sqlConnection;

        public SimCustomer()
        {
            connectionString = SqlConnectionClass.GetConnectionString();
            sqlConnection = new MySqlConnection(connectionString);
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

                // Insert the new User Account
                SimUser user = new SimUser();
                bool result = user.Register(fullName, username, hashedPassword); // Use hashed password
                if (result)
                {
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
                else
                {
                    MessageBox.Show("Error while registration ");
                    return false;
                }
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
            string query = $"SELECT COUNT(*) FROM customers WHERE LoyaltyNumber = @loyaltyNumber";
            sqlConnection.Open();

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@loyaltyNumber", loyaltyNumber);

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
            string query = $"SELECT * FROM customer_details WHERE LoyaltyNumber = @loyaltyNumber";
            sqlConnection.Open();

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@loyaltyNumber", loyaltyNumber);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
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
                                LoyaltyPoints = Convert.ToInt32(reader["LoyaltyPoints"]),
                                DateOfJoin = (DateTime)reader["DateOfJoin"]
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

        public  bool AddLoyaltyPoints(string loyaltyNumber, string loyaltyPoints)
        {
            try
            {
                sqlConnection.Open();

                using (MySqlTransaction transaction = sqlConnection.BeginTransaction())
                {
                    try
                    {
                        string queryUpdateLoyaltyPoints = "INSERT INTO `loyaltypoints_transactions`(`LoyaltyNumber`,`Amount`, `State`) VALUES (@loyaltyNumber,@loyaltyPoints,'Credit')";

                        using (MySqlCommand cmd = new MySqlCommand(queryUpdateLoyaltyPoints, sqlConnection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@loyaltyPoints", loyaltyPoints);
                            cmd.Parameters.AddWithValue("@loyaltyNumber", loyaltyNumber);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error during transaction: {ex.Message}");

                        // Rollback the transaction in case of an error
                        transaction.Rollback();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to the database: {ex.Message}");
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public  bool RemoveLoyaltyPoints(string loyaltyNumber, string loyaltyPoints)
        {
            try
            {
                sqlConnection.Open();

                using (MySqlTransaction transaction = sqlConnection.BeginTransaction())
                {
                    try
                    {
                        string queryUpdateLoyaltyPoints = "INSERT INTO `loyaltypoints_transactions`(`LoyaltyNumber`,`Amount`, `State`) VALUES (@loyaltyNumber,@loyaltyPoints,'Debit')";

                        using (MySqlCommand cmd = new MySqlCommand(queryUpdateLoyaltyPoints, sqlConnection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@loyaltyPoints", loyaltyPoints);
                            cmd.Parameters.AddWithValue("@loyaltyNumber", loyaltyNumber);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error during transaction: {ex.Message}");

                        // Rollback the transaction in case of an error
                        transaction.Rollback();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to the database: {ex.Message}");
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
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
            public DateTime DateOfJoin { get; set; }
        }
    }
}
