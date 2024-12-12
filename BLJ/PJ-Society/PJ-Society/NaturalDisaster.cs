namespace PJ_Society;

public class NaturalDisaster
{
    private string Type { get; }
    private double Severity { get; }
    private double MoralityRate;
    private int Duration;
    private int RemainingDuration;

    public NaturalDisaster(string type, double severity)
    {
        this.Type = type;
        this.Severity = severity;
        bool IsActive = true;
    }

    public int calculateCasualties(int population)
    {
        return
    }

    public void applyEconomicImpact(Economy economy) { } 
    public void update() { }
}