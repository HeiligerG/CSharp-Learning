using System.Security.Cryptography.X509Certificates;

namespace GalaxieExplorer;

class Program
{
    static void Main(string[] args)
    {
        bool beenden = false;

        while (!beenden)
        {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("         GALAXIEN-EXPLORER         ");
            Console.WriteLine("===================================");
            Console.WriteLine("1. Galaxie erkunden");
            Console.WriteLine("2. Planeten scannen");
            Console.WriteLine("3. Ressourcen verwalten");
            Console.WriteLine("4. Raumschiff upgraden");
            Console.WriteLine("5. Spiel beenden");
            Console.WriteLine("===================================");
            Console.Write("Wählen Sie eine Option (1-5): ");

            string eingabe = Console.ReadLine()?.Trim();

            switch (eingabe)
            {
                case "1":
                    GalaxieErkunden();
                    break;
                case "2":
                    PlanetenScannen();
                    break;
                case "3":
                    RessourcenVerwalten();
                    break;
                case "4":
                    RaumschiffUpgraden();
                    break;
                case "5":
                    Console.WriteLine("Das Spiel wird beendet. Auf Wiedersehen!");
                    beenden = true;
                    break;
                default:
                    Console.WriteLine("Ungültige Auswahl. Bitte wählen Sie eine Option von 1 bis 5.");
                    Console.ReadKey(); // Warten auf Benutzereingabe
                    break;
            }
        }
    }