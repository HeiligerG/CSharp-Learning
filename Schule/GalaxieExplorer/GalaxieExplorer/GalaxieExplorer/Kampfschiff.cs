class Kampfschiff : Raumschiff
{
    public void Angreifen()
    {
        if (Zustand < 50)
        {
            Console.WriteLine("Schiff zu stark beschädigt für Kampfmanöver!");
            return;
        }
        Console.WriteLine("Kampfmodus aktiviert!");
        Zustand -= 10;
    }

    public Kampfschiff(string name, int treibstoff, int kapazitaet) 
        : base(name, treibstoff, kapazitaet)
    {
        Geschwindigkeit = 2;
    }
}