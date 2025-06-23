using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem
{
    internal class Motorcycle : Vehicle
    {
        public override void Stop()
        {
            Console.WriteLine($"{Brand} {Model} поставлен на подножку.");
        }
    }
}


