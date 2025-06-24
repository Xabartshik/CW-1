using System.Reflection;
using TransportManagementSystem.Transport;

public class ElectricCar : Vehicle
{
    public ElectricCar(string brand, string model) : base(brand, model)
    {
    }

    public override void Start()
    {
        Console.WriteLine($"{Brand} {Model} тихо включил электромотор ⚡");
    }
}