# C# Namenskonventionen

## Großschreibungsregeln

| Bezeichner   | Notation    | Beispiel             |
|--------------|-------------|----------------------|
| Namespace    | PascalCase  | `System.Drawing`     |
| Klasse       | PascalCase  | `Customer`           |
| Schnittstelle| PascalCase  | `ITransfer`          |
| Methode      | PascalCase  | `TransferAccount`    |
| Eigenschaft  | PascalCase  | `TransferConfig`     |
| Feld         | camelCase   | `_transferConfig`    |
| Parameter    | camelCase   | `accountNumber`      |
| Konstante    | PascalCase  | `InfiniteThrottle`   |
| Enum-Typ     | PascalCase  | `BrowserType`        |
| Enum-Wert    | PascalCase  | `InternetExplorer`   |
| Ereignis     | PascalCase  | `TransferComplete`   |
| Ausnahmeklasse| PascalCase | `TransferException`  |

## Allgemeine Namenskonventionen

- **Lesbare Bezeichner verwenden:** Bevorzuge Lesbarkeit gegenüber Kürze.
- **Keine Unterstriche oder Bindestriche:** Verwende keine Unterstriche, Bindestriche oder ungarische Notation.
- **Aussagekräftige generische Namen:** Nutze semantisch interessante generische Namen, z. B. `GetAmountDue` statt `GetDecimalValue`.
- **Vermeide Abkürzungen:** Verwende keine Abkürzungen, es sei denn, sie sind allgemein anerkannt und notwendig.

## Namenskonventionen für spezifische Elemente

- **Namespaces:** Wähle Namen, die die Funktionalität widerspiegeln, z. B. `Company.Product.Feature`.
- **Klassen, Strukturen und Schnittstellen:** Verwende PascalCase für Nomen oder Nominalphrasen, z. B. `Customer`, `Invoice`. Schnittstellen sollten mit einem `I` beginnen, z. B. `ITransfer`.
- **Methoden:** Verwende PascalCase für Verbphrasen, die die Aktion beschreiben, z. B. `CalculateTotal`.
- **Eigenschaften:** Verwende PascalCase für Nomen oder Adjektivphrasen, z. B. `BackgroundColor`.
- **Felder:** Verwende camelCase mit führendem Unterstrich für private Felder, z. B. `_totalCount`.
- **Parameter und lokale Variablen:** Verwende camelCase, z. B. `firstName`, `orderDate`.
- **Konstanten:** Verwende PascalCase für konstante Werte, z. B. `MaxValue`.
- **Enumerationen:** Verwende PascalCase für Enum-Typen und -Werte. Für Flags-Enums nutze Pluralformen, z. B. `FileAccessModes` mit Werten wie `Read`, `Write`.
- **Ereignisse:** Verwende PascalCase für Ereignisse, z. B. `DataReceived`.
- **Ausnahme-Klassen:** Verwende PascalCase und füge das Suffix `Exception` hinzu, z. B. `FileNotFoundException`.

## Ressourcen

- [C# Namenskonventionen Cheat Sheet von Greg Finzer](https://cheatography.com/gregfinzer/cheat-sheets/c-naming-conventions/pdf/)
- [C# Coding Standards and Naming Conventions von Konstantin Taranov](https://github.com/ktaranov/naming-convention/blob/master/C%23%20Coding%20Standards%20and%20Naming%20Conventions.md)
- [Microsoft .NET Coding Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)