abstract class Himmelskoerper
{
    public string Name { get; protected set; }
    public double Masse { get; protected set; }
    public (double x, double y, double z) Position { get; protected set; }

    protected Himmelskoerper(string name, double masse, (double x, double y, double z) position)
    {
        Name = name;
        Masse = masse;
        Position = position;
    }
}