using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using Windows.Media.AppBroadcasting;

namespace Project_SIM.Models
{
    public class SimBill
    {
        private readonly string connectionString;
        private string insertedTransactionId;
        private SimCustomer customer;
        private readonly int loyaltyPointPaymentID = 3;

        private string createdBillNumber;

        public SimBill()
        {
            connectionString = string.Empty;
            insertedTransactionId = string.Empty;
            createdBillNumber = string.Empty;


            connectionString = SqlConnectionClass.GetConnectionString();
            customer = new SimCustomer();
        }

        public List<PaymentMethod> GetPaymentMethods()
        {
            List<PaymentMethod> listPaymentMethods = new List<PaymentMethod>();

            string query = "SELECT * FROM payment_methods";

            using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read()) // Loop through all rows
                            {
                                PaymentMethod paymentMethod = new PaymentMethod
                                {
                                    ID = Convert.ToInt32(reader["PaymentMethodID"]),
                                    Name = reader["Name"].ToString(),
                                    Description = reader["Description"].ToString()
                                };

                                listPaymentMethods.Add(paymentMethod);
                            }

                            return listPaymentMethods;
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    FormatMaker.ShowErrorMessageBox($"Error executing query: {ex.Message}");
                }
            }

            return null;
        }

        public int GetLastTransactionID()
        {
            string query = "SELECT `TransactionID` FROM `transactions` ORDER BY `TransactionID` DESC";

            using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int ID = Convert.ToInt32(reader["TransactionID"]);
                                return ID;
                            }

                            return 1;
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    FormatMaker.ShowErrorMessageBox($"Error executing query: {ex.Message}");
                }
            }
            return 0;
        }

        public string GetInsertedTransactionId()
        {
            return insertedTransactionId;
        }
        public string GetCreatedBillNumber()
        {
            return createdBillNumber;
        }
        
        public string GenerateBillNumber()
        {
            DateTime currentDateTime = DateTime.Now;
            string datePart = currentDateTime.ToString("yyyyMMddHHmmss");
            string billNumber = datePart;

            return billNumber;
        }

        public bool CreateTransaction(string userId, string customerId, decimal totalAmount,decimal totalDiscount,decimal totalPaidAmount,decimal totalChange)
        {
            string billNumber = GenerateBillNumber();

            try
            {
                using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    using (MySqlTransaction transaction = sqlConnection.BeginTransaction())
                    {
                        try
                        {
                            string queryAddTransaction = "INSERT INTO `transactions`(`UserID`, `CustomerID`, `TotalAmount`,`TotalDiscount`, `TotalPaidAmount`, `TotalChange`, `BillNumber`) " +
                                "VALUES (@UserID, @CustomerID, @TotalAmount,@TotalDiscount,@TotalPaidAmount,@TotalChange, @BillNumber); SELECT LAST_INSERT_ID()";

                            using (MySqlCommand cmd = new MySqlCommand(queryAddTransaction, sqlConnection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@UserID", userId);
                                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                                cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                                cmd.Parameters.AddWithValue("@TotalDiscount", totalDiscount);
                                cmd.Parameters.AddWithValue("@TotalPaidAmount", totalPaidAmount);
                                cmd.Parameters.AddWithValue("@TotalChange", totalChange);
                                cmd.Parameters.AddWithValue("@BillNumber", billNumber);
                                insertedTransactionId = cmd.ExecuteScalar().ToString();
                            }

                            transaction.Commit();
                            createdBillNumber = billNumber;
                            return true;
                        }
                        catch (Exception ex)
                        {
                            FormatMaker.ShowErrorMessageBox($"Error during transaction: {ex.Message}");

                            // Rollback the transaction in case of an error
                            transaction.Rollback();
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FormatMaker.ShowErrorMessageBox($"Error connecting to the database: {ex.Message}");
                return false;
            }
        }

        public bool CreateTransactionPayments(List<Payments> payments,string loyaltyNumber)
        {
            try
            {
                using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    using (MySqlTransaction transaction = sqlConnection.BeginTransaction())
                    {
                        try
                        {
                            foreach (Payments payment in payments)
                            {
                                string queryAddTransactionPayments = "INSERT INTO `transactions_payment`(`TransactionID`, `PaymentMethodID`, `PaidAmount`, `Remark`)" +
                                    "VALUES (@TransactionID, @PaymentMethodID, @PaidAmount, @Remark)";

                                using (MySqlCommand cmd = new MySqlCommand(queryAddTransactionPayments, sqlConnection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@TransactionID", insertedTransactionId);
                                    cmd.Parameters.AddWithValue("@PaymentMethodID", payment.PaymentMethodID);
                                    cmd.Parameters.AddWithValue("@PaidAmount", payment.PaidAmount);
                                    cmd.Parameters.AddWithValue("@Remark", payment.Remark);
                                    cmd.ExecuteNonQuery();
                                }
                                if(payment.PaymentMethodID == loyaltyPointPaymentID)
                                {
                                    bool result = customer.RemoveLoyaltyPoints(loyaltyNumber, payment.PaidAmount);
                                }
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            FormatMaker.ShowErrorMessageBox($"Error during transaction: {ex.Message}");

                            // Rollback the transaction in case of an error
                            transaction.Rollback();
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FormatMaker.ShowErrorMessageBox($"Error connecting to the database: {ex.Message}");
                return false;
            }
        }

        public bool AddLoyalyaltyPoints(string loyaltyNumber, string pointsEarned)
        {
            return customer.AddLoyaltyPoints(loyaltyNumber, pointsEarned);
        }

        public bool CreateTransactionDetails(List<BillItem> bill)
        {
            try
            {
                using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    using (MySqlTransaction transaction = sqlConnection.BeginTransaction())
                    {
                        try
                        {
                            foreach (BillItem item in bill)
                            {
                                string queryAddTransactionPayments = "INSERT INTO `transaction_details`(`TransactionID`, `ProductID`, `Quantity`, `UnitPrice`, `Subtotal`) " +
                                    "VALUES (@TransactionID,@ProductID,@Quantity,@UnitPrice,@Subtotal)";

                                using (MySqlCommand cmd = new MySqlCommand(queryAddTransactionPayments, sqlConnection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@TransactionID", insertedTransactionId);
                                    cmd.Parameters.AddWithValue("@ProductID", item.ProductID);
                                    cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                                    cmd.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                                    cmd.Parameters.AddWithValue("@Subtotal", (item.Quantity * item.UnitPrice));
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            FormatMaker.ShowErrorMessageBox($"Error during transaction: {ex.Message}");

                            // Rollback the transaction in case of an error
                            transaction.Rollback();
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FormatMaker.ShowErrorMessageBox($"Error connecting to the database: {ex.Message}");
                return false;
            }
        }

        public List<ReturnItem> GetBilledItems(string billNumber)
        {
            List<ReturnItem> listBilledItems = new List<ReturnItem>();

            string query = "SELECT * FROM combined_billed_retuned_products WHERE BillNumber = @BillNumber";

            using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@BillNumber", billNumber);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    ReturnItem returnItem = new ReturnItem
                                    {
                                        BillNumber = reader["BillNumber"].ToString(),
                                        TransactionDetailID = Convert.ToInt32(reader["TransactionDetailID"]),
                                        ProductID = Convert.ToInt32(reader["ProductID"]),
                                        ProductCode = reader["ProductCode"].ToString(),
                                        ProductName = reader["ProductName"].ToString(),
                                        BilledQuantity = Convert.ToDouble(reader["BilledQuantity"]),
                                        Unit = reader["UnitOfMeasurement"].ToString(),
                                        Reason = reader["Reason"].ToString()
                                    };
                                    returnItem.ReturnedQuantity = 0.0;
                                    if (!String.IsNullOrEmpty(reader["ReturnedQuantity"].ToString()))
                                    {
                                        returnItem.ReturnedQuantity = Convert.ToDouble(reader["ReturnedQuantity"]);
                                    }

                                    listBilledItems.Add(returnItem);
                                }
                            }
                            else
                            {
                                return null;
                            }
                        }

                        return listBilledItems;
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error executing query: {ex.Message}");
                    return null;
                }
            }
        }


        public bool CreateRetrunedItem(ReturnItem returnItem, int loggedUserId)
        {
            try
            {
                using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    using (MySqlTransaction transaction = sqlConnection.BeginTransaction())
                    {
                        try
                        {
                            // Assuming you have variables like insertedTransactionId, loyaltyPointPaymentID, etc.
                            string queryAddTransactionPayments = "INSERT INTO `bill_return_item`(`BillNumber`, `TransactionDetailId`, `ReturnedQuantity`, `Unit`, `Reason`, `UserID`) VALUES (@BillNumber, @TransactionDetailId, @ReturnedQuantity, @Unit, @Reason, @UserID)";

                            using (MySqlCommand cmd = new MySqlCommand(queryAddTransactionPayments, sqlConnection, transaction))
                            {
                                // Assuming that you have properties like returnItem.BillNumber, returnItem.TransactionDetailID, etc.
                                cmd.Parameters.AddWithValue("@BillNumber", returnItem.BillNumber);
                                cmd.Parameters.AddWithValue("@TransactionDetailId", returnItem.TransactionDetailID);
                                cmd.Parameters.AddWithValue("@ReturnedQuantity", returnItem.ToReturnQuantity);
                                cmd.Parameters.AddWithValue("@Unit", returnItem.Unit);
                                cmd.Parameters.AddWithValue("@Reason", returnItem.Reason);
                                cmd.Parameters.AddWithValue("@UserID", loggedUserId);

                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            FormatMaker.ShowErrorMessageBox($"Error during transaction: {ex.Message}");

                            // Rollback the transaction in case of an error
                            transaction.Rollback();
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FormatMaker.ShowErrorMessageBox($"Error connecting to the database: {ex.Message}");
                return false;
            }
        }

    }

    public class BillItem
    {
        public int Number { get; set; }
        public int ProductID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public string Unit { get; set; }
    }
    public class ReturnItem
    {
        public string BillNumber { get; set; }
        public int TransactionDetailID {  get; set; }
        public int ProductID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double BilledQuantity { get; set; }
        public double ReturnedQuantity { get; set; } = 0.000;
        public double ToReturnQuantity { get; set; } = 0.000;
        public string Unit { get; set; }
        public string Reason {  get; set; } = string.Empty;

    }
    public class PaymentMethod
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Payments
    {
        public int PaymentMethodID { get; set; }
        public string PaidAmount { get; set; }
        public string Remark { get; set; }
    }
}
