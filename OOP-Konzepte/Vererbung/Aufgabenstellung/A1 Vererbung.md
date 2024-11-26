# Geometrische Formen: Shape, Circle und Rectangle

## Beschreibung

Die Klassen **Shape**, **Circle** und **Rectangle** demonstrieren grundlegende Prinzipien der **Vererbung**, **Konstruktorverkettung** und **Methodenüberschreibung** in der objektorientierten Programmierung. Ziel ist es, verschiedene geometrische Formen zu modellieren, die gemeinsame Funktionalitäten teilen, aber auch spezialisierte Implementierungen besitzen.

---

## Anforderungen

### **Basisklasse: Shape**
1. **Private Felder**
   - `color` (string): Die Farbe der Form.

2. **Eigenschaften (Properties)**
   - `Color`: Nur lesbar, gibt die Farbe der Form zurück.

3. **Virtuelle Methoden**
   - `GetArea()`: Gibt die Fläche der Form zurück (Standard: `0`).
   - `GetPerimeter()`: Gibt den Umfang der Form zurück (Standard: `0`).

4. **Konstruktor**
   - Der Konstruktor setzt die Farbe der Form.

---

### **Abgeleitete Klassen**

#### **Circle** (Kreis)
1. **Zusätzliche Felder**
   - `radius` (double): Der Radius des Kreises.

2. **Eigenschaften**
   - `Radius`: Nur lesbar, gibt den Radius des Kreises zurück.

3. **Konstruktor**
   - Initialisiert die Farbe und den Radius.
   - Ruft den Konstruktor der Basisklasse mit `base(color)` auf.

4. **Überschriebene Methoden**
   - `GetArea()`: Berechnet die Fläche: \(\pi \times r^2\).
   - `GetPerimeter()`: Berechnet den Umfang: \(2 \times \pi \times r\).

---

#### **Rectangle** (Rechteck)
1. **Zusätzliche Felder**
   - `width` (double): Die Breite des Rechtecks.
   - `height` (double): Die Höhe des Rechtecks.

2. **Eigenschaften**
   - `Width`: Nur lesbar, gibt die Breite des Rechtecks zurück.
   - `Height`: Nur lesbar, gibt die Höhe des Rechtecks zurück.

3. **Konstruktor**
   - Initialisiert die Farbe, Breite und Höhe.
   - Ruft den Konstruktor der Basisklasse mit `base(color)` auf.

4. **Überschriebene Methoden**
   - `GetArea()`: Berechnet die Fläche: \(Breite \times Höhe\).
   - `GetPerimeter()`: Berechnet den Umfang: \(2 \times (Breite + Höhe)\).

---

## Erwarteter Output beim Testen

```plaintext
Kreis (Rot):
- Radius: 5
- Fläche: 78.54 m²
- Umfang: 31.42 m

Rechteck (Blau):
- Breite: 4, Höhe: 6
- Fläche: 24.00 m²
- Umfang: 20.00 m
```

---

## Startvorlage

```csharp
public class Shape
{
    // TODO: Fügen Sie hier das private Feld für die Farbe hinzu

    // TODO: Fügen Sie hier die Eigenschaft Color hinzu

    // TODO: Implementieren Sie den Konstruktor

    // TODO: Implementieren Sie die virtuellen Methoden GetArea und GetPerimeter
}

public class Circle : Shape
{
    // TODO: Fügen Sie hier das private Feld für den Radius hinzu

    // TODO: Fügen Sie hier die Eigenschaft Radius hinzu

    // TODO: Implementieren Sie den Konstruktor mit base()

    // TODO: Überschreiben Sie die Methoden GetArea und GetPerimeter
}

public class Rectangle : Shape
{
    // TODO: Fügen Sie hier die privaten Felder für Breite und Höhe hinzu

    // TODO: Fügen Sie hier die Eigenschaften Width und Height hinzu

    // TODO: Implementieren Sie den Konstruktor mit base()

    // TODO: Überschreiben Sie die Methoden GetArea und GetPerimeter
}
```

---

## Lernziele

1. **Vererbung**:
   - Wiederverwendung gemeinsamer Funktionalitäten durch eine Basisklasse.
   - Spezialisierung spezifischer Funktionen in abgeleiteten Klassen.

2. **Konstruktorverkettung**:
   - Sicherstellen, dass die Basisklasse korrekt initialisiert wird, indem der Konstruktor der Basisklasse mit `base()` aufgerufen wird.

3. **Methodenüberschreibung**:
   - Bereitstellung spezifischer Implementierungen für jede Form durch `override` und Verwendung von `virtual` in der Basisklasse.

4. **Datenkapselung**:
   - Verwendung privater Felder und schreibgeschützter Eigenschaften.

---

## Erweiterungen

Nach erfolgreicher Implementierung können folgende Funktionen hinzugefügt werden:
- **Dreiecke hinzufügen**:
  - Eine neue Klasse `Triangle` mit Formeln für Fläche und Umfang.
- **3D-Formen**:
  - Klassen wie `Sphere` (Kugel) und `Cuboid` (Quader) für Volumen und Oberfläche.
- **Benutzeroberfläche**:
  - Visualisierung der Formen und ihrer Berechnungen in einer grafischen Anwendung.

---

## Fragen oder Feedback

Falls Sie Fragen oder Probleme bei der Implementierung haben, stehe ich gerne zur Verfügung! 😊

- **Autor:** [HolyG](https://github.com/heiligerg)  
- **E-Mail:** devholyg@gmail.com  

---

Viel Spaß bei der Umsetzung!
