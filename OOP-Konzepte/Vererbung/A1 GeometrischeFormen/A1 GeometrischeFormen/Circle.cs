namespace A1_GeometrischeFormen;

public class Circle : Shape
{
    private double radius;
    
    public double Radius => radius;

    public Circle(double Radius) : base("Rot")
    {
        this.radius = Radius;
    }

    // Override überschreibt die Methoden der Basisklasse
    public override double GetArea()
    {
        return Math.PI * radius * radius;
    }

    public override double GetPerimeter()
    {
        return 2 * Math.PI * radius;
    }
}