using System.Reflection;
using TransportManagementSystem;
using TransportManagementSystem.Transport;

internal class Program
{


    static void Main(string[] args)
    {
        var garage = new Garage();

        garage.AddCar("A123BC", new Car("Toyota", "Corolla")
        {
            Engine = new Engine { Model = "1NZ-FE", HorsePower = 110 },
            LastServiceDate = DateTime.Now.AddMonths(-8)
        });

        garage.AddCar("B456DE", new Car("BMW", "M3")
        {
            Engine = new Engine { Model = "S55", HorsePower = 425 }
        });

        // Поиск существующей машины
        var foundCar = garage.FindCar("A123BC");
        garage.PrintCarInfo(foundCar, "A123BC");

        // Поиск несуществующей машины
        var notFoundCar = garage.FindCar("Z999ZZ");
        garage.PrintCarInfo(notFoundCar, "Z999ZZ");

        // Проверка необходимости ТО
        if (foundCar != null)
        {
            Console.WriteLine($"Needs service: {garage.NeedsService(foundCar)}");
        }
    }

}