public class Erkundungsschiff : Raumschiff
{
    public void Scannen(Planet planet)
    {
        if (Zustand < 30)
        {
            Console.WriteLine("Scanner beschädigt! Reparatur erforderlich!");
            return;
        }
        Console.WriteLine($"Scanner aktiviert für Planet {planet.Name}...");
        Thread.Sleep(1000);
        Zustand -= 2;
    }

    public Erkundungsschiff(string name, int treibstoff, int kapazitaet) 
        : base(name, treibstoff, kapazitaet)
    {
        Geschwindigkeit = 3;
    }
}