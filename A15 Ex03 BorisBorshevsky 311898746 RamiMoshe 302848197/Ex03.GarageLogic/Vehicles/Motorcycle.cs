using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.VehicleElements;

namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Motorcycle : Vehicle
    {
        public readonly eMotorcycleLicenseType r_LicenseType;
        public readonly int r_EngineCc;

        protected Motorcycle(string i_ModelName, string i_SerialNumber, List<Wheel> i_Wheels, eMotorcycleLicenseType i_LicenseType, int i_EngineCc)
            :base(i_ModelName, i_SerialNumber, i_Wheels)
        {
            r_LicenseType = i_LicenseType;
            r_EngineCc = i_EngineCc;
        }
    }
}
