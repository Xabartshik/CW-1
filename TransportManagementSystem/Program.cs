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
    }

}
