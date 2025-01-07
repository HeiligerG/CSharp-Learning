using System;
using System.Collections.Generic;

public class Spieler
{
    private Raumschiff _schiff;
    private List<Galaxie> _entdeckteGalaxien;
    private Dictionary<string, int> _ressourcen;
    private int _kredite;
    private Stern _aktuellerStern;
    
    public int Kredite => _kredite;

    public Spieler(string name)
    {
        _schiff = new Erkundungsschiff(name + "s Schiff", 100, 5);
        _entdeckteGalaxien = new List<Galaxie>();
        _entdeckteGalaxien.Add(new Galaxie("Milchstraße"));
        _ressourcen = new Dictionary<string, int>();
        _kredite = 1000;
    }

    public void ZeigeVerfuegbareGalaxien()
    {
        Console.WriteLine("\nVerfügbare Galaxien:");
        foreach (var galaxie in _entdeckteGalaxien)
        {
            Console.WriteLine($"- {galaxie.Name} ({galaxie.Sterne.Count} Sterne)");
        }
    }

    public List<Stern> HoleVerfuegbareSterne()
    {
        var sterne = new List<Stern>();
        foreach (var galaxie in _entdeckteGalaxien)
        {
            sterne.AddRange(galaxie.Sterne);
        }
        return sterne;
    }

    public List<Planet> HoleVerfuegbarePlaneten()
    {
        if (_aktuellerStern == null) return new List<Planet>();
        return _aktuellerStern.Planeten;
    }

    public void ReiseZuStern(Stern stern)
    {
        if (_schiff.Treibstoff < 10)
        {
            Console.WriteLine("Nicht genug Treibstoff!");
            return;
        }

        Console.WriteLine($"Reise zu Stern {stern.Name} begonnen...");
        Thread.Sleep(1000);
        _schiff.Treibstoff -= 10;
        _aktuellerStern = stern;
        Console.WriteLine("Ziel erreicht!");
    }

    public void ScannePlanet(Planet planet)
    {
        if (_schiff is Erkundungsschiff erkundungsschiff)
        {
            erkundungsschiff.Scannen(planet);
            Console.WriteLine("Gefundene Ressourcen:");
            foreach (var ressource in planet.Ressourcen)
            {
                Console.WriteLine($"- {ressource.Key}: {ressource.Value}");
            }
        }
        else
        {
            Console.WriteLine("Dein Schiff kann keine Planeten scannen!");
        }
    }

    public void ReparierSchiff()
    {
        int kosten = 100;
        if (_kredite >= kosten)
        {
            _kredite -= kosten;
            _schiff.Reparieren();
            Console.WriteLine($"Schiff repariert. Verbleibende Kredite: {_kredite}");
        }
        else
        {
            Console.WriteLine("Nicht genug Kredite!");
        }
    }

    public void FuelleTreibstoffAuf()
    {
        int kosten = 50;
        if (_kredite >= kosten)
        {
            _kredite -= kosten;
            _schiff.Treibstoff = 100;
            Console.WriteLine($"Treibstoff aufgefüllt. Verbleibende Kredite: {_kredite}");
        }
        else
        {
            Console.WriteLine("Nicht genug Kredite!");
        }
    }

    public void RuesteSchiffAuf()
    {
        int kosten = 200;
        if (_kredite >= kosten)
        {
            _kredite -= kosten;
            _schiff.Kapazitaet += 2;
            Console.WriteLine($"Schiff aufgerüstet. Neue Kapazität: {_schiff.Kapazitaet}");
        }
        else
        {
            Console.WriteLine("Nicht genug Kredite!");
        }
    }

    public void KaufeRessourcen()
    {
        Console.WriteLine("\nVerfügbare Ressourcen:");
        Console.WriteLine("1. Eisen (50 Kredite)");
        Console.WriteLine("2. Kristalle (100 Kredite)");
        Console.WriteLine("3. Zurück");

        var eingabe = Console.ReadLine();
        switch (eingabe)
        {
            case "1":
                KaufeRessource("Eisen", 50);
                break;
            case "2":
                KaufeRessource("Kristalle", 100);
                break;
        }
    }

    private void KaufeRessource(string name, int preis)
    {
        if (_kredite >= preis)
        {
            _kredite -= preis;
            if (!_ressourcen.ContainsKey(name))
                _ressourcen[name] = 0;
            _ressourcen[name]++;
            Console.WriteLine($"{name} gekauft. Verbleibende Kredite: {_kredite}");
        }
        else
        {
            Console.WriteLine("Nicht genug Kredite!");
        }
    }

    public void VerkaufeRessourcen()
    {
        Console.WriteLine("\nDeine Ressourcen:");
        foreach (var ressource in _ressourcen)
        {
            Console.WriteLine($"- {ressource.Key}: {ressource.Value}");
        }

        Console.WriteLine("\nWas möchtest du verkaufen?");
        var ressourceName = Console.ReadLine();

        if (_ressourcen.ContainsKey(ressourceName) && _ressourcen[ressourceName] > 0)
        {
            _ressourcen[ressourceName]--;
            _kredite += ressourceName == "Eisen" ? 40 : 80;
            Console.WriteLine($"Ressource verkauft. Neue Kredite: {_kredite}");
        }
        else
        {
            Console.WriteLine("Ressource nicht verfügbar!");
        }
    }

    public void ZeigeInventar()
    {
        Console.WriteLine("\nDein Raumschiff:");
        Console.WriteLine($"Name: {_schiff.Name}");
        Console.WriteLine($"Treibstoff: {_schiff.Treibstoff}");
        Console.WriteLine($"Kapazität: {_schiff.Kapazitaet}");
        Console.WriteLine($"Zustand: {_schiff.Zustand}%");
        Console.WriteLine("\nRessourcen:");
        foreach (var ressource in _ressourcen)
        {
            Console.WriteLine($"- {ressource.Key}: {ressource.Value}");
        }
        Console.WriteLine($"\nKredite: {_kredite}");
    }

    public void ZeigeStatus()
    {
        Console.WriteLine("\nStatus:");
        Console.WriteLine($"Aktuelle Position: {(_aktuellerStern?.Name ?? "Im Orbit")}");
        Console.WriteLine("\nEntdeckte Galaxien:");
        foreach (var galaxie in _entdeckteGalaxien)
        {
            Console.WriteLine($"- {galaxie.Name}");
        }
    }

    public void ZeigeHilfe()
    {
        Console.WriteLine("\nSpielanleitung:");
        Console.WriteLine("1. Erkunde Galaxien um neue Sterne und Planeten zu entdecken");
        Console.WriteLine("2. Scanne Planeten nach wertvollen Ressourcen");
        Console.WriteLine("3. Handle mit Ressourcen um Kredite zu verdienen");
        Console.WriteLine("4. Nutze Kredite um dein Schiff zu verbessern");
        Console.WriteLine("5. Achte auf deinen Treibstoff und Schiffszustand!");
    }
}