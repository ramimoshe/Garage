using System.Collections.Generic;
using Ex03.GarageLogic.VehicleElements;

namespace Ex03.GarageLogic.Vehicles
{
    public class Motorcycle : Vehicle
    {
        public readonly eMotorcycleLicenseType r_LicenseType; //TODO: Print it into report & make private
        public readonly int r_EngineCc; //TODO: Print it into report & make private

        public Motorcycle(string i_ModelName, string i_LicencePlate, List<Tire> i_Wheels, eMotorcycleLicenseType i_LicenseType, int i_EngineCc, Engine i_Engine)
            : base(i_ModelName, i_LicencePlate, i_Wheels, i_Engine)
        {
            r_LicenseType = i_LicenseType;
            r_EngineCc = i_EngineCc;
        }

        public override float GetEnergyLeftPrecent()
        {
            return Engine.GetEnergyLeftPrecent();
        }
    }
}
