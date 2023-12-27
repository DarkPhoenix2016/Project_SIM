using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Project_SIM.Models
{
    public class SimProduct
    {
        private readonly string connectionString;

        public SimProduct()
        {
            this.connectionString = SqlConnectionClass.GetConnectionString();
        }

        public SimProductData GetProductByCodeOrBarcode(string codeOrBarcode)
        {
            codeOrBarcode = codeOrBarcode.ToUpper().Trim();
            string query = "SELECT * FROM products WHERE Barcode = @CodeOrBarcode OR ProductCode = @CodeOrBarcode";

            using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@CodeOrBarcode", codeOrBarcode);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader != null && reader.HasRows)
                            {
                                reader.Read();

                                SimProductData product = new SimProductData
                                {
                                    ProductID = Convert.ToInt32(reader["ProductID"]),
                                    ProductCode = reader["ProductCode"].ToString(),
                                    Barcode = reader["Barcode"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    Price = Convert.ToDecimal(reader["Price"]),
                                    Unit = reader["UnitOfMeasurement"].ToString()
                                };

                                return product;
                            }
                            else
                            {
                                Console.WriteLine($"No matching product found: {codeOrBarcode}");
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error executing query: {ex.Message}");
                }
            }

            return null;
        }

        public List<SimProductData> GetProductsByProductCodeSearch(string codeOrBarcode)
        {
            List<SimProductData> productList = new List<SimProductData>();

            codeOrBarcode = codeOrBarcode.Trim();
            string query = "SELECT * FROM products WHERE ProductCode LIKE @CodeOrBarcode OR Name LIKE @CodeOrBarcode ";

            using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@CodeOrBarcode", codeOrBarcode + "%");

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader != null && reader.Read())
                            {
                                SimProductData product = new SimProductData
                                {
                                    ProductID = Convert.ToInt32(reader["ProductID"]),
                                    ProductCode = reader["ProductCode"].ToString(),
                                    Barcode = reader["Barcode"].ToString(),
                                    Name = reader["Name"].ToString(),
                                    Price = Convert.ToDecimal(reader["Price"]),
                                    Unit = reader["UnitOfMeasurement"].ToString()
                                };

                                productList.Add(product);
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Error executing query: {ex.Message}");
                }
            }

            return productList;
        }


        public class SimProductData
        {
            public int ProductID { get; set; }
            public string ProductCode { get; set; }
            public string Barcode { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Unit {  get; set; }
        }
    }
}
