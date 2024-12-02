namespace LA_320_4212_Schergen;

internal class Killer : Scherge
{
    public Killer(string name) : base(name, 10, 5) { }
    
    public override void GreifeAn(Geheimagent geheimagent)
    {
        geheimagent.ReduziereSchaden(1);
        Console.WriteLine($"{Name} hackt sich in {geheimagent.Name}'s Systeme und reduziert seinen Schaden permanent um 1!");
        Console.WriteLine($"{geheimagent.Name}'s Schaden ist jetzt: {geheimagent.Schaden}");
    }
}