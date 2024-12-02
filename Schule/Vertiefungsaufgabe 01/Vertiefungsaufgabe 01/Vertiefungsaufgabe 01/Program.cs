namespace Vertiefungsaufgabe_01;

class Program
{
    static void Main(string[] args)
    {
        Zylinder z1 = new Zylinder();
        z1.setDurchmesser(10.5);
        z1.setHoehe(20.5);
        double v1 = z1.getVolumen();
        double a1= z1.getGrundflaeche() ;
        double m1 = z1.getMantelflaeche();
        double o1 = z1.getOberflaeche();
        Console.WriteLine(“Zylinder 01 : Volumen=" + v1.toString() + "Oberflaeche=" + o1.toString());
        
        //---------------------------------------------
        
        Zylinder z2 = new Zylinder(30.0, 15.5);   //Param1 = Durchmesser, Param2 = Höhe
        double o2 = z2.getOberflaeche();
        Console.WriteLine(“Zylinder 02: Volumen=” + v2.toString() + “Oberflaeche=” + o2.toString() );
        
        //---------------------------------------------
        
        double o3 = Zylinder.getOberflaeche(50.5, 20.0);   //Param1 = Durchmesser, Param2 = Höhe
        Console.WriteLine(“Zylinder 03: Oberflaeche=” o3.toString() )
            
        //---------------------------------------------
        
        Console.ReadLine();
    }
    }
}