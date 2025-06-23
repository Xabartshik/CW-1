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

        Vehicle truck = new Vehicle();
        truck.brand = "Volvo";
        truck.model = "FH16";
        truck.year = 2022;
        truck.maxSpeed = 120;

        Console.WriteLine(car.GetInfo());
        car.Start();
        car.Stop();

        Console.WriteLine(truck.GetInfo());
        truck.Start();
        truck.Stop();

        Console.ReadLine();

    }
}