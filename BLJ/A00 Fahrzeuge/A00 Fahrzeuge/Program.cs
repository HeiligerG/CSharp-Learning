namespace A00_Fahrzeuge;

class Program
{
    static void Main(string[] args)
    {
        Car car = new Car("Violet", "VW", VehicleCondition.Damaged);
        Motorcycle motorcycle = new Motorcycle("MontanaBlack", "Rot", "Lambo", VehicleCondition.Totaled);
        Mountainbike mountainbike = new Mountainbike(2, "Rot", "Porsche", VehicleCondition.New);
        
        Engine engine1 = new Engine(1.8, 100);
        Engine engine2 = new Engine(2.0, 200);
        Engine engine3 = new Engine(1.8, 100);
        
        
        car.printInfo();
        motorcycle.printInfo();
        mountainbike.printInfo();
        
        car.Move();
        motorcycle.Move();
        mountainbike.Move();
        
        motorcycle.startEngine();
        car.startEngine();
        motorcycle.startEngine();
        car.startEngine();
        motorcycle.stopEngine();
        car.stopEngine();
        
        car.getZustand();
        motorcycle.getZustand();
        mountainbike.getZustand();

        Console.WriteLine(engine1.ToString());
        Console.WriteLine(engine1.Equals(engine1));
        Console.WriteLine(engine1.Equals(engine2));
        Console.WriteLine(engine1.GetHashCode());
        Console.WriteLine(engine3.GetHashCode());
    }
}