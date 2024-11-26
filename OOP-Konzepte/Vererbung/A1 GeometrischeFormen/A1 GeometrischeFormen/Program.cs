using System.Drawing;

namespace A1_GeometrischeFormen;

class Program
{
    static void Main(string[] args)
    {
        Shape shape = new Shape("");
        Rectangle rectangle = new Rectangle(4, 6);
        Circle circle = new Circle(5);
        
        Console.WriteLine($"Kreis {circle.Color}:");
        Console.WriteLine($"- Radius: {circle.Radius}:");
        Console.WriteLine($"- Fläche: {circle.GetArea()} m2");
        Console.WriteLine($"- Umfang: {circle.GetPerimeter()} m");
        
        
        Console.WriteLine($"Rechteck: {rectangle.Color}:");
        Console.WriteLine($"- Breite: {rectangle.Width}, Höhe: {rectangle.Height}");
        Console.WriteLine($"- Fläche: {rectangle.GetArea()} m2");
        Console.WriteLine($"- Umfang: {rectangle.GetPerimeter()} m");
    }
}