using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SocietySimulation
{
    public enum SocialClass
    {
        Poor,
        MiddleClass,
        Rich
    }

    public class World
    {
        private List<Person> population;
        private Random random;
        private Economy economy;
        private int year;
        private const double DISASTER_PROBABILITY = 0.1;

        public World(int initialPopulation)
        {
            random = new Random();
            economy = new Economy();
            population = new List<Person>();
            year = 2024;

            // Initiale Bevölkerung erstellen
            for (int i = 0; i < initialPopulation; i++)
            {
                double classDeterminator = random.NextDouble();
                if (classDeterminator < 0.05) // 5% Rich
                    population.Add(new Rich($"Person{i}", random.Next(18, 80), 100000 + random.Next(50000, 1000000)));
                else if (classDeterminator < 0.65) // 60% Middle Class
                    population.Add(new MiddleClass($"Person{i}", random.Next(18, 80), 30000 + random.Next(20000, 70000)));
                else // 35% Poor
                    population.Add(new Poor($"Person{i}", random.Next(18, 80), random.Next(5000, 25000)));
            }
        }

        public void SimulateYear()
        {
            year++;
            economy.UpdateEconomy();

            // Naturkatastrophen
            if (random.NextDouble() < DISASTER_PROBABILITY)
            {
                HandleNaturalDisaster();
            }

            // Population updaten
            foreach (var person in population.ToList())
            {
                person.Update(economy);
            }

            // Geburten
            int birthCount = (int)(population.Count * 0.05 * random.NextDouble());
            for (int i = 0; i < birthCount; i++)
            {
                double classDeterminator = random.NextDouble();
                if (classDeterminator < 0.05)
                    population.Add(new Rich($"NewBorn{i}", 0, 50000));
                else if (classDeterminator < 0.65)
                    population.Add(new MiddleClass($"NewBorn{i}", 0, 15000));
                else
                    population.Add(new Poor($"NewBorn{i}", 0, 1000));
            }

            PrintYearlyReport();
        }

        private void HandleNaturalDisaster()
        {
            string[] disasters = { "Dürre", "Flut", "Erdbeben", "Sturm" };
            string disaster = disasters[random.Next(disasters.Length)];
            double severity = random.NextDouble();
            int casualties = (int)(population.Count * severity * 0.01);

            // Zufällige Opfer auswählen
            for (int i = 0; i < casualties; i++)
            {
                if (population.Count > 0)
                {
                    int index = random.Next(population.Count);
                    population[index].Die();
                    population.RemoveAt(index);
                }
            }

            economy.ApplyDisasterEffect(severity);
            Console.WriteLine($"\n⚠️ Naturkatastrophe: {disaster}");
            Console.WriteLine($"Todesopfer: {casualties}");
            Console.WriteLine($"Wirtschaftlicher Schaden: -{(severity * 10):F1}% BIP");
        }

        private void PrintYearlyReport()
        {
            Console.Clear();
            Console.WriteLine($"=== Gesellschaftssimulation Jahr {year} ===\n");
            Console.WriteLine($"Gesamtbevölkerung: {population.Count:N0}");
            Console.WriteLine("------------------------");
            
            var richCount = population.Count(p => p is Rich);
            var middleCount = population.Count(p => p is MiddleClass);
            var poorCount = population.Count(p => p is Poor);
            
            Console.WriteLine("Klassenverteilung:");
            Console.WriteLine($"🎩 Oberschicht:     {richCount,5} ({(double)richCount/population.Count:P1})");
            Console.WriteLine($"👔 Mittelschicht: {middleCount,5} ({(double)middleCount/population.Count:P1})");
            Console.WriteLine($"👕 Unterschicht:  {poorCount,5} ({(double)poorCount/population.Count:P1})\n");

            economy.PrintReport();

            Console.WriteLine("\nDrücken Sie eine Taste für das nächste Jahr...");
            Console.ReadKey();
        }
    }

    public abstract class Person
    {
        protected string name;
        protected int age;
        protected double money;
        protected Random random;
        protected bool isAlive;

        public Person(string name, int age, double money)
        {
            this.name = name;
            this.age = age;
            this.money = money;
            this.random = new Random();
            this.isAlive = true;
        }

        public abstract void Update(Economy economy);

        protected void Age()
        {
            age++;
            // Sterbewahrscheinlichkeit steigt mit dem Alter
            if (age > 60 && random.NextDouble() < (age - 60) * 0.01)
            {
                Die();
            }
        }

        public void Die()
        {
            isAlive = false;
        }
    }

    public class Rich : Person
    {
        private const double INVESTMENT_RETURN_RATE = 0.1;

        public Rich(string name, int age, double money) : base(name, age, money) { }

        public override void Update(Economy economy)
        {
            if (!isAlive) return;

            Age();
            // Passives Einkommen durch Investitionen
            money *= (1 + INVESTMENT_RETURN_RATE * random.NextDouble());
            money *= (1 + economy.GetEconomicEffect());
        }
    }

    public class MiddleClass : Person
    {
        private const double UPGRADE_CHANCE = 0.01;
        private const double DOWNGRADE_CHANCE = 0.05;

        public MiddleClass(string name, int age, double money) : base(name, age, money) { }

        public override void Update(Economy economy)
        {
            if (!isAlive) return;

            Age();
            money *= (1 + economy.GetEconomicEffect());

            if (money > 200000 && random.NextDouble() < UPGRADE_CHANCE)
            {
                // Aufstieg zur Oberschicht
                money *= 1.5;
            }
            else if (money < 20000 && random.NextDouble() < DOWNGRADE_CHANCE)
            {
                // Abstieg zur Unterschicht
                money *= 0.7;
            }
        }
    }

    public class Poor : Person
    {
        private const double UPGRADE_CHANCE = 0.005;
        private const double SOCIAL_SUPPORT = 10000;

        public Poor(string name, int age, double money) : base(name, age, money) { }

        public override void Update(Economy economy)
        {
            if (!isAlive) return;

            Age();
            money *= (1 + economy.GetEconomicEffect());
            money += SOCIAL_SUPPORT; // Grundeinkommen/Sozialleistungen

            if (money > 50000 && random.NextDouble() < UPGRADE_CHANCE)
            {
                // Aufstieg zur Mittelschicht
                money *= 1.2;
            }
        }
    }

    public class Economy
    {
        private double marketTrend;
        private Random random;
        private const double VOLATILITY = 0.1;

        public Economy()
        {
            random = new Random();
            marketTrend = 0;
        }

        public void UpdateEconomy()
        {
            marketTrend = Math.Max(-0.2, Math.Min(0.2, marketTrend + (random.NextDouble() - 0.5) * VOLATILITY));
        }

        public double GetEconomicEffect()
        {
            return marketTrend;
        }

        public void ApplyDisasterEffect(double severity)
        {
            marketTrend -= severity * 0.2;
        }

        public void PrintReport()
        {
            Console.WriteLine("Wirtschaftliche Indikatoren:");
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Marktstabilität: {(marketTrend > 0 ? "Wachsend" : marketTrend < 0 ? "Fallend" : "Stabil")}");
            Console.WriteLine($"Markttrend: {marketTrend:P1}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Willkommen zur Gesellschaftssimulation!");
            Console.WriteLine("Geben Sie die initiale Bevölkerungsgröße ein:");
            
            int initialPopulation;
            while (!int.TryParse(Console.ReadLine(), out initialPopulation) || initialPopulation <= 0)
            {
                Console.WriteLine("Bitte geben Sie eine positive Zahl ein:");
            }

            World world = new World(initialPopulation);

            while (true)
            {
                world.SimulateYear();
            }
        }
    }
}