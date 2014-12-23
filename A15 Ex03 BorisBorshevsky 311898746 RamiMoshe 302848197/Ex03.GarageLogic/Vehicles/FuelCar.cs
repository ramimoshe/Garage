using System.Collections.Generic;
using Ex03.GarageLogic.VehicleElements;

namespace Ex03.GarageLogic.Vehicles
{
    public class FuelCar : Car
    {
        public readonly FuelEngine r_Engine;

        public FuelCar(string i_ModelName, string i_SerialNumber, List<Wheel> i_Wheels, eCarColor i_Color, eNumOfDoors i_Doors, FuelEngine i_Engine)
            : base(i_ModelName, i_SerialNumber, i_Wheels, i_Color, i_Doors)
        {
            r_Engine = i_Engine;
        }

        public override float GetEnergyLeftPrecent()
        {
            return r_Engine.CurrentFuelAmount / r_Engine.r_MaxFuelAmount;
        }
    }
}
