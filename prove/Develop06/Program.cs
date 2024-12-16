using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store shapes
        List<Shape> shapesCollection = new List<Shape>();

        // Add various shapes to the collection
        shapesCollection.Add(new Square("Red", 5));
        shapesCollection.Add(new Rectangle("Blue", 7, 4));
        shapesCollection.Add(new Circle("Yellow", 3));

        // Loop through the shapes and display their details
        foreach (Shape shape in shapesCollection)
        {
            Console.WriteLine($"The {shape.GetColor()} shape has an area of {shape.CalculateArea():F2}.");
        }
    }
}
