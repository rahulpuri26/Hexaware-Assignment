using System;

class ATM
{
    static void Main()
    {
       
        double balance = 20000;

        // display  options
        Console.WriteLine("ATM Menu:");
        Console.WriteLine("1. Check Balance");
        Console.WriteLine("2. Withdraw");
        Console.WriteLine("3. Deposit");
        Console.Write("Choose an option (1-3): ");
        int option = int.Parse(Console.ReadLine());

        
        switch (option)
        {
            case 1: 
                Console.WriteLine("Your current balance is: " + balance);
                break;

            case 2: 
                Console.Write("Enter the amount you want to withdraw: ");
                double withdrawAmount = double.Parse(Console.ReadLine());

                // check if withdrawal is in multiples of 100 or 500
                if (withdrawAmount % 100 == 0 || withdrawAmount % 500 == 0)
                {
                    // check if withdrawal amount is less than or equal to the current balance
                    if (withdrawAmount <= balance)
                    {
                        balance = balance-withdrawAmount;
                        Console.WriteLine("Withdrawal successful! Your new balance is: " + balance);
                    }
                    else
                    {
                        Console.WriteLine("Insufficient funds. Your current balance is: " + balance);
                    }
                }
                else
                {
                    Console.WriteLine("Withdrawal amount must be in multiples of 100 or 500.");
                }
                break;

            case 3: // deposit
                Console.Write("Enter the amount you want to deposit: ");
                double depositAmount = double.Parse(Console.ReadLine());

                // add the deposit amount to the balance
                balance = balance+depositAmount;
                Console.WriteLine("Deposit successful! Your new balance is: " + balance);
                break;

            default:
                Console.WriteLine("Invalid option. Please choose a valid transaction.");
                break;
        }
    }
}
