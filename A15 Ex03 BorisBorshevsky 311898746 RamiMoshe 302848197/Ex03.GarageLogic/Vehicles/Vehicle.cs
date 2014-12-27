using System;
using System.Collections.Generic;
using Ex03.GarageLogic.VehicleElements;

namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(string i_ModelName, string i_SerialNumber, List<Wheel> i_Wheels)
        {
            ModelName = i_ModelName;
            SerialNumber = i_SerialNumber;
            Wheels = i_Wheels;
        }

        public string ModelName { get; private set; }

        public string SerialNumber { get; private set; }

        protected List<Wheel> Wheels  { get; set; }

        public abstract float GetEnergyLeftPrecent();

        public void FillManufacturerAirPressure()
        {
            foreach (Wheel wheel in Wheels)
            {
                wheel.FillManufacturerAirPressure();
            }   
        }
    }
}
