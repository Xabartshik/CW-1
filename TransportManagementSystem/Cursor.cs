using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem
{
    //Класс курсора, передвигаемого по экрану
    internal class Cursor : IMovable
    {
        public void Move()
        {
            Console.WriteLine($"Курсор двигается по экрану");
        }
    }
}
