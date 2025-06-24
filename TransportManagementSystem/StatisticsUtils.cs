using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Cars;

namespace TransportManagementSystem
{
    public static class StatisticsUtils
    {
        public static double GetAverageHorsePower(List<Car> cars)
        {
            double mid = 0;
            return cars.Where(car => car.Engine != null).Average(car => car.Engine.HorsePower);
        }
    }
}
