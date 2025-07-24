using System;
using System.Collections.Generic;
using System.Linq;

namespace SQL_CODECHALLENGE
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }
    }

    class Program1
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>()
            {
                new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager",     DOB = DateTime.Parse("16-11-1984"), DOJ = DateTime.Parse("08-06-2011"), City = "Mumbai" },
                new Employee { EmployeeID = 1002, FirstName = "Asdin",   LastName = "Dhalla",     Title = "AsstManager", DOB = DateTime.Parse("20-08-1994"), DOJ = DateTime.Parse("07-07-2012"), City = "Mumbai" },
                new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza",        Title = "Consultant",  DOB = DateTime.Parse("14-11-1987"), DOJ = DateTime.Parse("12-04-2015"), City = "Pune" },
                new Employee { EmployeeID = 1004, FirstName = "Saba",    LastName = "Shaikh",     Title = "SE",          DOB = DateTime.Parse("03-06-1990"), DOJ = DateTime.Parse("02-02-2016"), City = "Mumbai" },
                new Employee { EmployeeID = 1005, FirstName = "Nazia",   LastName = "Shaikh",     Title = "SE",          DOB = DateTime.Parse("08-03-1991"), DOJ = DateTime.Parse("02-02-2016"), City = "Mumbai" },
                new Employee { EmployeeID = 1006, FirstName = "Amit",    LastName = "Pathak",     Title = "Consultant",  DOB = DateTime.Parse("07-11-1989"), DOJ = DateTime.Parse("08-08-2014"), City = "Chennai" },
                new Employee { EmployeeID = 1007, FirstName = "Vijay",   LastName = "Natrajan",   Title = "Consultant",  DOB = DateTime.Parse("02-12-1989"), DOJ = DateTime.Parse("01-06-2015"), City = "Mumbai" },
                new Employee { EmployeeID = 1008, FirstName = "Rahul",   LastName = "Dubey",      Title = "Associate",   DOB = DateTime.Parse("11-11-1993"), DOJ = DateTime.Parse("06-11-2014"), City = "Chennai" },
                new Employee { EmployeeID = 1009, FirstName = "Suresh",  LastName = "Mistry",     Title = "Associate",   DOB = DateTime.Parse("12-08-1992"), DOJ = DateTime.Parse("03-12-2014"), City = "Chennai" },
                new Employee { EmployeeID = 1010, FirstName = "Sumit",   LastName = "Shah",       Title = "Manager",     DOB = DateTime.Parse("12-04-1991"), DOJ = DateTime.Parse("02-01-2016"), City = "Pune" }
            };

            // a. Display all employees
            Console.WriteLine("a) All Employees:\n");
            foreach (var emp in empList)
                Display(emp);

            // b. Employees not in Mumbai
            Console.WriteLine("\nb) Employees NOT from Mumbai:\n");
            var notMumbai = empList.Where(e => e.City != "Mumbai");
            foreach (var emp in notMumbai)
                Display(emp);

            // c. Employees with title AsstManager
            Console.WriteLine("\nc) Employees with Title = AsstManager:\n");
            var asstManagers = empList.Where(e => e.Title == "AsstManager");
            foreach (var emp in asstManagers)
                Display(emp);

            // d. Employees with Last Name starting with 'S'
            Console.WriteLine("\nd) Employees whose Last Name starts with 'S':\n");
            var lastNameStartsWithS = empList.Where(e => e.LastName.StartsWith("S"));
            foreach (var emp in lastNameStartsWithS)
                Display(emp);

            // Keep console window open
            Console.ReadLine();
        }

        static void Display(Employee emp)
        {
            Console.WriteLine($"ID: {emp.EmployeeID}, Name: {emp.FirstName} {emp.LastName}, Title: {emp.Title}, DOB: {emp.DOB.ToShortDateString()}, DOJ: {emp.DOJ.ToShortDateString()}, City: {emp.City}");
        }
    }
}
