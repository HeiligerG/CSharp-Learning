class Kolonistenschiff : Raumschiff
{
    public void Kolonisieren()
    {
        if (Zustand < 70)
        {
            Console.WriteLine("Schiff nicht in ausreichendem Zustand für Kolonisierung!");
            return;
        }
        Console.WriteLine("Beginne Kolonisierung...");
        Zustand -= 5;
    }

    public Kolonistenschiff(string name, int treibstoff, int kapazitaet) 
        : base(name, treibstoff, kapazitaet)
    {
        Geschwindigkeit = 1;
    }
}