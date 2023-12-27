using BCrypt.Net;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Generators;
using static Project_SIM.Models.SimProduct;
using System;

namespace Project_SIM.Models
{
    
    public class Authenticator
    {
        public static string HashPassword(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return hashedPassword;
        }
        public static string StartSession(string username, string password, string designation)
        {
            string hashedPassword = GetHashedPassword(username, designation);
            
            if (!ValidateLogin(username, password, designation))
            {

                return string.Empty;

            }
            return SessionManager.StartSession(username, hashedPassword, designation);
        }
        private static bool ValidateLogin(string username,string password,string designation)
                {
                    username = username.Trim();
                    password = password.Trim();
                    if (!ValidateUsername(username,designation))
                    {
                        FormatMaker.ShowErrorMessageBox("Given username Not Found");
                        return false;
                    }
                    string hashedPassword = GetHashedPassword(username, designation);

                    if(!BCrypt.Net.BCrypt.Verify(password, hashedPassword))
                    {   
                        FormatMaker.ShowErrorMessageBox("Given Password is incorrect");
                        return false;
                    }
            
                    return true;       
                }
        private static bool ValidateUsername(string username, string designation)
        {
            SimUser user = new SimUser();
            username = username.Trim();
            return !user.IsUsernameAvailable(username,designation);

        }
        private static string GetHashedPassword(string username, string designation)
        {
            SimUser user = new SimUser();
            username = username.Trim();
            return user.GetHashedPassword(username,designation);
        }
        
    }

}

