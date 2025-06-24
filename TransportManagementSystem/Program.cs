using System.Globalization;
using System.Reflection;
using TransportManagementSystem;
using TransportManagementSystem.Cars;

internal class Program
{


    static void Main(string[] args)
    {
        var cars = new List<Car>
        {
            new Car("Toyota", "Corolla") { Engine = new Engine { HorsePower = 110 } },
            new Car("BMW", "M3") { Engine = new Engine { HorsePower = 420 } },
            new Car("Lada", "Vesta") { Engine = new Engine { HorsePower = 106 } },
            new Car("Toyota", "Corolla") { Engine = new Engine { HorsePower = 110 } },
            new Car("Lada", "Vesta") { Engine = new Engine { HorsePower = 106 } },
            new Car("Audi", "A6") { Engine = new Engine { HorsePower = 190 } },
            new Car("Mazda", "CX-5") { Engine = new Engine { HorsePower = 150 } },
            new Car("Ford", "Focus") { Engine = new Engine { HorsePower = 125 } },
            new Car("Chevrolet", "Camaro") { Engine = new Engine { HorsePower = 275 } }
        };

        var powerfuelengine = cars.Where(car => car.Engine != null && car.Engine.HorsePower > 120).ToList();
        Console.WriteLine("\nМашины с мощностью > 120 л.с.:");
        foreach (var car in powerfuelengine)
            Console.WriteLine($"{car.Brand} {car.Model} ({car.Engine.HorsePower} л.с.)");

        var sorteddown = powerfuelengine.OrderByDescending(car => car.Engine.HorsePower).ToList();
        Console.WriteLine("\nСортировка по убыванию мощности:");
        foreach (var car in sorteddown)
            Console.WriteLine($"{car.Brand} {car.Model} ({car.Engine.HorsePower} л.с.)");

        var unique = cars.DistinctBy(car => car.Brand).ToList();
        Console.WriteLine("\nУдалены дубликаты:");
        foreach (var car in unique)
            Console.WriteLine($"{car.Brand} {car.Model} ({car.Engine.HorsePower} л.с.)");

        var uniqueBrands = cars.Select(car => car.Brand).Distinct().ToList();
        Console.WriteLine("\nТолько марки машин:");
        foreach (var brand in uniqueBrands)
            Console.WriteLine($"{brand}");

        var grouped = cars.GroupBy(car => car.Brand[0]).ToList();
        Console.WriteLine("\nСгруппировано:");
        foreach (var group in grouped)
        {
            Console.WriteLine($"{group.Key}");
            foreach (var car in group)
                Console.Write($"{car.Brand} {car.Model}   ");
            Console.WriteLine();
        }
        if (cars.Any(car => car.Brand == "Audi"))
        {
            Console.WriteLine("Есть Ауди");
        }
        else
        {
            Console.WriteLine("Нет Ауди");
        }
        var ccar = cars.FirstOrDefault(car => car.Model[0].ToString().ToLower() == "c");
        Console.WriteLine("\nМашина на С");
        if (ccar != null)
            Console.WriteLine($"{ccar.Brand} {ccar.Model}");
        else
            Console.WriteLine("\nНет машины с моделью на 'C'");

    }

}
