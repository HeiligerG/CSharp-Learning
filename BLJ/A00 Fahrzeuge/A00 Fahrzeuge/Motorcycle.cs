namespace A00_Fahrzeuge;

class Motorcycle
{
    private string Color { get; }
    private string Brand { get; }
    private string Fahrer { get; }

    internal Motorcycle(string color, string brand, string fahrer)
    {
        this.Color = color;
        this.Brand = brand;
        this.Fahrer = fahrer;
    }

    internal void printInfo()
    {
        Console.WriteLine($"Dein Motorrad ist {Color} und ist von der Marke {Brand} und er gehört {Fahrer}");;
    }

    internal void Move()
    {
        Console.WriteLine($"Dein {Brand} ist am Fahren!");
    }
}
