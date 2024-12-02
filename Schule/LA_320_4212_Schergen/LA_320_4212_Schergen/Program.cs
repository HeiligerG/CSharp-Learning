namespace LA_320_4212_Schergen
{
    public class Program
    {
        static void Main(string[] args)
        {
            Boesewicht blofeld = new Boesewicht("Blofeld");
            Geheimagent bond = new Geheimagent("James Bond");
            blofeld.Erzfeind = bond;
            blofeld.AddScherge(new Schlaeger("Beisser"));
            blofeld.AddScherge(new Killer("Xenia"));
            blofeld.AddScherge(new Hacker("Boris"));
            blofeld.HetzeSchergenAufErzfeind();
        }
    }
}