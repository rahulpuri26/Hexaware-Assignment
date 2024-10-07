using System;
namespace RestofTasks.Models
{
    public class ZeroBalance : Account
    {
        private object accountNumber1;
        private long customerName;

        public ZeroBalance(int accountNumber, string customerName)
            : base(accountNumber, customerName, 0) 
        {
        }

        public ZeroBalance(object accountNumber1, long customerName)
        {
            this.accountNumber1 = accountNumber1;
            this.customerName = customerName;
        }
    }
}

