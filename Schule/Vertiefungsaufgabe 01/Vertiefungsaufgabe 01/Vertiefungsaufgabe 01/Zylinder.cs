namespace Vertiefungsaufgabe_01;

public class Zylinder
{
    private double Durchmesser;
    private double Hoehe;
    
    public Zylinder(double durchmesser, double hoehe)
    {
        this.Durchmesser = durchmesser;
        this.Hoehe = hoehe;
    }

    public void setDurchmesser()
    {
        this.Durchmesser = durchmesser;
    }
    public void setHoehe() {}

    public double getVolumen()
    {
        return (Math.PI * Durchmesser) * Hoehe;
    }

    public double getGrundflaeche()
    {
        return Durchmesser * Math.PI;
    }

    public double getMantelflaeche()
    {
        return Durchmesser * Hoehe;
    }

    public double getOberflaeche()
    {
        return (Durchmesser * Math.PI) + (Hoehe * ((Durchmesser / 2) * Math.PI * 2));
    }
}