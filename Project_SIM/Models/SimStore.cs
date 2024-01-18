using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Project_SIM.Models
{
    public class SimStore
    {
        private readonly string connectionString;

        public SimStore()
        {
            // Get connection string
            connectionString = string.Empty;
            connectionString = SqlConnectionClass.GetConnectionString();
        }

        public StoreDetails GetFirstStore()
        {
            StoreDetails store = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM store_details LIMIT 1";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                store = new StoreDetails
                                {
                                    StoreId = reader["storeId"].ToString(),
                                    StoreName = reader["storeName"].ToString(),
                                    StoreAddress = reader["storeAddress"].ToString(),
                                    StoreStartDate = Convert.ToDateTime(reader["storeStartDate"])
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception (log it, display an error message, etc.)
                    Console.WriteLine("Error executing GetFirstStore: " + ex.Message);
                }
                finally
                {
                    // Ensure the connection is closed even if an exception occurs
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }

            return store;
        }

        public List<StoreDetails> GetAllStores()
        {
            List<StoreDetails> stores = new List<StoreDetails>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM store_details";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StoreDetails store = new StoreDetails
                                {
                                    StoreId = reader["storeId"].ToString(),
                                    StoreName = reader["storeName"].ToString(),
                                    StoreAddress = reader["storeAddress"].ToString(),
                                    StoreStartDate = Convert.ToDateTime(reader["storeStartDate"])
                                };

                                stores.Add(store);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception (log it, display an error message, etc.)
                    Console.WriteLine("Error executing GetAllStores: " + ex.Message);
                }
                finally
                {
                    // Ensure the connection is closed even if an exception occurs
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }

            return stores;
        }

        public void AddStore(StoreDetails store)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO store_details (storeId, storeName, storeAddress, storeStartDate) " +
                                   "VALUES (@storeId, @storeName, @storeAddress, @storeStartDate)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@storeId", store.StoreId);
                        command.Parameters.AddWithValue("@storeName", store.StoreName);
                        command.Parameters.AddWithValue("@storeAddress", store.StoreAddress);
                        command.Parameters.AddWithValue("@storeStartDate", store.StoreStartDate);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception (log it, display an error message, etc.)
                    Console.WriteLine("Error executing AddStore: " + ex.Message);
                }
                finally
                {
                    // Ensure the connection is closed even if an exception occurs
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

        public void UpdateStore(StoreDetails store)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE store_details " +
                                   "SET storeName = @storeName, storeAddress = @storeAddress, storeStartDate = @storeStartDate " +
                                   "WHERE storeId = @storeId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@storeName", store.StoreName);
                        command.Parameters.AddWithValue("@storeAddress", store.StoreAddress);
                        command.Parameters.AddWithValue("@storeStartDate", store.StoreStartDate);
                        command.Parameters.AddWithValue("@storeId", store.StoreId);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception (log it, display an error message, etc.)
                    Console.WriteLine("Error executing UpdateStore: " + ex.Message);
                }
                finally
                {
                    // Ensure the connection is closed even if an exception occurs
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

        public void DeleteStore(string storeId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "DELETE FROM store_details WHERE storeId = @storeId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@storeId", storeId);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception (log it, display an error message, etc.)
                    Console.WriteLine("Error executing DeleteStore: " + ex.Message);
                }
                finally
                {
                    // Ensure the connection is closed even if an exception occurs
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

        public string CalculateAge()
        {
            DateTime currentDate = DateTime.Now;

            StoreDetails shopData = GetFirstStore();
            DateTime dateOfJoin = shopData.StoreStartDate;

            // Calculate the difference in years, months, and days
            TimeSpan difference = currentDate - dateOfJoin;

            int years = (int)(difference.TotalDays / 365.25);
            int months = (int)((difference.TotalDays % 365.25) / 30.44);
            int days = (int)(difference.TotalDays % 30.44);

            // Adjust the age if the birthday hasn't occurred yet in the current year
            if (currentDate.DayOfYear < dateOfJoin.DayOfYear)
            {
                years--;
                months = 12 - dateOfJoin.Month + currentDate.Month - 1;
                days = (int)(difference.TotalDays % 30.44);
            }

            return $"{years} Year{(years != 1 ? "s" : "")} {months} Month{(months != 1 ? "s" : "")} {days} Day{(days != 1 ? "s" : "")}";
        }




    }

    public class StoreDetails
    {
        public string StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public DateTime StoreStartDate { get; set; }
    }
}
