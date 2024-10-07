using System;
namespace RestofTasks.Repostiry
{
    public interface IAccountRepository
    {
        void Deposit(double amount);
        void Withdraw(double amount);
        void CalculateInterest();
        void PrintAccountInfo();
    }
}

