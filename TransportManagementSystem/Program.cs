using TransportManagementSystem;

internal class Program
{

    static void Main(string[] args)
    {
        Vehicle car = new Vehicle
        {
            Brand = "Toyota",
            Model = "Camry",
            Year = 2023,
            MaxSpeed = 220
        };
        car.CanReachSpeed(200);
        Vehicle truck = new Vehicle
        {
            Brand = "Volvo",
            Model = "FH16",
            Year = 2022,
            MaxSpeed = 120
        };
        truck.CanReachSpeed(200);

    }


}