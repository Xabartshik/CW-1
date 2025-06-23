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

        myCar.Move();
        var dog = new Dog
        {
            Breed = "Jack-Russel",
            Name = "Lessie"
        };

        dog.Move();

        var cursor = new Cursor
        { X = 0, Y = 0 };
        cursor.Move();
        cursor.X = 10;
        cursor.Y = 20;
        cursor.Move();
    }


}