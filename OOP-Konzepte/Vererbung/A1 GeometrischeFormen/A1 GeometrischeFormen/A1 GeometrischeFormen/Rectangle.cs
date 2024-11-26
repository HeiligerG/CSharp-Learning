namespace A1_GeometrischeFormen;

public class Rectangle : Shape
{
    private double width;
    private double height;

    public double Width => width;
    public double Height => height;

    public Rectangle(double width, double height) : base("Blau")
    {
        this.width = width;
        this.height = height;
    }

    public override double GetArea()
    {
        return width * height;
    }

     public override double GetPerimeter()
    {
        return 2 * width + 2 * height;
    }
}