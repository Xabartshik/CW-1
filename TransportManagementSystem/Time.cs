using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagementSystem
{
    public class Time : IMovable
    {
        private int _seconds = 0;
        private int _minutes = 0;
        private int _hours = 0;

        public Time(int Seconds, int Minutes, int Hours, int Days)
        {
        }

        public int Seconds
        {
            get { return _seconds; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Значение не может быть меньше 0");
                }
                if (value > 60)
                {
                    Minutes += value / 60;
                    _seconds = value % 60;
                }
                else
                    _seconds = value;
            }

        }

        public int Minutes
        {
            get { return _minutes; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Значение не может быть меньше 0");
                }
                if (value > 60)
                {
                    Hours += value / 60;
                    _minutes = value % 60;
                }
                else 
                    _minutes = value;
            }

        }

        public int Hours
        {
            get { return _hours; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Значение не может быть меньше 0");
                }
                if (value > 24)
                {
                    Days += value / 24;
                    _hours = value % 24;
                }
                else 
                    _seconds = value;
            }

        }
        public int Days { get; set; }
        public void Move()
        {
            Seconds += 5;
            Console.WriteLine($"Время движется вперед... Сейчас {Days} дней, {Hours}:{Minutes}:{Seconds}");
        }
    }
}
