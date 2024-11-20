using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            // Generate a random magic number between 1 and 100
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = 0;
            int guessCount = 0;

            // Loop until the guess is correct
            while (guess != magicNumber)
            {
                // Ask for the user's guess
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                // Check if the guess is correct, higher, or lower
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                    Console.WriteLine("Guess again, you can do it! 😊");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                    Console.WriteLine("Keep trying, you're almost there! 👍");
                }
                else
                {
                    Console.WriteLine("Finally, you did it! 🎉");
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }
            }

            // Ask if the user wants to play again
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
        }
    }
}
