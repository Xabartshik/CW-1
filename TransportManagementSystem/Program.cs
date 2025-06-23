using TransportManagementSystem;

internal class Program
{
    static void ServiceVehicle(Vehicle v) => Console.WriteLine($"Обслуживаем {v.GetInfo()}");

    static void Main(string[] args)
    {
        var myCar = new Car
        {
            Brand = "Toyota",
            Model = "Corolla",
            Year = 2022,
            MaxSpeed = 195,
            Doors = 4
        };

        myCar.Start();          
        myCar.OpenTrunk();      
        Console.WriteLine(myCar.GetInfo());
        ServiceVehicle(myCar);

        var tesla = new ElectricCar
        {
            Brand = "Tesla",
            Model = "Y3",
            Year = 2022,
            MaxSpeed = 200
        };

        tesla.Start();
        Console.WriteLine(tesla.GetInfo());

        var bike = new Motorcycle
        {
            Brand = "Yamaha",
            Model = "R1",
            Year = 2023,
            MaxSpeed = 300
        };
        bike.Start();
        bike.Stop();
        Console.WriteLine(bike.GetInfo());
    }


}