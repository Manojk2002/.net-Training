// 1. Create an Abstract class Student with  Name, StudentId, Grade as members and also an abstract method Boolean Ispassed(grade) which takes grade as an input and checks whether student passed the course or not.Create 2 Sub classes Undergraduate and Graduate that inherits all members of the student and overrides Ispassed(grade) method For the UnderGrad class, if the grade is above 70.0, then isPassed returns true, otherwise it returns false. For the Grad class, if the grade is above 80.0, then isPassed returns true, otherwise returns false.Test the above by creating appropriate objects

using System;

namespace CCA02
{
    abstract class Student
    {
        public string Name { get; set; }
        public int StudentId { get; set; }
        public double Grade { get; set; }

        public abstract bool IsPassed(double grade);
    }

    class Undergraduate : Student
    {
        public override bool IsPassed(double grade)
        {
            return grade > 70.0;
        }
    }

    class Graduate : Student
    {
        public override bool IsPassed(double grade)
        {
            return grade > 80.0;
        }
    }

    class Prog01
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Undergraduate Student Details:");
            Undergraduate undergraduate = new Undergraduate();

            Console.Write("Name: ");
            undergraduate.Name = Console.ReadLine();

            Console.Write("Student ID: ");
            undergraduate.StudentId = int.Parse(Console.ReadLine());

            Console.Write("Grade: ");
            undergraduate.Grade = double.Parse(Console.ReadLine());

            Console.WriteLine("\nUndergraduate Result:");
            Console.WriteLine("Name: " + undergraduate.Name);
            Console.WriteLine("Student ID: " + undergraduate.StudentId);
            Console.WriteLine("Grade: " + undergraduate.Grade);
            Console.WriteLine("Passed: " + undergraduate.IsPassed(undergraduate.Grade));
            Console.WriteLine();

            Console.WriteLine("Enter Graduate Student Details:");
            Graduate graduate = new Graduate();

            Console.Write("Name: ");
            graduate.Name = Console.ReadLine();

            Console.Write("Student ID: ");
            graduate.StudentId = int.Parse(Console.ReadLine());

            Console.Write("Grade: ");
            graduate.Grade = double.Parse(Console.ReadLine());

            Console.WriteLine("\nGraduate Result:");
            Console.WriteLine("Name: " + graduate.Name);
            Console.WriteLine("Student ID: " + graduate.StudentId);
            Console.WriteLine("Grade: " + graduate.Grade);
            Console.WriteLine("Passed: " + graduate.IsPassed(graduate.Grade));

            Console.ReadLine();
        }
    }
}
