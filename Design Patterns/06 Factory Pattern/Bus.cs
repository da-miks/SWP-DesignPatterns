using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Factory_Pattern
{
    internal class Bus : IVehicle
    {
        public void Move(string to)
        {
            Console.WriteLine("Bus is moving to " + to);
        }
    }
}
