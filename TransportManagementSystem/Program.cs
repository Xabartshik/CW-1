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
            new Car("Toyota", "Corolla"){Engine = new Engine{ HorsePower = 100} },
            new Car("BMW", "M3"){Engine = new Engine{ HorsePower = 400} },
            new Car("Lada", "Vesta"){Engine = new Engine{ HorsePower = 200} },
            new Car("Moskvich", "410"),
            new Car("Minsk", "MTZ-82"){Engine = new Engine{ HorsePower = 15} },
            new Car("Mazda", "567FG"){Engine = new Engine{ HorsePower = 250} },
            new Car("MahaYa", "MK-108"){Engine = new Engine{ HorsePower = 105} },
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
        var longModels = cars.FindAll(car => car.Model.Length > 5);
        foreach (var longModel in longModels)
            Console.WriteLine($"Машина с длинной моделью: {longModel.Brand} {longModel.Model} ({longModel.Model.Length} символов)");

        var brandM = cars.FindAll(car => car.Brand[0].ToString().ToLower() == "m");
        Console.WriteLine($"Машина с маркой на M");
        foreach (var car in brandM)
            Console.WriteLine($"*   {car.Brand} {car.Model}");
        var sorted = brandM.OrderBy(car => car.Model);
        Console.WriteLine($"Сортировано по модели");
        foreach (var car in sorted)
            Console.WriteLine($"*   {car.Brand} {car.Model}");
        var unique = cars.DistinctBy(car => car.Model);
        Console.WriteLine($"Уникальные по модели");
        foreach (var car in unique)
            Console.WriteLine($"*   {car.Brand} {car.Model}");
        if (cars.Find(cars => cars.Engine !=null && cars.Engine.HorsePower > 200 ) != null)
            Console.WriteLine($"Машина с двигателем мощнее 200 л.с. есть");
        else
        { Console.WriteLine($"Машина с двигателем мощнее 200 л.с. нет"); }
        var firstCarD = cars.FirstOrDefault(car => car.Brand.ToLower().Contains("d"));
        if (firstCarD != null)
        {
            Console.WriteLine($"Машина с буквой D в марке: {firstCarD.Brand}, {firstCarD.Model}");
        }
        else
        {
            Console.WriteLine($"Машина с буквой D в марке отсутствует");
        }

    }

}
