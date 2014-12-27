using System.Collections.Generic;
using Ex03.GarageLogic.VehicleElements;

namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(string i_ModelName, string i_SerialNumber, List<Tire> i_Tires, Engine i_Engine)
        {
            ModelName = i_ModelName;
            SerialNumber = i_SerialNumber;
            Tires = i_Tires;
            r_Engine = i_Engine;
        }

        private readonly Engine r_Engine;
        public Engine Engine
        {
            get { return r_Engine; }
        }

        public string ModelName { get; private set; }

        public string SerialNumber { get; private set; }

        public List<Tire> Tires { get; protected set; }

        public abstract float GetEnergyLeftPrecent();

        public void FillManufacturerAirPressure()
        {
            foreach (Tire wheel in Tires)
            {
                wheel.FillManufacturerAirPressure();
            }   
        }
    }
}
