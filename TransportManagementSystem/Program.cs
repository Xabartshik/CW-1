using System.Reflection;
using TransportManagementSystem;
using TransportManagementSystem.Cars;

internal class Program
{


    static void Main(string[] args)
    {
        var cars = new List<Car>
        {
            new Car("Toyota", "Corolla"){Engine = new Engine{ HorsePower = 100} },
            new Car("BMW", "M3"){Engine = new Engine{ HorsePower = 400} },
            new Car("Lada", "Vesta"){Engine = new Engine{ HorsePower = 200} }, 
            new Car("Москвич", "410"),
            new Car("Минск", "МТЗ-82"){Engine = new Engine{ HorsePower = 15} },
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
        Console.WriteLine($"Среднее значение л.с. двигателей у машин: {StatisticsUtils.GetAverageHorsePower(cars)}");
        var longModels = cars.FindAll(car => car.Model.Count() > 5);
        foreach (var longModel in longModels)
            Console.WriteLine($"Машина с длинной моделью: {longModel.Brand} {longModel.Model} ({longModel.Model.Count()} символов)");
    }

}
