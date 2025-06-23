using System.Reflection;
using TransportManagementSystem;
using TransportManagementSystem.Cars;

internal class Program
{


    static void Main(string[] args)
    {

        // Создаём словарь, где ключ — госномер, а значение — объект Car
        var carDictionary = new Dictionary<string, Car>
        {
            { "A123BC", new Car("Toyota", "Corolla") { Doors = 4 } },
            { "B456DE", new Car("BMW", "M3") { Doors = 2 } },
            { "C789FG", new Car("Mazda", "rx-7") { Doors = 2 } }
        };

        // Получаем машину по ключу (госномеру)
        var car = carDictionary["B456DE"];
        Console.WriteLine($"Brand: {car.Brand}, Model: {car.Model}"); // BMW M3

        // Можно пройтись по всем парам ключ-значение
        foreach (var pair in carDictionary)
        {
            Console.WriteLine($"Number: {pair.Key}, Brand: {pair.Value.Brand}, Model: {pair.Value.Model}");
        }
    }


}