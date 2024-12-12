Iteration über die Bevölkerung:

foreach (var person in Population.ToList())
{
    var oldClass = person.SocialClass;
    person.Update();

    if (!person.IsAlive)
    {
        DailyStats.Deaths++;
    }

    if (person.SocialClass != oldClass)
    {
        DailyStats.AddClassChange(oldClass, person.SocialClass);
    }
}

    Was passiert?
        Population.ToList(): Erstellt eine Kopie der Liste, um Änderungen an der Population während der Iteration zu vermeiden (z. B. Entfernen verstorbener Personen).
        person.Update(): Aktualisiert den Zustand einer Person, z. B.:
            Gesundheit.
            Einkommen.
            Soziale Klasse.
            Lebensstatus (ob die Person noch lebt).
        if (!person.IsAlive): Überprüft, ob die Person gestorben ist, und erhöht entsprechend den Todeszähler (DailyStats.Deaths).
        if (person.SocialClass != oldClass): Überprüft, ob die soziale Klasse der Person sich verändert hat, und speichert diese Änderung in den täglichen Statistiken.

    Warum?
    Diese Iteration ermöglicht die Aktualisierung der gesamten Bevölkerung und das Sammeln von Statistiken über die täglichen Veränderungen.