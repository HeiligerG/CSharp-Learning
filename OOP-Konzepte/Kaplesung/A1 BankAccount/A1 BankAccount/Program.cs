namespace A1_BankAccount;

class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount("DE123456789", "Max Mustermann");
        
        Console.WriteLine("Neues Konto:");
        Console.WriteLine($"Besitzer: {account.Owner}");
        Console.WriteLine($"Kontonummer: {account.AccountNumber}");
        Console.WriteLine($"Kontostand: {account.Balance} EUR\n");
        
        account.Deposit(100);
        Console.WriteLine($"Nach Einzahlung von 100 EUR:");
        Console.WriteLine($"Kontostand: {account.Balance} EUR\n");

        if (account.Withdraw(30))
        {
            Console.WriteLine($"Nach Auszahlung von 30 EUR:");
            Console.WriteLine($"Kontostand: {account.Balance} EUR\n");
        }

        Console.WriteLine("Versuch 80 EUR abzuheben:");
        if (!account.Withdraw(80))
        {
            Console.WriteLine("Fehler: Nicht genügend Guthaben!");
            Console.WriteLine($"Kontostand: {account.Balance} EUR");
        }
    }
}