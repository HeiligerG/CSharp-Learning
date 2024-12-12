using System.Data;

namespace PJ_Society;

public abstract class Person
{
    protected string Name { get; }
    protected int Age { get; }
    protected double Money { get; set; }
    protected bool IsAlive { get; }
    protected Random Random;
    protected SocialClass SocialClass { get; }

    public Person(string name, int age, double money, bool isAlive, socialClass socialClass)
    {
        this.Name = name;
        this.Age = age;
        this.Money = money;
        this.IsAlive = isAlive;
        this.SocialClass = socialClass;
    }

    public virtual void update() { }

    protected bool canUpgradeClass()
    {
        return
    }

    protected void adjustMoney() { }

    protected bool tryReproduction()
    {
        return
    }

    protected void age() { }

    protected double calculateDethProbability()
    {
        return
    }
    
}