using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Railway_Reservation_Mini_Project.Models;

namespace Railway_Reservation_Mini_Project.Services
{
    public class CustomerService
    {
        private readonly string _connectionString;

        public CustomerService()
        {
            // Reads connection string from App.config
            _connectionString = ConfigurationManager.ConnectionStrings["RailwayDb"].ConnectionString;
        }

        public bool RegisterCustomer(Customer customer)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = @"INSERT INTO Customers (CustName, Phone, Email, Password, IsDeleted)
                                     VALUES (@CustName, @Phone, @Email, @Password, 0)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustName", customer.CustName);
                        cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);
                        cmd.Parameters.AddWithValue("@Password", customer.Password);

                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error registering customer: " + ex.Message);
                return false;
            }
        }

        public Customer ValidateUser(string email, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = @"SELECT * FROM Customers 
                                     WHERE Email = @Email AND Password = @Password AND IsDeleted = 0";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Customer
                                {
                                    CustId = Convert.ToInt32(reader["CustId"]),
                                    CustName = reader["CustName"].ToString(),
                                    Phone = reader["Phone"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Password = reader["Password"].ToString(),
                                    IsDeleted = Convert.ToBoolean(reader["IsDeleted"])
                                };
                            }
                        }
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error validating user: " + ex.Message);
                return null;
            }
        }

        public bool SoftDeleteCustomer(int custId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "UPDATE Customers SET IsDeleted = 1 WHERE CustId = @CustId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustId", custId);

                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting customer: " + ex.Message);
                return false;
            }
        }

        public List<Customer> GetAllActiveCustomers()
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT CustId, CustName, Phone, Email, IsDeleted FROM Customers WHERE IsDeleted = 0";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customers.Add(new Customer
                                {
                                    CustId = Convert.ToInt32(reader["CustId"]),
                                    CustName = reader["CustName"].ToString(),
                                    Phone = reader["Phone"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    IsDeleted = Convert.ToBoolean(reader["IsDeleted"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching customers: " + ex.Message);
            }
            return customers;
        }
    }
}
