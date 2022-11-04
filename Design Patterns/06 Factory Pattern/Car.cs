using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Factory_Pattern
{
    internal class Car : IVehicle
    {
        public void Move(string to)
        {
            Console.WriteLine("Car is moving to "+ to);
        }
    }
}
