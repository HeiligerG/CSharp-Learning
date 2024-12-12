namespace PJ_SocietyTag;

public class MiddleClass : Person
{
    public double UpgradeChance { get; private set; }
    public double DowngradeChance { get; private set; }
    public double SavingsRate { get; private set; }
    public double Savings { get; private set; }

    private const double MIN_SAVINGS = 5000;
    
    public MiddleClass(string name, int age, double money) : base(name, age, money)
    {
        SocialClass = SocialClass.MIDDLE_CLASS;
        UpgradeChance = 0.01;
        DowngradeChance = 0.05;
        SavingsRate = 0.2;
        Savings = 12000;
    }

    public override void Update(Economy economy)
    {
        CalculateDeathProbability();
        if (!IsAlive) return;
        
        HandleSavings(economy);
        AdjustMoney(economy);
        CheckClassChange();
    }

    public void HandleSavings(Economy economy)
    {
        double income = economy.CalculateIncome(SocialClass);
        double savingsAmount = income * SavingsRate;

        Savings += savingsAmount;
        Money -= savingsAmount;

        double inerest = Savings * (0.02 + economy.MarketTrend * 0.01);
        Savings += inerest;
    }

    private void CheckClassChange()
    {
        if (Money > 200000 || (_random.NextDouble() < UpgradeChance && Money > 150000))
        {
            ChangeSocialClass(SocialClass.RICH);
        }
        else if (Money < 20000 || (_random.NextDouble() < DowngradeChance && Savings < MIN_SAVINGS))
        {
            ChangeSocialClass(SocialClass.POOR);
        }
    }
    
    private void AdjustMoney(Economy economy)
    {
        double income = economy.CalculateIncome(SocialClass);
        Money += income;
        
        double livingCosts = 30000 * (1 + economy.Inflation);
        Money -= livingCosts;
        
        if (Money < 5000 && Savings > MIN_SAVINGS)
        {
            double withdrawal = Math.Min(Savings - MIN_SAVINGS, 5000);
            Money += withdrawal;
            Savings -= withdrawal;
        }
    }
}