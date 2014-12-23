using Ex03.GarageLogic.Exceptions;
using System;

namespace Ex03.GarageLogic.VehicleElements
{
    public class FuelEngine
    {
        public float r_MaxFuelAmount;

        public void Fuel(float i_Amount, eFuelType i_FuelType)
        {
            if (i_Amount < 0)
            {
                throw new ArgumentException("Cant add negative amount of fuel");
            }

            if (i_Amount + CurrentFuelAmount > r_MaxFuelAmount)
            {
                throw new ValueOutOfRangeException("Cant fill air more then the maximum fuel", 0, r_MaxFuelAmount);
            }

            if (FuelType != i_FuelType)
            {
                throw new ArgumentException("Not suitable fuel type");
            }

            CurrentFuelAmount += i_Amount;
        }

        public eFuelType FuelType { get; set; }

        public float CurrentFuelAmount { get; set; }
    }
}
