using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;


namespace Project_SIM.Models
{
    
    public class SqlConnectionClass
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        private readonly string configFilePath;

        // Constructor with default server details
        public SqlConnectionClass()
        {
            this.configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "resources", "server_config.txt");
            this.LoadServerDetails();
            this.Initialize();
        }

        // Initialize values with custom server details
        private void Initialize()
        {
            string connectionString = $"SERVER={this.server};DATABASE={this.database};UID={this.uid};PASSWORD={this.password};SslMode=None;";
            connection = new MySqlConnection(connectionString);
        }

        // Open connection to the database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        // Close connection to the database
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        // Execute a query and return a reader
        public MySqlDataReader ExecuteQuery(string query)
        {
            if (this.OpenConnection())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    return cmd.ExecuteReader();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error executing query: {ex.Message}");
                    return null;
                }
                finally
                {
                    this.CloseConnection();
                }
            }

            return null;
        }

        // Set new server details
        public void SetServerDetails(string server, string database, string uid, string password)
        {
            this.server = server;
            this.database = database;
            this.uid = uid;
            this.password = password;

            this.SaveServerDetails();
            this.Initialize();
        }

        // Save server details to a file
        private void SaveServerDetails()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(this.configFilePath))
                {
                    writer.WriteLine($"Server={this.server}");
                    writer.WriteLine($"Database={this.database}");
                    writer.WriteLine($"Uid={this.uid}");
                    writer.WriteLine($"Password={this.password}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving server details: {ex.Message}");
            }
        }

        // Load server details from a file
        private void LoadServerDetails()
        {
            try
            {
                if (File.Exists(this.configFilePath))
                {
                    string[] lines = File.ReadAllLines(this.configFilePath);
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split('=');
                        if (parts.Length == 2)
                        {
                            string key = parts[0].Trim();
                            string value = parts[1].Trim();

                            switch (key)
                            {
                                case "Server":
                                    this.server = value;
                                    break;
                                case "Database":
                                    this.database = value;
                                    break;
                                case "Uid":
                                    this.uid = value;
                                    break;
                                case "Password":
                                    this.password = value;
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading server details: {ex.Message}");
            }
        }
    }

}
