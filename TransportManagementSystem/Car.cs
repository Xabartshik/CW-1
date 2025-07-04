﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem
{
    public class Car : Vehicle, IMovable
    {
        public int Doors { get; set; }

        public void Move()
        {
            Console.WriteLine($"{Brand} {Model} едет по дороге");
        }

        public void OpenTrunk() => Console.WriteLine($"{Brand} открыл багажник");
    }
}
