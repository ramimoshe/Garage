using System.Collections.Generic;
using Ex03.GarageLogic.VehicleElements;

namespace Ex03.GarageLogic.Vehicles
{
    public class Truck : Vehicle
    {
        public readonly FuelEngine r_Engine;

        public bool IsContainsDangerusMatirial { get; set; }

        public float MaxCargoWeightAllowed { get; set; }

        public float CurrentCargoWeight { get; set; }

        protected Truck(string i_ModelName, string i_SerialNumber, List<Wheel> i_Wheels)
            : base(i_ModelName, i_SerialNumber, i_Wheels)
        {
            r_Engine = new FuelEngine();
        }

        public override float GetEnergyLeftPrecent()
        {
            return r_Engine.CurrentFuelAmount / r_Engine.r_MaxFuelAmount;
        }
    }
}
