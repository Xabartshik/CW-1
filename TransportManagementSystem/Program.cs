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
            new Car("Lada", "Vesta"),
            new Car("Audi", "A6"),
            new Car("Mazda", "CX-5")
        };

        var aCars = cars.FindAll(car => car.Brand.ToLower().Contains("a"));
        foreach (var car in aCars)
            Console.WriteLine($"Марка содержит 'a': {car.Brand} {car.Model}");

        var longModel = cars.Find(car => car.Model.Length > 4);
        if (longModel != null)
            Console.WriteLine($"Модель длиннее 4 символов: {longModel.Brand} {longModel.Model}");
    }

}
