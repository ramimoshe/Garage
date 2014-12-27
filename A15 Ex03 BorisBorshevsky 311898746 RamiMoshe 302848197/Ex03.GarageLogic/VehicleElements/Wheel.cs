using System;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.VehicleElements
{
    public class Wheel
    {
        private const float k_MinimalAmountOfAir = 0f;

        private readonly float r_MaxManufacturerAirPressure;
        private readonly string r_ManufacturerName;

        public Wheel(float i_MaxManufacturerAirPressure, string i_ManufacturerName, float i_CurrentAirPressure)
        {
            r_MaxManufacturerAirPressure = i_MaxManufacturerAirPressure;
            r_ManufacturerName = i_ManufacturerName;
            CurrentAirPressure = i_CurrentAirPressure;
        }

        public float CurrentAirPressure { get; private set; }

        public string ManufacturerName
        {
            get { return r_ManufacturerName; }
        }

        public float MaxManufacturerAirPressure
        {
            get { return r_MaxManufacturerAirPressure; }
        }

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

        public void FillManufacturerAirPressure()
        {
            CurrentAirPressure = MaxManufacturerAirPressure;
        }
    }
}
