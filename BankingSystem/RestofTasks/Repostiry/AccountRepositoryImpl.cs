using System;
using RestofTasks.Models;

namespace RestofTasks.Repostiry
{
    public class AccountRepositoryImpl : IAccountRepository
    {
        private Account account;

        
        public AccountRepositoryImpl(int accountNumber, string accountType, double accountBalance)
        {
            account = new Account(accountNumber, accountType, accountBalance);
        }

        
        public void Deposit(float amount)
        {
            Deposit((double)amount);
        }

        public void Deposit(int amount)
        {
            Deposit((double)amount);
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                account.AccountBalance += amount;
                Console.WriteLine($"Successfully deposited {amount}. New balance: {account.AccountBalance}");
            }
            else
            {
                Console.WriteLine("Deposit amount must be positive.");
            }
        }

        
        public void Withdraw(float amount)
        {
            Withdraw((double)amount);
        }

        public void Withdraw(int amount)
        {
            Withdraw((double)amount);
        }

        public void Withdraw(double amount)
        {
            if (amount > 0)
            {
                if (account.AccountBalance >= amount)
                {
                    account.AccountBalance -= amount;
                    Console.WriteLine($"Successfully withdrew {amount}. New balance: {account.AccountBalance}");
                }
                else
                {
                    Console.WriteLine("Insufficient balance.");
                }
            }
            else
            {
                Console.WriteLine("Withdrawal amount must be positive.");
            }
        }

       
        public void CalculateInterest()
        {
            if (account.AccountType == "Savings")
            {
                const double interestRate = 4.5; 
                double interest = (account.AccountBalance * interestRate) / 100;
                Console.WriteLine($"Interest on current balance {account.AccountBalance} at {interestRate}%: {interest}");
            }
            else
            {
                Console.WriteLine("Interest calculation is only applicable for savings accounts.");
            }
        }

        
        public void PrintAccountInfo()
        {
            Console.WriteLine("Account Information:");
            Console.WriteLine($"Account Number: {account.AccountNumber}");
            Console.WriteLine($"Account Type: {account.AccountType}");
            Console.WriteLine($"Account Balance: {account.AccountBalance}");
        }
    }
}

