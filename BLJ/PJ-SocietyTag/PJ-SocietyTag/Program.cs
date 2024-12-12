namespace PJ_SocietyTag
{
    class Program
    {
        static void DrawLine(char left, char mid, char right, int width)
        {
            Console.Write(left);
            Console.Write(new string(mid, width - 2));
            Console.WriteLine(right);
        }

        static void DrawFrame(string content, int width)
        {
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            DrawLine('╔', '═', '╗', width);
            Console.Write("║");
            int padding = (width - 2 - content.Length) / 2;
            Console.Write(new string(' ', padding));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(content);
            Console.ResetColor();
            Console.Write(new string(' ', width - 2 - padding - content.Length));
            Console.WriteLine("║");
            DrawLine('╚', '═', '╝', width);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Gesellschaftssimulation startet...");

            World world = new World(1000);
            const int width = 80;

            while (true)
            {
                world.SimulateDay();

                Console.Clear();
                Console.OutputEncoding = System.Text.Encoding.UTF8;

                // Anzeige mit dynamischem Titel basierend auf Simulation
                DrawFrame($"Datum: {world.CurrentDate:dd.MM.yyyy}", width);

                // Hauptinformationen
                DrawLine('╔', '═', '╗', width);
                Console.Write("║ ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Bevölkerung: ");
                Console.ResetColor();
                Console.Write($"{world.Population.Count:N0}".PadRight(28));
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Inflation: ");
                Console.ResetColor();
                Console.Write($"{world.Economy.Inflation:P2}".PadRight(28));
                Console.WriteLine("");

                Console.Write("║ ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Markttrend: ");
                Console.ResetColor();
                Console.Write($"{world.Economy.MarketTrend:F2}".PadRight(25));
                Console.WriteLine("");
                DrawLine('╚', '═', '╝', width);

                // Klassenverteilung
                DrawLine('╔', '═', '╗', width);
                Console.Write("║ ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Klassenverteilung:".PadRight(width - 3) + "");
                Console.ResetColor();

                int richCount = world.Population.Count(p => p.SocialClass == SocialClass.RICH);
                int middleCount = world.Population.Count(p => p.SocialClass == SocialClass.MIDDLE_CLASS);
                int poorCount = world.Population.Count(p => p.SocialClass == SocialClass.POOR);

                Console.Write("║ ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Oberschicht: ");
                Console.ResetColor();
                Console.Write($"{richCount,6:N0} ({(double)richCount / world.Population.Count:P1})".PadRight(28));
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Mittelschicht: ");
                Console.ResetColor();
                Console.WriteLine($"{middleCount,6:N0} ({(double)middleCount / world.Population.Count:P1})".PadRight(25) + "");

                Console.Write("║ ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Unterschicht: ");
                Console.ResetColor();
                Console.WriteLine($"{poorCount,6:N0} ({(double)poorCount / world.Population.Count:P1})".PadRight(width - 14) + "");
                DrawLine('╚', '═', '╝', width);

                // Tagesstatistiken
                DrawLine('╔', '═', '╗', width);
                Console.Write("║ ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Tagesstatistiken:".PadRight(width - 3) + "");
                Console.ResetColor();

                Console.Write("║ ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Geburten: ");
                Console.ResetColor();
                Console.Write($"{world.DailyStats.Births,6}".PadRight(28));
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Todesfälle: ");
                Console.ResetColor();
                Console.WriteLine($"{world.DailyStats.Deaths,6}".PadRight(31) + "");

                Console.Write("║ ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("↑ Mittelschicht: ");
                Console.ResetColor();
                Console.Write($"{world.DailyStats.UpgradesToMiddle,6}".PadRight(23));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("↓ Unterschicht: ");
                Console.ResetColor();
                Console.WriteLine($"{world.DailyStats.DowngradesToPoor,6}".PadRight(26) + "");

                Console.Write("║ ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("↑ Oberschicht: ");
                Console.ResetColor();
                Console.Write($"{world.DailyStats.UpgradesToRich,6}".PadRight(25));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("↓ Mittelschicht: ");
                Console.ResetColor();
                Console.WriteLine($"{world.DailyStats.DowngradesToMiddle,6}".PadRight(25) + "");
                DrawLine('╚', '═', '╝', width);

                // Katastrophen-Anzeige
                if (world.ActiveDisasters.Any())
                {
                    DrawLine('╔', '═', '╗', width);
                    Console.Write("║ ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("! AKTIVE KATASTROPHEN !".PadRight(width - 3) + "");
                    Console.ResetColor();

                    foreach (var disaster in world.ActiveDisasters)
                    {
                        Console.Write("║ ");
                        Console.Write($"{disaster.Type} - ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"Schwere: {disaster.Severity:F2}");
                        Console.ResetColor();
                        Console.WriteLine($" - Noch {disaster.RemainingDuration} Tage".PadRight(width - 30) + "");
                    }
                    DrawLine('╚', '═', '╝', width);
                }

                // Hilfetext
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Drücken Sie [ESC] zum Beenden oder eine andere Taste zum Pausieren");
                Console.ResetColor();

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Escape) break;
                }

                Thread.Sleep(100); // Kleine Verzögerung für bessere Lesbarkeit
            }
        }
    }
}