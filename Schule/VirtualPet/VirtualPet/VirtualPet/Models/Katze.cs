namespace VirtualPet.Models;

public class Katze : Haustier
{
    private int schnurrIntensitaet;

    public Katze(string name) : base(name)
    {
        schnurrIntensitaet = 50;
    }

    public void Schnurren()
    {
        Stimmung += 10;
        schnurrIntensitaet += 10;
        UpdateStatus();
    }

    public override void ReagiereAufAktion()
    {
        Stimmung += 15;
        Schnurren();
    }
}