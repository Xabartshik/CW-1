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
        public int Year { get; set; }
        private double _maxSpeed;
        public double MaxSpeed
        {
            get {
                Console.WriteLine($"Максимальная скорость: {_maxSpeed} км/ч"); 
                return _maxSpeed; }
            set { if (value < 0) {
                    throw new ArgumentOutOfRangeException("Значение скорости не может быть меньше 0");
                }
                _maxSpeed = value;
            }

        }

        // Метод для запуска двигателя
        public  virtual void Start()
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
            return $"{Brand} {Model} ({Year} год)";
        }
        //Проверка на достижимость скорости
        public void CanReachSpeed(double speed)
        {
            if (speed <= MaxSpeed)
            {
                Console.WriteLine($"{Brand} {Model} может достичь скорости {MaxSpeed}.");
            }
            else { Console.WriteLine($"{Brand} {Model} не может достичь скорости {MaxSpeed}."); };
            }
        }

        

}
