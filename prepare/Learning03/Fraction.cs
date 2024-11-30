using System;

public class Fraction
{
    private int _numerator;
    private int _denominator;

    // No-parameter constructor that initializes the fraction to 1/1
    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    // Single-parameter constructor that initializes the fraction to numerator/1
    public Fraction(int numerator)
    {
        _numerator = numerator;
        _denominator = 1;
    }

    // Two-parameter constructor that initializes the fraction to numerator/denominator
    public Fraction(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }

    // Getter for numerator
    public int GetNumerator()
    {
        return _numerator;
    }

    // Setter for numerator
    public void SetNumerator(int numerator)
    {
        _numerator = numerator;
    }

    // Getter for denominator
    public int GetDenominator()
    {
        return _denominator;
    }

    // Setter for denominator
    public void SetDenominator(int denominator)
    {
        _denominator = denominator;
    }

    // Method to return the fraction as a string
    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    // Method to return the fraction as a decimal
    public double GetDecimalValue()
    {
        return (double)_numerator / _denominator;
    }
}
