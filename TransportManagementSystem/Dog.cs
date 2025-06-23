using TransportManagementSystem;

public class Dog : IMovable
{
    public string Name { get; set; }
    public string Breed { get; set; }

    public void Move()
    {
        Console.WriteLine($"Собака {Name} ({Breed}) бежит по парку");
    }
}