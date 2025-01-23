# Virtuelles Haustier WPF-Anwendung

## Beschreibung
Eine einfache WPF-Anwendung zur Simulation eines virtuellen Haustiers. Das Haustier hat verschiedene Statuswerte (Energie, Hunger, Stimmung, Gesundheit) und kann durch Benutzerinteraktionen beeinflusst werden.

## Bekannte Einschränkungen
- Gesundheit kann auf 0 fallen, hat aber keine Auswirkungen
- Kein Haustierwechsel implementiert
- Vererbungsstruktur vorhanden, aber nicht vollständig genutzt

## Funktionen
- Füttern: Reduziert Hunger, erhöht Energie
- Schlafen: Erhöht Energie, steigert Hunger leicht
- Spaziergang: Verbraucht Energie, steigert Stimmung

## Technische Details
- WPF-Anwendung
- Implementiert Interface-basierte Architektur
- Abstrakte Basisklasse mit zwei spezialisierten Klassen (nur eine aktiv)

## Geplante Erweiterungen (nicht implementiert)
- Haustierwechsel
- Konsequenzen bei Gesundheit 0
- Vollständige Nutzung der Vererbungshierarchie

## Setup
1. Repository klonen
2. In Visual Studio öffnen
3. Build und Run

## Projektstruktur
```
VirtualPet/
├── Img/
│   └── bello.jpg
├── Interface/
│   └── IHaustierAktionen.cs
├── Models/
│   ├── Haustier.cs
│   ├── Hund.cs
│   └── Katze.cs
├── UI/
│   ├── MainWindow.xaml
│   └── MainWindow.xaml.cs
└── README.md
```