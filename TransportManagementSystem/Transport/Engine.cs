using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Contracts;

namespace TransportManagementSystem.Transport
{
    public class Engine : IRepairable
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public int HorsePower { get; set; }
        public DateTime? LastRepairDate { get; set; }
    }
}
