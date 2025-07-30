using System;
using System.Data;
using System.Data.SqlClient;

namespace CCA01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=ICS-LT-7Y6G7V3\\SQLEXPRESS;Initial Catalog=EmployeeeManagement;Integrated Security=true;";

            Console.WriteLine("Enter Employee Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Given Salary:");
            decimal givenSalary;
            while (!decimal.TryParse(Console.ReadLine(), out givenSalary) || givenSalary < 25000)
            {
                Console.WriteLine("Invalid input. Salary must be >= 25000:");
            }

            Console.WriteLine("Enter Gender (M/F):");
            char gender;
            while (!char.TryParse(Console.ReadLine(), out gender) || (gender != 'M' && gender != 'F'))
            {
                Console.WriteLine("Invalid input. Enter M or F:");
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Call InsertEmployee with stored procedure
                    using (SqlCommand insertCmd = new SqlCommand("InsertEmployee", connection))
                    {
                        insertCmd.CommandType = CommandType.StoredProcedure;

                        insertCmd.Parameters.AddWithValue("@Name", name);
                        insertCmd.Parameters.AddWithValue("@GivenSalary", givenSalary);
                        insertCmd.Parameters.AddWithValue("@Gender", gender);

                        SqlParameter empIdParam = new SqlParameter("@GeneratedEmpId", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        insertCmd.Parameters.Add(empIdParam);

                        SqlParameter salaryParam = new SqlParameter("@CalculatedSalary", SqlDbType.Decimal)
                        {
                            Precision = 10,
                            Scale = 2,
                            Direction = ParameterDirection.Output
                        };
                        insertCmd.Parameters.Add(salaryParam);

                        insertCmd.ExecuteNonQuery();

                        int empId = (int)empIdParam.Value;
                        decimal salary = (decimal)salaryParam.Value;

                        Console.WriteLine($"\nEmployee inserted successfully.");
                        Console.WriteLine($"EmpId: {empId}");
                        Console.WriteLine($"Calculated Salary: {salary}");

                        // Call UpdateSalary stored procedure
                        using (SqlCommand updateCmd = new SqlCommand("UpdateSalary", connection))
                        {
                            updateCmd.CommandType = CommandType.StoredProcedure;
                            updateCmd.Parameters.AddWithValue("@EmpId", empId);

                            SqlParameter updatedSalaryParam = new SqlParameter("@UpdatedSalary", SqlDbType.Decimal)
                            {
                                Precision = 10,
                                Scale = 2,
                                Direction = ParameterDirection.Output
                            };
                            updateCmd.Parameters.Add(updatedSalaryParam);

                            SqlParameter netSalaryParam = new SqlParameter("@NetSalary", SqlDbType.Decimal)
                            {
                                Precision = 10,
                                Scale = 2,
                                Direction = ParameterDirection.Output
                            };
                            updateCmd.Parameters.Add(netSalaryParam);

                            updateCmd.ExecuteNonQuery();

                            decimal updatedSalary = (decimal)updatedSalaryParam.Value;
                            decimal netSalary = (decimal)netSalaryParam.Value;

                            Console.WriteLine($"\nSalary updated.");
                            Console.WriteLine($"Updated Salary: {updatedSalary}");
                            Console.WriteLine($"Net Salary: {netSalary}");

                            // Display updated employee details
                            using (SqlCommand selectCmd = new SqlCommand("SELECT * FROM Employee_Details WHERE EmpId = @EmpId", connection))
                            {
                                selectCmd.Parameters.AddWithValue("@EmpId", empId);
                                using (SqlDataReader reader = selectCmd.ExecuteReader())
                                {
                                    Console.WriteLine("\nUpdated Employee Details:");
                                    while (reader.Read())
                                    {
                                        Console.WriteLine($"EmpId: {reader["EmpId"]}");
                                        Console.WriteLine($"Name: {reader["Name"]}");
                                        Console.WriteLine($"Salary: {reader["Salary"]}");
                                        Console.WriteLine($"Gender: {reader["Gender"]}");
                                    }
                                }
                            }

                            // Display all employee records
                            using (SqlCommand allCmd = new SqlCommand("SELECT * FROM Employee_Details", connection))
                            {
                                using (SqlDataReader reader = allCmd.ExecuteReader())
                                {
                                    Console.WriteLine("\nAll Employee Records:");
                                    Console.WriteLine("EmpId\tName\t\tSalary\t\tGender");
                                    while (reader.Read())
                                    {
                                        Console.WriteLine($"{reader["EmpId"]}\t{reader["Name"],-10}\t{reader["Salary"],-10}\t{reader["Gender"]}");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
