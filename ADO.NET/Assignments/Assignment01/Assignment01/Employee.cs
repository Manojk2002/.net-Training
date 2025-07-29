using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment01
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

    class Program
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee>
            {
                new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = DateTime.Parse("1984-11-16"), DOJ = DateTime.Parse("2011-06-08"), City = "Mumbai" },
                new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = DateTime.Parse("1984-08-20"), DOJ = DateTime.Parse("2012-07-07"), City = "Mumbai" },
                new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = DateTime.Parse("1987-11-14"), DOJ = DateTime.Parse("2015-04-12"), City = "Pune" },
                new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("1990-06-03"), DOJ = DateTime.Parse("2016-02-02"), City = "Pune" },
                new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("1991-03-08"), DOJ = DateTime.Parse("2016-02-02"), City = "Mumbai" },
                new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = DateTime.Parse("1989-11-07"), DOJ = DateTime.Parse("2014-08-08"), City = "Chennai" },
                new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = DateTime.Parse("1989-12-02"), DOJ = DateTime.Parse("2015-06-01"), City = "Mumbai" },
                new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = DateTime.Parse("1993-11-11"), DOJ = DateTime.Parse("2014-11-06"), City = "Chennai" },
                new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = DateTime.Parse("1992-08-12"), DOJ = DateTime.Parse("2014-12-03"), City = "Chennai" },
                new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = DateTime.Parse("1991-04-12"), DOJ = DateTime.Parse("2016-01-02"), City = "Pune" }
            };

            // 1. Joined before 2015
            var joinedBefore2015 = employees.Where(e => e.DOJ < new DateTime(2015, 1, 1));
            Console.WriteLine("Employees who joined before 2015:");
            foreach (var e in joinedBefore2015)
                Console.WriteLine($"{e.EmployeeID} - {e.FirstName} {e.LastName}");

            // 2. Born after 1990
            var bornAfter1990 = employees.Where(e => e.DOB > new DateTime(1990, 1, 1));
            Console.WriteLine("\nEmployees born after 1990:");
            foreach (var e in bornAfter1990)
                Console.WriteLine($"{e.EmployeeID} - {e.FirstName} {e.LastName}");

            // 3. Consultant or Associate
            var specificTitles = employees.Where(e => e.Title == "Consultant" || e.Title == "Associate");
            Console.WriteLine("\nConsultants and Associates:");
            foreach (var e in specificTitles)
                Console.WriteLine($"{e.EmployeeID} - {e.FirstName} {e.LastName} ({e.Title})");

            // 4. Total employees
            Console.WriteLine($"\nTotal employees: {employees.Count}");

            // 5. Employees in Chennai
            Console.WriteLine($"Employees in Chennai: {employees.Count(e => e.City == "Chennai")}");

            // 6. Highest Employee ID
            Console.WriteLine($"Highest Employee ID: {employees.Max(e => e.EmployeeID)}");

            // 7. Joined after 2015
            Console.WriteLine($"Joined after 2015: {employees.Count(e => e.DOJ > new DateTime(2015, 1, 1))}");

            // 8. Not Associate
            Console.WriteLine($"Not Associate: {employees.Count(e => e.Title != "Associate")}");

            // 9. Count by City
            Console.WriteLine("\nEmployee count by city:");
            var byCity = employees.GroupBy(e => e.City);
            foreach (var group in byCity)
                Console.WriteLine($"{group.Key}: {group.Count()}");

            // 10. Count by City and Title
            Console.WriteLine("\nEmployee count by city and title:");
            var byCityTitle = employees.GroupBy(e => new { e.City, e.Title });
            foreach (var group in byCityTitle)
                Console.WriteLine($"{group.Key.City} - {group.Key.Title}: {group.Count()}");

            // 11. Youngest employee
            var youngest = employees.OrderByDescending(e => e.DOB).First();
            Console.WriteLine($"\nYoungest employee: {youngest.FirstName} {youngest.LastName} (DOB: {youngest.DOB.ToShortDateString()})");
        }
    }
}
