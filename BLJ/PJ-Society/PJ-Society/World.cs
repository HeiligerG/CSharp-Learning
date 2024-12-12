namespace PJ_Society;

public class World
{
    public List<Person> Population { get; private set; }
    public int Year { get; private set; }
    public double CatastropheProbability { get; private set; }
    public Random Random { get; private set; }
    public Economy Economy { get; private set; }
    public List<NaturalDisaster> ActiveDisasters { get; private set; }

    public World(List<Person> population, int year, Economy economy)
    {
        this.Population = population;
        this.Year = year;
        this.Economy = economy;
    }
    
    public void simulateWorld() { } 
    public void handleBirthsAndDeaths() { } 
    public void handleNaturalDisaster() { } 
    public void updateEconomy() { }

    public double getClassDistribution(double SocialClass)
    {
    }
}