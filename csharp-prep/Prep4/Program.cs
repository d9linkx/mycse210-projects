using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Initialize the list to store numbers
        List<int> numbers = new List<int>();
        int number;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Step 1: Collect numbers from the user
        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                numbers.Add(number);
            }
        } while (number != 0);

        // Step 2: Compute the sum, average, and maximum
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }

        float average = (float)sum / numbers.Count;
        int max = numbers[0];
        foreach (int num in numbers)
        {
            if (num > max)
            {
                max = num;
            }
        }

        // Stretch Challenge: Find the smallest positive number
        int? smallestPositive = null;
        foreach (int num in numbers)
        {
            if (num > 0 && (smallestPositive == null || num < smallestPositive))
            {
                smallestPositive = num;
            }
        }

        // Stretch Challenge: Sort the list
        numbers.Sort();

        // Display the results
        Console.WriteLine("\nResults:");
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average:F2}");
        Console.WriteLine($"The largest number is: {max}");

        if (smallestPositive != null)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("There are no positive numbers in the list.");
        }

        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}
