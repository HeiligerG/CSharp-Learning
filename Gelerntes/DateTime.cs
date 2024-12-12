In C# kann der DateTime-Typ nicht direkt inkrementiert werden (z. B. mit ++), da er ein Immutable Struct ist, das bedeutet, dass er unveränderlich ist. Wenn Sie einen Tag hinzufügen möchten, können Sie stattdessen die Methode AddDays verwenden, um eine neue DateTime-Instanz zu erhalten.
Beispiel für das Hinzufügen eines Tages

using System;

class Program
{
    static void Main(string[] args)
    {
        DateTime currentDate = DateTime.Now; // Aktuelles Datum und Uhrzeit
        Console.WriteLine("Aktuelles Datum: " + currentDate);

        // Einen Tag hinzufügen
        currentDate = currentDate.AddDays(1);
        Console.WriteLine("Nächstes Datum: " + currentDate);
    }
}

Wichtige Punkte:

    AddDays(double value) gibt ein neues DateTime-Objekt zurück, das die angegebene Anzahl von Tagen zur aktuellen Instanz hinzufügt.
    Die Originalinstanz von DateTime wird nicht verändert, da sie unveränderlich ist.

Anwendung in einer Eigenschaft

Falls Sie dies als Teil einer Eigenschaft mit einem Inkrement realisieren möchten, könnten Sie eine Methode verwenden:

using System;

class DateHandler
{
    public DateTime CurrentDate { get; private set; }

    public DateHandler(DateTime startDate)
    {
        CurrentDate = startDate;
    }

    public void IncrementDay()
    {
        CurrentDate = CurrentDate.AddDays(1);
    }
}

class Program
{
    static void Main(string[] args)
    {
        DateHandler handler = new DateHandler(DateTime.Now);
        Console.WriteLine("Startdatum: " + handler.CurrentDate);

        // Einen Tag inkrementieren
        handler.IncrementDay();
        Console.WriteLine("Nach einem Tag: " + handler.CurrentDate);
    }
}

Erklärung:

    IncrementDay-Methode:
        Diese Methode fügt der CurrentDate-Eigenschaft einen Tag hinzu, indem sie AddDays(1) verwendet.

    DateTime bleibt unverändert:
        Statt ++ zu verwenden, erzeugen wir eine neue Instanz von DateTime.

    Flexibilität:
        Sie können die Anzahl der Tage flexibel übergeben, z. B. AddDays(7) für eine Woche.

Ergebnis:

Sie erhalten ein inkrementierbares DateTime, aber unter Beachtung der unveränderlichen Natur des Typs.