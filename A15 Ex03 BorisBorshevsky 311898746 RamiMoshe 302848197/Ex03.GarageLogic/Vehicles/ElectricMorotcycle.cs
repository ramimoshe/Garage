using System.Collections.Generic;
using Ex03.GarageLogic.VehicleElements;

namespace Ex03.GarageLogic.Vehicles
{
    public class ElectricMorotcycle : Motorcycle
    {
        public readonly ElectricEngine r_Engine;

        private const float k_MaxWorkHour = 1.8f;

        public ElectricMorotcycle(string i_ModelName, string i_SerialNumber, List<Wheel> i_Wheels, eMotorcycleLicenseType i_LicenseType, int i_EngineCc, float i_WorkHoursRemining, float i_MaxWorkHour)
            :base(i_ModelName, i_SerialNumber, i_Wheels, i_LicenseType, i_EngineCc)
        {
            r_Engine = new ElectricEngine(i_WorkHoursRemining, i_MaxWorkHour);
        }

        private ElectricEngine Engine
        {
            get { return r_Engine; }
        }

        public float MaxWorkHour
        {
            get { return k_MaxWorkHour; }
        }

        public override float GetEnergyLeftPrecent()
        {
            return r_Engine.WorkHoursRemining / r_Engine.r_MaxWorkHour;
        }
    }
}
