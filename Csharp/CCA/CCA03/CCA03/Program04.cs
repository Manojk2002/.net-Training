using System;

public class Calculator
{
    public delegate int OperationDelegate(int firstOperand, int secondOperand);

    public static int Add(int firstOperand, int secondOperand)
    {
        return firstOperand + secondOperand;
    }

    public static int Subtract(int firstOperand, int secondOperand)
    {
        return firstOperand - secondOperand;
    }

    public static int Multiply(int firstOperand, int secondOperand)
    {
        return firstOperand * secondOperand;
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter the First integer---->: ");
        int firstNumber = int.Parse(Console.ReadLine());

        Console.Write("Enter the Second integer---->: ");
        int secondNumber = int.Parse(Console.ReadLine());

        OperationDelegate addOperation = Add;
        OperationDelegate subtractOperation = Subtract;
        OperationDelegate multiplyOperation = Multiply;

        Console.WriteLine("\nCalculator Results are: ");
        Console.WriteLine($"Addition: {firstNumber} + {secondNumber} = {addOperation(firstNumber, secondNumber)}");
        Console.WriteLine($"Subtraction: {firstNumber} - {secondNumber} = {subtractOperation(firstNumber, secondNumber)}");
        Console.WriteLine($"Multiplication: {firstNumber} * {secondNumber} = {multiplyOperation(firstNumber, secondNumber)}");

        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    }
}