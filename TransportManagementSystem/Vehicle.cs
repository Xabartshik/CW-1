using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem
{
    public class Vehicle
    {
        public string brand;
        public string model;
        public int year;
        public double maxSpeed;
        public double fuelLevel;

        // Метод для запуска двигателя
        public void Start()
        {
            Console.WriteLine($"{brand} {model} завёл двигатель!");
        }

        // Метод для остановки
        public void Stop()
        {
            Console.WriteLine($"{brand} {model} остановился.");
        }

        // Метод для получения информации
        public string GetInfo()
        {
            return $"{brand} {model} ({year} год)";
        }
        //Метод для заправки автомобиля
        public void Refuel(double liters)
        {
            this.fuelLevel += liters;
            Console.WriteLine($"{brand} {model} заправлен на {liters} литров. Текущий уровень топлива: {this.fuelLevel} л.");
        }

    }


}
