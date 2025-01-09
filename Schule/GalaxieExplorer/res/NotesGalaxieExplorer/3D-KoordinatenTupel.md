Das Konzept der Tupel anhand eines greifbareren Beispiels erklärt - sagen wir, wir entwickeln ein 3D-Grafikprogramm für architektonische Entwürfe:

```csharp
public abstract class BauElement
{
    public string Name { get; protected set; }
    public double Gewicht { get; protected set; }
    public (double x, double y, double z) Position { get; protected set; }

    protected BauElement(string name, double gewicht, (double x, double y, double z) position)
    {
        Name = name;
        Gewicht = gewicht;
        Position = position;
    }
}

public class Moebel : BauElement
{
    public string Material { get; private set; }

    public Moebel(string name, double gewicht, (double x, double y, double z) position)
        : base(name, gewicht, position)
    {
        Material = "Holz";
    }
}

public class Zimmer : BauElement
{
    public List<Moebel> Moebelstuecke { get; private set; }

    public Zimmer(string name, double gewicht, (double x, double y, double z) position)
        : base(name, gewicht, position)
    {
        Moebelstuecke = new List<Moebel>();
        MoeblierZimmer();
    }

    private void MoeblierZimmer()
    {
        // Erstelle Möbel mit verschiedenen Positionen im Raum
        var tisch = new Moebel("Esstisch", 25.5, (2, 0, 3));     // Tisch in der Mitte
        var stuhl1 = new Moebel("Stuhl1", 5.0, (1.5, 0, 2.5));  // Stuhl am Tisch
        var stuhl2 = new Moebel("Stuhl2", 5.0, (2.5, 0, 2.5));  // Zweiter Stuhl
        var schrank = new Moebel("Schrank", 50.0, (0, 0, 5));    // Schrank an der Wand

        Moebelstuecke.Add(tisch);
        Moebelstuecke.Add(stuhl1);
        Moebelstuecke.Add(stuhl2);
        Moebelstuecke.Add(schrank);
    }

    public void VerschiebeMoebel(string moebelName, double neuesX, double neuesY, double neuesZ)
    {
        var moebel = Moebelstuecke.Find(m => m.Name == moebelName);
        if (moebel != null)
        {
            // Neue Position als Tupel zuweisen
            moebel.Position = (neuesX, neuesY, neuesZ);
            Console.WriteLine($"{moebelName} wurde verschoben nach Position: ({neuesX}, {neuesY}, {neuesZ})");
        }
    }

    public void ZeigeMoebelPositionen()
    {
        foreach (var moebel in Moebelstuecke)
        {
            Console.WriteLine($"{moebel.Name} befindet sich an Position: " +
                $"(x:{moebel.Position.x}, y:{moebel.Position.y}, z:{moebel.Position.z})");
        }
    }
}

// Verwendung:
var wohnzimmer = new Zimmer("Wohnzimmer", 0, (0, 0, 0));  // Zimmer am Ursprung
wohnzimmer.ZeigeMoebelPositionen();
wohnzimmer.VerschiebeMoebel("Esstisch", 3, 0, 3);  // Tisch verschieben
```

Hier sehen wir:

1. **Tupel als Koordinaten**:
   - `(double x, double y, double z)` definiert einen Tupel-Typ für 3D-Koordinaten
   - Jeder Wert im Tupel hat einen Namen (x, y, z) für bessere Lesbarkeit
   - Zugriff erfolgt über `Position.x`, `Position.y`, `Position.z`

2. **Dynamische Positionierung**:
   - Möbel können überall im Raum platziert werden
   - Positionen sind nicht statisch, sondern können zur Laufzeit geändert werden
   - Der Tupel macht es einfach, mit allen drei Koordinaten gleichzeitig zu arbeiten

3. **Vererbungshierarchie**:
   - `BauElement` ist die abstrakte Basisklasse (wie Himmelskoerper)
   - `Moebel` erbt von `BauElement` (wie Planet von Himmelskoerper)
   - `Zimmer` verwaltet eine Sammlung von Möbeln (wie Stern seine Planeten)

4. **Tupel-Zuweisung**:
```csharp
// Direkte Zuweisung beim Erstellen
var tisch = new Moebel("Esstisch", 25.5, (2, 0, 3));

// Neue Position zuweisen
moebel.Position = (neuesX, neuesY, neuesZ);
```

Dies ist vergleichbar mit deinem Weltraum-Beispiel, aber vielleicht etwas greifbarer, da wir uns Möbel in einem Raum besser vorstellen können als Sterne im Weltall. Das Prinzip ist aber das gleiche:
- Jedes Objekt hat eine Position im 3D-Raum
- Die Position kann sich ändern
- Wir können auf einzelne Koordinaten zugreifen
- Die Struktur wird vererbt