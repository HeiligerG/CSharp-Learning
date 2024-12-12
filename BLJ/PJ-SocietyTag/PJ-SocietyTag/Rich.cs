using PJ_SocietyTag;

public class Rich : Person
{
    public double LuxuryTaxRate { get; private set; }
    public double InvestmentRate { get; private set; }
    public List<Investment> Investments { get; private set; }
    
    private const int MAX_INVESTMENTS = 10;

    public Rich(string name, int age, double money) : base(name, age, money)
    {
        SocialClass = SocialClass.RICH;
        LuxuryTaxRate = 0.1;
        InvestmentRate = 0.3;
        Investments = new List<Investment>();
    }

    public override void Update(Economy economy)
    {
        CalculateDeathProbability();
        if (!IsAlive) return;
        
        HandleInvestments(economy);
        PayLuxuryTax();
        AdjustMoney(economy);
        CheckDowngrade();
    }
    
    private void HandleInvestments(Economy economy)
    {
        var currentInvestments = Investments.ToList();
        
        foreach (var investment in currentInvestments)
        {
            double returns = investment.CalculateReturn(economy);
            Money += returns;
            
            if (returns < 0)
            {
                Investments.Remove(investment);
            }
        }
        
        if (Investments.Count < MAX_INVESTMENTS && Money > 100000)
        {
            double investmentAmount = Money * InvestmentRate;
            if (investmentAmount > 10000)
            {
                var newInvestment = new Investment(
                    investmentAmount,
                    _random.NextDouble() * 0.8,
                    0.05 + _random.NextDouble() * 0.15
                );
                Investments.Add(newInvestment);
                Money -= investmentAmount;
            }
        }
    }
    
    private void PayLuxuryTax()
    {
        double tax = Money * LuxuryTaxRate;
        Money -= tax;
    }
    
    private void AdjustMoney(Economy economy)
    {
        double income = economy.CalculateIncome(SocialClass);
        Money += income;
        
        double livingCosts = 100000 * (1 + economy.Inflation);
        Money -= livingCosts;
    }
    
    private void CheckDowngrade()
    {
        if (Money < 100000 && Investments.Count == 0)
        {
            ChangeSocialClass(SocialClass.MIDDLE_CLASS);
        }
    }
}