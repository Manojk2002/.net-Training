----ICS-LT-7Y6GV3\SQLEXPRESS

-- Create the database
CREATE DATABASE RailwayReservationdb;
GO

USE RailwayReservationdb;
GO

CREATE TABLE Admins (
    AdminId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(50) NOT NULL,
    IsActive BIT DEFAULT 1
);

CREATE TABLE Customers (
    CustId INT IDENTITY(1,1) PRIMARY KEY,
    CustName NVARCHAR(100),
    Phone NVARCHAR(15),
    Email NVARCHAR(100) UNIQUE,
    Password NVARCHAR(100),
    IsDeleted BIT DEFAULT 0
);

CREATE TABLE Trains (
    TrainId INT IDENTITY(1,1) PRIMARY KEY,
    TrainNo NVARCHAR(20),
    TrainName NVARCHAR(100),
    Source NVARCHAR(100),
    Destination NVARCHAR(100),
    DepartureTime TIME,
    ArrivalTime TIME,
    RunningDays NVARCHAR(50),
    IsDeleted BIT DEFAULT 0
);

CREATE TABLE TrainClassAvailability (
    AvailabilityId INT IDENTITY(1,1) PRIMARY KEY,
    TrainId INT FOREIGN KEY REFERENCES Trains(TrainId),
    ClassType NVARCHAR(50),
    MaxSeats INT,
    AvailableSeats INT,
    CostPerSeat DECIMAL(10,2),
    IsActive BIT DEFAULT 1
);

CREATE TABLE Reservations (
    BookingId INT IDENTITY(1,1) PRIMARY KEY,
    CustId INT FOREIGN KEY REFERENCES Customers(CustId),
    TrainId INT FOREIGN KEY REFERENCES Trains(TrainId),
    TravelDate DATE,
    ClassType NVARCHAR(50),
    SeatsBooked INT,
    BerthAllotment NVARCHAR(50),
    TotalCost DECIMAL(10,2),
    BookingDate DATETIME,
    IsCancelled BIT DEFAULT 0,
    IsDeleted BIT DEFAULT 0
);

CREATE TABLE Cancellations (
    CancellationId INT IDENTITY(1,1) PRIMARY KEY,
    BookingId INT FOREIGN KEY REFERENCES Reservations(BookingId),
    RefundAmount DECIMAL(10,2),
    CancellationDate DATETIME,
    TicketCancelled BIT DEFAULT 1
);

CREATE TABLE Cancellations (
    CancellationId INT IDENTITY(1,1) PRIMARY KEY,
    BookingId INT FOREIGN KEY REFERENCES Reservations(BookingId),
    RefundAmount DECIMAL(10,2),
    CancellationDate DATETIME,
    TicketCancelled BIT DEFAULT 1
);

-- Admins
INSERT INTO Admins (Username, Password, IsActive) VALUES
('manu', 'manu2002', 1);

-- Customers
INSERT INTO Customers (CustName, Phone, Email, Password, IsDeleted) VALUES
('Kumar', '9876543210', 'kumar@example.com', 'pass123', 0),
('Vinay', '9123456789', 'vinay@example.com', 'pass456', 0);

-- Trains
INSERT INTO Trains (TrainNo, TrainName, Source, Destination, DepartureTime, ArrivalTime, RunningDays, IsDeleted) VALUES
('11', 'BExpress', 'Bnagalore', 'Mumbai', '08:00', '20:00', 'Mon,Tue,Wed,Thu,Fri', 0),
('22', 'Goast Rider', 'Bangalore', 'Goa', '06:30', '18:45', 'Sat,Sun', 0);

-- TrainClassAvailability
INSERT INTO TrainClassAvailability (TrainId, ClassType, MaxSeats, AvailableSeats, CostPerSeat, IsActive) VALUES
(1, 'Sleeper', 100, 80, 500.00, 1),
(1, '2nd AC', 50, 45, 1200.00, 1),
(2, '3rd AC', 60, 60, 900.00, 1);

-- Reservations
INSERT INTO Reservations (CustId, TrainId, TravelDate, ClassType, SeatsBooked, BerthAllotment, TotalCost, BookingDate, IsCancelled, IsDeleted) VALUES
(1, 1, '2024-06-15', 'Sleeper', 2, 'Auto', 1000.00, GETDATE(), 0, 0),
(2, 2, '2024-06-16', '3rd AC', 1, 'Auto', 900.00, GETDATE(), 0, 0);

-- Cancellations
INSERT INTO Cancellations (BookingId, RefundAmount, CancellationDate, TicketCancelled) VALUES
(1, 500.00, GETDATE(), 1);



Select * from Customers

SELECT * FROM Admins;
SELECT * FROM Customers;
SELECT * FROM Reservations;
