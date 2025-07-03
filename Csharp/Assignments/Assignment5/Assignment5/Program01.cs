//1) You have a class which has methods for transaction for a banking system. (created earlier)
//Define your own methods for deposit money, withdraw money and balance in the account.
//Write your own new application Exception class called InsuffientBalanceException.
//This new Exception will be thrown in case of withdrawal of money from the account where customer doesn’t have sufficient balance.
//Identify and categorize all possible checked and unchecked exception.
using System;

namespace BankingSystem
{ 
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }

    public class BankAccount
    {
        private string accountHolder;
        private double balance;

        public BankAccount(string accountHolder, double initialBalance)
        {
            this.accountHolder = accountHolder;
            this.balance = initialBalance;
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive.");

            balance += amount;
            Console.WriteLine($"Deposited: {amount:C}");
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive.");

            if (amount > balance)
                throw new InsufficientBalanceException("Insufficient balance for withdrawal.");

            balance -= amount;
            Console.WriteLine($"Withdrawn: {amount:C}");
        }

        public void DisplayBalance()
        {
            Console.WriteLine($"Current Balance: {balance:C}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter account holder name: ");
                string name = Console.ReadLine();

                Console.Write("Enter initial balance: ");
                double initialBalance = Convert.ToDouble(Console.ReadLine());

                BankAccount account = new BankAccount(name, initialBalance);

                Console.Write("Enter deposit amount: ");
                double depositAmount = Convert.ToDouble(Console.ReadLine());
                account.Deposit(depositAmount);

                Console.Write("Enter withdrawal amount: ");
                double withdrawalAmount = Convert.ToDouble(Console.ReadLine());
                account.Withdraw(withdrawalAmount);

                account.DisplayBalance();
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Invalid input: " + ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number format. Please enter numeric values.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }
            Console.ReadLine();
        }
    }
}
