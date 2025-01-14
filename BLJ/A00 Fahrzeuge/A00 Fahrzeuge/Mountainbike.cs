namespace A00_Fahrzeuge;

internal class Mountainbike : Fahrzeug
{
    private int AnzahlRaeder { get; }

    internal Mountainbike(int anzahlRaeder, string color, string brand, VehicleCondition condition) : base(color, brand, condition)
    {
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
    
    internal override void getZustand()
    {
        Console.WriteLine($"Dein {Brand} ist {Condition}");
    }
}