using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public static class VehicleFactory
    {
        public static T GenerateVehicle<T>(string serialNumber)
        {
            return default(T);
        }
    }
}
