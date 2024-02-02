using MySql.Data.MySqlClient;
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
       
        public bool Register(string fullName, string username, string password,string AccessLevel)
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
                        $"VALUES ('{username}','{hashedPassword}','{fullName}','{AccessLevel}')";

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

        public UserData Select(string userName, string Designation)
        {
            string query = $"SELECT * FROM `users` WHERE `Username`= '{userName}' AND `AccessLevel`= '{Designation}';";
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
                            AccountState = reader["State"].ToString()  
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

            return null; 
        }

        public bool SetState(int userId,bool BoolState)
        {
            try
            {
                using (MySqlConnection _sqlConnection = new MySqlConnection(connectionString))
                {
                    _sqlConnection.Open();

                    using (MySqlTransaction transaction = _sqlConnection.BeginTransaction())
                    {
                        string state = "Deactive";
                        if (BoolState)
                        {
                            state = "Active";
                        }
                        try
                        {
                            string query = $"UPDATE users SET State ='{state}' WHERE UserID = {userId} ";

                            Console.WriteLine(query);

                            // ExecuteNonQuery is used for non-query commands (INSERT, UPDATE, DELETE)
                            new MySqlCommand(query, _sqlConnection, transaction).ExecuteNonQuery();

                            // Commit the transaction
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

        public bool Update(int userId, string fullName, string username, string AccessLevel)
        {
            try
            {
                using (MySqlConnection _sqlConnection = new MySqlConnection(connectionString))
                {
                    _sqlConnection.Open();

                    using (MySqlTransaction transaction = _sqlConnection.BeginTransaction())
                    {
                        try
                        {
                            string query = $"UPDATE users SET FullName ='{fullName}', Username ='{username}', AccessLevel = '{AccessLevel}'  WHERE UserID = {userId} ";

                            Console.WriteLine(query);

                            // ExecuteNonQuery is used for non-query commands (INSERT, UPDATE, DELETE)
                            new MySqlCommand(query, _sqlConnection, transaction).ExecuteNonQuery();

                            // Commit the transaction
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

        public bool Update(int userId, string fullName, string username)
        {
            try
            {
                using (MySqlConnection _sqlConnection = new MySqlConnection(connectionString))
                {
                    _sqlConnection.Open();

                    using (MySqlTransaction transaction = _sqlConnection.BeginTransaction())
                    {
                        try
                        {
                            string query = $"UPDATE users SET FullName ='{fullName}', Username ='{username}' WHERE UserID = {userId} ";

                            Console.WriteLine(query);

                            // ExecuteNonQuery is used for non-query commands (INSERT, UPDATE, DELETE)
                            new MySqlCommand(query, _sqlConnection, transaction).ExecuteNonQuery();

                            // Commit the transaction
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

        public bool Update(int userId, string password)
        {
            try
            {
                using (MySqlConnection _sqlConnection = new MySqlConnection(connectionString))
                {
                    _sqlConnection.Open();

                    using (MySqlTransaction transaction = _sqlConnection.BeginTransaction())
                    {
                        try
                        {
                            // Hash the password and get salt
                            string hashedPassword = Authenticator.HashPassword(password);

                            string query = $"UPDATE users SET PasswordHash ='{hashedPassword}' WHERE UserID = {userId} ";

                            Console.WriteLine(query);

                            // ExecuteNonQuery is used for non-query commands (INSERT, UPDATE, DELETE)
                            new MySqlCommand(query, _sqlConnection, transaction).ExecuteNonQuery();

                            // Commit the transaction
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

        public List<UserData> GetUsers(string searchText = null)
        {
            string query = "SELECT * FROM `users` WHERE `AccessLevel` <> 'Customer'";

            if (!string.IsNullOrEmpty(searchText))
            {
                query += $" AND (`Username` LIKE '{searchText}%' OR `FullName` LIKE '{searchText}%')";
            }

            query += " LIMIT 100;";

            sqlConnection.Open();

            try
            {
                List<UserData> userList = new List<UserData>();

                using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        int count = 1;

                        while (reader.Read())
                        {
                            UserData user = new UserData
                            {
                                RecordId = count,
                                UserID = Convert.ToInt32(reader["UserID"]),
                                Username = reader["Username"].ToString(),
                                AccessLevel = reader["AccessLevel"].ToString(),
                                FullName = reader["FullName"].ToString(),
                                AccountState = reader["State"].ToString()
                            };

                            userList.Add(user);
                            count++;
                        }
                    }

                    return userList;
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

            return null;
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

        public List<Designation> GetDesignations()
        {
            string query = "SELECT * FROM `_accesslevels` a  WHERE `AccessLevel` <> 'Customer';";

            sqlConnection.Open();

            try
            {
                List<Designation> designationList = new List<Designation>();

                using (MySqlCommand cmd = new MySqlCommand(query, sqlConnection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Designation title = new Designation
                            {
                                RecordId = Convert.ToInt32(reader["ID"]),
                                Title = reader["AccessLevel"].ToString()
                            };

                            designationList.Add(title);
                        }
                    }

                    return designationList;
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

            return null;
        }



        public class UserData
        {
            public int RecordId { get; set; }
            public int UserID { get; set; }
            public string Username { get; set; }
            public string FullName { get; set; }
            public string AccessLevel { get; set; }
            public string AccountState { get; set; }
        }

        public class Designation
        {
            public int RecordId { get; set;}
            public string Title {  get; set; }
        }
    }
   
}
