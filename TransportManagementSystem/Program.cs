using System.Reflection;
using TransportManagementSystem;
using TransportManagementSystem.Cars;

internal class Program
{


    static void Main(string[] args)
    {
        var cars = new Car[]
        {
            new Car("Toyota", "Corolla"),
            new Car("BMW", "M3")
        };

        try
        {
            var car = cars[1];
            Console.WriteLine(car.Brand);
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Ошибка: Индекс вне диапазона массива автомобилей!");
        }
        finally
        {
            Console.WriteLine("Отработал блок finally");
        }

        Garage garage = new Garage();
        garage.AddCar("A123BC", new Car("Toyota", "Corolla"));
        try
        {
            var car = garage.FindCar("Z999ZZ");
            string brand = car?.Brand ?? "Unknown";
            Console.WriteLine(brand);
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("Ошибка: Машина с таким номером не найдена!");
        }
        finally { Console.WriteLine("Завершение поиска автомобиля"); }
    }

}
