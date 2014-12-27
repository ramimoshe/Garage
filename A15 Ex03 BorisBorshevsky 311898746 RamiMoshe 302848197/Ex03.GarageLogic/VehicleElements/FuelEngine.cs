using Ex03.GarageLogic.Exceptions;
using System;

namespace Ex03.GarageLogic.VehicleElements
{
    public class FuelEngine : Engine
    {
        private const float k_minimumAmountToFuel = 0f;
        private readonly eFuelType r_FuelType;
        private readonly float r_MaxFuelAmount;
        private float m_CurrentFuelAmount;

        public FuelEngine(eFuelType i_FuelType, float i_CurrentFuelAmount, float i_MaxFuelAmount)
        {
            if (i_CurrentFuelAmount > i_MaxFuelAmount)
            {
                throw new ValueOutOfRangeException("Cant fill more then maximum amount of fuel", k_minimumAmountToFuel, i_MaxFuelAmount);
            }
            
            r_FuelType = i_FuelType;
            r_MaxFuelAmount = i_MaxFuelAmount;
            m_CurrentFuelAmount = i_CurrentFuelAmount;
        }

        public void Fuel(float i_AmountToAdd, eFuelType i_FuelType)
        {
            if (i_AmountToAdd < k_minimumAmountToFuel)
            {
                throw new ArgumentException("Cant add amount below " + k_minimumAmountToFuel.ToString());
            }
            else if (i_AmountToAdd + CurrentFuelAmount > r_MaxFuelAmount)
            {
                throw new ValueOutOfRangeException("Cant fill more then the maximum fuel", k_minimumAmountToFuel, r_MaxFuelAmount);
            }
            else if (FuelType != i_FuelType)
            {
                throw new ArgumentException("Not suitable fuel type");
            }
            else 
            { 
                CurrentFuelAmount += i_AmountToAdd;
            }
        }

        private eFuelType FuelType { 
            get { return r_FuelType; } 
        }

        public float CurrentFuelAmount {
            get { return m_CurrentFuelAmount; }
            private set { m_CurrentFuelAmount = value; }
        }

        public float MaxFuelAmount
        {
            get { return r_MaxFuelAmount; }
        }

        public override void FillEnergy(Engery i_Energy)
        {
            if (i_Energy is FuelEnergy)
            {
                FuelEnergy energy = (FuelEnergy) i_Energy;
                Fuel(energy.Amount, energy.FuelType);
            }
        }
    }
}
