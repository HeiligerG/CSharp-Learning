namespace A00_Fahrzeuge;

public class Mountainbike
{
    private string Color { get; }
    private string Brand { get; }
    private int AnzahlRaeder { get; }

    internal Mountainbike(string color, string brand, int anzahlRaeder)
    {
        this.Color = color;
        this.Brand = brand;
        this.AnzahlRaeder = anzahlRaeder;
    }

    internal void printInfo()
    {
        Console.WriteLine($"Dein Bike ist {Color} und ist von der Marke {Brand} und hat {AnzahlRaeder} Raeder.");;
    }

    internal void Move()
    {
        Console.WriteLine($"Dein {Brand} ist am Fahren!");
    }
}