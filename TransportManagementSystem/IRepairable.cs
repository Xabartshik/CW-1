using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem
{
    public interface IRepairable
    {
        string Model { get; set; }
        string Brand { get; set; }
    }
}
