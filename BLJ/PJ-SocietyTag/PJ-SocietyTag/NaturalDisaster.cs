using System.Data;

namespace PJ_SocietyTag;

public class NaturalDisaster
{
    public string Type { get; }
    public double Severity { get; }
    public double MortalityRate { get; }
    public int Duration { get; }
    public int RemainingDuration { get; private set; }
    public bool IsActive => RemainingDuration > 0;
    
    private readonly Dictionary<string, double> _disasterImpacts = new()
    {
        { "Drought", 1.2 },
        { "Flood", 1.5 },
        { "Earthquake", 2.0 },
        { "Hurricane", 1.8 }
    };

    public NaturalDisaster(string type, double severity, double mortalityRate, int duration)
    {
        Type = type;
        Severity = Math.Clamp(severity, 0, 1);
        MortalityRate = mortalityRate;
        Duration = duration;
        RemainingDuration = duration;
    }

    public int CalculateCasualties(int population)
    {
        double impactMultiplier = _disasterImpacts.GetValueOrDefault(Type, 1.0);
        double casualtyRate = MortalityRate * Severity * impactMultiplier;
        return (int)(population * casualtyRate);
    }
    
    public void ApplyEconomicImpact(Economy economy)
    {
        double impactMultiplier = _disasterImpacts.GetValueOrDefault(Type, 1.0);
        economy.MarketVolatility += 0.1 * Severity * impactMultiplier;
        
        if (economy.MarketTrend > -0.5)
        {
            economy.MarketTrend -= 0.2 * Severity * impactMultiplier;
        }
    }
    
    public void Update()
    {
        if (IsActive)
        {
            RemainingDuration--;
        }
    }
}