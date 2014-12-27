using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.VehicleElements
{
    public class FuelEnergy : Engery
    {
        public FuelEnergy(eFuelType i_fuelType, float i_Amount)
            :base(i_Amount)
        {
            FuelType = i_fuelType;
        }

        public eFuelType FuelType { get; set; }
    }
}
