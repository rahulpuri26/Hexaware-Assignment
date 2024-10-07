using System;

class IntCal
{
    static void Main()
    {
            Console.Write("Enter the number of customers: ");
        int numCustomers = int.Parse(Console.ReadLine());

        
        for (int i = 1; i <= numCustomers; i++)
        {
            Console.WriteLine($"\nCustomer {i}:");

           
            Console.Write("Enter the initial balance: ");
            int initialBalance = int.Parse(Console.ReadLine());

            Console.Write("Enter the annual interest rate in %: ");
            int annualInterestRate = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of years: ");
            int years = int.Parse(Console.ReadLine());

            // Calculate the future balance using the compound interest formula
            double futureBalance = initialBalance * Math.Pow((1 + annualInterestRate / 100), years);

           
            Console.WriteLine($"Future balance for Customer {i} after {years} years: {futureBalance}");
        }
    }
}
