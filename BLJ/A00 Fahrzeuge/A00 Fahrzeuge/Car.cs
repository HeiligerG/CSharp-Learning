namespace A00_Fahrzeuge;

class Car
{
    private string Color { get; }
    private string Brand { get; }

    internal Car(string color, string brand)
    {
        this.Color = color;
        this.Brand = brand;
    }

    internal void printInfo()
    {
        Console.WriteLine($"Dein Auto ist {Color} und ist von der Marke {Brand}");;
    }

    internal void Move()
    {
        Console.WriteLine($"Dein {Brand} ist am Fahren!");
    }
}