using System;
using RestofTasks.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using RestofTasks.Utilities;

namespace RestofTasks.Services
{
        public class BankServiceProvider : IBankServiceProvider
        {
            private static string connectionString = DbConnUtil.GetConnString(); 

            public void CreateAccount(Customer customer, long accNo, string accType, float balance)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Accounts (AccountNumber, CustomerName, AccountType, Balance) VALUES (@AccountNumber, @CustomerName, @AccountType, @Balance)";
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@AccountNumber", accNo);
                    command.Parameters.AddWithValue("@CustomerName", customer.Name);
                    command.Parameters.AddWithValue("@AccountType", accType);
                    command.Parameters.AddWithValue("@Balance", balance);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            public float Deposit(long accountNumber, float amount)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Accounts SET Balance = Balance + @Amount WHERE AccountNumber = @AccountNumber";
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@AccountNumber", accountNumber);
                    command.Parameters.AddWithValue("@Amount", amount);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                return GetAccountBalance(accountNumber);
            }

            public float Withdraw(long accountNumber, float amount)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                   
                    float currentBalance = GetAccountBalance(accountNumber);

                    
                    if (currentBalance < amount)
                    {
                        Console.WriteLine("Insufficient funds for this withdrawal.");
                        return currentBalance; 
                    }

                    string query = "UPDATE Accounts SET Balance = Balance - @Amount WHERE AccountNumber = @AccountNumber";
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@AccountNumber", accountNumber);
                    command.Parameters.AddWithValue("@Amount", amount);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                return GetAccountBalance(accountNumber);
            }

        public float GetAccountBalance(long accountNumber)
        {
            string query = "SELECT Balance FROM Accounts WHERE AccountNumber = @accountNumber";

           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();  

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
                    object result = cmd.ExecuteScalar();  

                    if (result != null)
                    {
                        return Convert.ToSingle(result);  
                    }
                    else
                    {
                        throw new Exception("Account not found.");
                    }
                }

                
            }
        }



        public void Transfer(long fromAccountNumber, long toAccountNumber, float amount)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                   
                    Withdraw(fromAccountNumber, amount);

                    
                    Deposit(toAccountNumber, amount);
                }
            }

        public string GetAccountDetails(long accountNumber)
        {
            string query = "SELECT a.AccountNumber, a.Balance, c.FirstName, c.LastName " +
                           "FROM Accounts a " +
                           "JOIN Customers c ON a.CustomerID = c.CustomerID " + 
                           "WHERE a.AccountNumber = @accountNumber";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@accountNumber", accountNumber);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string customerFirstName = reader["FirstName"].ToString(); 
                            string customerLastName = reader["LastName"].ToString(); 
                            long accountNum = Convert.ToInt64(reader["AccountNumber"]);
                            float balance = Convert.ToSingle(reader["Balance"]);

                            return $"Customer Name: {customerFirstName} {customerLastName}, " +
                                   $"Account Number: {accountNum}, " +
                                   $"Balance: {balance}";
                        }
                        else
                        {
                            return "Account not found.";
                        }
                    }
                }
            }
        }


        public List<Account> ListAccounts()
        {
            List<Account> accounts = new List<Account>();
            string query = "SELECT AccountNumber, AccountType, Balance FROM Accounts"; 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            int accountNumber = reader.GetInt32(0); 

                           
                            string accountType = reader.GetString(1); 

                            
                            float balance = reader.IsDBNull(2) ? 0 : (float)reader.GetInt32(2); 

                            accounts.Add(new Account
                            {
                                AccountNumber = accountNumber, 
                                AccountType = accountType,
                                Balance = balance 
                            });
                        }
                    }
                }
            }
            return accounts;
        }




       
        void IBankServiceProvider.CreateAccount(Customer customer, long accNo, string accType, float balance)
        {
            throw new NotImplementedException();
        }

        Account[] IBankServiceProvider.ListAccounts()
        {
            throw new NotImplementedException();
        }

        void IBankServiceProvider.CalculateInterest()
        {
            throw new NotImplementedException();
        }
    }
    }


