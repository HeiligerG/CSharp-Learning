# BankAccount Klasse

## Beschreibung

Die Klasse **BankAccount** dient dazu, grundlegende Bankkontofunktionen zu simulieren. Diese Übung konzentriert sich auf die Prinzipien der **Kapselung** in der objektorientierten Programmierung, indem private Felder, schreibgeschützte Properties und Validierungslogik verwendet werden.

---

## Anforderungen

### **Private Felder**
1. `accountNumber` (string): Die Kontonummer des Bankkontos.
2. `balance` (decimal): Der aktuelle Kontostand des Bankkontos.
3. `owner` (string): Der Besitzer des Bankkontos.

### **Eigenschaften (Properties)**
1. `AccountNumber`: Nur lesbar, gibt die Kontonummer zurück.
2. `Balance`: Nur lesbar, gibt den aktuellen Kontostand zurück.
3. `Owner`: Nur lesbar, gibt den Besitzer des Kontos zurück.

### **Methoden**
1. `Deposit(decimal amount)`: Ermöglicht das Einzahlen von Geld auf das Konto. 
   - **Bedingung**: Der Betrag muss größer als 0 sein.
2. `Withdraw(decimal amount)`: Ermöglicht das Abheben von Geld vom Konto.
   - **Bedingung**: Es darf nur abgehoben werden, wenn genügend Guthaben vorhanden ist. Andernfalls wird eine Fehlermeldung ausgegeben.

### **Konstruktor**
- Der Konstruktor setzt die Kontonummer (`accountNumber`) und den Besitzer (`owner`).
- Der Kontostand (`balance`) wird beim Erstellen automatisch auf `0` gesetzt.

---

## Erwarteter Output beim Testen

```plaintext
Neues Konto:
Besitzer: Max Mustermann
Kontonummer: DE123456789
Kontostand: 0 EUR

Nach Einzahlung von 100 EUR:
Kontostand: 100 EUR

Nach Abhebung von 30 EUR:
Kontostand: 70 EUR

Versuch 80 EUR abzuheben:
Fehler: Nicht genügend Guthaben!
Kontostand: 70 EUR
```

---

## Startvorlage

```csharp
public class BankAccount
{
    // TODO: Fügen Sie hier die privaten Felder hinzu

    // TODO: Fügen Sie hier die Properties hinzu

    // TODO: Implementieren Sie den Konstruktor

    // TODO: Implementieren Sie die Deposit Methode

    // TODO: Implementieren Sie die Withdraw Methode
}
```

---

## Lernziele

1. **Datenkapselung**:
   - Schützen Sie die Daten durch private Felder.
   - Bieten Sie kontrollierte Zugriffe über schreibgeschützte Properties.

2. **Validierung**:
   - Stellen Sie sicher, dass Operationen wie das Abheben nur unter bestimmten Bedingungen ausgeführt werden können.

3. **Datenintegrität**:
   - Verhindern Sie ungültige Operationen wie negative Beträge oder Abhebungen ohne ausreichendes Guthaben.

4. **Wartbarkeit**:
   - Trennen Sie Implementierungsdetails und öffentliche Schnittstellen, um den Code flexibel und verständlich zu halten.

---

## Erweiterungen

Nach erfolgreicher Implementierung können folgende Funktionen hinzugefügt werden:
- Historie der Transaktionen (Einzahlungen, Abhebungen).
- Überweisungen zwischen Konten.
- Zinssätze und automatische Zinsberechnungen.

---

## Fragen oder Feedback

Falls Sie Fragen oder Probleme bei der Implementierung haben, stehe ich gerne zur Verfügung! 😊

- **Autor:** [HolyG](https://github.com/heiligerg)
- **E-Mail:** devholyg@gmail.com 


--- 

Viel Spaß bei der Umsetzung!
