using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Project_SIM.Models
{
    public class SimInventory
    {
        private readonly string connectionString;
        public SimInventory()
        {

            connectionString = string.Empty;

            connectionString = SqlConnectionClass.GetConnectionString();
        }

        public void AddStockToMainInventory(int productId, int quantity, string location, string remark,DateTime date ,string vendor,DateTime expiryDate )
        {
            using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();

                    // Start a transaction to ensure atomicity
                    using (MySqlTransaction transaction = sqlConnection.BeginTransaction())
                    {
                        try
                        {
                            // Add stock to main_inventory
                            string addStockQuery = "INSERT INTO `main_inventory`(`ProductID`, `Quantity`, `Location`, `Remark`) VALUES (@productId, @quantity, @location, @remark)";
                            using (MySqlCommand addStockCmd = new MySqlCommand(addStockQuery, sqlConnection, transaction))
                            {
                                addStockCmd.Parameters.AddWithValue("@productId", productId);
                                addStockCmd.Parameters.AddWithValue("@quantity", quantity);
                                addStockCmd.Parameters.AddWithValue("@location", location);
                                addStockCmd.Parameters.AddWithValue("@remark", remark);
                                addStockCmd.ExecuteNonQuery();
                            }
                            
                            // Getting Main invertory ID
                            string getLastInsertIdQuery = "SELECT LAST_INSERT_ID()";
                            int inventoryID;
                            using (MySqlCommand cmd = new MySqlCommand(getLastInsertIdQuery, sqlConnection, transaction))
                            {
                                inventoryID = Convert.ToInt32(cmd.ExecuteScalar());
                            }

                            // Create stock_transactions with Stock In record
                            string stockTransactionQuery = "INSERT INTO `stock_transactions`(`InventoryID`, `Date`, `Type`, `Quantity`, `Vendor`, `ExpiryDate`, `Remark`, `Table`) VALUES (@inventoryID,@date,'Stock In',@quantity,@vendor,@expiryDate,@remark,'Main Inventory')";
                            using (MySqlCommand stockTransactionCmd = new MySqlCommand(stockTransactionQuery, sqlConnection, transaction))
                            {
                                stockTransactionCmd.Parameters.AddWithValue("@inventoryID", inventoryID);
                                stockTransactionCmd.Parameters.AddWithValue("@date", date);
                                stockTransactionCmd.Parameters.AddWithValue("@quantity", quantity);
                                stockTransactionCmd.Parameters.AddWithValue("@vendor", vendor);
                                stockTransactionCmd.Parameters.AddWithValue("@expiryDate", expiryDate);
                                stockTransactionCmd.Parameters.AddWithValue("@remark", remark);
                                
                                stockTransactionCmd.ExecuteNonQuery();
                            }

                            // Commit the transaction
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            // Handle any exceptions
                            Console.WriteLine($"Error in AddStockToMainInventory transaction: {ex.Message}");
                            transaction.Rollback();
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error connecting to the database: {ex.Message}");
                }
            }
        }

        public List<StoreStockedProducts> GetStoreStockedProductsInverntory()
        {
            List<StoreStockedProducts> productsList = new List<StoreStockedProducts>();

            string query = "SELECT * FROM store_product_inventory LIMIT 100";

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
                                while (reader.Read())
                                {
                                    StoreStockedProducts item = new StoreStockedProducts
                                    {
                                        StoreInventoryID = Convert.ToInt32(reader["StoreInventoryID"]),
                                        Date = Convert.ToDateTime(reader["Date"]),
                                        ProductID = Convert.ToInt32(reader["ProductID"]),
                                        ProductCode = reader["ProductCode"].ToString(),
                                        Name = reader["Name"].ToString(),
                                        ExpiryDate = Convert.ToDateTime(reader["ExpiryDate"]),
                                        Quantity = Convert.ToDouble(reader["Quantity"]),
                                        StockLocation = reader["StockLocation"].ToString(),
                                        Remark = reader["Remark"].ToString()
                                    };

                                    productsList.Add(item);
                                }
                            }
                            else
                            {
                                return null;
                            }
                        }

                        return productsList;
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error executing query: {ex.Message}");
                    return null;
                }
            }

        }

        public List<StoreStockedProducts> GetStoreStockedProductsInverntory(string codeOrName)
        {
            List<StoreStockedProducts> productsList = new List<StoreStockedProducts>();

            string query = "SELECT * FROM store_product_inventory WHERE ProductCode LIKE @codeOrName OR Name LIKE @codeOrName ";

            using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@codeOrName", codeOrName + "%");

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    StoreStockedProducts item = new StoreStockedProducts
                                    {
                                        StoreInventoryID = Convert.ToInt32(reader["StoreInventoryID"]),
                                        Date = Convert.ToDateTime(reader["Date"]),
                                        ProductID = Convert.ToInt32(reader["ProductID"]),
                                        ProductCode = reader["ProductCode"].ToString(),
                                        Name = reader["Name"].ToString(),
                                        ExpiryDate = Convert.ToDateTime(reader["ExpiryDate"]),
                                        Quantity = Convert.ToDouble(reader["Quantity"]),
                                        StockLocation = reader["StockLocation"].ToString(),
                                        Remark = reader["Remark"].ToString()
                                    };

                                    productsList.Add(item);
                                }
                            }
                            else
                            {
                                return null;
                            }
                        }

                        return productsList;
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error executing query: {ex.Message}");
                    return null;
                }
            }

        }

        public StoreStockProductSum GetStoreStockProductSum(string codeOrBarcode)
        {
            StoreStockProductSum product = new StoreStockProductSum();

            string query = "SELECT * FROM store_product_sums WHERE ProductCode=@codeOrBarcode";

            using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@codeOrBarcode", codeOrBarcode);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    product.ProductID = Convert.ToInt32(reader["ProductID"]);
                                    product.ProductCode = reader["ProductCode"].ToString();
                                    product.Name = reader["Name"].ToString();
                                    product.TotalQuantity = Convert.ToDouble(reader["TotalQuantity"]);
                                    product.TotalSoldQuantity = Convert.ToDouble(reader["TotalSoldQuantity"]);
                                    product.TotalReturnedQuantity = Convert.ToDouble(reader["TotalReturnedQuantity"]);
                                    product.Balance = Convert.ToDouble(reader["Balance"]);
                                }
                            }
                            else
                            {
                                return null; 
                            }
                        }

                        return product;
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error executing query: {ex.Message}");
                    return null; // Return an empty struct in case of an exception
                }
            }
        }



        public List<StoreStockedProducts> GetMainStockedProductsInverntory()
        {
            List<StoreStockedProducts> productsList = new List<StoreStockedProducts>();

            string query = "SELECT * FROM main_product_inventory LIMIT 100";

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
                                while (reader.Read())
                                {
                                    StoreStockedProducts item = new StoreStockedProducts
                                    {
                                        StoreInventoryID = Convert.ToInt32(reader["InventoryID"]),
                                        Date = Convert.ToDateTime(reader["TrasactionDate"]),
                                        ProductID = Convert.ToInt32(reader["ProductID"]),
                                        ProductCode = reader["ProductCode"].ToString(),
                                        Name = reader["ProductName"].ToString(),
                                        ExpiryDate = Convert.ToDateTime(reader["ExpiryDate"]),
                                        Quantity = Convert.ToDouble(reader["InventoryQuantity"]),
                                        StockLocation = reader["StockLocation"].ToString(),
                                        Remark = reader["InventoryRemark"].ToString()
                                    };

                                    productsList.Add(item);
                                }
                            }
                            else
                            {
                                return null;
                            }
                        }

                        return productsList;
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error executing query: {ex.Message}");
                    return null;
                }
            }

        }

        public List<StoreStockedProducts> GetMainStockedProductsInverntory(string codeOrName)
        {
            List<StoreStockedProducts> productsList = new List<StoreStockedProducts>();

            string query = "SELECT * FROM main_product_inventory WHERE ProductCode LIKE @codeOrName OR Name LIKE @codeOrName ";

            using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@codeOrName", codeOrName + "%");

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    StoreStockedProducts item = new StoreStockedProducts
                                    {
                                        StoreInventoryID = Convert.ToInt32(reader["InventoryID"]),
                                        Date = Convert.ToDateTime(reader["TrasactionDate"]),
                                        ProductID = Convert.ToInt32(reader["ProductID"]),
                                        ProductCode = reader["ProductCode"].ToString(),
                                        Name = reader["ProductName"].ToString(),
                                        ExpiryDate = Convert.ToDateTime(reader["ExpiryDate"]),
                                        Quantity = Convert.ToDouble(reader["InventoryQuantity"]),
                                        StockLocation = reader["StockLocation"].ToString(),
                                        Remark = reader["InventoryRemark"].ToString()
                                    };

                                    productsList.Add(item);
                                }
                            }
                            else
                            {
                                return null;
                            }
                        }

                        return productsList;
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error executing query: {ex.Message}");
                    return null;
                }
            }

        }


    }

    public class StoreStockedProducts
    {
        public int StoreInventoryID { get; set; }
        public DateTime Date { get; set; }
        public int ProductID { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Double Quantity { get; set; }
        public string StockLocation { get; set; }
        public string Remark { get; set; }
        
    }

    public class StoreStockProductSum
    {
        public int ProductID { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public double TotalQuantity { get; set; }
        public double TotalSoldQuantity { get; set; }
        public double TotalReturnedQuantity { get; set; }
        public double Balance { get; set; }
    }
}
