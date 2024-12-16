using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Avantiva99 Mindfulness Program!");
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");

            string choice = GetValidInput("Enter your choice (1-4): ");

            switch (choice)
            {
                case "1":
                    int breathingDuration = GetValidDuration("Enter the duration in seconds: ");
                    var breathingActivity = new BreathingActivity(breathingDuration);
                    breathingActivity.PerformActivity();
                    break;
                case "2":
                    int reflectionDuration = GetValidDuration("Enter the duration in seconds: ");
                    var reflectionActivity = new ReflectionActivity(reflectionDuration);
                    reflectionActivity.PerformActivity();
                    break;
                case "3":
                    int listingDuration = GetValidDuration("Enter the duration in seconds: ");
                    var listingActivity = new ListingActivity(listingDuration);
                    listingActivity.PerformActivity();
                    break;
                case "4":
                    Console.WriteLine("Thank you for using the program! Have a peaceful day.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    // Method to handle input validation
    static string GetValidInput(string prompt)
    {
        string input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();
        } while (string.IsNullOrEmpty(input) || !input.All(char.IsDigit));
        return input;
    }

    // Method to handle valid duration input
    static int GetValidDuration(string prompt)
    {
        int duration;
        do
        {
            Console.Write(prompt);
        } while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0);
        return duration;
    }
}
