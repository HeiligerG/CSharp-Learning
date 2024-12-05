namespace LA_320_4212_Schergen;

internal class Schlaeger : Scherge
{
    public Schlaeger(string name) : base(name, 1, 5) { }

    public override void GreifeAn(Geheimagent geheimagent)
    {
        Console.WriteLine($"{Name} startet seinen Dauerschlag-Angriff!");
        int angriffNummer = 1;
            
        while (!IstBesiegt)
        {
            /*
            Console.WriteLine($"Attack {++angriffNummer}");
            */
            Console.WriteLine($"\nAngriff #{angriffNummer++}:");
            geheimagent.KassiereSchaden(_schaden);
            Console.WriteLine($"{Name} fügt {geheimagent.Name} {_schaden} Schaden zu!");
                
            int gegenschaden = geheimagent.TeileSchadenAus();
            _hitpoints -= gegenschaden;
            Console.WriteLine($"{geheimagent.Name} kontert mit {gegenschaden} Schaden!");
                
            if (geheimagent.IstAusserGefecht) break;
        }
        Console.WriteLine($"{Name} wurde nach {angriffNummer-1} Angriffen besiegt!");
    }
}