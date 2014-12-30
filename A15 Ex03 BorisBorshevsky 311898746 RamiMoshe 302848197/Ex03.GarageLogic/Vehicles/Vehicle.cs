using System.Collections.Generic;
using Ex03.GarageLogic.Energy;
using Ex03.GarageLogic.VehicleElements;

namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(string i_ModelName, string i_LicencePlate, List<Tire> i_Tires, Engine i_Engine)
        {
            ModelName = i_ModelName;
            LicencePlate = i_LicencePlate;
            Tires = i_Tires;
            r_Engine = i_Engine;
        }

        private readonly Engine r_Engine;
        public Engine Engine
        {
            get { return r_Engine; }
        }

        public string ModelName { get; private set; }

        public string LicencePlate { get; private set; }

        public List<Tire> Tires { get; protected set; }

        public abstract float GetEnergyLeftPrecent();

        public virtual void FillEnergy(BaseEnergy i_Energy)
        {
            Engine.FillEnergy(i_Energy);
        }

        public void FillManufacturerAirPressure()
        {
            foreach (Tire wheel in Tires)
            {
                wheel.AddAdir(wheel.MaxManufacturerAirPressure - wheel.CurrentAirPressure);
            }   
        }
    }
}
