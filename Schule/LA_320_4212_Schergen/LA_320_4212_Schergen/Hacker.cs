namespace LA_320_4212_Schergen;

internal class Hacker : Scherge
{
    public Hacker(string name) : base(name, 0, 2) { }
    public override void GreifeAn(Geheimagent geheimagent)
    {
        while (_hitpoints > 0)
        {
            geheimagent.KassiereSchaden(_schaden);
            _hitpoints -= geheimagent.TeileSchadenAus();
        }
    }
}