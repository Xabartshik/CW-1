using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem.Cars
{
    public class SportCar : Car
    {
        public SportCar(string brand, string model) : base(brand, model)
        {
        }

        public string SpoilerType { get; set; }

    }
}
