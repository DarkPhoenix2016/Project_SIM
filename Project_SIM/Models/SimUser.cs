﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static Project_SIM.Models.SimCustomer;
using ZXing;

namespace Project_SIM.Models
{
    public class SimUser
    {
        private MySqlConnection sqlConnection;
        private MySqlDataReader reader;
        private readonly string connectionString;
       
        public SimUser()
        {
            connectionString = SqlConnectionClass.GetConnectionString();
            sqlConnection = new MySqlConnection(connectionString);
        }
       
        public bool Register(string fullName, string username, string password)
        {
            MySqlTransaction transaction = null;

            using (MySqlConnection sqlConnection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Hash the password and get salt
                    string hashedPassword = Authenticator.HashPassword(password);

                    // Open connection and begin transaction
                    sqlConnection.Open();
                    transaction = sqlConnection.BeginTransaction();

                    // Insert the new user account
                    string queryAddUserAccount = $"INSERT INTO `users`(`Username`, `PasswordHash`, `FullName`, `AccessLevel`)" +
                        $"VALUES ('{username}','{hashedPassword}','{fullName}','Customer')";

                    // ExecuteNonQuery is used for non-query commands (INSERT, UPDATE, DELETE)
                    new MySqlCommand(queryAddUserAccount, sqlConnection, transaction).ExecuteNonQuery();

                    // Commit the transaction
                    transaction.Commit();

                    return true;
                }
                catch (MySqlException ex)
                {
                    // Roll back the transaction in case of an exception
                    FormatMaker.ShowErrorMessageBox($"Error registering User: {ex.Message}");
                    transaction?.Rollback();
                    return false;
                }
                finally
                {
                    // Close connection
                    sqlConnection.Close();
                }
            }
        }

        public UserData Select(string username)
        {
            string query = $"SELECT * FROM `users` WHERE `Username`= '{username}';";
            sqlConnection.Open();

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                {
                    reader = cmd.ExecuteReader();

                    if (reader != null && reader.HasRows)
                    {
                        reader.Read(); // Read the first row

                        UserData user = new UserData
                        {
                            UserID = Convert.ToInt32(reader["UserID"]),
                            Username = reader["Username"].ToString(),
                            AccessLevel = reader["AccessLevel"].ToString(),
                            FullName = reader["FullName"].ToString(),
                            
                        };
                        return user;
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

            return null; // Return null if no customer is found
        }

        public bool IsUsernameAvailable(string username)
        {
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();

                    // Check if the username already exists in the database
                    string queryCheckUsername = $"SELECT COUNT(*) FROM `users` WHERE `Username` = '{username}'";
                    int count = Convert.ToInt32(new MySqlCommand(queryCheckUsername, sqlConnection).ExecuteScalar());

                    return count == 0; // If count is 0, username is available; otherwise, it's not
                }
                catch (MySqlException ex)
                {
                    FormatMaker.ShowErrorMessageBox($"Error checking username availability: {ex.Message}");
                    return false; // Consider handling the exception according to your application's needs
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
        public bool IsUsernameAvailable(string username, string designation)
        {
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();

                    // Check if the username already exists in the database
                    string queryCheckUsername = $"SELECT COUNT(*) FROM `users` WHERE `Username` = '{username}' AND `AccessLevel` = '{designation}'";
                    int count = Convert.ToInt32(new MySqlCommand(queryCheckUsername, sqlConnection).ExecuteScalar());

                    return count == 0; // If count is 0, username is available; otherwise, it's not
                }
                catch (MySqlException ex)
                {
                    FormatMaker.ShowErrorMessageBox($"Error checking username availability: {ex.Message}");
                    return false; // Consider handling the exception according to your application's needs
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public string GetHashedPassword(string username)
        {
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();

                    // Select the password hash for the given username
                    string querySelectPasswordHash = $"SELECT `PasswordHash` FROM `users` WHERE `Username` = '{username}'";
                    object result = new MySqlCommand(querySelectPasswordHash, sqlConnection).ExecuteScalar();

                    // Check if the username exists and return the hashed password, or return null if not found
                    return result != null ? result.ToString() : null;
                }
                catch (MySqlException ex)
                {
                    FormatMaker.ShowErrorMessageBox($"Error retrieving hashed password: {ex.Message}");
                    // Consider handling the exception according to your application's needs
                    return null;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public string GetHashedPassword(string username, string designation)
        {
            using (sqlConnection)
            {
                try
                {
                    sqlConnection.Open();

                    // Select the password hash for the given username
                    string querySelectPasswordHash = $"SELECT `PasswordHash` FROM `users` WHERE `Username` = '{username}' AND `AccessLevel` = '{designation}'";
                    object result = new MySqlCommand(querySelectPasswordHash, sqlConnection).ExecuteScalar();

                    // Check if the username exists and return the hashed password, or return null if not found
                    return result != null ? result.ToString() : null;
                }
                catch (MySqlException ex)
                {
                    FormatMaker.ShowErrorMessageBox($"Error retrieving hashed password: {ex.Message}");
                    // Consider handling the exception according to your application's needs
                    return null;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
        
        public class UserData
        {
            public int UserID { get; set; }
            public string Username { get; set; }
            public string FullName { get; set; }
            public string AccessLevel { get; set; }

        }

    }
   
}
