using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem.Cars
{
    public class Garage
    {
        private Dictionary<string, Car> _cars = new();
        public void AddCar(string licensePlate, Car car)
        {
            _cars[licensePlate] = car;
        }
        public Car? FindCar(string licensePlate)
        {
            return _cars.GetValueOrDefault(licensePlate);
        }
        public void PrintCarInfo(Car? car, string licensePlate)
        {
            Console.WriteLine($"License: {licensePlate}");
            Console.WriteLine($"Brand: {car?.Brand ?? "Unknown"}");
            Console.WriteLine($"Model: {car?.Model ?? "Unknown"}");
            Console.WriteLine($"Engine HP: {car?.Engine?.HorsePower ?? 0}");
            Console.WriteLine($"Last service: {car?.LastServiceDate?.ToString("dd.MM.yyyy") ?? "Never"}");
            Console.WriteLine();
        }
        public bool NeedsService(Car car)
        {
            var lastService = car.LastServiceDate ?? DateTime.MinValue;
            return DateTime.Now.Subtract(lastService).TotalDays > 365;
        }
    }

}
