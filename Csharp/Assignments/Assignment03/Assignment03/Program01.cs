using System;
namespace Assignment03
{

public class Accounts
{
    protected int accountNo;
    protected string customerName;
    protected string accountType;
    protected char transactionType; // 'D' for Deposit, 'W' for Withdrawal
    protected int amount;
    protected int balance;

    public Accounts(int accNo, string custName, string accType, int initialBalance)
    {
        accountNo = accNo;
        customerName = custName;
        accountType = accType;
        balance = initialBalance;
    }


    protected void Credit(int amt)
    {
        balance += amt;
        Console.WriteLine($"Deposited: {amt}");
    }


    protected void Debit(int amt)
    {
        if (amt > balance)
        {
            Console.WriteLine("Insufficient balance!");
        }
        else
        {
            balance -= amt;
            Console.WriteLine($"Withdrawn: {amt}");
        }
    }

    public void ShowData()
    {
        Console.WriteLine("\n--- Account Details ---");
        Console.WriteLine($"Account No: {accountNo}");
        Console.WriteLine($"Customer Name: {customerName}");
        Console.WriteLine($"Account Type: {accountType}");
        Console.WriteLine($"Balance: {balance}");
            Console.ReadLine();
    }
}

public class TransactionAccount : Accounts
{
    public TransactionAccount(int accNo, string custName, string accType, int initialBalance)
        : base(accNo, custName, accType, initialBalance)
    {
    }

    // Method to perform transaction
    public void PerformTransaction(char transType, int amt)
    {
        transactionType = transType;
        amount = amt;

        if (transactionType == 'D' || transactionType == 'd')
        {
            Credit(amount);
        }
        else if (transactionType == 'W' || transactionType == 'w')
        {
            Debit(amount);
        }
        else
        {
            Console.WriteLine("Invalid transaction type.");
        }
    }
}

// Main Program
public class Program01
{
    public static void Main()
    {
        TransactionAccount acc = new TransactionAccount(1001, "John Doe", "Savings", 5000);

        acc.PerformTransaction('D', 1500); // Deposit
        acc.PerformTransaction('W', 2000); // Withdrawal
        acc.ShowData();
    }
}
}
