using System;
namespace Assignment03
{
    public class Student
    {
        // Fields
        private int rollNo;
        private string name;
        private string studentClass;
        private int semester;
        private string branch;
        private int[] marks = new int[5];

        // Constructor
        public Student(int rollNo, string name, string studentClass, int semester, string branch)
        {
            this.rollNo = rollNo;
            this.name = name;
            this.studentClass = studentClass;
            this.semester = semester;
            this.branch = branch;
        }

        // Method to input marks
        public void GetMarks()
        {
            Console.WriteLine("Enter marks for 5 subjects:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Subject {i + 1}: ");
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        // Method to display result
        public void DisplayResult()
        {
            int total = 0;
            bool hasFailedSubject = false;

            foreach (int mark in marks)
            {
                if (mark < 35)
                {
                    hasFailedSubject = true;
                }
                total += mark;
            }

            double average = total / 5.0;

            Console.WriteLine("\n--- Result ---");
            if (hasFailedSubject)
            {
                Console.WriteLine("Result: Failed (One or more subjects below 35)");
            }
            else if (average < 50)
            {
                Console.WriteLine("Result: Failed (Average below 50)");
            }
            else
            {
                Console.WriteLine("Result: Passed");
            }
        }

        // Method to display student data
        public void DisplayData()
        {
            Console.WriteLine("\n--- Student Details ---");
            Console.WriteLine($"Roll No: {rollNo}");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Class: {studentClass}");
            Console.WriteLine($"Semester: {semester}");
            Console.WriteLine($"Branch: {branch}");
            Console.WriteLine("Marks: " + string.Join(", ", marks));
            Console.ReadLine();
        }
    }

    // Main Program
    public class Program02
    {
        public static void Main()
        {
            // Create a student object
            Student student = new Student(101, "Alice", "10th", 2, "Science");

            // Input marks
            student.GetMarks();

            // Display result and data
            student.DisplayResult();
            student.DisplayData();
        }
    }
}
