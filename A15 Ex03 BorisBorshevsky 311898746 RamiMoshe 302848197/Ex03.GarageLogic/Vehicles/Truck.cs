using System.Collections.Generic;
using Ex03.GarageLogic.VehicleElements;

namespace Ex03.GarageLogic.Vehicles
{
    public class Truck : Vehicle
    {
        private const int c_WheelsCount = 8;
        private const int c_MaxManufacturerAirPressure = 24;
        public readonly FuelEngine r_Engine;
        public readonly float r_MaxCargoWeightAllowed;

        public bool IsContainsDangerusMatirial { get; set; }

        public float CurrentCargoWeight { get; set; }

        public Truck(string i_ModelName, string i_SerialNumber, List<Wheel> i_Wheels, float i_MaxCargoWeightAllowed)
            : base(i_ModelName, i_SerialNumber, i_Wheels)
        {
            r_Engine = new FuelEngine(eFuelType.Soler, 0, 12);
            r_MaxCargoWeightAllowed = i_MaxCargoWeightAllowed;
        }

        public override float GetEnergyLeftPrecent()
        {
            return r_Engine.CurrentFuelAmount / r_Engine.r_MaxFuelAmount;
        }
    }
}
