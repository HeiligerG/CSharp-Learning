using System;
using System.Threading;

class Spielsteuerung
{
    private Spieler _aktuellerSpieler;

    public void ZeigeHauptmenu()
    {
        Console.WriteLine("Willkommen im Weltraum-Spiel!");
        ErstelleNeuerSpieler();
        
        while (true)
        {
            Console.WriteLine("\nHauptmenü:");
            Console.WriteLine("1. Zeige Inventar");
            Console.WriteLine("2. Zeige Status");
            Console.WriteLine("3. Zeige Hilfe");
            Console.WriteLine("4. Galaxie erkunden");
            Console.WriteLine("5. Raumschiff-Management");
            Console.WriteLine("6. Handel");
            Console.WriteLine("7. Beenden");
            
            var eingabe = Console.ReadLine();
            
            switch (eingabe)
            {
                case "1":
                    ZeigeInventar();
                    break;
                case "2":
                    ZeigeStatus();
                    break;
                case "3":
                    ZeigeHilfe();
                    break;
                case "4":
                    GalaxieErkunden();
                    break;
                case "5":
                    RaumschiffManagement();
                    break;
                case "6":
                    Handel();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Ungültige Eingabe!");
                    break;
            }
        }
    }

    private void ErstelleNeuerSpieler()
    {
        Console.WriteLine("Wie lautet dein Name?");
        var name = Console.ReadLine();
        _aktuellerSpieler = new Spieler(name);
    }

    private void GalaxieErkunden()
    {
        while (true)
        {
            Console.WriteLine("\nGalaxie-Erkundung:");
            Console.WriteLine("1. Zeige verfügbare Galaxien");
            Console.WriteLine("2. Reise zu Stern");
            Console.WriteLine("3. Planet scannen");
            Console.WriteLine("4. Zurück zum Hauptmenü");

            var eingabe = Console.ReadLine();

            switch (eingabe)
            {
                case "1":
                    _aktuellerSpieler.ZeigeVerfuegbareGalaxien();
                    break;
                case "2":
                    ReiseZuStern();
                    break;
                case "3":
                    PlanetScannen();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Ungültige Eingabe!");
                    break;
            }
        }
    }

    private void RaumschiffManagement()
    {
        while (true)
        {
            Console.WriteLine("\nRaumschiff-Management:");
            Console.WriteLine("1. Raumschiff reparieren");
            Console.WriteLine("2. Treibstoff auffüllen");
            Console.WriteLine("3. Raumschiff aufrüsten");
            Console.WriteLine("4. Zurück zum Hauptmenü");

            var eingabe = Console.ReadLine();

            switch (eingabe)
            {
                case "1":
                    _aktuellerSpieler.ReparierSchiff();
                    break;
                case "2":
                    _aktuellerSpieler.FuelleTreibstoffAuf();
                    break;
                case "3":
                    _aktuellerSpieler.RuesteSchiffAuf();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Ungültige Eingabe!");
                    break;
            }
        }
    }

    private void Handel()
    {
        while (true)
        {
            Console.WriteLine("\nHandel:");
            Console.WriteLine("1. Ressourcen kaufen");
            Console.WriteLine("2. Ressourcen verkaufen");
            Console.WriteLine("3. Zurück zum Hauptmenü");

            var eingabe = Console.ReadLine();

            switch (eingabe)
            {
                case "1":
                    _aktuellerSpieler.KaufeRessourcen();
                    break;
                case "2":
                    _aktuellerSpieler.VerkaufeRessourcen();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Ungültige Eingabe!");
                    break;
            }
        }
    }

    private void ReiseZuStern()
    {
        var sterne = _aktuellerSpieler.HoleVerfuegbareSterne();
        if (sterne.Count == 0)
        {
            Console.WriteLine("Keine Sterne verfügbar!");
            return;
        }

        Console.WriteLine("\nVerfügbare Sterne:");
        for (int i = 0; i < sterne.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {sterne[i].Name}");
        }

        Console.WriteLine("Wähle einen Stern (Nummer):");
        if (int.TryParse(Console.ReadLine(), out int auswahl) && auswahl > 0 && auswahl <= sterne.Count)
        {
            _aktuellerSpieler.ReiseZuStern(sterne[auswahl - 1]);
        }
        else
        {
            Console.WriteLine("Ungültige Auswahl!");
        }
    }

    private void PlanetScannen()
    {
        var planeten = _aktuellerSpieler.HoleVerfuegbarePlaneten();
        if (planeten.Count == 0)
        {
            Console.WriteLine("Keine Planeten verfügbar!");
            return;
        }

        Console.WriteLine("\nVerfügbare Planeten:");
        for (int i = 0; i < planeten.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {planeten[i].Name}");
        }

        Console.WriteLine("Wähle einen Planeten (Nummer):");
        if (int.TryParse(Console.ReadLine(), out int auswahl) && auswahl > 0 && auswahl <= planeten.Count)
        {
            _aktuellerSpieler.ScannePlanet(planeten[auswahl - 1]);
        }
        else
        {
            Console.WriteLine("Ungültige Auswahl!");
        }
    }

    public void ZeigeInventar() => _aktuellerSpieler.ZeigeInventar();
    public void ZeigeStatus() => _aktuellerSpieler.ZeigeStatus();
    public void ZeigeHilfe() => _aktuellerSpieler.ZeigeHilfe();
}