using Ex03.GarageLogic.Exceptions;
using System;

namespace Ex03.GarageLogic.VehicleElements
{
    public class FuelEngine : Engine
    {
        private const float k_MinimumAmountToFuel = 0f;

        private readonly eFuelType r_FuelType;
        private readonly float r_MaxFuelAmount;

        public float CurrentFuelAmount { get; private set; }
        public eFuelType FuelType { get { return r_FuelType; } }
        public float MaxFuelAmount { get { return r_MaxFuelAmount; } }

        public FuelEngine(eFuelType i_FuelType, float i_CurrentFuelAmount, float i_MaxFuelAmount)
        {
            if (i_CurrentFuelAmount > i_MaxFuelAmount)
            {
                throw new ValueOutOfRangeException("Cant fill more then maximum amount of fuel", k_MinimumAmountToFuel, i_MaxFuelAmount);
            }
            
            r_FuelType = i_FuelType;
            r_MaxFuelAmount = i_MaxFuelAmount;
            CurrentFuelAmount = i_CurrentFuelAmount;
        }

        private void fuel(float i_AmountToAdd, eFuelType i_FuelType)
        {
            if (i_AmountToAdd < k_MinimumAmountToFuel)
            {
                throw new ArgumentException("Cant add amount below " + k_MinimumAmountToFuel.ToString());
            }

            if (i_AmountToAdd + CurrentFuelAmount > r_MaxFuelAmount)
            {
                throw new ValueOutOfRangeException("Cant fill more then the maximum fuel", k_MinimumAmountToFuel, r_MaxFuelAmount);
            }

            if (FuelType != i_FuelType)
            {
                throw new ArgumentException("Not suitable fuel type");
            }

            CurrentFuelAmount += i_AmountToAdd;
        }

        public override void FillEnergy(Energy i_Energy)
        {
            FuelEnergy fuelEnergy = i_Energy as FuelEnergy;
            if (fuelEnergy != null)
            {
                FuelEnergy energy = fuelEnergy;
                fuel(energy.Amount, energy.FuelType);
            }
        }

        public override float GetEnergyLeftPrecent()
        {
            return CurrentFuelAmount / MaxFuelAmount;
        }
    }
}