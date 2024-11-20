using System;

class Program
{
    static void Main(string[] args)
    {
        // Call the functions in the required order
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(userNumber);
        DisplayResult(userName, squaredNumber);
    }

    // Function to display a welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Xteraaks Program!");
    }

    // Function to prompt the user for their name and return it
    static string PromptUserName()
    {
        Console.Write("Please enter your first name: ");
        return Console.ReadLine();
    }

    // Function to prompt the user for their favorite number and return it
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: (choose from 1 to 1000) ");
        return int.Parse(Console.ReadLine());
    }

    // Function to square a number and return the result
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Function to display the result
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}
