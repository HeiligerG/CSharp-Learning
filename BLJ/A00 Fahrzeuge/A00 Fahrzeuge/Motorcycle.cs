namespace A00_Fahrzeuge;

class Motorcycle : Fahrzeug
{
    private string Fahrer { get; }

    internal Motorcycle(string fahrer, string color, string brand) : base(color, brand)
    {
        this.Fahrer = fahrer;
    }

    internal override void printInfo()
    {
        Console.WriteLine($"Dein Motorrad ist {Color} und ist von der Marke {Brand} und er gehört {Fahrer}");;
    }

    internal void Move()
    {
        Console.WriteLine($"Dein {Brand} ist am Fahren!");
    }
}
