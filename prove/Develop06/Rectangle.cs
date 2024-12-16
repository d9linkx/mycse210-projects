using System;

// Class representing a rectangle, derived from the Shape base class
public class Rectangle : Shape
{
    // Fields to store the dimensions of the rectangle
    private double _length;
    private double _width;

    // Constructor to set the color, length, and width
    public Rectangle(string color, double length, double width) : base(color)
    {
        _length = length;
        _width = width;
    }

    // Overriding the abstract method to calculate the area
    public override double CalculateArea()
    {
        return _length * _width;
    }
}
