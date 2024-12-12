Population.RemoveAll(p => !p.IsAlive);

    Was passiert?
    Verstorbene Personen werden aus der Population-Liste entfernt.

    Warum?
    Personen, die gestorben sind, sollen nicht länger Teil der Simulation sein. Das Entfernen dieser Personen hält die Population-Liste aktuell und reduziert den Speicherverbrauch.