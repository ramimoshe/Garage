using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.VehicleElements;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic
{
    public static class VehicleFactory
    {
        private const float k_MaxFuelCar = 45;
        private const float k_MaxElectricPowerCar = 45;

        private const float k_MaxFuelMotorcycle = 45;
        private const float k_MaxElectricPowerMotorcycle = 45;

        private const float k_MaxFuelTruck = 45;

        public static Car GenerateFuelCar(string i_ModelName, string i_SerialNumber, eCarColor i_CarColor, eNumOfDoors i_Doors, string i_ManufacturerTireName, float i_CurrentTireAirPressure, float i_CurrentFuelAmount)
        {
            List<Tire> tires = createTires(4, 29, i_ManufacturerTireName, i_CurrentTireAirPressure);
            FuelEngine engine = new FuelEngine(eFuelType.Octan95, i_CurrentFuelAmount, k_MaxFuelCar);
            return new Car(i_ModelName, i_SerialNumber, tires, i_CarColor, i_Doors, engine);
        }

        public static Car GenerateElectricCar(string i_ModelName, string i_SerialNumber, eCarColor i_CarColor, eNumOfDoors i_Doors, string i_ManufacturerTireName, float i_CurrentTireAirPressure, float i_WorkHoursRemining)
        {
            List<Tire> tires = createTires(4, 29, i_ManufacturerTireName, i_CurrentTireAirPressure);
            ElectricEngine engine = new ElectricEngine(i_WorkHoursRemining, k_MaxElectricPowerCar);
            return new Car(i_ModelName, i_SerialNumber, tires, i_CarColor, i_Doors, engine);
        }

        public static Motorcycle GenerateFuelMorotcycle(string i_ModelName, string i_SerialNumber, eMotorcycleLicenseType i_LicenseType, int i_EngineCc, string i_ManufacturerTireName, float i_CurrentTireAirPressure, float i_CurrentFuelAmount)
        {
            List<Tire> tires = createTires(2, 30, i_ManufacturerTireName, i_CurrentTireAirPressure);
            FuelEngine engine = new FuelEngine(eFuelType.Octan95, i_CurrentFuelAmount, k_MaxFuelMotorcycle);
            return new Motorcycle(i_ModelName, i_SerialNumber, tires, i_LicenseType, i_EngineCc, engine);
        }

        public static Motorcycle GenerateElectricMorotcycle(string i_ModelName, string i_SerialNumber, eMotorcycleLicenseType i_LicenseType, int i_EngineCc, string i_ManufacturerTireName, float i_CurrentTireAirPressure, float i_WorkHoursRemining)
        {
            List<Tire> tires = createTires(2, 30, i_ManufacturerTireName, i_CurrentTireAirPressure);
            ElectricEngine engine = new ElectricEngine(i_WorkHoursRemining, k_MaxElectricPowerCar);
            return new Motorcycle(i_ModelName, i_SerialNumber, tires, i_LicenseType, i_EngineCc, engine);
        }

        public static Truck GenerateTruck(string i_ModelName, string i_SerialNumber, float i_MaxCargoWeightAllowed, string i_ManufacturerTireName, float i_CurrentTireAirPressure, float i_CurrentFuelAmount)
        {
            List<Tire> tires = createTires(8, 24, i_ManufacturerTireName, i_CurrentTireAirPressure);
            FuelEngine engine = new FuelEngine(eFuelType.Octan95, i_CurrentFuelAmount, k_MaxFuelMotorcycle);
            return new Truck(i_ModelName, i_SerialNumber, tires, i_MaxCargoWeightAllowed, engine);
        }

        private static List<Tire> createTires(int i_TiresCount, float i_MaxManufacturerAirPressure, string i_ManufacturerName, float i_CurrentAirPressure)
        {
            List<Tire> tires = new List<Tire>();
            for (int tireIndex = 0; tireIndex < i_TiresCount; tireIndex++)
            {
                tires.Add(new Tire(i_MaxManufacturerAirPressure, i_ManufacturerName, i_CurrentAirPressure));
            }

            return tires;
        }
    }
}
