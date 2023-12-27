using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Project_SIM.Models
{
    public class SessionManager
    {
        private static Dictionary<string, UserInfo> sessions = new Dictionary<string, UserInfo>();

        public static string StartSession(string username, string passwordHash, string designation)
        {
            string sessionId = Guid.NewGuid().ToString();

            UserInfo userInfo = new UserInfo(username, passwordHash, designation);

            sessions.Add(sessionId, userInfo);

            return sessionId;
        }

        public static bool ValidateSession(string sessionId)
        {
            return sessions.ContainsKey(sessionId);
        }

        public static void EndSession(string sessionId)
        {
            if (sessions.ContainsKey(sessionId))
            {
                sessions.Remove(sessionId);
            }
        }

        public static UserInfo GetUserInfo(string sessionId)
        {
            if (sessions.TryGetValue(sessionId, out UserInfo userInfo))
            {
                return userInfo;
            }

            return null;
        }

    }

    public class UserInfo
    {
        public string Username { get; }
        public string PasswordHash { get; }
        public string Designation {  get; }

        public UserInfo(string username, string passwordHash, string designation)
        {

            Username = username;
            PasswordHash = passwordHash;
            Designation = designation;
        }
    }
}
