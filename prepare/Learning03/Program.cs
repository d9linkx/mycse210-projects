using System;


public class Program
{
    public static void Main(string[] args)
    {
        // Create instances of the Fraction class using different constructors
        Fraction f1 = new Fraction();
        Fraction f2 = new Fraction(6);
        Fraction f3 = new Fraction(6, 7);

        // Display the fraction as a string
        Console.WriteLine(f1.GetFractionString()); // Output: 1/1
        Console.WriteLine(f2.GetFractionString()); // Output: 6/1
        Console.WriteLine(f3.GetFractionString()); // Output: 6/7

        // Display the fraction as a decimal
        Console.WriteLine(f1.GetDecimalValue()); // Output: 1.0
        Console.WriteLine(f2.GetDecimalValue()); // Output: 6.0
        Console.WriteLine(f3.GetDecimalValue()); // Output: 0.8571428571428571

        // Test getters and setters
        f1.SetNumerator(3);
        f1.SetDenominator(4);
        Console.WriteLine(f1.GetFractionString()); // Output: 3/4
        Console.WriteLine(f1.GetDecimalValue()); // Output: 0.75
    }
}
