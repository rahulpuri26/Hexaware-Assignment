using System;
using RestofTasks.Models;

namespace RestofTasks.Services
{
    public interface IBankServiceProvider
    {
       
        void CreateAccount(Customer customer, long accNo, string accType, float balance);

        Account[] ListAccounts();

        void CalculateInterest();
    }
}

