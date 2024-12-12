namespace PJ_SocietyTag;

public class Economy
{
    public double Inflation { get; private set; }
    public double MarketVolatility { get; private set; }
    public double BaseIncome { get; private set; }
    public double MarketTrend { get; private set; }

    private readonly Random _random;
    private const double MAX_INFLATION = 0.15;
    private const double MIN_INFLATION = -0.05;

    public Economy()
    {
        _random = new Random();
        Inflation = 0.02;
        MarketVolatility = 0.1;
        BaseIncome = 30000;
        MarketTrend = 0;
    }

    public void UpdateMarket()
    {
        MarketTrend += (_random.NextDouble() - 0.5) * MarketVolatility;
        MarketTrend = Math.Clamp(MarketTrend, -1, 1);

        Inflation += (_random.NextDouble() - 0.5) * 0.01;
        Inflation = Math.Clamp(Inflation, MIN_INFLATION, MAX_INFLATION);
        
        MarketVolatility = Math.Max(0.05, MarketVolatility + (_random.NextDouble() - 0.5) * 0.02);    
    }

    public double CalculateIncome(SocialClass socialClass)
    {
        double baseMultiplier = socialClass switch
        {
            SocialClass.RICH => 0.5,
            SocialClass.MIDDLE_CLASS => 2.0,
            SocialClass.POOR => 1.0,
            _ => throw new ArgumentException("Invalid social class")
        };
        
        double marketImpact = 1 + (MarketTrend * MarketVolatility);
        double inflationImpact = 1 + Inflation;

        return BaseIncome * baseMultiplier * marketImpact * inflationImpact;
    }
}