using System.Collections.Generic;
using Ex03.GarageLogic.VehicleElements;

namespace Ex03.GarageLogic.Vehicles
{
    public class FuelMorotcycle : Motorcycle
    {
        public readonly FuelEngine r_Engine;

        public FuelMorotcycle(string i_ModelName, string i_SerialNumber, List<Wheel> i_Wheels, eMotorcycleLicenseType i_LicenseType, int i_EngineCc, FuelEngine i_Engine)
            :base(i_ModelName, i_SerialNumber, i_Wheels, i_LicenseType, i_EngineCc)
        {
            r_Engine = i_Engine;
        }

        public override float GetEnergyLeftPrecent()
        {
            return r_Engine.CurrentFuelAmount / r_Engine.r_MaxFuelAmount;
        }
    }
}
