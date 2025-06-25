using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Contracts;

namespace TransportManagementSystem.Transport
{
    public class Car : Vehicle, IMovable, IRepairable
    {
        public static int TotalCarsCreated = 0; // Статическое поле
        public Car(string brand, string model) : base(brand, model)
        {
            TotalCarsCreated++; // Увеличиваем счетчик при каждом создании машины
        }
        public Engine? engine { get; set; }
        public DateTime? LastServiceDate { get; set; }
        public int Doors { get; set; }

        public void Move()
        {
            Console.WriteLine($"{Brand} {Model} едет по дороге");
        }

        public void OpenTrunk() => Console.WriteLine($"{Brand} открыл багажник");
    }
}
