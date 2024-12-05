namespace LA_320_4212_Schergen;

class Boesewicht
{
    private List<Scherge> Schergen = new ();
    public Geheimagent Erzfeind { get; set; }
    public string Name { get; init; }
    
    /*
    public List<Scherge> Schergen { get; }
    */
    
    public List<Scherge> _schergen => Schergen;

    public Boesewicht(string name)
    {
        this.Name = name;
    }

    public void AddScherge(Scherge scherge)
    {
        _schergen.Add(scherge);
    }

    public void HetzeSchergenAufErzfeind()
    {
        Console.WriteLine($"\n{Name} hetzt seine Schergen auf {Erzfeind.Name}!");
            
        foreach (var scherge in _schergen)
        {
            Console.WriteLine($"\n{scherge.Name} greift an!");
            scherge.GreifeAn(Erzfeind);
        }

        if (Erzfeind.IstAusserGefecht)
        {
            Console.WriteLine($"\n{Name}: Ausgezeichnet! {Erzfeind.Name} wurde besiegt!");
        }
        else
        {
            Console.WriteLine($"\n{Name}: Ich gebe mich geschlagen. {Erzfeind.Name} ist zu stark!");
        }
    }
}