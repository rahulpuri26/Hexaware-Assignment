using System;

class BankAccount
{ 
    public int AccountNumber { get; set; }
    public decimal Balance { get; set; }

    
    public BankAccount(int accountNumber, decimal balance)
    {
        AccountNumber = accountNumber;
        Balance = balance;
    }
}

class BankProgram
{
    static void Main(string[] args)
    {
        
        BankAccount[] bankAccounts = new BankAccount[]
        {
            new BankAccount(1001, 5000.75m),  
            new BankAccount(1002, 10000.50m), 
            new BankAccount(1003, 750.00m)    
        };

        int accountNumber;
        bool accountFound = false;

        // loop until the user enters a valid account number
        while (!accountFound)
        {
            
            Console.Write("Please enter your account number: ");

            accountNumber = int.Parse(Console.ReadLine());

            
            foreach (var account in bankAccounts)
            {
                if (account.AccountNumber == accountNumber)
                {
                    // If account found, display the balance and set flag to exit loop
                    Console.WriteLine($"Account Number: {account.AccountNumber}, Balance: {account.Balance}");
                    accountFound = true;
                    break;
                }
            }

            // if no account matches, ask for the account number again
            if (!accountFound)
            {
                Console.WriteLine("Invalid account number. Please try again.");
            }
        }

        Console.WriteLine("Thank you for using our service.");
    }
}
