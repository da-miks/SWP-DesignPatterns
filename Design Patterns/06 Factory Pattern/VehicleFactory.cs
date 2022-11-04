using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Factory_Pattern
{
    public enum VehicleTypes
    {
        Car,
        Bus
    }
    internal class VehicleFactory
    {
        public static IVehicle CreateVehicle(VehicleTypes type)
        {
            switch(type)
            {
                case VehicleTypes.Car:
                    return new Car();
                case VehicleTypes.Bus:
                    return new Bus();
                default:
                    throw new NotSupportedException("Invalid vehicle type " + type.ToString());
            }
        }
    }
}
