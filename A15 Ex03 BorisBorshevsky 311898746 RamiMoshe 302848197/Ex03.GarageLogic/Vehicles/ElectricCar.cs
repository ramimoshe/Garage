using System.Collections.Generic;
using Ex03.GarageLogic.VehicleElements;

namespace Ex03.GarageLogic.Vehicles
{
    public class ElectricCar : Car
    {
        private readonly ElectricEngine r_Engine;
        
        private const float k_MaxWorkHour = 2.6f;

        public ElectricCar(string i_ModelName, string i_SerialNumber, List<Wheel> i_Wheels, eCarColor i_Color, eNumOfDoors i_Doors, float i_WorkHoursRemining)
            : base(i_ModelName, i_SerialNumber, i_Wheels, i_Color, i_Doors)
        {
            r_Engine = new ElectricEngine(i_WorkHoursRemining, MaxWorkHour);
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
