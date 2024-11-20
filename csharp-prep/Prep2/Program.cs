using System;

class Program
{
    static void Main(string[] args)
    {
        // Step 1: Ask for the grade percentage
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        int percentage = int.Parse(input);

        // Step 2: Determine the letter grade
        string letter;
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Step 3: Determine the sign
        string sign = "";
        int lastDigit = percentage % 10;

        if (letter != "A" && letter != "F") // No A+ or F+/F-
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        else if (letter == "A" && lastDigit < 3)
        {
            sign = "-";
        }

        // Step 4: Check if the user passed
        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Unfortunately, you did not pass. But, don't give up. I wish you better luck next time!");
        }

        // Step 5: Print the letter grade with the sign
        Console.WriteLine($"Your letter grade is: {letter}{sign}");
    }
}
