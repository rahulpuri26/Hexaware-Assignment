using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Please enter a password for your bank account:");
        string password = Console.ReadLine();

        string validationMessage = ValidatePassword(password);
        Console.WriteLine(validationMessage);
    }

    static string ValidatePassword(string password)
    {
       
        if (password.Length < 8)
        {
            return "Your password needs to be at least 8 characters long.";
        }

       
        bool hasUppercase = false;
        bool hasDigit = false;

        foreach (char c in password)
        {
            if (char.IsUpper(c))
            {
                hasUppercase = true;
            }

            
            if (char.IsDigit(c))
            {
                hasDigit = true;
            }
        }

        if (!hasUppercase)
        {
            return "Your password needs at least one uppercase letter.";
        }

        if (!hasDigit)
        {
            return "Your password needs at least one number.";
        }

        
        return "Your password is good to go!";
    }
}
