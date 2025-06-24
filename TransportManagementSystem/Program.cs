using System.Reflection;
using TransportManagementSystem;
using TransportManagementSystem.Cars;

internal class Program
{


    static void Main(string[] args)
    {
        var cars = new List<Car>
        {
            new Car("Toyota", "Corolla"),
            new Car("BMW", "M3"),
            new Car("Lada", "Vesta")
        };

        // Найти первую машину марки BMW
        var bmw = cars.Find(car => car.Brand == "BMW");
        if (bmw != null)
            Console.WriteLine($"Найдена: {bmw.Brand} {bmw.Model}");

        // Получить все машины, у которых марка начинается на 'T'
        var tCars = cars.FindAll(car => car.Brand.StartsWith("T"));
        foreach (var car in tCars)
            Console.WriteLine($"Марка на T: {car.Brand} {car.Model}");
        var carService = new CarService();
        var carByIndex = carService.GetCarByIndex(cars, 5);
        if (carByIndex != null)
        {
            Console.WriteLine($"Машина найдена: {carByIndex.Brand} {carByIndex.Model}");
        }
        else {
            Console.WriteLine("Машина не найдена");
        }
    }

}
