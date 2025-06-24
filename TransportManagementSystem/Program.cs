using System.Reflection;
using TransportManagementSystem;
using TransportManagementSystem.Cars;

internal class Program
{


    static void Main(string[] args)
    {
        var garage = new Garage();
        string plate = "A123BC";
        if (CarUtils.IsValidLicensePlate(plate))
            Console.WriteLine($"Номер {plate} корректен");
        else
            Console.WriteLine($"Номер {plate} некорректен");

        // Пример с некорректным номером
        string wrongPlate = "123";
        if (CarUtils.IsValidLicensePlate(wrongPlate))
            Console.WriteLine($"Номер {wrongPlate} корректен");
        else
            Console.WriteLine($"Номер {wrongPlate} некорректен");
    }

}
