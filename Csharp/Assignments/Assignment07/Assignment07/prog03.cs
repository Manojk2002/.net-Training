using System;
using System.Collections.Generic;
using System.Linq;

public class Employee
{
    public int EmpId { get; set; }
    public string EmpName { get; set; }
    public string EmpCity { get; set; }
    public double EmpSalary { get; set; }

    public void Display()
    {
        Console.WriteLine($"ID: {EmpId}, Name: {EmpName}, City: {EmpCity}, Salary: {EmpSalary}");
        Console.ReadLine();
    }
}

class prog03
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>();

        Console.Write("Enter number of employees: ");
        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"\nEnter details for Employee {i + 1}:");

            Console.Write("EmpId: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("EmpName: ");
            string name = Console.ReadLine();

            Console.Write("EmpCity: ");
            string city = Console.ReadLine();

            Console.Write("EmpSalary: ");
            double salary = double.Parse(Console.ReadLine());

            employees.Add(new Employee { EmpId = id, EmpName = name, EmpCity = city, EmpSalary = salary });
            Console.ReadLine();
        }

        Console.WriteLine("\nAll Employees:");
        foreach (var emp in employees)
            emp.Display();

        Console.WriteLine("\nEmployees with Salary > 45000:");
        var highSalary = employees.Where(e => e.EmpSalary > 45000);
        foreach (var emp in highSalary)
            emp.Display();

        Console.WriteLine("\nEmployees from Bangalore:");
        var bangaloreEmployees = employees.Where(e => e.EmpCity.Equals("Bangalore", StringComparison.OrdinalIgnoreCase));
        foreach (var emp in bangaloreEmployees)
            emp.Display();

        Console.WriteLine("\nEmployees sorted by Name (Ascending):");
        var sortedEmployees = employees.OrderBy(e => e.EmpName);
        foreach (var emp in sortedEmployees)
            emp.Display();

        Console.ReadLine();
    }
}
