using System.Collections.Generic;
using Ex03.GarageLogic.VehicleElements;

namespace Ex03.GarageLogic.Vehicles
{
    public class FuelCar : Car
    {
        public readonly FuelEngine r_Engine;

        private const float k_MaxFuel = 45;

        public FuelCar(string i_ModelName, string i_SerialNumber, List<Wheel> i_Wheels, eCarColor i_Color, eNumOfDoors i_Doors, float i_CurrenctFuelAmount)
            : base(i_ModelName, i_SerialNumber, i_Wheels, i_Color, i_Doors)
        {
            r_Engine = new FuelEngine(eFuelType.Octan95, i_CurrenctFuelAmount, MaxFuel);
        }

        private FuelEngine Engine
        {
            get { return r_Engine; }
        }

        public float MaxFuel
        {
            get { return k_MaxFuel; }
        }

        public override float GetEnergyLeftPrecent()
        {
            return r_Engine.CurrentFuelAmount / r_Engine.r_MaxFuelAmount;
        }
    }
}
