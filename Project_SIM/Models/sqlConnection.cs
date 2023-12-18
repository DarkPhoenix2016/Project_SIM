using System;
using MySql.Data.MySqlClient;

namespace Project_SIM.Models
{
    // Class for managing MySQL database connections
    public static class SqlConnectionClass
    {
        private static string connectionString;
        private static string server;
        private static string database;
        private static string uid;
        private static string password;

        // Constructor to initialize the class
        static SqlConnectionClass()
        {
            Initialize();
        }

        // Initialize connection details from application settings
        private static void Initialize()
        {
            server = Properties.Settings.Default.Server;
            database = Properties.Settings.Default.Database;
            uid = Properties.Settings.Default.Uid;
            password = Properties.Settings.Default.Password;

            UpdateConnectionString();
        }

        // Update the connection string based on current details
        private static void UpdateConnectionString()
        {
            connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
        }

        // Get the current connection string
        public static string GetConnectionString()
        {
            return connectionString;
        }

        // Set new server details, save to settings, and update connection string
        public static void SetServerDetails(string newServer, string newDatabase, string newUid, string newPassword)
        {
            server = newServer;
            database = newDatabase;
            uid = newUid;
            password = newPassword;

            SaveServerDetails();
            UpdateConnectionString();
        }

        // Save current server details to application settings
        private static void SaveServerDetails()
        {
            Properties.Settings.Default.Server = server;
            Properties.Settings.Default.Database = database;
            Properties.Settings.Default.Uid = uid;
            Properties.Settings.Default.Password = password;

            Properties.Settings.Default.Save();
        }
    }
}
