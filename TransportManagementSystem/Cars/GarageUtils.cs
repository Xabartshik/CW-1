using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem.Cars
{
    public static class GarageUtils
    {
        // Статический метод для проверки корректности номера
        public static bool IsCarNeedService(Car car)
        {
            var lastService = car.LastServiceDate ?? DateTime.MinValue;
            return DateTime.Now.Subtract(lastService).TotalDays > 365;
        }
    }
}
