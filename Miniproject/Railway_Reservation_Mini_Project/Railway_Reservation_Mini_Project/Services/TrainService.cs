using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Railway_Reservation_Mini_Project.Models;

namespace Railway_Reservation_Mini_Project.Services
{
    public class TrainService
    {
        private readonly string _connectionString;

        public TrainService()
        {
            // Reads connection string from App.config
            _connectionString = ConfigurationManager.ConnectionStrings["RailwayDb"].ConnectionString;
        }

        public bool AddTrain(Train train)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = @"INSERT INTO Trains 
                                    (TrainNo, TrainName, Source, Destination, DepartureTime, ArrivalTime, RunningDays, IsDeleted)
                                    VALUES 
                                    (@TrainNo, @TrainName, @Source, @Destination, @DepartureTime, @ArrivalTime, @RunningDays, 0)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TrainNo", train.TrainNo);
                        cmd.Parameters.AddWithValue("@TrainName", train.TrainName);
                        cmd.Parameters.AddWithValue("@Source", train.Source);
                        cmd.Parameters.AddWithValue("@Destination", train.Destination);
                        cmd.Parameters.AddWithValue("@DepartureTime", train.DepartureTime);
                        cmd.Parameters.AddWithValue("@ArrivalTime", train.ArrivalTime);
                        cmd.Parameters.AddWithValue("@RunningDays", train.RunningDays);

                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding train: " + ex.Message);
                return false;
            }
        }

        public List<Train> GetAllTrains()
        {
            List<Train> trains = new List<Train>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "SELECT * FROM Trains WHERE IsDeleted = 0";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                trains.Add(new Train
                                {
                                    TrainId = Convert.ToInt32(reader["TrainId"]),
                                    TrainNo = reader["TrainNo"].ToString(),
                                    TrainName = reader["TrainName"].ToString(),
                                    Source = reader["Source"].ToString(),
                                    Destination = reader["Destination"].ToString(),
                                    DepartureTime = (TimeSpan)reader["DepartureTime"],
                                    ArrivalTime = (TimeSpan)reader["ArrivalTime"],
                                    RunningDays = reader["RunningDays"].ToString(),
                                    IsDeleted = Convert.ToBoolean(reader["IsDeleted"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching trains: " + ex.Message);
            }
            return trains;
        }

        public bool SoftDeleteTrain(int trainId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "UPDATE Trains SET IsDeleted = 1 WHERE TrainId = @TrainId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TrainId", trainId);
                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting train: " + ex.Message);
                return false;
            }
        }
    }
}
