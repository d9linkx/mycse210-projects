using System;

// Abstract class serving as a blueprint for shapes
public abstract class Shape
{
    // Field to hold the color of the shape
    private string _color;

    // Constructor to initialize the color
    public Shape(string color)
    {
        _color = color;
    }

    // Method to retrieve the color
    public string GetColor()
    {
        return _color;
    }

    // Method to update the color
    public void SetColor(string color)
    {
        _color = color;
    }

    // Abstract method to calculate the area, implementation will differ for each shape
    public abstract double CalculateArea();
}
