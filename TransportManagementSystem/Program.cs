using System.Reflection;
using TransportManagementSystem;
using TransportManagementSystem.Cars;

internal class Program
{


    static void Main(string[] args)
    {
        var engine1 = new Engine
        {
            Brand = "Toyota",
            Model = "2JZ-GTE",
            HorsePower = 110
        };
        var engine2 = new Engine
        {
            Brand = "Nissan",
            Model = "1NZ-FE",
            HorsePower = 280
        };

        Engine[] enginesArray = new Engine[3];
        enginesArray[0] = engine1;
        enginesArray[1] = engine2;
        foreach (var engine in enginesArray)
        {
            if (engine != null) { Console.WriteLine($"Model: {engine.Model}, HP: {engine.HorsePower}"); }
        }

        var enginesList = new List<Engine>(enginesArray);
        var engine3 = new Engine
        {
            Brand = "Mersedes",
            Model = "B16B",
            HorsePower = 185
        };
        var engine4 = new Engine
        {
            Brand = "Nissan",
            Model = "RB26DETT",
            HorsePower = 280
        };
        Console.WriteLine();
        enginesList.Add(engine3);
        enginesList.Add(engine4);
        enginesList.RemoveAll(item => item is null || item.HorsePower < 150);
        foreach (var engine in enginesList)
        { Console.WriteLine($"Model: {engine.Model}, HP: {engine.HorsePower}"); }

    }


}