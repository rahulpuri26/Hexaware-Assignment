//using System;
//using RestofTasks.Models;

//namespace RestofTasks.Repostiry
//{
//    public class Bank
//    {


//        //    public void DisplayMenu()
//        //    {
//        //        Console.WriteLine("Welcome to the Banking System!");
//        //        Console.WriteLine("1. Create Account");
//        //        Console.WriteLine("2. Exit");
//        //        Console.Write("Choose an option: ");
//        //    }

//        //    public void CreateAccount()
//        //    {
//        //        Console.WriteLine("Choose Account Type:");
//        //        Console.WriteLine("1. Savings Account");
//        //        Console.WriteLine("2. Current Account");
//        //        Console.Write("Enter your choice: ");

//        //        int choice = Convert.ToInt32(Console.ReadLine());
//        //        BankAccount acc = null;

//        //        switch (choice)
//        //        {
//        //            case 1:
//        //                Console.Write("Enter Account Number: ");
//        //                int savingsAccNum = Convert.ToInt32(Console.ReadLine());
//        //                Console.Write("Enter Customer Name: ");
//        //                string savingsCustomerName = Console.ReadLine();
//        //                Console.Write("Enter Initial Balance: ");
//        //                double savingsBalance = Convert.ToDouble(Console.ReadLine());
//        //                Console.Write("Enter Interest Rate: ");
//        //                double interestRate = Convert.ToDouble(Console.ReadLine());
//        //                acc = new SavingsAccount2(savingsAccNum, savingsCustomerName, savingsBalance, interestRate);
//        //                break;

//        //            case 2:
//        //                Console.Write("Enter Account Number: ");
//        //                int currentAccNum = Convert.ToInt32(Console.ReadLine());
//        //                Console.Write("Enter Customer Name: ");
//        //                string currentCustomerName = Console.ReadLine();
//        //                Console.Write("Enter Initial Balance: ");
//        //                double currentBalance = Convert.ToDouble(Console.ReadLine());
//        //                acc = new CurrentAccount(currentAccNum, currentCustomerName, currentBalance);
//        //                break;

//        //            default:
//        //                Console.WriteLine("Invalid choice. Please try again.");
//        //                return;
//        //        }

//        //        Console.WriteLine("\nAccount Created Successfully!");
//        //        acc.PrintAccountInfo();

//        //        PerformAccountOperations(acc);
//        //    }

//        //    private void PerformAccountOperations(BankAccount acc)
//        //    {
//        //        bool exit = false;

//        //        while (!exit)
//        //        {
//        //            Console.WriteLine("\nAccount Operations:");
//        //            Console.WriteLine("1. Deposit");
//        //            Console.WriteLine("2. Withdraw");
//        //            Console.WriteLine("3. Calculate Interest (Savings Account Only)");
//        //            Console.WriteLine("4. Exit");
//        //            Console.Write("Choose an option: ");

//        //            int operationChoice = Convert.ToInt32(Console.ReadLine());

//        //            switch (operationChoice)
//        //            {
//        //                case 1:
//        //                    Console.Write("Enter deposit amount: ");
//        //                    float depositAmount = Convert.ToSingle(Console.ReadLine());
//        //                    acc.Deposit(depositAmount);
//        //                    break;

//        //                case 2:
//        //                    Console.Write("Enter withdrawal amount: ");
//        //                    float withdrawAmount = Convert.ToSingle(Console.ReadLine());
//        //                    acc.Withdraw(withdrawAmount);
//        //                    break;

//        //                case 3:
//        //                    if (acc is SavingsAccount2 savingsAccount)
//        //                    {
//        //                        savingsAccount.CalculateInterest();
//        //                    }
//        //                    else
//        //                    {
//        //                        Console.WriteLine("Interest calculation is only available for Savings Accounts.");
//        //                    }
//        //                    break;

//        //                case 4:
//        //                    exit = true;
//        //                    break;

//        //                default:
//        //                    Console.WriteLine("Invalid choice. Please try again.");
//        //                    break;
//        //            }
//        //        }
//        //    }
//        //}

        
//            private readonly Dictionary<long, BankAccount> accounts;
//            private long nextAccountNumber; // To keep track of the next account number

//            public Bank()
//            {
//                accounts = new Dictionary<long, BankAccount>();
//                nextAccountNumber = 1001; // Initialize account number starting from 1001
//            }

//            // Create a new bank account for the given customer with the initial balance
//            //public void CreateAccount(Customer customer, string accType, float balance)
//            //{
//            //    long accNo = nextAccountNumber++; // Assign and increment the account number
//            //    BankAccount account = null;

//            //    if (accType.Equals("SavingsAccount", StringComparison.OrdinalIgnoreCase))
//            //    {
//            //        account = new (accNo, customer.Name, balance, 4.5);
//            //    }
//            //    else if (accType.Equals("CurrentAccount", StringComparison.OrdinalIgnoreCase))
//            //    {
//            //        account = new CurrentAccount(accNo, customer.Name, balance);
//            //    }
//            //    else
//            //    {
//            //        Console.WriteLine("Invalid account type.");
//            //        return;
//            //    }

//            //    accounts.Add(accNo, account);
//            //    Console.WriteLine($"Account created successfully for {customer.Name}. Account Number: {accNo}");
//            //}

//            // Retrieve the balance of an account given its account number
//            public float GetAccountBalance(long accountNumber)
//            {
//                if (accounts.TryGetValue(accountNumber, out BankAccount account))
//                {
//                    return (float)account.Balance;
//                }

//                Console.WriteLine("Account not found.");
//                return 0;
//            }

//            // Deposit the specified amount into the account
//            public float Deposit(long accountNumber, float amount)
//            {
//                if (accounts.TryGetValue(accountNumber, out BankAccount account))
//                {
//                    account.Deposit(amount);
//                    return (float)account.Balance;
//                }

//                Console.WriteLine("Account not found.");
//                return 0;
//            }

//            // Withdraw the specified amount from the account
//            public float Withdraw(long accountNumber, float amount)
//            {
//                if (accounts.TryGetValue(accountNumber, out BankAccount account))
//                {
//                    account.Withdraw(amount);
//                    return (float)account.Balance;
//                }

//                Console.WriteLine("Account not found.");
//                return 0;
//            }

//            // Transfer money from one account to another
//            public void Transfer(long fromAccountNumber, long toAccountNumber, float amount)
//            {
//                if (accounts.TryGetValue(fromAccountNumber, out BankAccount fromAccount) &&
//                    accounts.TryGetValue(toAccountNumber, out BankAccount toAccount))
//                {
//                    fromAccount.Withdraw(amount);
//                    toAccount.Deposit(amount);
//                    Console.WriteLine($"Transferred {amount} from account {fromAccountNumber} to account {toAccountNumber}.");
//                }
//                else
//                {
//                    Console.WriteLine("One or both accounts not found.");
//                }
//            }

//            // Return the account and customer details
//            public void GetAccountDetails(long accountNumber)
//            {
//                if (accounts.TryGetValue(accountNumber, out BankAccount account))
//                {
//                    Console.WriteLine($"Account Number: {account.AccountNumber}");
//                    Console.WriteLine($"Customer Name: {account.CustomerName}");
//                    Console.WriteLine($"Account Balance: {account.Balance}");
//                }
//                else
//                {
//                    Console.WriteLine("Account not found.");
//                }
//            }
//        }
//    }


