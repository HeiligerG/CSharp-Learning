namespace A00_Fahrzeuge;

internal class Motorcycle : Fahrzeug, IMotirizedVehicle
{
    private string Fahrer { get; }

    internal Motorcycle(string fahrer, string color, string brand, VehicleCondition condition) : base(color, brand, condition)
    {
        this.Fahrer = fahrer;
    }
    
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
            Console.WriteLine($"Motor deines {Brand} gestopt!");
        } else {
            Console.WriteLine($"Motor des {Brand} ist bereits gestopt!");
        }
    }

    internal override void printInfo()
    {
        Console.WriteLine($"Dein Motorrad ist {Color} und ist von der Marke {Brand} und er gehört {Fahrer}");;
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
