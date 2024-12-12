namespace PJ_SocietyTag;

public class Investment
{
    public double Amount { get; private set; }
    public double RiskFactor { get; private set; }
    public double ReturnRate { get; private set; }

    private readonly Random _random;

    public Investment(double amount, double riskFactor, double returnRate)
    {
        Amount = amount;
        RiskFactor = Math.Clamp(riskFactor, 0, 1);
        ReturnRate = returnRate;
        _random = new Random();
    }

    public double CalculateReturn(Economy economy)
    {
        double marketImpact = 1 + (economy.MarketTrend * economy.MarketVolatility);
        double riskImpact = (_random.NextDouble() - 0.5) * 2 * RiskFactor;

        double totalReturn = Amount * (ReturnRate * RiskFactor) * marketImpact;
        return Math.Max(-Amount, totalReturn);
    }
}