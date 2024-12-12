using System.Data;

namespace PJ_SocietyTag;

public class NaturalDisaster
{
    public string Type { get; }
    public double Severity { get; private set; }
    public double MortalityRate { get; private set; }
    public int Duration { get; private set; }
    public int RemainingDuration { get; private set; }
    public bool IsActive => RemainingDuration > 0;

    public NaturalDisaster(string type, double severity, double mortalityRate, int duration)
    {
        Type = type;
        Severity = severity;
        MortalityRate = mortalityRate;
        Duration = duration;
        RemainingDuration = duration;
    }

    public int CalculateCasualities(int populisation)
    {
        return
    }
    
    public void ApplyEconomicImpact(Economy economy) { }
    
    public void Update() { }
}