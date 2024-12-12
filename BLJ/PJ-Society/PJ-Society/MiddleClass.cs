namespace PJ_Society;

public class MiddleClass : Person
{
    private double UpgradeChance { get; }
    private double DowngradeChance { get; }
    private double SavingsRate;
    private double Savings { get; }
    
    public MiddleClass(double upgradeChance, double downgradeChance,double savings, string name, int age, double money, bool isAlive, socialClass socialClass) : base(name, age, money, isAlive, socialClass)
    {
        this.UpgradeChance = upgradeChance;
        this.DowngradeChance = downgradeChance;
        this.Savings = savings;
        this.Name = name;
        this.Age = age;
        this.Money = money;
        this.IsAlive = isAlive;
        this.SocialClass = socialClass;
    }
    
    public void handleSavings() { }

    public bool tryUpgrade()
    {
        return
    }

    public override void update() { }
}