namespace A00_Fahrzeuge;

class Program
{
    static void Main(string[] args)
    {
        Car car = new Car("Blau", "Porsche");
        Motorcycle motorcycle = new Motorcycle("Rot", "Lambo", "MonatnaBlack");
        Mountainbike mountainbike = new Mountainbike("Violet", "Peugot", 2);
        
        car.printInfo();
        motorcycle.printInfo();
        mountainbike.printInfo();
        
        car.Move();
        motorcycle.Move();
        mountainbike.Move();
    }
}