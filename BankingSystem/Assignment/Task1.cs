using System;

class LoanChecker
{
    static void Main()
    {
        
        Console.Write("Enter Credit Score: ");
        int creditscore = int.Parse(Console.ReadLine());

        Console.Write("Enter Annual Income: ");
        int annualincome = int.Parse(Console.ReadLine());

        // Eligibility criteria
        int minCreditscore = 700;
        int minincome = 50000;

        
        if (creditscore > minCreditscore && annualincome >= minincome)
        {
            Console.WriteLine("Congratulations! You are eligible for a loan.");
        }
        else
        {
            Console.WriteLine("Sorry, you are not eligible for a loan.");
        }
    }
}
