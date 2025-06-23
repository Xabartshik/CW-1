using System.Reflection;
using TransportManagementSystem;

internal class Program
{
    static void ServiceVehicle(Vehicle v) => Console.WriteLine($"Обслуживаем {v.GetInfo()}");

    static void Main(string[] args)
    {
        var sportcar = new SportCar("Toyota", "Камри 3.5")
        {
            SpoilerType = "Крыло"
        };

    }


}