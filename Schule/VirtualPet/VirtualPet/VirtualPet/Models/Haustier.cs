using VirtualPet.Interface;

namespace VirtualPet.Models;

public abstract class Haustier : IHaustierAktionen
{
    private string name;
    private int energie;
    private int hunger;
    private int stimmung;
    private int gesundheit;

    public string Name { get; set; }
    public int Energie 
    { 
        get => energie;
        set => energie = Math.Clamp(value, 0, 100);
    }
    public int Hunger
    {
        get => hunger;
        set => hunger = Math.Clamp(value, 0, 100);
    }
    public int Stimmung
    {
        get => stimmung;
        set => stimmung = Math.Clamp(value, 0, 100);
    }
    public int Gesundheit
    {
        get => gesundheit;
        set => gesundheit = Math.Clamp(value, 0, 100);
    }

    protected Haustier(string name)
    {
        Name = name;
        Energie = 50;
        Hunger = 50;
        Stimmung = 50;
        Gesundheit = 100;
    }

    public virtual void Fuettern()
    {
        Hunger -= 30;
        Energie += 10;
        UpdateStatus();
    }

    public virtual void Spaziergang()
    {
        Energie -= 20;
        Hunger += 20;
        Stimmung += 30;
        UpdateStatus();
    }

    public virtual void Schlafen()
    {
        Energie += 40;
        Hunger += 10;
        UpdateStatus();
    }

    protected virtual void UpdateStatus()
    {
        if (Hunger > 80) Gesundheit -= 5;
        if (Energie < 20) Gesundheit -= 5;
    }

    public abstract void ReagiereAufAktion();
}