namespace PJ_SocietyTag;

public class Poor : Person
{
    public double UpgradeChance { get; private set; }
    public double SocialSupport { get; private set; }
    public double BasicIncome { get; private set; }

    public Poor(string name, int age, double money) : base(name, age, money)
    {
        SocialClass = SocialClass.POOR;
        UpgradeChance = 0.005;
        SocialSupport = 10000;
        BasicIncome = 12000;
    }

    public override void Update(Economy economy)
    {
        CalculateDeathProbability();
        if (!IsAlive) return;
        
        ReceiveSocialSupport(economy);
        AdjustMoney(economy);
        CheckUpgrade();
    }

    public void ReceiveSocialSupport(Economy economy)
    {
        double support = SocialSupport * (1 + economy.Inflation);
        Money += support;
    }
    private void CheckUpgrade()
    {
        if (Money > 50000 || (_random.NextDouble() < UpgradeChance && Money > 30000))
        {
            ChangeSocialClass(SocialClass.MIDDLE_CLASS);
        }
    }
    
    private void AdjustMoney(Economy economy)
    {
        double income = economy.CalculateIncome(SocialClass);
        Money += income;
        
        double livingCosts = BasicIncome * (1 + economy.Inflation);
        Money -= livingCosts;
        
        Money = Math.Max(0, Money);
    }
}
