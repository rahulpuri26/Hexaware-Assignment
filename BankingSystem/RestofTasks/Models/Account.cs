using System;
namespace RestofTasks.Models
{
	public class Account
    {
        
        private int accountNumber;
        private string accountType;
        private float accountBalance;
        private const double interestRate = 4.5; 
        
        public Account()
        {
            accountNumber = 0;
            accountType = "Unknown";
            accountBalance = 0.0f;
        }

        
        public Account(int accountNumber, string accountType, double accountBalance)
        {
            this.accountNumber = accountNumber;
            this.accountType = accountType;
            this.accountBalance = (float)accountBalance;
        }

       
        public int AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }

        public string AccountType
        {
            get { return accountType; }
            set { accountType = value; }
        }

        public double AccountBalance
        {
            get { return accountBalance; }
            set { accountBalance = (float)value; }
        }

        public float Balance { get; internal set; }

        public void PrintAccountInfo()
        {
            Console.WriteLine("Account Information:");
            Console.WriteLine($"Account Number: {accountNumber}");
            Console.WriteLine($"Account Type: {accountType}");
            Console.WriteLine($"Account Balance: {accountBalance:C}");
        }

        internal float Deposit(float amount)
        {
            throw new NotImplementedException();
        }

        internal float Withdraw(float amount)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Account(CurrentAccount v)
        {
            throw new NotImplementedException();
        }


        //public void Deposit(double amount)
        //{
        //    if (amount > 0)
        //    {
        //        accountBalance += amount;
        //        Console.WriteLine($"Successfully deposited {amount}. New balance: {accountBalance}");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Deposit amount must be positive.");
        //    }
        //}


        //public void Withdraw(double amount)
        //{
        //    if (amount > 0)
        //    {
        //        if (accountBalance >= amount)
        //        {
        //            accountBalance -= amount;
        //            Console.WriteLine($"Successfully withdrew {amount}. New balance: {accountBalance}");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Insufficient balance.");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Withdrawal amount must be positive.");
        //    }
        //}


        //public void CalculateInterest()
        //{
        //    double interest = (accountBalance * interestRate) / 100;
        //    Console.WriteLine($"Interest on current balance {accountBalance} at {interestRate}%: {interest}");
        //}
    }
}

