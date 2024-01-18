using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SIM.Models
{
    public class SimManager
    {
        private readonly string connectionString;


        public SimManager()
        {
            connectionString = string.Empty;
            connectionString = SqlConnectionClass.GetConnectionString();

        }

        //Creating Dashborad Data for Manager
        public decimal GetTotalAmountBilled()
        {
            string query = "call TotalSumOfTransactions();";
            decimal totalAmount = 0;

            using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                totalAmount = Convert.ToDecimal(reader["Total"].ToString());
                            }
                            else
                            {
                                return 0;
                            }
                        }

                        return totalAmount;
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error executing query: {ex.Message}");
                    return 0;
                }
            }
        }

        public int GetTotalCustomers()
        {
            string query = "call TotalCustomersTillNow(); ;";
            int totalAmount = 0;

            using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                totalAmount = Convert.ToInt32(reader["Total"].ToString());
                            }
                            else
                            {
                                return 0;
                            }
                        }

                        return totalAmount;
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error executing query: {ex.Message}");
                    return 0;
                }
            }
        }

        public int GetTotalProducts()
        {
            string query = "call TotalProductsTillNow();";
            int totalAmount = 0;

            using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                totalAmount = Convert.ToInt32(reader["Total"].ToString());
                            }
                            else
                            {
                                return 0;
                            }
                        }

                        return totalAmount;
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error executing query: {ex.Message}");
                    return 0;
                }
            }
        }

        public int GetTotalTransactions()
        {
            string query = "call TotalCountOfTransactionsTillNow(); ";
            int totalAmount = 0;

            using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                totalAmount = Convert.ToInt32(reader["Total"].ToString());
                            }
                            else
                            {
                                return 0;
                            }
                        }

                        return totalAmount;
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error executing query: {ex.Message}");
                    return 0;
                }
            }
        }

    }
}
