using System;
namespace Assignment03
{

    public class SaleDetails
    {
        // Fields
        private static int salesNo;
        private static int productNo;
        private static double price;
        private static DateTime dateOfSale;
        private static int qty;
        private static double totalAmount;

        // Constructor
        public SaleDetails(int sNo, int pNo, double pr, int quantity, DateTime saleDate)
        {
            salesNo = sNo;
            productNo = pNo;
            price = pr;
            qty = quantity;
            dateOfSale = saleDate;
            Sales(); // Automatically calculate total amount
        }

        // Method to calculate total amount
        private void Sales()
        {
            totalAmount = qty * price;
        }

        // Static method to show data without object
        public static void ShowData()
        {
            Console.WriteLine("\n--- Sale Details ---");
            Console.WriteLine($"Sales No: {salesNo}");
            Console.WriteLine($"Product No: {productNo}");
            Console.WriteLine($"Price: {price}");
            Console.WriteLine($"Quantity: {qty}");
            Console.WriteLine($"Date of Sale: {dateOfSale.ToShortDateString()}");
            Console.WriteLine($"Total Amount: {totalAmount}");
            Console.ReadLine();
        }
    }
    public class Program03
    {
        public static void Main()
        {
            
            SaleDetails sale = new SaleDetails(101, 202, 499.99, 3, DateTime.Now);

            SaleDetails.ShowData();
        }
    }
}