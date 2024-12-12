namespace PJ_Society;

public class Poor : Person
{
    private double UpgradeChance { get; }
    private double SocialSupport { get; }
    private double BasicIncome;
    
    public Poor(double upgradeChance, double socialSupport, string name, int age, double money, bool isAlive, socialClass socialClass) : base(name, age, money, isAlive, socialClass)
    {
        this.UpgradeChance = upgradeChance;
        this.SocialSupport = socialSupport;
        this.Name = name;
        this.Age = age;
        this.Money = money;
        this.IsAlive = isAlive;
        this.SocialClass = socialClass;
    }

    public void receiveSocialSupport() { }

    public bool tryUpgrade()
    {
        return 
    }
    
    public void update() { }
}