Ein Beispiel mit einer Schule, dies zeigt sehr gut die Verkettung von Objekten:

```csharp
public class Schule
{
    public string Name { get; private set; }
    public List<Klasse> Klassen { get; private set; }

    public Schule(string name)
    {
        Name = name;
        Klassen = new List<Klasse>();
        ErstelleStartKlassen();
    }

    private void ErstelleStartKlassen()
    {
        Klassen.Add(new Klasse("10A", "Herr Müller"));
        Klassen.Add(new Klasse("10B", "Frau Schmidt"));
    }

    public void ZeigeKlassenInfos()
    {
        Console.WriteLine($"\nKlassen der {Name}:");
        foreach (var klasse in Klassen)
        {
            // Hier kommt die Verkettung:
            // klasse.Name greift auf den Namen der Klasse zu
            // klasse.Schueler gibt die Schülerliste zurück
            // .Count zählt die Anzahl der Schüler
            Console.WriteLine($"- {klasse.Name} (Klassenlehrer: {klasse.Klassenlehrer})" + 
                            $" hat {klasse.Schueler.Count} Schüler");

            // Weitere Verkettung für Details:
            foreach (var schueler in klasse.Schueler)
            {
                // schueler.Name greift auf den Schülernamen zu
                // schueler.Noten ist das Dictionary
                // .Average() berechnet den Durchschnitt
                double notenschnitt = schueler.Noten.Values.Average();
                Console.WriteLine($"  * {schueler.Name} - Notenschnitt: {notenschnitt:F1}");
            }
        }
    }
}

public class Klasse
{
    public string Name { get; private set; }
    public string Klassenlehrer { get; private set; }
    public List<Schueler> Schueler { get; private set; }

    public Klasse(string name, string klassenlehrer)
    {
        Name = name;
        Klassenlehrer = klassenlehrer;
        Schueler = new List<Schueler>();
        FuegeStartSchuelerHinzu();
    }

    private void FuegeStartSchuelerHinzu()
    {
        Schueler.Add(new Schueler("Max Mustermann"));
        Schueler.Add(new Schueler("Lisa Mueller"));
    }
}

public class Schueler
{
    public string Name { get; private set; }
    public Dictionary<string, double> Noten { get; private set; }

    public Schueler(string name)
    {
        Name = name;
        Noten = new Dictionary<string, double>();
        ErstelleTestnoten();
    }

    private void ErstelleTestnoten()
    {
        Noten.Add("Mathe", 2.0);
        Noten.Add("Deutsch", 2.5);
        Noten.Add("Englisch", 1.5);
    }
}
```

Verwendung:
```csharp
var schule = new Schule("Gymnasium Musterstadt");
schule.ZeigeKlassenInfos();
```

Mögliche Ausgabe:
```
Klassen der Gymnasium Musterstadt:
- 10A (Klassenlehrer: Herr Müller) hat 2 Schüler
  * Max Mustermann - Notenschnitt: 2.0
  * Lisa Mueller - Notenschnitt: 2.0
- 10B (Klassenlehrer: Frau Schmidt) hat 2 Schüler
  * Max Mustermann - Notenschnitt: 2.0
  * Lisa Mueller - Notenschnitt: 2.0
```

Hier sehen wir verschiedene Arten der Verkettung:

1. `klasse.Schueler.Count`
   - `klasse` gibt uns das Klassenobjekt
   - `.Schueler` gibt uns die Liste der Schüler
   - `.Count` gibt uns die Anzahl der Elemente in der Liste

2. `schueler.Noten.Values.Average()`
   - `schueler` gibt uns das Schülerobjekt
   - `.Noten` gibt uns das Dictionary mit den Noten
   - `.Values` gibt uns eine Collection aller Notenwerte
   - `.Average()` berechnet den Durchschnitt dieser Werte

Diese Verkettungen ermöglichen es uns, tief in die verschachtelte Struktur zu navigieren:
- Schule → Klassen → Schüler → Noten

Dies ist vergleichbar mit deinem Weltraum-Beispiel:
- Galaxie → Sterne → Planeten → Ressourcen

Der Vorteil dieser Struktur ist, dass wir leicht auf alle Ebenen zugreifen können und die Daten sinnvoll organisiert sind.