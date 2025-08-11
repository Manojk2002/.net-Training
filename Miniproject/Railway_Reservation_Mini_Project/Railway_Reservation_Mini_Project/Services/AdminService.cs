using System;
using System.Configuration;
using System.Data.SqlClient;
using Railway_Reservation_Mini_Project.Models;

namespace Railway_Reservation_Mini_Project.Services
{
    public class AdminService
    {
        private readonly string _connectionString;

        public AdminService()
        {
            // Reads connection string from App.config
            _connectionString = ConfigurationManager.ConnectionStrings["RailwayDb"].ConnectionString;
        }

        /// <summary>
        /// Returns Admin object if credentials are valid and active.
        /// </summary>
        public Admin Login(string username, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT * FROM Admins WHERE Username = @Username AND Password = @Password AND IsActive = 1";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Admin
                                {
                                    AdminId = Convert.ToInt32(reader["AdminId"]),
                                    Username = reader["Username"].ToString(),
                                    Password = reader["Password"].ToString()
                                };
                            }
                        }
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during admin login: " + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Returns true if admin credentials are valid and active.
        /// </summary>
        public bool ValidateAdmin(string username, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT COUNT(*) FROM Admins WHERE Username = @Username AND Password = @Password AND IsActive = 1";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        conn.Open();
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error validating admin: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Registers a new admin.
        /// </summary>
        public bool RegisterAdmin(Admin admin)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "INSERT INTO Admins (Username, Password, IsActive) VALUES (@Username, @Password, 1)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", admin.Username);
                        cmd.Parameters.AddWithValue("@Password", admin.Password);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error registering admin: " + ex.Message);
                return false;
            }
        }
    }
}
