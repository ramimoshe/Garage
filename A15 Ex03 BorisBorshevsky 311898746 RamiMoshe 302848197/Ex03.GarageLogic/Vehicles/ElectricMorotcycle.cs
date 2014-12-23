using System.Collections.Generic;
using Ex03.GarageLogic.VehicleElements;

namespace Ex03.GarageLogic.Vehicles
{
    public class ElectricMorotcycle : Motorcycle
    {
        public readonly ElectricEngine r_Engine;

        public ElectricMorotcycle(string i_ModelName, string i_SerialNumber, List<Wheel> i_Wheels, eMotorcycleLicenseType i_LicenseType, int i_EngineCc, ElectricEngine i_Engine)
            :base(i_ModelName, i_SerialNumber, i_Wheels, i_LicenseType, i_EngineCc)
        {
            r_Engine = i_Engine;
        }

        public override float GetEnergyLeftPrecent()
        {
            return r_Engine.WorkHoursRemining / r_Engine.r_MaxWorkHour;
        }
    }
}
