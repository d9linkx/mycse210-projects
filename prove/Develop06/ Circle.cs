using System;

// Class representing a circle, inheriting from Shape
public class Circle : Shape
{
    // Field to store the radius of the circle
    private double _radius;

    // Constructor to initialize the color and radius
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    // Overriding the method to compute the circle's area
    public override double CalculateArea()
    {
        return Math.PI * _radius * _radius;
    }
}
