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
            if (car.LastServiceDate is null || !car.LastServiceDate.HasValue)
                return false;

            return DateTime.Now.Subtract(car.LastServiceDate.Value).TotalDays > 365;
        }
        // возвращает список всех машин, у которых двигатель не ремонтировался более двух лет (или дата ремонта не указана).
        public List<Car> NeedsRepair()
        {
            var repairList = new List<Car>();
            DateTime lastRepairDate;
            foreach (var car in _cars.Values)
            {
                if (car.engine is null)
                    continue;

                if (!car.engine.LastRepairDate.HasValue)
                    continue;

                lastRepairDate = car.engine.LastRepairDate!.Value;

                if (DateTime.Now.Subtract(lastRepairDate).TotalDays < 365 * 2)
                    continue;
                repairList.Add(car);
            }
            return repairList;
        }
        //Возвращает словарь, где ключ — это марка машины, а значение — список моделей этой марки, присутствующих в гараже.
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
