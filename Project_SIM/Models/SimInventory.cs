using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<StoreStockedProducts> GetStoreStockedProductsInverntory(string codeOrBarcode)
        {
            List<StoreStockedProducts> productsList = new List<StoreStockedProducts>();

            string query = "SELECT * FROM store_product_inventory WHERE ProductCode LIKE @codeOrBarcode OR Name LIKE @codeOrBarcode ";

            using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@codeOrBarcode", codeOrBarcode + "%");

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
