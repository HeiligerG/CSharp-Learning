using System.Net.Sockets;
using System.Security.AccessControl;

namespace PJ_SocietyTag;

public class World
{
    public List<Person> Population { get; private set; }
    public DateTime CurrentDate { get; private set; }
    public double CatastropheProbability { get; private set; }
    public Random Random { get; private set; }
    public Economy Economy { get; private set; }
    public List<NaturalDisaster> ActiveDisasters { get; private set; }
    public SimulationStats DailyStats { get; private set; }

    public World(int initialPopulation)
    {
        Population = new List<Person>();
        CurrentDate = new DateTime(2024, 1, 1);
        CatastropheProbability = 0.001;
        Random = new Random();
        Economy = new Economy();
        ActiveDisasters = new List<NaturalDisaster>();
        DailyStats = new SimulationStats();
        InitializePopulation(initialPopulation);
    }

    public void SimulateDay()
    {
        CurrentDate = CurrentDate.AddDays(1);
        DailyStats.Reset();
        
        Economy.UpdateMarket();
        HandleBirthsAndDeaths();
        HandleNaturalDisaster();
        
        foreach (var person in Population.ToList())
        {
            var oldClass = person.SocialClass;
            person.Update();

            if (!person.IsAlive)
            {
                DailyStats.Deaths++;
            }

            if (person.SocialClass != oldClass)
            {
                DailyStats.AddClassChange(oldClass, person.SocialClass);
            }
        }

        Population.RemoveAll(p => !p.IsAlive);
        Thread.Sleep(100);
    }

    private void HandleBirthsAndDeaths()
    {
        List<Person> newBorns = new List<Person>();
        foreach (var person in Population.Where(p => p.Age >= 18 && p.Age <= 45))
        {
            if (person.TryReproduction())
            {
                switch (person.SocialClass)
                {
                    case SocialClass.RICH:
                        newBorns.Add(new Rich($"Child{Random.Next()}", 0, 50000));
                        break;
                    case SocialClass.MIDDLE_CLASS:
                        newBorns.Add(new MiddleClass($"Child{Random.Next()}", 0, 15000));
                        break;
                    case SocialClass.POOR:
                        newBorns.Add(new Poor($"Child{Random.Next()}", 0, 1000));
                        break;
                }
            }
        }
        
 
    }
    private void InitializePopulation(int count)
    {
        for (int i = 0; i < count; i++)
    {
        double classDeterminator = Random.NextDouble();
        if (classDeterminator < 0.05)
            Population.Add(new Rich($"Person{i}", Random.Next(18, 80), 100000 + Random.Next(50000, 1000000)));
        else if (classDeterminator < 0.65)
            Population.Add(new MiddleClass($"Person{i}", Random.Next(18, 80), 30000 + Random.Next(20000, 70000)));
        else
            Population.Add(new Poor($"Person{i}", Random.Next(18, 80), Random.Next(5000, 25000)));
    }
}

    private void HandleNaturalDisaster()
    {
        if (Random.NextDouble() < CatastropheProbability)
        {
            string[] disasterTypes = { "Drought", "Flood", "Earthquake", "Hurricane" };
            string type = disasterTypes[Random.Next(disasterTypes.Length)];
            double severity = Random.NextDouble();

            var disaster = new NaturalDisaster(type, severity, 0.01 * severity, Random.Next(1, 4));
            ActiveDisasters.Add(disaster);

            int casualities = disaster.CalculateCasualities(Population);
            for (int i = 0; i < casualities; i++)
            {
                if (Population.Count > 0)
                {
                    int index = Random.Next(Population.Count);
                    Population.RemoveAll(index);
                }
            }
            disaster.ApplyEconomicImpact(Economy);
        }
    }
}