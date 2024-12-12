using System.Data.SqlTypes;

namespace PJ_Society;

public class Rich : Person
{
    private double LuxuryTaxRate { get; }
    private double InvestmentRate { get; }
    private List<Investment> Investments;

    public Rich(double luxuryTaxRate, double investmentRate, string name, int age, double money, bool isAlive, socialClass socialClass) : base(name, age, money, isAlive, socialClass)
    {
        this.LuxuryTaxRate = luxuryTaxRate;
        this.InvestmentRate = investmentRate;
        this.Name = name;
        this.Age = age;
        this.Money = money;
        this.IsAlive = isAlive;
        this.SocialClass = socialClass;
    }

    public override void update() { }
    public void handleInvestments() { }
    public void payLuxuryTax() { }
}