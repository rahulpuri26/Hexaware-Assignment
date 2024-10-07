using System;
namespace RestofTasks.Models
{
    public class SavingsAccount : Account
    {
        private Customer customer;
        private int accNo;

        public double InterestRate { get; set; }

        
        public SavingsAccount() : base()
        {
            InterestRate = 4.5; 
        }

        
        public SavingsAccount(int accountNumber, string accountType, double accountBalance, double interestRate)
            : base(accountNumber, accountType, accountBalance)
        {
            InterestRate = interestRate;
        }

        public SavingsAccount(Customer customer, int accNo, float balance)
        {
            this.customer = customer;
            this.accNo = accNo;
            Balance = balance;
        }

        internal void CalculateInterest()
        {
            throw new NotImplementedException();
        }
    }
}

