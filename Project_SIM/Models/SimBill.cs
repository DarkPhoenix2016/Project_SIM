using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Transactions;
using Windows.Media.AppBroadcasting;
using static Project_SIM.Models.SimCustomer;

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

        // Getting Data from Database related to the Bills
        // Getting Listed payment methods from database

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
        
        //Getting Inserted Transaction ID for the bill - Then can create other record for the bill
        public string GetInsertedTransactionId()
        {
            return insertedTransactionId;
        }
        
        // Getting created Billnumber for the Bill - then can create other recored with that bill number 
        public string GetCreatedBillNumber()
        {
            return createdBillNumber;
        }
        
        // Creaeting a bill number baed on Date and time
        public string GenerateBillNumber()
        {
            DateTime currentDateTime = DateTime.Now;
            string datePart = currentDateTime.ToString("yyyyMMddHHmmss");
            string billNumber = datePart;

            return billNumber;
        }

        //Creating a new bill ( Trasaction with customer)
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

        //Creating a new payment for the bill ( Trasaction with customer)
        public bool CreateTransactionPayments(List<Payments> payments, string billNumber, string loyaltyNumber)
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
                                    bool result = customer.RemoveLoyaltyPoints(billNumber,loyaltyNumber, payment.PaidAmount);
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

        //updateting loyalty points as bill
        public bool AddLoyalyaltyPoints(string billNumber, string loyaltyNumber, string pointsEarned)
        {
            return customer.AddLoyaltyPoints(billNumber, loyaltyNumber, pointsEarned);
        }

        //Getting and creating Full Bill for reporting

        public Tuple<SalesTransaction, List<SalesTransactionDetails>, List<Payments>, List<LoyaltyTransaction>> GetFullBill(string BillNumber, int TransactionID)
        {
            SalesTransaction salesTransaction = new SalesTransaction();
            List<SalesTransactionDetails> detailsList = new List<SalesTransactionDetails>();
            List<Payments> paymentsList = new List<Payments>();
            List<LoyaltyTransaction> loyaltyTransactionList = new List<LoyaltyTransaction>();

            using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
            {
                string query = $"SELECT * FROM `customer_bills` WHERE BillNumber = '{BillNumber}'";

                try
                {
                    sqlConnection.Open();

                    MySqlCommand cmd = new MySqlCommand(query, sqlConnection);

                    MySqlDataReader reader1 = cmd.ExecuteReader();
                    
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            salesTransaction = new SalesTransaction()
                            {
                                TransactionID = Convert.ToInt32(reader1["TransactionID"]),
                                UserID = Convert.ToInt32(reader1["UserID"]),
                                CustomerID = Convert.ToInt32(reader1["CustomerID"]),
                                CustomerUserID = reader1["CustomerUserID"] == DBNull.Value ? 0 : Convert.ToInt32(reader1["CustomerUserID"]),
                                UserFullName = reader1["UserFullName"].ToString(),
                                CustomerFullName = reader1["CustomerFullName"].ToString(),
                                TransactionDate = Convert.ToDateTime(reader1["TransactionDate"]),
                                TotalLineCount = Convert.ToInt64(reader1["TotalLineCount"]),
                                TotalAmount = Convert.ToDecimal(reader1["TotalAmount"]),
                                TotalDiscount = Convert.ToDecimal(reader1["TotalDiscount"]),
                                TotalPaidAmount = Convert.ToDecimal(reader1["TotalPaidAmount"]),
                                TotalChange = Convert.ToDecimal(reader1["TotalChange"]),
                                BillNumber = reader1["BillNumber"].ToString()
                            };
                        }
                    }
                    
                }
                catch (MySqlException ex)
                {
                    FormatMaker.ShowErrorMessageBox($"Error executing query: {ex.Message}");
                }
                finally
                {
                    sqlConnection.Close();
                }

                query = $"SELECT * FROM `billed_products` WHERE BillNumber = '{BillNumber}'";
                try
                {
                    sqlConnection.Open();
                    MySqlCommand cmd = new MySqlCommand(query, sqlConnection);
                    MySqlDataReader reader2 = cmd.ExecuteReader();
     
                    if (reader2.HasRows)
                    {
                        int count = 1;
                        while (reader2.Read())
                        {
                            SalesTransactionDetails salesTransactionDetails = new SalesTransactionDetails()
                            {
                                Number = count,
                                TransactionDate = Convert.ToDateTime(reader2["TransactionDate"]),
                                TransactionID = Convert.ToInt32(reader2["TransactionID"]),
                                TransactionDetailID = Convert.ToInt32(reader2["TransactionDetailID"]),
                                BillNumber = reader2["BillNumber"].ToString(),
                                ProductCode = reader2["ProductCode"].ToString(),
                                ProductName = reader2["ProductName"].ToString(),
                                Quantity = Convert.ToDecimal(reader2["Quantity"]),
                                UnitOfMeasurement = reader2["UnitOfMeasurement"].ToString(),
                                UnitPrice = Convert.ToDecimal(reader2["UnitPrice"]),
                                Subtotal = Convert.ToDecimal(reader2["Subtotal"])
                            };
                            detailsList.Add(salesTransactionDetails);
                            count++;
                        }
                    }
                        
                    
                }
                catch (MySqlException ex)
                {
                    FormatMaker.ShowErrorMessageBox($"Error executing query: {ex.Message}");
                }
                finally
                {
                    sqlConnection.Close();
                }

                query = "SELECT * FROM `transactions_payment` WHERE TransactionID = @TransactionID";
                try
                {
                    sqlConnection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@TransactionID", TransactionID);

                        using (MySqlDataReader reader3 = cmd.ExecuteReader())
                        {
                            if (reader3.HasRows)
                            {
                                while (reader3.Read())
                                {
                                    Payments payment = new Payments()
                                    {
                                        PaymentMethodID = Convert.ToInt32(reader3["PaymentMethodID"]),
                                        PaidAmount = reader3["PaidAmount"].ToString(),
                                        Remark = reader3["Remark"].ToString()
                                    };
                                    paymentsList.Add(payment);
                                }
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    FormatMaker.ShowErrorMessageBox($"Error executing query: {ex.Message}");
                }
                finally
                {
                    sqlConnection.Close();
                }
                query = "SELECT * FROM `loyaltypoints_transactions` WHERE BillNumber = @BillNumber";
                try
                {
                    sqlConnection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@BillNumber", BillNumber);

                        using (MySqlDataReader reader4 = cmd.ExecuteReader())
                        {
                            if (reader4.HasRows)
                            {
                                while (reader4.Read())
                                {
                                    LoyaltyTransaction payment = new LoyaltyTransaction()
                                    {
                                        TransactionID = Convert.ToInt32(reader4["TransactionID"]),
                                        TransactionDate = Convert.ToDateTime(reader4["TransactionDate"]),
                                        LoyaltyNumber = reader4["LoyaltyNumber"].ToString(),
                                        Amount = Convert.ToDecimal(reader4["Amount"].ToString()),
                                        State = reader4["State"].ToString()

                                    };

                                    if (reader4["State"].ToString() == "Credit")
                                    {

                                        payment.TotalEarnedAmount += Convert.ToDecimal(reader4["Amount"].ToString());
                                    }
                                    if (reader4["State"].ToString() == "Debit")
                                    {

                                        payment.TotalSpendAmount += Convert.ToDecimal(reader4["Amount"].ToString());
                                    }
                                    loyaltyTransactionList.Add(payment);
                                }
                            }
                            else
                            {
                                LoyaltyTransaction payment = new LoyaltyTransaction()
                                {
                                    TransactionID = 0,
                                    TransactionDate = DateTime.Now,
                                    LoyaltyNumber = string.Empty,
                                    Amount = 0,
                                    State = string.Empty,
                                    TotalEarnedAmount =0,
                                    TotalSpendAmount = 0

                                };
                                loyaltyTransactionList.Add(payment);
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    FormatMaker.ShowErrorMessageBox($"Error executing query: {ex.Message}");
                }
                finally
                {
                    sqlConnection.Close();
                }
            }

            return Tuple.Create(salesTransaction, detailsList, paymentsList, loyaltyTransactionList);
        }

        public List<ReturnItem> GetBilledItems(string billNumber)
        {
            List<ReturnItem> listBilledItems = new List<ReturnItem>();

            string query = "SELECT * FROM combined_billed_retuned_products WHERE BillNumber = @BillNumber";

            using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))

            {
                sqlConnection.Open();
                try
                {

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

        // Creating a return record for bill
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


        //Getting Bills

        public List<BillSummry> GetBillSummary()
        {
           
            using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
            {
                sqlConnection.Open();
                try
                {
                    
                    string query = "SELECT * FROM `customer_bills` LIMIT 100 ";
                    using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<BillSummry> Bills = new List<BillSummry>();

                            while (reader != null && reader.Read())
                            {
                                BillSummry billSummary = new BillSummry
                                {
                                    TransactionID = reader["TransactionID"] != DBNull.Value ? Convert.ToInt32(reader["TransactionID"]) : 0,
                                    TransactionDate = reader["TransactionDate"] != DBNull.Value ? (DateTime)reader["TransactionDate"] : DateTime.MinValue,
                                    BillNumber = reader["BillNumber"] != DBNull.Value ? reader["BillNumber"].ToString() : string.Empty,
                                    CustomerID = reader["CustomerID"] != DBNull.Value ? Convert.ToInt32(reader["CustomerID"]) : 0,
                                    UserID = reader["UserID"] != DBNull.Value ? Convert.ToInt32(reader["UserID"]) : 0,

                                    TotalLineCount = reader["TotalLineCount"] != DBNull.Value ? Convert.ToInt32(reader["TotalLineCount"]) : 0,
                                    TotalAmount = reader["TotalAmount"] != DBNull.Value ? reader["TotalAmount"].ToString() : string.Empty,
                                    TotalDiscount = reader["TotalDiscount"] != DBNull.Value ? reader["TotalDiscount"].ToString() : string.Empty,
                                    TotalPaidAmount = reader["TotalPaidAmount"] != DBNull.Value ? reader["TotalPaidAmount"].ToString() : string.Empty,
                                    TotalChange = reader["TotalChange"] != DBNull.Value ? reader["TotalChange"].ToString() : string.Empty,
                                    
                                };

                                Bills.Add(billSummary);
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
            }

            return null; // 
        }

        public List<BillSummry> GetBillSummary(string billNumber)
        {
            using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
            {
                sqlConnection.Open();
                try
                {
                    string query = "SELECT * FROM `customer_bills` WHERE BillNumber=@BillNumber LIMIT 100 ";
                    using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@BillNumber", billNumber+'%');
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<BillSummry> Bills = new List<BillSummry>();

                            while (reader != null && reader.Read())
                            {
                                BillSummry billSummary = new BillSummry
                                {
                                    TransactionID = reader["TransactionID"] != DBNull.Value ? Convert.ToInt32(reader["TransactionID"]) : 0,
                                    TransactionDate = reader["TransactionDate"] != DBNull.Value ? (DateTime)reader["TransactionDate"] : DateTime.MinValue,
                                    BillNumber = reader["BillNumber"] != DBNull.Value ? reader["BillNumber"].ToString() : string.Empty,
                                    CustomerID = reader["CustomerID"] != DBNull.Value ? Convert.ToInt32(reader["CustomerID"]) : 0,
                                    UserID = reader["UserID"] != DBNull.Value ? Convert.ToInt32(reader["UserID"]) : 0,

                                    TotalLineCount = reader["TotalLineCount"] != DBNull.Value ? Convert.ToInt32(reader["TotalLineCount"]) : 0,
                                    TotalAmount = reader["TotalAmount"] != DBNull.Value ? reader["TotalAmount"].ToString() : string.Empty,
                                    TotalDiscount = reader["TotalDiscount"] != DBNull.Value ? reader["TotalDiscount"].ToString() : string.Empty,
                                    TotalPaidAmount = reader["TotalPaidAmount"] != DBNull.Value ? reader["TotalPaidAmount"].ToString() : string.Empty,
                                    TotalChange = reader["TotalChange"] != DBNull.Value ? reader["TotalChange"].ToString() : string.Empty,

                                };

                                Bills.Add(billSummary);
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
            }

            return null; // 
        }

    }

    public class SalesTransaction
    {
        public int TransactionID { get; set; }
        public int UserID { get; set; }
        public int CustomerID { get; set; }
        public int CustomerUserID { get; set; }
        public string UserFullName { get; set; }
        public string CustomerFullName { get; set; }
        public DateTime TransactionDate { get; set; }
        public long TotalLineCount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalPaidAmount { get; set; }
        public decimal TotalChange { get; set; }
        public string BillNumber { get; set; }
    }
    public class SalesTransactionDetails
    {
        public int Number { get; set; }
        public DateTime TransactionDate { get; set; }
        public int TransactionID { get; set; }
        public int TransactionDetailID { get; set; }
        public string BillNumber { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public string UnitOfMeasurement { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
    }
    public class LoyaltyTransaction
    {
        public int TransactionID { get; set; }
        public string LoyaltyNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string State { get; set; }
        public decimal TotalEarnedAmount { get; set; }
        public decimal TotalSpendAmount { get; set; }

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

    public class BillSummry
    {
        public int TransactionID { get; set; }
        public string BillNumber { get; set; }
        public int CustomerID { get; set; }
        public int UserID { get; set; }
        public DateTime TransactionDate { get; set; }
        public int TotalLineCount { get; set; }
        public string TotalAmount { get; set; }
        public string TotalDiscount { get; set; }
        public string TotalPaidAmount { get; set; }
        public string TotalChange { get; set; }
        public string BillTotalAmount { get; set; }
    }
}
