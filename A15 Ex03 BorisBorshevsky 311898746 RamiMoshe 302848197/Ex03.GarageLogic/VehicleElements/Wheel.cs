using System;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.VehicleElements
{
    public class Wheel
    {
        public readonly float r_MaxManufacturerAirPressure;

        public Wheel(float i_MaxManufacturerAirPressure)
        {
            r_MaxManufacturerAirPressure = i_MaxManufacturerAirPressure;
        }

        public string ManufacturerName { get; set; }

        public float CurrentAirPressure { get; set; }

        public void AddAdir(float i_Amount)
        {
            if (i_Amount < 0)
            {
                throw new ArgumentException("Cant add negative amount of air pressure");
            }

            if (i_Amount + CurrentAirPressure > r_MaxManufacturerAirPressure)
            {
                throw new ValueOutOfRangeException("Cant fill air more then the maximum pressure", 0, r_MaxManufacturerAirPressure);
            }

            CurrentAirPressure += i_Amount;
        }
    }
}
