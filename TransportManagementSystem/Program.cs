using TransportManagementSystem;

internal class Program
{
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

    }
}