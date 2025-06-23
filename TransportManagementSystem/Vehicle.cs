using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem
{
    public class Vehicle
    {
        private string _brand;
        public string Brand
        {
            get { return _brand.ToUpper(); }
            set { _brand = value.Trim(); }
        }
        public string Model { get; set; }
        public int year;
        public double maxSpeed;

        // Метод для запуска двигателя
        public void Start()
        {
            Console.WriteLine($"{Brand} {Model} завёл двигатель!");
        }

        // Метод для остановки
        public void Stop()
        {
            Console.WriteLine($"{Brand} {Model} остановился.");
        }

        // Метод для получения информации
        public string GetInfo()
        {
            return $"{Brand} {Model} ({year} год)";
        }

    }


}
