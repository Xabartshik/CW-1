using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem.Transport
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
            Console.WriteLine($"Engine HP: {car?.engine?.HorsePower ?? 0}");
            Console.WriteLine($"Last service: {car?.LastServiceDate?.ToString("dd.MM.yyyy") ?? "Never"}");
            Console.WriteLine();
        }
        public bool NeedsService(Car car)
        {
            var lastService = car.LastServiceDate ?? DateTime.MinValue;
            return DateTime.Now.Subtract(lastService).TotalDays > 365;
        }

        public List<Car> NeedsRepair()
        {
            var repairList = new List<Car>();
            var lastRepairDate = new DateTime();
            foreach (var car in _cars.Values)
            {
                lastRepairDate = car.engine?.LastRepairDate ?? DateTime.MinValue;
                if (DateTime.Now.Subtract(lastRepairDate).TotalDays > 365 * 2)
                {
                    repairList.Add(car);
                }
            }
            return repairList;
        }

        public Dictionary<string, List<string>> sortBrand()
        { 
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
            foreach (var car in _cars)
            {
                if (result.ContainsKey(car.Value.Brand) == false)
                {
                        result[car.Value.Brand] = new List<string>();
                }
                result[car.Value.Brand].Add(car.Value.Model);

            }
            return result;
        }
    }

}
