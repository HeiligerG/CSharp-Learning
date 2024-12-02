namespace LA_320_4212_Schergen;

internal abstract class Scherge
{
    internal string Name { get; init; }
    protected int _schaden;
    protected int _hitpoints;
    public bool IstBesiegt => _hitpoints <= 0;

    protected Scherge(string name, int schaden, int hitpoints)
    {
        Name = name;
        _schaden = schaden;
        _hitpoints = hitpoints;
    }
    
    public virtual void GreifeAn(Geheimagent geheimagent)
    {
        geheimagent.KassiereSchaden(_schaden);
        Console.WriteLine($"{Name} fügt {geheimagent.Name} {_schaden} Schaden zu!");
            
        int gegenschaden = geheimagent.TeileSchadenAus();
        _hitpoints -= gegenschaden;
        Console.WriteLine($"{geheimagent.Name} kontert mit {gegenschaden} Schaden!");
            
        if (IstBesiegt)
        {
            Console.WriteLine($"{Name} wurde besiegt!");
        }
    }
}