using System.Collections.Generic;
using Ex03.GarageLogic.VehicleElements;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic
{
    public static class VehicleFactory
    {
        private const float k_MaxFuelCar = 45f;
        private const float k_MaxElectricPowerCar = 2.6f;
        private const int k_TiresAmountCar = 4;
        private const int k_MaxManufacturerAirPressureCar = 29;

        private const float k_MaxFuelMotorcycle = 6.5f;
        private const float k_MaxElectricPowerMotorcycle = 1.8f;
        private const int k_TiresAmountMotorcycle = 2;
        private const int k_MaxManufacturerAirPressureMotorcycle = 30;

        private const float k_MaxFuelTruck = 200f;
        private const int k_TiresAmountTruck = 8;
        private const int k_MaxManufacturerAirPressureTruck = 24;

        public static Car GenerateFuelCar(string i_ModelName, string i_LicencePlate, eCarColor i_CarColor, eNumOfDoors i_Doors, string i_ManufacturerTireName, float i_CurrentTireAirPressure, float i_CurrentFuelAmount)
        {
            List<Tire> tires = createTires(k_TiresAmountCar, k_MaxManufacturerAirPressureCar, i_ManufacturerTireName, i_CurrentTireAirPressure);
            FuelEngine engine = new FuelEngine(eFuelType.Octan95, i_CurrentFuelAmount, k_MaxFuelCar);

            return new Car(i_ModelName, i_LicencePlate, tires, i_CarColor, i_Doors, engine);
        }

        public static Car GenerateElectricCar(string i_ModelName, string i_LicencePlate, eCarColor i_CarColor, eNumOfDoors i_Doors, string i_ManufacturerTireName, float i_CurrentTireAirPressure, float i_WorkHoursRemining)
        {
            List<Tire> tires = createTires(k_TiresAmountCar, k_MaxManufacturerAirPressureCar, i_ManufacturerTireName, i_CurrentTireAirPressure);
            ElectricEngine engine = new ElectricEngine(i_WorkHoursRemining, k_MaxElectricPowerCar);

            return new Car(i_ModelName, i_LicencePlate, tires, i_CarColor, i_Doors, engine);
        }

        public static Motorcycle GenerateFuelMorotcycle(string i_ModelName, string i_LicencePlate, eMotorcycleLicenseType i_LicenseType, int i_EngineCc, string i_ManufacturerTireName, float i_CurrentTireAirPressure, float i_CurrentFuelAmount)
        {
            List<Tire> tires = createTires(k_TiresAmountMotorcycle, k_MaxManufacturerAirPressureMotorcycle, i_ManufacturerTireName, i_CurrentTireAirPressure);
            FuelEngine engine = new FuelEngine(eFuelType.Octan95, i_CurrentFuelAmount, k_MaxFuelMotorcycle);

            return new Motorcycle(i_ModelName, i_LicencePlate, tires, i_LicenseType, i_EngineCc, engine);
        }

        public static Motorcycle GenerateElectricMorotcycle(string i_ModelName, string i_LicencePlate, eMotorcycleLicenseType i_LicenseType, int i_EngineCc, string i_ManufacturerTireName, float i_CurrentTireAirPressure, float i_WorkHoursRemining)
        {
            List<Tire> tires = createTires(k_TiresAmountMotorcycle, k_MaxManufacturerAirPressureMotorcycle, i_ManufacturerTireName, i_CurrentTireAirPressure);
            ElectricEngine engine = new ElectricEngine(i_WorkHoursRemining, k_MaxElectricPowerMotorcycle);

            return new Motorcycle(i_ModelName, i_LicencePlate, tires, i_LicenseType, i_EngineCc, engine);
        }

        public static Truck GenerateTruck(string i_ModelName, string i_LicencePlate, float i_MaxCargoWeightAllowed, float i_CurrentCargoWeight, string i_ManufacturerTireName, float i_CurrentTireAirPressure, float i_CurrentFuelAmount)
        {
            List<Tire> tires = createTires(k_TiresAmountTruck, k_MaxManufacturerAirPressureTruck, i_ManufacturerTireName, i_CurrentTireAirPressure);
            FuelEngine engine = new FuelEngine(eFuelType.Octan95, i_CurrentFuelAmount, k_MaxFuelTruck);
            Truck truck = new Truck(i_ModelName, i_LicencePlate, tires, i_MaxCargoWeightAllowed, engine);
            truck.CurrentCargoWeight = i_CurrentCargoWeight;

            return truck;
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
