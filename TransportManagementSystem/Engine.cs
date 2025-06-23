using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Contracts;

namespace TransportManagementSystem
{
    public class Engine : IRepairable
    {
        public string Model { get; set; }
        public string Brand { get; set; }
    }
}
