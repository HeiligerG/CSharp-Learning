namespace A00_Fahrzeuge;

internal abstract class Fahrzeug 
{
    internal string Color { get; }
    internal string Brand { get; }

    internal Fahrzeug(string color, string brand)
    {
        this.Color = color;
        this.Brand = brand;
    }
    
    internal virtual void printInfo() { }

    internal virtual void Move() { }
}