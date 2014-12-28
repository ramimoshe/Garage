using System.Collections.Generic;
using Ex03.GarageLogic.VehicleElements;

namespace Ex03.GarageLogic.Vehicles
{
    public class Truck : Vehicle
    {
        private readonly float r_MaxCargoWeightAllowed;

        public float MaxCargoWeightAllowed { get { return r_MaxCargoWeightAllowed; } }

        public bool IsContainsDangerusMatirial { get; set; }

        public float CurrentCargoWeight { get; set; }

        public Truck(string i_ModelName, string i_LicencePlate, List<Tire> i_Tires, float i_MaxCargoWeightAllowed, Engine i_Engine)
            : base(i_ModelName, i_LicencePlate, i_Tires, i_Engine)
        {
            //Todo: Throw exeption if current cargo above max cargo
            r_MaxCargoWeightAllowed = i_MaxCargoWeightAllowed;
        }

        public override float GetEnergyLeftPrecent()
        {
            return Engine.GetEnergyLeftPrecent();
        }
    }
}
