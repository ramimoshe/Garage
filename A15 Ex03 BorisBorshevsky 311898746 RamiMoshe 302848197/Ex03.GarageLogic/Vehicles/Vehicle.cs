using System;
using System.Collections.Generic;
using Ex03.GarageLogic.VehicleElements;

namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(string i_ModelName, string i_SerialNumber, List<Tire> i_Wheels, Engine i_Engine)
        {
            ModelName = i_ModelName;
            SerialNumber = i_SerialNumber;
            Wheels = i_Wheels;
            r_Engine = i_Engine;
        }

        private readonly Engine r_Engine;
        public Engine Engine
        {
            get { return r_Engine; }
        }

        public string ModelName { get; private set; }

        public string SerialNumber { get; private set; }

        protected List<Tire> Wheels  { get; set; }

        public abstract float GetEnergyLeftPrecent();

        public void FillManufacturerAirPressure()
        {
            foreach (Tire wheel in Wheels)
            {
                wheel.FillManufacturerAirPressure();
            }   
        }
    }
}
