namespace A00_Fahrzeuge;

internal abstract class Fahrzeug
{
    internal string Color { get; }
    internal string Brand { get; }
    internal VehicleCondition Condition { get; set; }

    internal Fahrzeug(string color, string brand, VehicleCondition condition)
    {
        this.Color = color;
        this.Brand = brand;
        this.Condition = condition;
    }

    internal virtual void printInfo()
    {
        Console.WriteLine($"Dein Auto ist {Color} und ist von der Marke {Brand}");
    }

    internal virtual void Move()
    {
        Console.WriteLine($"Dein {Brand} ist am Fahren!");
    }
    
    internal virtual void getZustand()
    {
        Console.WriteLine($"Dein {Brand} ist {Condition}");
    }
}