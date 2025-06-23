using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem
{
    public class Bicycle : IRepairable
    {
        public string Model { get; set; }
        public string Brand { get; set; }
    }
}
