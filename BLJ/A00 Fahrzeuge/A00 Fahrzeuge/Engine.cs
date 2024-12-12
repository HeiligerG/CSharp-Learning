namespace A00_Fahrzeuge;

public class Engine
{
    public double AmountLiter { get; }
    public int Horsepower { get; }
    public bool IsStarted { get; set; }

    public Engine(double AmountLiter, int Horsepower)
    {
        this.Horsepower = Horsepower;
        this.AmountLiter = AmountLiter;
        this.IsStarted = false;
    }

    public override string ToString()
    {
        return $"AmountLiter: {AmountLiter}, Horsepower: {Horsepower}, Gestartet: {IsStarted}";
        
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        Engine Other = (Engine)obj;
        return AmountLiter.Equals(Other.AmountLiter) && Horsepower == Other.Horsepower;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(AmountLiter, Horsepower);
    }
}