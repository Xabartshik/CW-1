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
        Car car = new Car("UAZ", "469")
        {
            LastServiceDate = DateTime.Now.AddMonths(-20)
        };
        if (GarageUtils.IsCarNeedService(car))
            Console.WriteLine($"{car.Brand} {car.Model} требует обслуживания");
        else
            Console.WriteLine($"{car.Brand} {car.Model} не требует обслуживания");

    }

}
