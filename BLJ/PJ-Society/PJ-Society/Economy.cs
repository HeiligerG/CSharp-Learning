namespace PJ_Society;

public class Economy
{
    private double Inflation { get; }
    private double MarketVolatility { get; }
    private double BaseIncome { get; }
    private double MarketTrend;

    public Economy(double inflation, double marketVolatility, double baseIncome)
    {
        this.Inflation = inflation;
        this.MarketVolatility = marketVolatility;
        this.BaseIncome = baseIncome;
    }

    public void updateMarket() { }

    public double calculateIncome()
    {
        return
    }
    
    public void applyInflation() { } 
}