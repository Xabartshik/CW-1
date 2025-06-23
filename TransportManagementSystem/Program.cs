using TransportManagementSystem;

internal class Program
{
    static void Main(string[] args)
    {
        Vehicle car = new Vehicle();
        car.Brand = "Toyota";
        car.Model = "Camry";
        car.Year = 2023;
        car.MaxSpeed = 220;
        car.CanReachSpeed(200);

        Vehicle truck = new Vehicle();
        truck.Brand = "Volvo";
        truck.Model = "FH16";
        truck.Year = 2022;
        truck.MaxSpeed = 120;

        Console.WriteLine(car.GetInfo());
        car.Start();
        car.Stop();

        Console.WriteLine("\n" + truck.GetInfo());
        truck.Start();
        truck.Stop();
        truck.CanReachSpeed(200);

        Console.ReadLine();

    }
}