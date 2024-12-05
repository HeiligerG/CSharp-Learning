namespace A00_Fahrzeuge;

internal class Car : Fahrzeug, IMotirizedVehicle
{

    internal Car(string color, string brand) : base(color, brand) { }
    
    internal bool IsStartEngine { get; private set; } = false;

    internal bool IsStopEngine { get; private set; } = false;
    
    public void startEngine()
    {
        if (!this.IsStartEngine)
        {
            this.IsStartEngine = true;
            Console.WriteLine($"Motor des {Brand} gestartet!");
        } else {
            Console.WriteLine($"Motor des {Brand} ist bereits gestartet!");
        }
    }
    
    public void stopEngine()
    {
        if (!this.IsStopEngine)
        {
            this.IsStopEngine = false;
            Console.WriteLine($"Motor des {Brand} gestopt!");
        } else {
            Console.WriteLine($"Motor des {Brand} ist bereits gestopt!");
        }
    }
    
    internal override void printInfo()
    {
        Console.WriteLine($"Dein Auto ist {Color} und ist von der Marke {Brand}");
    }

    internal override void Move()
    {
        Console.WriteLine($"Dein {Brand} ist am Fahren!");
    }
    
    
}