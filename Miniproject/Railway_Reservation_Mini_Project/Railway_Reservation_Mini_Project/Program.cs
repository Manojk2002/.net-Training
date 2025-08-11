using System;
using System.Collections.Generic;
using ConsoleTables;
using Railway_Reservation_Mini_Project.Models;
using Railway_Reservation_Mini_Project.Services;

namespace Railway_Reservation_Mini_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Railway Reservation System";
            Console.Clear();

            AdminService adminService = new AdminService();
            CustomerService customerService = new CustomerService();
            TrainService trainService = new TrainService();
            ReservationService reservationService = new ReservationService();
            CancellationService cancellationService = new CancellationService();
            TrainClassAvailabilityService availabilityService = new TrainClassAvailabilityService();

            while (true)
            {
                PrintBanner("Railway Reservation System");

                Console.WriteLine("1. Admin Login");
                Console.WriteLine("2. User Login");
                Console.WriteLine("3. Register as User");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                if (choice == "0") break;
                else if (choice == "1") AdminMenu(adminService, trainService, availabilityService);
                else if (choice == "2") UserMenu(customerService, reservationService, cancellationService, availabilityService, trainService);
                else if (choice == "3") RegisterUser(customerService);
                else Console.WriteLine("Invalid choice. Try again.");

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void PrintBanner(string title)
        {
            Console.WriteLine(new string('-', 60));
            Console.WriteLine($"| {title,-56} |");
            Console.WriteLine(new string('-', 60));
        }

        static void RegisterUser(CustomerService customerService)
        {
            PrintBanner("User Registration");

            Customer customer = new Customer();
            Console.Write("Name: ");
            customer.CustName = Console.ReadLine();
            Console.Write("Phone: ");
            customer.Phone = Console.ReadLine();
            Console.Write("Email: ");
            customer.Email = Console.ReadLine();
            Console.Write("Password: ");
            customer.Password = Console.ReadLine();

            bool success = customerService.RegisterCustomer(customer);
            Console.WriteLine(success ? "Registration successful." : "Registration failed.");
        }

        static void AdminMenu(AdminService adminService, TrainService trainService, TrainClassAvailabilityService availabilityService)
        {
            PrintBanner("Admin Login");

            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            if (!adminService.ValidateAdmin(username, password))
            {
                Console.WriteLine("Invalid credentials.");
                return;
            }

            PrintBanner("Admin Panel");

            Console.WriteLine("1. Add Train");
            Console.WriteLine("2. View All Trains");
            Console.WriteLine("3. Add Class Availability");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Train train = new Train();
                Console.Write("Train No: ");
                train.TrainNo = Console.ReadLine();
                Console.Write("Train Name: ");
                train.TrainName = Console.ReadLine();
                Console.Write("Source: ");
                train.Source = Console.ReadLine();
                Console.Write("Destination: ");
                train.Destination = Console.ReadLine();
                Console.Write("Departure Time (HH:mm): ");
                train.DepartureTime = TimeSpan.Parse(Console.ReadLine());
                Console.Write("Arrival Time (HH:mm): ");
                train.ArrivalTime = TimeSpan.Parse(Console.ReadLine());
                Console.Write("Running Days: ");
                train.RunningDays = Console.ReadLine();

                bool added = trainService.AddTrain(train);
                Console.WriteLine(added ? "Train added successfully." : "Failed to add train.");
            }
            else if (choice == "2")
            {
                var trains = trainService.GetAllTrains();
                var table = new ConsoleTable("ID", "TrainNo", "Name", "Source", "Dest", "DepTime", "ArrTime");
                foreach (var t in trains)
                {
                    table.AddRow(t.TrainId, t.TrainNo, t.TrainName, t.Source, t.Destination, t.DepartureTime, t.ArrivalTime);
                }
                table.Write();
            }
            else if (choice == "3")
            {
                TrainClassAvailability availability = new TrainClassAvailability();
                Console.Write("Train ID: ");
                availability.TrainId = int.Parse(Console.ReadLine());
                Console.Write("Class Type: ");
                availability.ClassType = Console.ReadLine();
                Console.Write("Max Seats: ");
                availability.MaxSeats = int.Parse(Console.ReadLine());
                Console.Write("Available Seats: ");
                availability.AvailableSeats = int.Parse(Console.ReadLine());
                Console.Write("Cost Per Seat: ");
                availability.CostPerSeat = decimal.Parse(Console.ReadLine());

                bool added = availabilityService.AddClassAvailability(availability);
                Console.WriteLine(added ? "Class availability added." : "Failed to add availability.");
            }
        }

        static void UserMenu(CustomerService customerService, ReservationService reservationService, CancellationService cancellationService, TrainClassAvailabilityService availabilityService, TrainService trainService)
        {
            PrintBanner("User Login");

            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            Customer customer = customerService.ValidateUser(email, password);
            if (customer == null)
            {
                Console.WriteLine("Invalid credentials.");
                return;
            }

            PrintBanner("User Panel");

            Console.WriteLine("1. Book Ticket");
            Console.WriteLine("2. Cancel Ticket");
            Console.WriteLine("3. View Reservations");
            Console.WriteLine("4. View Available Trains");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Train ID: ");
                int trainId = int.Parse(Console.ReadLine());
                Console.Write("Travel Date (yyyy-MM-dd): ");
                DateTime travelDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Class Type: ");
                string classType = Console.ReadLine();
                Console.Write("Seats to Book: ");
                int seats = int.Parse(Console.ReadLine());

                var availability = availabilityService.GetAvailability(trainId, classType);
                if (availability == null || availability.AvailableSeats < seats)
                {
                    Console.WriteLine("Not enough seats available.");
                    return;
                }

                decimal totalCost = seats * availability.CostPerSeat;
                Reservation reservation = new Reservation
                {
                    CustId = customer.CustId,
                    TrainId = trainId,
                    TravelDate = travelDate,
                    ClassType = classType,
                    SeatsBooked = seats,
                    BerthAllotment = "Auto",
                    TotalCost = totalCost,
                    BookingDate = DateTime.Now
                };

                bool booked = reservationService.MakeReservation(reservation);
                if (booked)
                    availabilityService.UpdateAvailableSeats(trainId, classType, seats);

                Console.WriteLine(booked ? "Reservation successful." : "Reservation failed.");
            }
            else if (choice == "2")
            {
                PrintBanner("Cancel Ticket");

                Console.Write("Booking ID: ");
                int bookingId = int.Parse(Console.ReadLine());
                var res = reservationService.GetReservationById(bookingId);
                if (res == null || res.IsCancelled)
                {
                    Console.WriteLine("Invalid or already cancelled booking.");
                    return;
                }

                bool cancelled = cancellationService.CancelTicket(bookingId, res.TotalCost * 0.5m);
                if (cancelled)
                    availabilityService.RestoreSeats(res.TrainId, res.ClassType, res.SeatsBooked);

                Console.WriteLine(cancelled ? "Cancellation successful." : "Cancellation failed.");
            }
            else if (choice == "3")
            {
                var reservations = reservationService.GetAllReservations();
                var userReservations = reservations.FindAll(r => r.CustId == customer.CustId);
                var table = new ConsoleTable("ID", "TrainID", "Seats", "Class", "Date", "Cost", "Cancelled");
                foreach (var r in userReservations)
                {
                    table.AddRow(r.BookingId, r.TrainId, r.SeatsBooked, r.ClassType, r.TravelDate.ToString("yyyy-MM-dd"), $"₹{r.TotalCost}", r.IsCancelled ? "Yes" : "No");
                }
                table.Write();
            }
            else if (choice == "4")
            {
                var trains = trainService.GetAllTrains();
                var table = new ConsoleTable("ID", "TrainNo", "Name", "Source", "Dest", "DepTime", "ArrTime");
                foreach (var t in trains)
                {
                    table.AddRow(t.TrainId, t.TrainNo, t.TrainName, t.Source, t.Destination, t.DepartureTime, t.ArrivalTime);
                }
                table.Write();
            }
        }
    }
}
