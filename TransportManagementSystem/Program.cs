using TransportManagementSystem;

internal class Program
{
    static void Main(string[] args)
    {
        Vehicle car = new Vehicle();
        car.brand = "Toyota";
        car.model = "Camry";
        car.year = 2023;
        car.maxSpeed = 220;
        car.fuelLevel = 10;

        Vehicle truck = new Vehicle();
        truck.brand = "Volvo";
        truck.model = "FH16";
        truck.year = 2022;
        truck.maxSpeed = 120;
        truck.fuelLevel = 20;

        Console.WriteLine(car.GetInfo());
        car.Start();
        car.Stop();
        car.Refuel(10);

        Console.WriteLine(truck.GetInfo());
        truck.Start();
        truck.Stop();
        truck.Refuel(15);
        Console.ReadLine();

    }
}