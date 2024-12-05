namespace A00_Fahrzeuge;

class Program
{
    static void Main(string[] args)
    {
        Car car = new Car("Violet", "VW", VehicleCondition.Damaged);
        Motorcycle motorcycle = new Motorcycle("MontanaBlack", "Rot", "Lambo", VehicleCondition.Totaled);
        Mountainbike mountainbike = new Mountainbike(2, "Rot", "Porsche", VehicleCondition.New);
        
        
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
    }
}