namespace VirtualPet.Models;

public class Hund : Haustier
{
    private int bellFrequenz;

    public Hund(string name) : base(name)
    {
        bellFrequenz = 50;
    }

    public void Bellen()
    {
        Energie -= 5;
        bellFrequenz += 10;
        UpdateStatus();
    }

    public override void ReagiereAufAktion()
    {
        Stimmung += 20;
        Bellen();
    }
}