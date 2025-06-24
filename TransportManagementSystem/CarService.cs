using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Cars;

namespace TransportManagementSystem
{
    public class CarService
    {
        public Car? GetCarByIndex(List<Car> cars, int index)
        {
            try
            {
                //Так как было написано, что метод должен бросать исключение, метод его и бросает
                if (index > cars.Count()) 
                    throw new ArgumentOutOfRangeException("index");
                var car = cars[index];
                return car;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Ошибка: индекс вне диапазона!");
                return null;
            }

        }
    }
}
