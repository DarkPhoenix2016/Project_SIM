using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.Pkcs;
using System.Windows;
using System.Windows.Documents;
using static Project_SIM.Models.SimCustomer;

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

        public Customer Select(string loyaltyNumberOrCustomerID)
        {
            string query = $"SELECT * FROM customer_details WHERE LoyaltyNumber = @loyaltyNumber OR CustomerID = @loyaltyNumber OR UserID = @loyaltyNumber ";
            sqlConnection.Open();

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@loyaltyNumber", loyaltyNumberOrCustomerID);

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

        public CustomerLastBillReport SelectCustomerLastBillSummary(string CustomerID)
        {
            string query = @"SELECT * FROM customer_bill_summary WHERE CustomerID = @CustomerID";
      
            sqlConnection.Open();

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null && reader.HasRows)
                        {
                            reader.Read(); // Read the first row

                            CustomerLastBillReport customerBillReport = new CustomerLastBillReport
                            {
                                CustomerID = reader["CustomerID"] != DBNull.Value ? Convert.ToInt32(reader["CustomerID"]) : 0,
                                FullName = reader["FullName"] != DBNull.Value ? reader["FullName"].ToString() : string.Empty,

                                LastBillNumber = reader["LastBillNumber"] != DBNull.Value ? reader["LastBillNumber"].ToString() : string.Empty,
                                LastBillDate = reader["LastBillDate"] != DBNull.Value ? (DateTime)reader["LastBillDate"] : DateTime.MinValue,
                                LastBillTotalAmount = reader["LastBillTotalAmount"] != DBNull.Value ? Convert.ToDecimal(reader["LastBillTotalAmount"]) : 0.00m,
                                LastBillTotalDiscount = reader["LastBillTotalDiscount"] != DBNull.Value ? Convert.ToDecimal(reader["LastBillTotalDiscount"]) : 0.00m,
                                LastBillTotalPaidAmount = reader["LastBillTotalPaidAmount"] != DBNull.Value ? Convert.ToDecimal(reader["LastBillTotalPaidAmount"]) : 0.00m,
                                LastBillTotalChange = reader["LastBillTotalChange"] != DBNull.Value ? Convert.ToDecimal(reader["LastBillTotalChange"]) : 0.00m,
                                CreditedLoyaltyPoints = reader["CreditedLoyaltyPoints"] != DBNull.Value ? Convert.ToDecimal(reader["CreditedLoyaltyPoints"]) : 0.00m,
                                DebitedLoyaltyPoints = reader["DebitedLoyaltyPoints"] != DBNull.Value ? Convert.ToDecimal(reader["DebitedLoyaltyPoints"]) : 0.00m,

                                BillCount = reader["BillCount"] != DBNull.Value ? Convert.ToInt32(reader["BillCount"]) : 0,
                                TotalLoyaltyPointsCredit = reader["TotalLoyaltyPointsCredit"] != DBNull.Value ? Convert.ToDecimal(reader["TotalLoyaltyPointsCredit"]) : 0.00m,
                                TotalLoyaltyPointsDebit = reader["TotalLoyaltyPointsDebit"] != DBNull.Value ? Convert.ToDecimal(reader["TotalLoyaltyPointsDebit"]) : 0.00m,
                                LoyaltyPointsBalance = reader["LoyaltyPointsBalance"] != DBNull.Value ? Convert.ToDecimal(reader["LoyaltyPointsBalance"]) : 0.00m
                            };

                            Console.WriteLine($"Customer summary found: {customerBillReport.FullName}");
                            return customerBillReport;
                        }
                        else
                        {
                            Console.WriteLine($"No matching customer summary found: {query}");
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

            return null; // Return null if no customer summary is found
        }

        public List<CustomerAllBillSummry> SelectCustomerAllBillSummary(string CustomerID)
        {
            string query = @"SELECT * FROM `customer_bills` WHERE CustomerID = @CustomerID";

            sqlConnection.Open();

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", CustomerID);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<CustomerAllBillSummry> billSummaries = new List<CustomerAllBillSummry>();

                        while (reader != null && reader.Read())
                        {
                            CustomerAllBillSummry billSummary = new CustomerAllBillSummry
                            {
                                CustomerID = reader["CustomerID"] != DBNull.Value ? Convert.ToInt32(reader["CustomerID"]) : 0,
                                TransactionID = reader["TransactionID"] != DBNull.Value ? Convert.ToInt32(reader["TransactionID"]) : 0,
                                UserID = reader["UserID"] != DBNull.Value ? Convert.ToInt32(reader["UserID"]) : 0,
                                TransactionDate = reader["TransactionDate"] != DBNull.Value ? (DateTime)reader["TransactionDate"] : DateTime.MinValue,
                                TotalLineCount = reader["TotalLineCount"] != DBNull.Value ? Convert.ToInt32(reader["TotalLineCount"]) : 0,
                                TotalAmount = reader["TotalAmount"] != DBNull.Value ? reader["TotalAmount"].ToString() : string.Empty,
                                TotalDiscount = reader["TotalDiscount"] != DBNull.Value ? reader["TotalDiscount"].ToString() : string.Empty,
                                TotalPaidAmount = reader["TotalPaidAmount"] != DBNull.Value ? reader["TotalPaidAmount"].ToString() : string.Empty,
                                TotalChange = reader["TotalChange"] != DBNull.Value ? reader["TotalChange"].ToString() : string.Empty,
                                BillNumber = reader["BillNumber"] != DBNull.Value ? reader["BillNumber"].ToString() : string.Empty
                            };

                            billSummaries.Add(billSummary);
                        }

                        if (billSummaries.Count > 0)
                        {
                            Console.WriteLine($"Customer summaries found: {billSummaries.Count}");
                            return billSummaries;
                        }
                        else
                        {
                            Console.WriteLine($"No matching customer summaries found: {query}");
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

            return null; // Return null if no customer summaries are found
        }

        public List<TransactionDetailInfo> TransactionDetailInfos(string transactionID)
        {
            string query = "SELECT * FROM `billed_products` WHERE TransactionID = @TransactionID";

            sqlConnection.Open();

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@TransactionID", transactionID);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<TransactionDetailInfo> transactionDetailInfos = new List<TransactionDetailInfo>();

                        while (reader != null && reader.Read())
                        {
                            TransactionDetailInfo record = new TransactionDetailInfo
                            {
                                CustomerID = reader["CustomerID"] != DBNull.Value ? Convert.ToInt32(reader["CustomerID"]) : 0,
                                TransactionID = reader["TransactionID"] != DBNull.Value ? Convert.ToInt32(reader["TransactionID"]) : 0,
                                UserID = reader["UserID"] != DBNull.Value ? Convert.ToInt32(reader["UserID"]) : 0,
                                TransactionDetailID = reader["TransactionDetailID"] != DBNull.Value ? Convert.ToInt32(reader["TransactionDetailID"]) : 0,
                                ProductID = reader["ProductID"] != DBNull.Value ? Convert.ToInt32(reader["ProductID"]) : 0,
                                ProductCode = reader["ProductCode"] != DBNull.Value ? reader["ProductCode"].ToString() : string.Empty,
                                ProductName = reader["ProductName"] != DBNull.Value ? reader["ProductName"].ToString() : string.Empty,
                                Quantity = reader["Quantity"] != DBNull.Value ? Convert.ToDecimal(reader["Quantity"]) : 0,
                                UnitOfMeasurement = reader["UnitOfMeasurement"] != DBNull.Value ? reader["UnitOfMeasurement"].ToString() : string.Empty,
                                UnitPrice = reader["UnitPrice"] != DBNull.Value ? Convert.ToDecimal(reader["UnitPrice"]) : 0,
                                Subtotal = reader["Subtotal"] != DBNull.Value ? Convert.ToDecimal(reader["Subtotal"]) : 0,
                                BillNumber = reader["BillNumber"] != DBNull.Value ? reader["BillNumber"].ToString() : string.Empty
                            };

                            transactionDetailInfos.Add(record);
                        }

                        if (transactionDetailInfos.Count > 0)
                        {
                            Console.WriteLine($"Transaction details found: {transactionDetailInfos.Count}");
                            return transactionDetailInfos;
                        }
                        else
                        {
                            Console.WriteLine($"No matching transaction details found for TransactionID: {transactionID}");
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

            return null; // Return null if no transaction details are found
        }

        public List<LoyaltyPointTransaction> LoyaltyPointTransactions(string loayaltyNumber)
        {
            string query = "SELECT * FROM `loyaltypoints_transactions` WHERE LoyaltyNumber = @loayaltyNumber";

            sqlConnection.Open();

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@loayaltyNumber", loayaltyNumber);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<LoyaltyPointTransaction> transactionDetailInfos = new List<LoyaltyPointTransaction>();

                        while (reader != null && reader.Read())
                        {
                            LoyaltyPointTransaction record = new LoyaltyPointTransaction
                            {
                                TransactionID = reader["TransactionID"] != DBNull.Value ? Convert.ToInt32(reader["TransactionID"]) : 0,
                                TransactionDate = reader["TransactionDate"] != DBNull.Value ? (DateTime)reader["TransactionDate"] : DateTime.MinValue,
                                Amount = reader["Amount"] != DBNull.Value ? Convert.ToDecimal(reader["Amount"]) : 0,
                                State = reader["State"] != DBNull.Value ? reader["State"].ToString() : string.Empty
                            };

                            transactionDetailInfos.Add(record);
                        }

                        if (transactionDetailInfos.Count > 0)
                        {
                            Console.WriteLine($"Transaction details found: {transactionDetailInfos.Count}");
                            return transactionDetailInfos;
                        }
                        else
                        {
                            Console.WriteLine($"No matching transaction details found for LoyaltyNumber: {loayaltyNumber}");
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

            return null; // Return null if no transaction details are found
        }

        public bool AddLoyaltyPoints(string loyaltyNumber, string loyaltyPoints)
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

        public class CustomerLastBillReport
        {
            public int CustomerID { get; set; }
            public string FullName { get; set; }
            public string LastBillNumber { get; set; }
            public DateTime LastBillDate { get; set; }
            public decimal LastBillTotalAmount { get; set; }
            public decimal LastBillTotalDiscount { get; set; }
            public decimal LastBillTotalPaidAmount { get; set; }
            public decimal LastBillTotalChange { get; set; }
            public decimal CreditedLoyaltyPoints { get; set; }
            public decimal DebitedLoyaltyPoints { get; set; }
            public int BillCount { get; set; }
            public decimal TotalLoyaltyPointsCredit { get; set; }
            public decimal TotalLoyaltyPointsDebit { get; set; }
            public decimal LoyaltyPointsBalance { get; set; }
        }

        public class CustomerAllBillSummry
        {
            public int CustomerID { get; set; }  
            public int TransactionID { get; set; }  
            public int UserID { get; set; }
            public DateTime TransactionDate { get; set; }
            public int TotalLineCount { get; set; }
            public string TotalAmount { get; set; }
            public string TotalDiscount { get; set; }
            public string TotalPaidAmount { get; set; }
            public string TotalChange { get; set; }
            public string BillNumber { get; set; }
            public string BillTotalAmount { get;set; }
        }

        public class TransactionDetailInfo
        {
            public int TransactionID { get; set; }
            public string BillNumber { get; set; }
            public int UserID { get; set; }
            public int CustomerID { get; set; }
            public int TransactionDetailID { get; set; }
            public int ProductID { get; set; }
            public string ProductCode { get; set; }
            public string ProductName { get; set; }
            public decimal Quantity { get; set; }
            public string UnitOfMeasurement { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal Subtotal { get; set; }
        }

        public class LoyaltyPointTransaction
        {
            public int TransactionID { get; set; }
            public DateTime TransactionDate { get; set; }
            public decimal Amount { get; set; }
            public string State { get; set; }
        }
    }
}
