using System;
using System.Configuration;
using System.Data.SqlClient;
using Railway_Reservation_Mini_Project.Models;

namespace Railway_Reservation_Mini_Project.Services
{
    public class CancellationService
    {
        private readonly string _connectionString;

        public CancellationService()
        {
            // Reads connection string from App.config
            _connectionString = ConfigurationManager.ConnectionStrings["RailwayDb"].ConnectionString;
        }

        public bool CancelTicket(int bookingId, decimal totalCost)
        {
            decimal refundAmount = totalCost * 0.5m;
            DateTime cancellationDate = DateTime.Now;

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    // Insert cancellation record
                    string insertQuery = @"INSERT INTO Cancellations 
                        (BookingId, RefundAmount, CancellationDate, TicketCancelled) 
                        VALUES (@BookingId, @RefundAmount, @CancellationDate, 1)";
                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@BookingId", bookingId);
                        insertCmd.Parameters.AddWithValue("@RefundAmount", refundAmount);
                        insertCmd.Parameters.AddWithValue("@CancellationDate", cancellationDate);

                        int rowsAffected = insertCmd.ExecuteNonQuery();

                        // Update reservation status
                        string updateQuery = @"UPDATE Reservations SET IsCancelled = 1 WHERE BookingId = @BookingId";
                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@BookingId", bookingId);
                            updateCmd.ExecuteNonQuery();
                        }

                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during ticket cancellation: " + ex.Message);
                return false;
            }
        }

        public Cancellation GetCancellationDetails(int bookingId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT * FROM Cancellations WHERE BookingId = @BookingId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BookingId", bookingId);
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Cancellation
                                {
                                    CancellationId = Convert.ToInt32(reader["CancellationId"]),
                                    BookingId = Convert.ToInt32(reader["BookingId"]),
                                    RefundAmount = Convert.ToDecimal(reader["RefundAmount"]),
                                    CancellationDate = Convert.ToDateTime(reader["CancellationDate"]),
                                    TicketCancelled = Convert.ToBoolean(reader["TicketCancelled"])
                                };
                            }
                        }
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching cancellation details: " + ex.Message);
                return null;
            }
        }
    }
}
