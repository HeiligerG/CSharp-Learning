using System.Collections.Generic;

public class Galaxie
{
    public string Name { get; private set; }
    public List<Stern> Sterne { get; private set; }

    public Galaxie(string name)
    {
        Name = name;
        Sterne = new List<Stern>();
        GeneriereStartSterne();
    }

    private void GeneriereStartSterne()
    {
        var stern1 = new Stern("Alpha Centauri", 2.0, (10, 10, 10));
        var stern2 = new Stern("Sirius", 2.5, (-5, 8, 12));
        var stern3 = new Stern("Proxima", 1.8, (15, -3, 7));
        Sterne.Add(stern1);
        Sterne.Add(stern2);
        Sterne.Add(stern3);
    }
}