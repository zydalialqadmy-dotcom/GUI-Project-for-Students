using System;
using System.Data;
using System.Data.SQLite;
using StudentGradesManager.Models;

namespace StudentGradesManager.Services
{
    public class UserService
    {
        // Authenticate user using SQLiteDataReader + Parameterized Query
        public User AuthenticateUser(string username, string password)
        {
            User user = null;

            try
            {
                using (SQLiteConnection conn = DatabaseService.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT UserId, Username, Password, Role " +
                                   "FROM Users WHERE Username = @Username AND Password = @Password";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        // Parameterized Query – prevents SQL Injection
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        // SqlDataReader equivalent for SQLite
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = new User
                                {
                                    UserId   = Convert.ToInt32(reader["UserId"]),
                                    Username = reader["Username"].ToString(),
                                    Password = reader["Password"].ToString(),
                                    Role     = reader["Role"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Authentication error: " + ex.Message);
            }

            return user;
        }
    }
}
