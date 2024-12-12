using System.Linq.Expressions;

namespace PJ_SocietyTag;

public abstract class Person
{
    public event Action<Person, SocialClass> OnClassChange;
    public event Action<Person> OnDeath;
    
    public string Name { get; protected set; }
    public int Age { get; protected set; }
    public double Money { get; protected set; }
    public bool IsAlive { get; protected set; }
    protected readonly Random _random;
    public SocialClass SocialClass { get; protected set; }

    protected Person(string name, int age, double money)
    {
        Name = name;
        Age = age;
        Money = money;
        IsAlive = true;
        _random = new Random();
    }

    public abstract void Update(Economy economy);

    protected void CalculateDeathProbability()
    {
        Age++;
        double baseProbability = Age > 60 ? 1 - Math.Exp(-(Age - 60) * 0.05) : 0;
        double moneyFactor = Math.Clamp((10000 - Math.Max(0, Money)) / 100000, 0, 0.5);
        double totalProbability = Math.Min(1, baseProbability + moneyFactor * 0.1);

        if (_random.NextDouble() < totalProbability)
        {
            Die();
        }
    }


    public virtual void Die()
    {
        IsAlive = false;
        OnDeath?.Invoke(this);
    }

    public bool TryReproduction()
    {
        if (Age < 18 || Age > 45) return false;

        double reproductionChance = 0.05;
        reproductionChance *= SocialClass switch
        {
            SocialClass.RICH => 0.8,
            SocialClass.MIDDLE_CLASS => 1.0,
            SocialClass.POOR => 1.2,
            _ => 1.0
        };
        return _random.NextDouble() < reproductionChance;
    }

    protected void ChangeSocialClass(SocialClass newClass)
    {
        if (SocialClass == newClass) return;

        var oldClass = SocialClass;
        SocialClass = newClass;
        OnClassChange?.Invoke(this, oldClass);
    }
}