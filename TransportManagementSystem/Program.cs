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
            engine = new Engine { Model = "1NZ-FE", HorsePower = 110, LastRepairDate = DateTime.Now.AddMonths(-32) },
            LastServiceDate = DateTime.Now.AddMonths(-8)
        });

        garage.AddCar("B456DE", new Car("Toyota", "M3")
        {
            engine = new Engine { Model = "S55", HorsePower = 425, LastRepairDate = DateTime.Now.AddMonths(-24) }
        });

        garage.AddCar("C789FG", new Car("Toyota", "Civic")
        {
            engine = new Engine { Model = "K20A", HorsePower = 200, LastRepairDate = DateTime.Now.AddMonths(-30) }, 
            LastServiceDate = DateTime.Now.AddMonths(-6)
        });

        garage.AddCar("D012HI", new Car("Ford", "Focus")
        {
            engine = new Engine { Model = "EcoBoost 1.0", HorsePower = 125, LastRepairDate = DateTime.Now.AddMonths(-10) }, 
            LastServiceDate = DateTime.Now.AddMonths(-3)
        });

        garage.AddCar("E345JK", new Car("Ford", "C-Class")
        {
            engine = new Engine { Model = "M274", HorsePower = 184 }, 
            LastServiceDate = DateTime.Now.AddMonths(-12)
        });

        garage.AddCar("F678LM", new Car("Ford", "A4")
        {
            engine = new Engine { Model = "EA888", HorsePower = 190, LastRepairDate = DateTime.Now.AddMonths(-40) }, 
            LastServiceDate = DateTime.Now.AddMonths(-9)
        });

        garage.AddCar("G901NO", new Car("Volkswagen", "Golf")
        {
            engine = new Engine { Model = "TSI 1.4", HorsePower = 150, LastRepairDate = DateTime.Now.AddMonths(-18) },
            LastServiceDate = DateTime.Now.AddMonths(-5)
        });

        List<Car> carsRepairNeeded = garage.NeedsRepair();
        foreach (Car car in carsRepairNeeded)
        {
            Console.WriteLine($"Brand: {car.Brand}; Model: {car.Model}, Last repair: {car?.engine?.LastRepairDate?.ToString("dd.MM.yyyy") ?? "Never"}");
        }
        Dictionary<string, List<string>> carsBrands = garage.sortBrand();
        foreach (var car in carsBrands)
        {
            Console.WriteLine($"Brand: {car.Key}; Models: {String.Join(", ", car.Value.ToArray())}");
        }
    }

}