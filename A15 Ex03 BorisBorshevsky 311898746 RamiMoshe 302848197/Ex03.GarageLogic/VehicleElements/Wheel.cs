using System;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.VehicleElements
{
    public class Wheel
    {
        private readonly float r_MaxManufacturerAirPressure;
        private const float k_MinimalAmountOfAir = 0f;

        public Wheel(float i_MaxManufacturerAirPressure)
        {
            r_MaxManufacturerAirPressure = i_MaxManufacturerAirPressure;
        }

        public string ManufacturerName { get; set; }

        public float CurrentAirPressure { get; set; }

        public void AddAdir(float i_Amount)
        {
            if (i_Amount < k_MinimalAmountOfAir)
            {
                throw new ArgumentException("Cant add less than " + k_MinimalAmountOfAir.ToString() + " air");
            }

            if (i_Amount + CurrentAirPressure > r_MaxManufacturerAirPressure)
            {
                throw new ValueOutOfRangeException("Cant fill air more then the maximum pressure", k_MinimalAmountOfAir, r_MaxManufacturerAirPressure);
            }

            CurrentAirPressure += i_Amount;
        }
    }
}
