using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem
{
    public static class CarUtils
    {
        // Статический метод для проверки корректности номера
        public static bool IsValidLicensePlate(string plate)
        {
            // Простой пример: номер должен быть не пустым и длиной 6 символов
            return !string.IsNullOrWhiteSpace(plate) && plate.Length == 6;
        }
    }
}
