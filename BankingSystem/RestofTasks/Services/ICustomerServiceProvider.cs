using System;
namespace RestofTasks.Services
{
    using System;

    namespace BankingSystem
    {
        public interface ICustomerServiceProvider
        {
            float GetAccountBalance(long accountNumber);
            float Deposit(long accountNumber, float amount);
            float Withdraw(long accountNumber, float amount);
            void Transfer(long fromAccountNumber, long toAccountNumber, float amount);
            string GetAccountDetails(long accountNumber);
        }
    }

}

