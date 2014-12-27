using System.Collections.Generic;
using Ex03.GarageLogic.VehicleElements;

namespace Ex03.GarageLogic.Vehicles
{
    public class Truck : Vehicle
    {
        private const int k_TiresCount = 8;
        private const int k_MaxManufacturerAirPressure = 24;
        private const float k_MaxFuelAmount = 200;

        private readonly float r_MaxCargoWeightAllowed;

        public float MaxCargoWeightAllowed { get { return r_MaxCargoWeightAllowed; } }

        public bool IsContainsDangerusMatirial { get; set; }

        public float CurrentCargoWeight { get; set; }

        public Truck(string i_ModelName, string i_SerialNumber, List<Tire> i_Tires, float i_MaxCargoWeightAllowed, Engine i_Engine)
            : base(i_ModelName, i_SerialNumber, i_Tires, i_Engine)
        {
            r_MaxCargoWeightAllowed = i_MaxCargoWeightAllowed;
        }

        public override float GetEnergyLeftPrecent()
        {
            return ((FuelEngine) Engine).CurrentFuelAmount/((FuelEngine) Engine).MaxFuelAmount;
        }
    }
}
