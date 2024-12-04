namespace A00_Fahrzeuge;

internal class Car : Fahrzeug
{

    internal Car(string color, string brand) : base(color, brand) { }

    internal override void printInfo()
    {
        Console.WriteLine($"Dein Auto ist {Color} und ist von der Marke {Brand}");
    }

    internal override void Move()
    {
        Console.WriteLine($"Dein {Brand} ist am Fahren!");
    }
}