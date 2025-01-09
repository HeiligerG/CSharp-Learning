using System.Collections.Generic;

public class Galaxie
{
    public string Name { get; private set; }
    public List<Stern> Sterne { get; private set; }

    private static readonly string[] SternNamen =
    {
        "Alpha Centauri", "Sirius", "Proxima", "Betelgeuse", "Rigel", "Vega"
    };

    public Galaxie(string name)
    {
        Name = name;
        Sterne = new List<Stern>();
        GeneriereStartSterne();
    }

    private void GeneriereStartSterne()
    {
        var anzahl = new Random().Next(3, 6);
        for (int i = 0; i < anzahl; i++)
        {
            var name = SternNamen[i];
            var masse = new Random().NextDouble() * 3 + 1;
            var position = (
                new Random().NextDouble() * 20 - 10,
                new Random().NextDouble() * 20 - 10,
                new Random().NextDouble() * 20 - 10
            );

            Sterne.Add(new Stern(name, masse, position));
        }
    }
}