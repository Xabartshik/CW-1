using System.Reflection;
using TransportManagementSystem;

internal class Program
{
    static void ServiceVehicle(Vehicle v) => Console.WriteLine($"Обслуживаем {v.GetInfo()}");

    static void Main(string[] args)
    {
        var myCar = new Car("Toyota", "Corolla")
        {
            Year = 2022,
            MaxSpeed = 195,
            Doors = 4
        };

        var sportcar = new SportCar("Toyota", "Камри 3.5")
        {
            SpoilerType = "Крыло"
        };
        // Program.cs
        var carServiceBox = new ServiceBox<Car>("Бокс ремонта авто");
        carServiceBox.ShofInfo();
        carServiceBox.Repair(myCar);
        carServiceBox.ShofInfo();

        Console.WriteLine();

        var engineServiceBox = new ServiceBox<Engine>("Бокс ремонта двигателей");
        engineServiceBox.ShofInfo();
        engineServiceBox.Repair(new Engine { Brand = "Subaru", Model = "EJ257" }); // создаем двигатель, заполняем его через инициализатор и сразу передаем в бокс
        engineServiceBox.ShofInfo();


    }


}