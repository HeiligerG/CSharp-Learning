using System.ComponentModel.Design;
using System.Security.Principal;

namespace A1_BankAccount;

public class BankAccount
{
    private string accountNumber;
    private decimal balance;
    private string owner;

    //  public string AccountNumber => accountNumber;:
    //  Was passiert hier?

    //  Das ist eine "Expression-bodied Property", die nur eine schreibgeschützte Lese-Zugriffsmethode bereitstellt.
    //  Der Zugriff auf accountNumber erfolgt über einen Getter, aber das zugrunde liegende Feld ist weiterhin privat.
    //  Diese Schreibweise bietet eine Kurzform für get { return accountNumber; }.
    
    public string AccountNumber => accountNumber;
    public decimal Balance => balance;
    public string Owner => owner;

    public BankAccount(string accountNumber, string owner)
    {
        this.accountNumber = accountNumber;
        this.owner = owner;
        this.balance = 0m;
        
        // 'm' kennzeichnet einen decimal-Wert
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Der eingezahlte Betrag muss grösser als 0 sein!");
        }
        balance += amount;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Der abgebuchte Betrag muss grösser als 0 sein!");
        }

        if (balance > amount)
        {
            balance -= amount;
            return true;
        }

        return false;
    }
}

//Empfehlung:
//Wenn du eine Eigenschaft außerhalb der Klasse zugänglich machen möchtest, solltest du immer eine public-Eigenschaft definieren, die ein privates Feld kapselt, wie in Beispiel 2 (public string AccountNumber => accountNumber;).
//Nutze { get; } nur, wenn du die Eigenschaft innerhalb der Klasse verwendest oder sie wirklich intern bleiben soll.