using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Contracts;

namespace TransportManagementSystem.Transport
{
    public class ServiceBox<T> where T : IRepairable
    {
        private T _repairableItem;
        private string _serviceName;

        public ServiceBox(string serviceName)
        {
            _serviceName = serviceName;
        }

        public void Repair(T item)
        {
            _repairableItem = item;
            Console.WriteLine($"{_repairableItem.Model} поставлен на ремонт");
        }

        public void ShofInfo()
        {
            if (_repairableItem == null)
                Console.WriteLine("Сервис свободен");
            else
                Console.WriteLine($"В сервисе {_repairableItem.Model}");
        }
    }
}
