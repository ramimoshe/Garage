using System.Collections.Generic;
using Ex03.GarageLogic.VehicleElements;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic
{
    public static class VehicleFactory
    {
        private const int k_CarTiresAmount = 4;
        private const int k_CarMaxManufacturerAirPressure = 29;
        private const eFuelType k_CarFuelType = eFuelType.Octan95;
        private const float k_CarMaxFuel = 45f;
        private const float k_CarMaxElectricPower = 2.6f;

        private const int k_MotorcycleTiresAmount = 2;
        private const float k_MotorcycleMaxFuel = 6.5f;
        private const eFuelType k_MotorcycleFuelType = eFuelType.Octan96;
        private const int k_MotorcycleMaxManufacturerAirPressure = 30;
        private const float k_MotorcycleMaxElectricPower = 1.8f;

        private const int k_TruckTiresAmount = 8;
        private const float k_TruckMaxFuel = 200f;
        private const int k_TruckMaxManufacturerAirPressure = 24;
        private const eFuelType k_TruckFuelType = eFuelType.Soler;

        public static Car GenerateFuelCar(string i_ModelName, string i_LicencePlate, eCarColor i_CarColor, eNumOfDoors i_Doors, string i_ManufacturerTireName, float i_CurrentTireAirPressure, float i_CurrentFuelAmount)
        {
            List<Tire> tires = createTires(k_CarTiresAmount, k_CarMaxManufacturerAirPressure, i_ManufacturerTireName, i_CurrentTireAirPressure);
            FuelEngine engine = new FuelEngine(k_CarFuelType, i_CurrentFuelAmount, k_CarMaxFuel);

            return new Car(i_ModelName, i_LicencePlate, tires, i_CarColor, i_Doors, engine);
        }

        public static Car GenerateElectricCar(string i_ModelName, string i_LicencePlate, eCarColor i_CarColor, eNumOfDoors i_Doors, string i_ManufacturerTireName, float i_CurrentTireAirPressure, float i_WorkHoursRemining)
        {
            List<Tire> tires = createTires(k_CarTiresAmount, k_CarMaxManufacturerAirPressure, i_ManufacturerTireName, i_CurrentTireAirPressure);
            ElectricEngine engine = new ElectricEngine(i_WorkHoursRemining, k_CarMaxElectricPower);

            return new Car(i_ModelName, i_LicencePlate, tires, i_CarColor, i_Doors, engine);
        }

        public static Motorcycle GenerateFuelMorotcycle(string i_ModelName, string i_LicencePlate, eMotorcycleLicenseType i_LicenseType, int i_EngineCc, string i_ManufacturerTireName, float i_CurrentTireAirPressure, float i_CurrentFuelAmount)
        {
            List<Tire> tires = createTires(k_MotorcycleTiresAmount, k_MotorcycleMaxManufacturerAirPressure, i_ManufacturerTireName, i_CurrentTireAirPressure);
            FuelEngine engine = new FuelEngine(k_MotorcycleFuelType, i_CurrentFuelAmount, k_MotorcycleMaxFuel);

            return new Motorcycle(i_ModelName, i_LicencePlate, tires, i_LicenseType, i_EngineCc, engine);
        }

        public static Motorcycle GenerateElectricMorotcycle(string i_ModelName, string i_LicencePlate, eMotorcycleLicenseType i_LicenseType, int i_EngineCc, string i_ManufacturerTireName, float i_CurrentTireAirPressure, float i_WorkHoursRemining)
        {
            List<Tire> tires = createTires(k_MotorcycleTiresAmount, k_MotorcycleMaxManufacturerAirPressure, i_ManufacturerTireName, i_CurrentTireAirPressure);
            ElectricEngine engine = new ElectricEngine(i_WorkHoursRemining, k_MotorcycleMaxElectricPower);

            return new Motorcycle(i_ModelName, i_LicencePlate, tires, i_LicenseType, i_EngineCc, engine);
        }

        public static Truck GenerateTruck(string i_ModelName, string i_LicencePlate, float i_MaxCargoWeightAllowed, float i_CurrentCargoWeight, string i_ManufacturerTireName, float i_CurrentTireAirPressure, float i_CurrentFuelAmount, bool i_IsCarryngDangerousMaterials)
        {
            List<Tire> tires = createTires(k_TruckTiresAmount, k_TruckMaxManufacturerAirPressure, i_ManufacturerTireName, i_CurrentTireAirPressure);
            FuelEngine engine = new FuelEngine(k_TruckFuelType, i_CurrentFuelAmount, k_TruckMaxFuel);
            Truck truck = new Truck(i_ModelName, i_LicencePlate, tires, i_MaxCargoWeightAllowed, engine)
            {
                CurrentCargoWeight = i_CurrentCargoWeight,
                IsContainsDangerusMatirial = i_IsCarryngDangerousMaterials
            };

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
