using System.Collections.Generic;

public class Planet : Himmelskoerper
{
    public Dictionary<string, int> Ressourcen { get; private set; }

    public Planet(string name, double masse, (double x, double y, double z) position) 
        : base(name, masse, position)
    {
        Ressourcen = new Dictionary<string, int>
        {
            { "Eisen", new Random().Next(1, 10) },
            { "Kristalle", new Random().Next(1, 5) }
        };
    }
}