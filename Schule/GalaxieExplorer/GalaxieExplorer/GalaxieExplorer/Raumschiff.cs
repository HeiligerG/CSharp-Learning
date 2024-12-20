abstract class Raumschiff
{
    public string Name { get; protected set; }
    public int Treibstoff { get; set; }
    public int Kapazitaet { get; set; }
    public int Geschwindigkeit { get; protected set; }
    public int Zustand { get; protected set; }

    protected Raumschiff(string name, int treibstoff, int kapazitaet)
    {
        Name = name;
        Treibstoff = treibstoff;
        Kapazitaet = kapazitaet;
        Geschwindigkeit = 1;
        Zustand = 100;
    }

    public void Reparieren()
    {
        Zustand = 100;
        Console.WriteLine($"{Name} wurde vollständig repariert.");
    }
}