using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementSystem
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
    }

    class Program
    {
        static List<Employee> employees = new List<Employee>();

        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("\n===== Employee Management Menu =====");
                Console.WriteLine("1. Add New Employee");
                Console.WriteLine("2. View All Employees");
                Console.WriteLine("3. Search Employee by ID");
                Console.WriteLine("4. Update Employee Details");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");
                Console.WriteLine("====================================");
                Console.Write("Enter your choice: ");

                try
                {
                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AddEmployee();
                            break;
                        case 2:
                            ViewAllEmployees();
                            break;
                        case 3:
                            SearchEmployeeById();
                            break;
                        case 4:
                            UpdateEmployee();
                            break;
                        case 5:
                            DeleteEmployee();
                            break;
                        case 6:
                            Console.WriteLine("Exiting program. Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    choice = 0;
                }

            } while (choice != 6);
        }

        static void AddEmployee()
        {
            try
            {
                Employee emp = new Employee();

                Console.Write("Enter Employee ID: ");
                emp.Id = int.Parse(Console.ReadLine());

                Console.Write("Enter Name: ");
                emp.Name = Console.ReadLine();

                Console.Write("Enter Department: ");
                emp.Department = Console.ReadLine();

                Console.Write("Enter Salary: ");
                emp.Salary = double.Parse(Console.ReadLine());

                employees.Add(emp);
                Console.WriteLine("Employee added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding employee: {ex.Message}");
            }
        }

        static void ViewAllEmployees()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            Console.WriteLine("\n--- Employee List ---");
            foreach (var emp in employees)
            {
                Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Department: {emp.Department}, Salary: {emp.Salary}");
            }
        }

        static void SearchEmployeeById()
        {
            try
            {
                Console.Write("Enter Employee ID to search: ");
                int id = int.Parse(Console.ReadLine());

                var emp = employees.FirstOrDefault(e => e.Id == id);

                if (emp != null)
                {
                    Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Department: {emp.Department}, Salary: {emp.Salary}");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching employee: {ex.Message}");
            }
        }

        static void UpdateEmployee()
        {
            try
            {
                Console.Write("Enter Employee ID to update: ");
                int id = int.Parse(Console.ReadLine());

                var emp = employees.FirstOrDefault(e => e.Id == id);

                if (emp != null)
                {
                    Console.Write("Enter new Name (leave blank to keep current): ");
                    string name = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(name)) emp.Name = name;

                    Console.Write("Enter new Department (leave blank to keep current): ");
                    string dept = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(dept)) emp.Department = dept;

                    Console.Write("Enter new Salary (leave blank to keep current): ");
                    string salaryInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(salaryInput))
                        emp.Salary = double.Parse(salaryInput);

                    Console.WriteLine("Employee updated successfully!");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating employee: {ex.Message}");
            }
        }

        static void DeleteEmployee()
        {
            try
            {
                Console.Write("Enter Employee ID to delete: ");
                int id = int.Parse(Console.ReadLine());

                var emp = employees.FirstOrDefault(e => e.Id == id);

                if (emp != null)
                {
                    employees.Remove(emp);
                    Console.WriteLine("Employee deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting employee: {ex.Message}");
            }
        }
    }
}
