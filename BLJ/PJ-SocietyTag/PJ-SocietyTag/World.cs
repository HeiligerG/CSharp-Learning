namespace PJ_SocietyTag;

public class World
{
    public List<Person> Population { get; private set; }
    public DateTime CurrentDate { get; private set; }
    public double CatastropheProbability { get; private set; }
    private readonly Random _random;
    public Economy Economy { get; private set; }
    public List<NaturalDisaster> ActiveDisasters { get; private set; }
    public SimulationStats DailyStats { get; private set; }
    
    private const int MAX_POPULATION = 1000000;

    public World(int initialPopulation)
    {
        Population = new List<Person>();
        CurrentDate = new DateTime(2024, 1, 1);
        CatastropheProbability = 0.001;
        _random = new Random();
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
        HandleNaturalDisasters();
        UpdatePopulation();
        
        foreach (var disaster in ActiveDisasters.ToList())
        {
            disaster.Update();
            if (!disaster.IsActive)
            {
                ActiveDisasters.Remove(disaster);
            }
            else
            {
                disaster.ApplyEconomicImpact(Economy);
            }
        }
        
        Thread.Sleep(1000);
    }

    private void HandleNaturalDisasters()
    {
        if (_random.NextDouble() < CatastropheProbability)
        {
            string[] disasterTypes = { "Drought", "Flood", "Earthquake", "Hurricane" };
            string type = disasterTypes[_random.Next(disasterTypes.Length)];
            double severity = _random.NextDouble();

            var disaster = new NaturalDisaster(type, severity, 0.01 * severity, _random.Next(1, 4));
            ActiveDisasters.Add(disaster);

            int casualties = disaster.CalculateCasualties(Population.Count);
            for (int i = 0; i < casualties && Population.Count > 0; i++)
            {
                int index = _random.Next(Population.Count);
                Population[index].Die();
            }
        }
    }

    private void UpdatePopulation()
    {
        var newborns = new List<Person>();
        foreach (var person in Population.Where(p => p.IsAlive && p.Age >= 18 && p.Age <= 45))
        {
            if (Population.Count >= MAX_POPULATION) break;
            
            if (person.TryReproduction())
            {
                Person newborn = person.SocialClass switch
                {
                    SocialClass.RICH => new Rich($"Child_{_random.Next()}", 0, 50000),
                    SocialClass.MIDDLE_CLASS => new MiddleClass($"Child_{_random.Next()}", 0, 15000),
                    SocialClass.POOR => new Poor($"Child_{_random.Next()}", 0, 1000),
                    _ => throw new ArgumentException("Invalid social class")
                };
                
                newborns.Add(newborn);
                DailyStats.Births++;
            }
        }
        Population.AddRange(newborns);

        foreach (var person in Population.ToList())
        {
            var oldClass = person.SocialClass;
            person.Update(Economy);

            if (!person.IsAlive)
            {
                DailyStats.Deaths++;
                Population.Remove(person);
            }
            else if (person.SocialClass != oldClass)
            {
                DailyStats.AddClassChange(oldClass, person.SocialClass);
            }
        }
    }

    private void InitializePopulation(int count)
    {
        for (int i = 0; i < count; i++)
        {
            double classDeterminator = _random.NextDouble();
            Person person;

            if (classDeterminator < 0.05)
            {
                person = new Rich(
                    $"Person_{i}",
                    _random.Next(20, 50),
                    100000 + _random.Next(50000, 1000000)
                );
            }
            else if (classDeterminator < 0.65)
            {
                person = new MiddleClass(
                    $"Person_{i}",
                    _random.Next(20, 50),
                    30000 + _random.Next(20000, 70000)
                );
            }
            else
            {
                person = new Poor(
                    $"Person_{i}",
                    _random.Next(20, 50),
                    _random.Next(5000, 25000)
                );
            }
            
            Population.Add(person);
        }
    }
}