using System;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.VehicleElements
{
    public class Tire
    {
        private const float k_MinimalAmountOfAir = 0f;

        private readonly float r_MaxManufacturerAirPressure;
        private readonly string r_ManufacturerName;

        public string ManufacturerName { get { return r_ManufacturerName; } }
        public float MaxManufacturerAirPressure { get { return r_MaxManufacturerAirPressure; } }
        public float CurrentAirPressure { get; private set; }

        public Tire(float i_MaxManufacturerAirPressure, string i_ManufacturerName, float i_CurrentAirPressure)
        {
            r_MaxManufacturerAirPressure = i_MaxManufacturerAirPressure;
            r_ManufacturerName = i_ManufacturerName;

            validateAmountOfAir(i_CurrentAirPressure); // TODO: throw exeption if initial air pressure above max <DONE>
            CurrentAirPressure = i_CurrentAirPressure;
        }

        public void AddAdir(float i_Amount)
        {
            validateAmountOfAir(i_Amount); //TODO: use this method instead FillManufacturerAirPressure() <DONE>

            CurrentAirPressure += i_Amount;
        }

        private void validateAmountOfAir(float i_Amount)
        {
            if (i_Amount < k_MinimalAmountOfAir)
            {
                throw new ArgumentException("Cant add less than " + k_MinimalAmountOfAir.ToString() + " air");
            }

            if (i_Amount + CurrentAirPressure > r_MaxManufacturerAirPressure)
            {
                throw new ValueOutOfRangeException("Cant fill air more then the maximum pressure", k_MinimalAmountOfAir,
                    r_MaxManufacturerAirPressure);
            }
        }
    }
}
