using System;
namespace RestofTasks.Models;

        public class CurrentAccount : BankAccount
        {
            public const double OverdraftLimit = 5000.0;
    private Customer customer;
    private long accNo;

    public CurrentAccount(long accNo, object name, float balance) : base()
            {
            }

           
            public CurrentAccount(int accountNumber, string customerName, double balance)
                : base(accountNumber, customerName, balance)
            {
            }

    public CurrentAccount(Customer customer, long accNo, float balance)
    {
        this.customer = customer;
        this.accNo = accNo;
        Balance = balance;
    }

    public override void Deposit(float amount)
            {
                if (amount > 0)
                {
                    Balance += amount;
                    Console.WriteLine($"Deposited {amount}. New balance: {Balance}");
                }
                else
                {
                    Console.WriteLine("Deposit amount must be positive.");
                }
            }

            
            public override void Withdraw(float amount)
            {
                if (amount > 0)
                {
                    if (Balance - amount >= -OverdraftLimit)
                    {
                        Balance -= amount;
                        Console.WriteLine($"Withdrew {amount}. New balance: {Balance}");
                    }
                    else
                    {
                        Console.WriteLine($"Cannot withdraw {amount}. Exceeds overdraft limit of {OverdraftLimit}");
                    }
                }
                else
                {
                    Console.WriteLine("Withdrawal amount must be positive.");
                }
            }

           
            public override void CalculateInterest()
            {
                Console.WriteLine("Current account does not earn interest.");
            }
        }
    



