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

    internal virtual void printInfo()
    {
        Console.WriteLine($"Dein Auto ist {Color} und ist von der Marke {Brand}");
    }

    internal virtual void Move()
    {
        Console.WriteLine($"Dein {Brand} ist am Fahren!");
    }
}