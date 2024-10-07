using System;
namespace RestofTasks.Models
{       public abstract class BankAccount
        {
            public int AccountNumber { get; set; }
            public string CustomerName { get; set; }
            public double Balance { get; set; }

            
            public BankAccount()
            {
                AccountNumber = 0;
                CustomerName = "Unknown";
                Balance = 0.0;
            }

            
            public BankAccount(int accountNumber, string customerName, double balance)
            {
                AccountNumber = accountNumber;
                CustomerName = customerName;
                Balance = balance;
            }

            
            public void PrintAccountInfo()
            {
                Console.WriteLine("Account Information:");
                Console.WriteLine($"Account Number: {AccountNumber}");
                Console.WriteLine($"Customer Name: {CustomerName}");
                Console.WriteLine($"Balance: {Balance}");
            }

            
            public abstract void Deposit(float amount);
            public abstract void Withdraw(float amount);
            public abstract void CalculateInterest();

        public static implicit operator BankAccount(SavingsAccount v)
        {
            throw new NotImplementedException();
        }
    }
    }


