using System.Reflection;
using TransportManagementSystem;

public class ElectricCar : Vehicle
{

    public override void Start()
    {
        Console.WriteLine($"{Brand} {Model} тихо включил электромотор ⚡");
    }
}