namespace A00_Fahrzeuge;

class Program
{
    static void Main(string[] args)
    {
        Car car = new Car("Violet", "VW");
        Motorcycle motorcycle = new Motorcycle("MontanaBlack", "Rot", "Lambo");
        Mountainbike mountainbike = new Mountainbike(2, "Rot", "Porsche");
        
        car.printInfo();
        motorcycle.printInfo();
        mountainbike.printInfo();
        
        car.Move();
        motorcycle.Move();
        mountainbike.Move();
    }
}