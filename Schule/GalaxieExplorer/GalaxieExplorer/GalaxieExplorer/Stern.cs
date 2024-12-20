using System.Collections.Generic;

class Stern : Himmelskoerper
{
    public List<Planet> Planeten { get; private set; }

    public Stern(string name, double masse, (double x, double y, double z) position) 
        : base(name, masse, position)
    {
        Planeten = new List<Planet>();
        GenerierePlaneten();
    }

    private void GenerierePlaneten()
    {
        var anzahl = new Random().Next(1, 4);
        for (int i = 1; i <= anzahl; i++)
        {
            Planeten.Add(new Planet($"Planet {Name}-{i}", Masse * 0.1, (Position.x + i, Position.y, Position.z)));
        }
    }
}