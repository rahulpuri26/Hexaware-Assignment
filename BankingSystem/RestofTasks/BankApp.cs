using System;
using RestofTasks.Repostiry;
using RestofTasks.Services;
using RestofTasks.Services.BankingSystem;

namespace RestofTasks.Models {



        public class BankApp
        {
            private static BankServiceProvider bankServiceProvider = new BankServiceProvider();

            public static void Main(string[] args)
            {
                string userInput = string.Empty;

                while (true)
                {
                    Console.WriteLine("Hi and Welcome to the Banking System !");
                    Console.WriteLine("Please select an operation:");
                    Console.WriteLine("1. create_account");
                    Console.WriteLine("2. deposit");
                    Console.WriteLine("3. withdraw");
                    Console.WriteLine("4. get_balance");
                    Console.WriteLine("5. transfer");
                    Console.WriteLine("6. getAccountDetails");
                    Console.WriteLine("7. ListAccounts");
                    //Console.WriteLine("8. getTransactions");
                    Console.WriteLine("9. exit");

                    userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        CreateAccount();
                        break;
                    case "2":
                        Deposit();
                        break;
                    case "3":
                        Withdraw();
                        break;
                    case "4":
                        GetBalance();
                        break;
                    case "5":
                        Transfer();
                        break;
                    case "6":
                        GetAccountDetails();
                        break;
                    case "7":
                        ListAccounts();
                        break;
                    //case "8":
                    //    GetTransactions();
                    //    break;
                    case "9":
                        Console.WriteLine("Thank you for using the Banking System. Goodbye!");
                        return; 
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

            }
        }

        private static void CreateAccount()
        {
            Console.WriteLine("Enter Customer Name:");
            string customerName = Console.ReadLine();

            Console.WriteLine("Choose Account Type (Savings, Current, ZeroBalance):");
            string accountType = Console.ReadLine();

            Console.WriteLine("Enter Initial Balance:");
            float balance = float.Parse(Console.ReadLine());

            long accNo = GenerateAccountNumber(); 

            //var customer = new Customer { Name = firstName };
            //bankServiceProvider.CreateAccount(customer, accNo, accountType, balance);

            Console.WriteLine($"Account created successfully with Account Number: {accNo}");
        }

        private static long GenerateAccountNumber()
            {
                
                return 1001 + new Random().Next(1, 1000);
            }

            private static void Deposit()
            {
                Console.WriteLine("Enter Account Number:");
                long accountNumber = long.Parse(Console.ReadLine());

                Console.WriteLine("Enter Amount to Deposit:");
                float amount = float.Parse(Console.ReadLine());

                float newBalance = bankServiceProvider.Deposit(accountNumber, amount);
                Console.WriteLine($"Deposit successful. New balance is: {newBalance}");
            }

            private static void Withdraw()
            {
                Console.WriteLine("Enter Account Number:");
                long accountNumber = long.Parse(Console.ReadLine());

                Console.WriteLine("Enter Amount to Withdraw:");
                float amount = float.Parse(Console.ReadLine());

                float newBalance = bankServiceProvider.Withdraw(accountNumber, amount);
                Console.WriteLine($"Withdrawal successful. New balance is: {newBalance}");
            }

            private static void GetBalance()
            {
                Console.WriteLine("Enter Account Number:");
                long accountNumber = long.Parse(Console.ReadLine());

                float balance = bankServiceProvider.GetAccountBalance(accountNumber);
                Console.WriteLine($"The balance for account number {accountNumber} is: {balance}");
            }

            private static void Transfer()
            {
                Console.WriteLine("Enter From Account Number:");
                long fromAccountNumber = long.Parse(Console.ReadLine());

                Console.WriteLine("Enter To Account Number:");
                long toAccountNumber = long.Parse(Console.ReadLine());

                Console.WriteLine("Enter Amount to Transfer:");
                float amount = float.Parse(Console.ReadLine());

                bankServiceProvider.Transfer(fromAccountNumber, toAccountNumber, amount);
                Console.WriteLine("Transfer successful.");
            }

        private static void GetAccountDetails()
        {
            Console.WriteLine("Enter Account Number:");
            long accountNumber = long.Parse(Console.ReadLine());

            string accountDetails = bankServiceProvider.GetAccountDetails(accountNumber);
            Console.WriteLine(accountDetails);
        }

        private static void ListAccounts()
            {
                List<Account> accounts = bankServiceProvider.ListAccounts();
                Console.WriteLine("List of Accounts:");
                foreach (var account in accounts)
                {
                    Console.WriteLine($"AccountNumber: {account.AccountNumber},AccountType: {account.AccountType}, Balance: {account.Balance}");
                }
            }

        
        }
    }





