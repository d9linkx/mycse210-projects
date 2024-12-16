using System;

// Class representing a square, derived from the base Shape class
public class Square : Shape
{
    // Field to store the side length of the square
    private double _sideLength;

    // Constructor accepting color and side length
    public Square(string color, double sideLength) : base(color)
    {
        _sideLength = sideLength;
    }

    // Overriding the abstract method to compute the area
    public override double CalculateArea()
    {
        return _sideLength * _sideLength;
    }
}
