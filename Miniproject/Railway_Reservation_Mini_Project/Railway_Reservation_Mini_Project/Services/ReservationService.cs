using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Railway_Reservation_Mini_Project.Models;

namespace Railway_Reservation_Mini_Project.Services
{
    public class ReservationService
    {
        private readonly string _connectionString;

        public ReservationService()
        {
            // Reads connection string from App.config
            _connectionString = ConfigurationManager.ConnectionStrings["RailwayDb"].ConnectionString;
        }

        public bool MakeReservation(Reservation reservation)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = @"INSERT INTO Reservations 
                                    (CustId, TrainId, TravelDate, ClassType, SeatsBooked, BerthAllotment, TotalCost, BookingDate, IsCancelled, IsDeleted)
                                    VALUES 
                                    (@CustId, @TrainId, @TravelDate, @ClassType, @SeatsBooked, @BerthAllotment, @TotalCost, @BookingDate, 0, 0)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustId", reservation.CustId);
                        cmd.Parameters.AddWithValue("@TrainId", reservation.TrainId);
                        cmd.Parameters.AddWithValue("@TravelDate", reservation.TravelDate);
                        cmd.Parameters.AddWithValue("@ClassType", reservation.ClassType);
                        cmd.Parameters.AddWithValue("@SeatsBooked", reservation.SeatsBooked);
                        cmd.Parameters.AddWithValue("@BerthAllotment", reservation.BerthAllotment);
                        cmd.Parameters.AddWithValue("@TotalCost", reservation.TotalCost);
                        cmd.Parameters.AddWithValue("@BookingDate", reservation.BookingDate);

                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error making reservation: " + ex.Message);
                return false;
            }
        }

        public Reservation GetReservationById(int bookingId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT * FROM Reservations WHERE BookingId = @BookingId AND IsDeleted = 0";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BookingId", bookingId);
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Reservation
                                {
                                    BookingId = Convert.ToInt32(reader["BookingId"]),
                                    CustId = Convert.ToInt32(reader["CustId"]),
                                    TrainId = Convert.ToInt32(reader["TrainId"]),
                                    TravelDate = Convert.ToDateTime(reader["TravelDate"]),
                                    ClassType = reader["ClassType"].ToString(),
                                    SeatsBooked = Convert.ToInt32(reader["SeatsBooked"]),
                                    BerthAllotment = reader["BerthAllotment"].ToString(),
                                    TotalCost = Convert.ToDecimal(reader["TotalCost"]),
                                    BookingDate = Convert.ToDateTime(reader["BookingDate"]),
                                    IsCancelled = Convert.ToBoolean(reader["IsCancelled"]),
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
                Console.WriteLine("Error fetching reservation: " + ex.Message);
                return null;
            }
        }

        public bool CancelReservation(int bookingId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "UPDATE Reservations SET IsCancelled = 1 WHERE BookingId = @BookingId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BookingId", bookingId);
                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error cancelling reservation: " + ex.Message);
                return false;
            }
        }

        public bool SoftDeleteReservation(int bookingId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "UPDATE Reservations SET IsDeleted = 1 WHERE BookingId = @BookingId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BookingId", bookingId);
                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting reservation: " + ex.Message);
                return false;
            }
        }

        public List<Reservation> GetAllReservations()
        {
            List<Reservation> reservations = new List<Reservation>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT * FROM Reservations WHERE IsDeleted = 0";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                reservations.Add(new Reservation
                                {
                                    BookingId = Convert.ToInt32(reader["BookingId"]),
                                    CustId = Convert.ToInt32(reader["CustId"]),
                                    TrainId = Convert.ToInt32(reader["TrainId"]),
                                    TravelDate = Convert.ToDateTime(reader["TravelDate"]),
                                    ClassType = reader["ClassType"].ToString(),
                                    SeatsBooked = Convert.ToInt32(reader["SeatsBooked"]),
                                    BerthAllotment = reader["BerthAllotment"].ToString(),
                                    TotalCost = Convert.ToDecimal(reader["TotalCost"]),
                                    BookingDate = Convert.ToDateTime(reader["BookingDate"]),
                                    IsCancelled = Convert.ToBoolean(reader["IsCancelled"]),
                                    IsDeleted = Convert.ToBoolean(reader["IsDeleted"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching reservations: " + ex.Message);
            }
            return reservations;
        }
    }
}
