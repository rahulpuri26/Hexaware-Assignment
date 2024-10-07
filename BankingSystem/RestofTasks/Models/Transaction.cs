using System;
namespace RestofTasks.Models
{
    public enum TransactionType
    {
        Withdraw,
        Deposit,
        Transfer
    }

    public class Transaction
    {
        public string Account { get; set; }           
        public string Description { get; set; }        
        public DateTime DateTime { get; set; }        
        public TransactionType Type { get; set; }      
        public float Amount { get; set; }
        public object TransactionType { get; internal set; }

        public Transaction(string account, string description, TransactionType type, float amount)
        {
            Account = account;
            Description = description;
            DateTime = DateTime.Now; 
            Type = type;
            Amount = amount;
        }

       
        public override string ToString()
        {
            return $"Account: {Account}, Description: {Description}, Date & Time: {DateTime}, " +
                   $"Transaction Type: {Type}, Amount: {Amount}";
        }
    }
}

