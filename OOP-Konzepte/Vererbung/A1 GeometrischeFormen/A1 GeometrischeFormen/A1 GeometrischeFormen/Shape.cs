namespace A1_GeometrischeFormen;

public class Shape
{
    private string color;
    
    public string Color => color;

    public Shape(string color)
    {
        this.color = color;

    }
    
    // Virtual Methoden können in abgeleiteten Klassen überschrieben 
    public virtual double GetArea()
    {
        return 0.0;
    }

    public virtual double GetPerimeter()
    {
        return 0.0;
    }
}