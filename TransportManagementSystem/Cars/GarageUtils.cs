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
            if (car.LastServiceDate is null || !car.LastServiceDate.HasValue)
            {
                return false;
            }
            var lastService = car.LastServiceDate.Value;
            return DateTime.Now.Subtract(lastService).TotalDays > 365;
        }
    }
}
