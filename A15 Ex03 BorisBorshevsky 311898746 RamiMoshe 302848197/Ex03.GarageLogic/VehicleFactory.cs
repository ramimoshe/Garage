using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.VehicleElements;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic
{
    public static class VehicleFactory
    {
        public static FuelCar GenerateFuelCar(string i_ModelName, string i_SerialNumber, eCarColor i_CarColor, eNumOfDoors i_Doors, string i_ManufacturerName, float i_CurrentAirPressure, float i_CurrentFuelAmount)
        {
            List<Wheel> wheels = createWheels(4, 29, i_ManufacturerName, i_CurrentAirPressure);
            return new FuelCar(i_ModelName, i_SerialNumber, wheels, i_CarColor, i_Doors, i_CurrentFuelAmount);
        }

        public static ElectricCar GenerateElectricCar(string i_ModelName, string i_SerialNumber, eCarColor i_CarColor, eNumOfDoors i_Doors, string i_ManufacturerName, float i_CurrentAirPressure, float i_WorkHoursRemining)
        {
            List<Wheel> wheels = createWheels(4, 29, i_ManufacturerName, i_CurrentAirPressure);
            return new ElectricCar(i_ModelName, i_SerialNumber, wheels, i_CarColor, i_Doors, i_WorkHoursRemining);
        }

        public static FuelMorotcycle GenerateFuelMorotcycle(string i_ModelName, string i_SerialNumber, eMotorcycleLicenseType i_LicenseType, int i_EngineCc, string i_ManufacturerName, float i_CurrentAirPressure, float i_CurrentFuelAmount, float i_CurrenctFuelAmount)
        {
            List<Wheel> wheels = createWheels(2, 30, i_ManufacturerName, i_CurrentAirPressure);
            return new FuelMorotcycle(i_ModelName, i_SerialNumber, wheels, i_LicenseType, i_EngineCc, i_CurrenctFuelAmount);
        }

        public static ElectricMorotcycle GenerateElectricMorotcycle(string i_ModelName, string i_SerialNumber, eMotorcycleLicenseType i_LicenseType, int i_EngineCc, string i_ManufacturerName, float i_CurrentAirPressure, float i_WorkHoursRemining, float i_MaxWorkHour)
        {
            List<Wheel> wheels = createWheels(2, 30, i_ManufacturerName, i_CurrentAirPressure);
            return new ElectricMorotcycle(i_ModelName, i_SerialNumber, wheels, i_LicenseType, i_EngineCc, i_WorkHoursRemining, i_MaxWorkHour);
        }

        public static Truck GenerateTruck(string i_ModelName, string i_SerialNumber, float i_MaxCargoWeightAllowed, string i_ManufacturerName, float i_CurrentAirPressure, float i_CurrenctFuelAmount)
        {
            List<Wheel> wheels = createWheels(8, 24, i_ManufacturerName, i_CurrentAirPressure);
            return new Truck(i_ModelName, i_SerialNumber, wheels, i_MaxCargoWeightAllowed, i_CurrenctFuelAmount);
        }

        private static List<Wheel> createWheels(int i_WheelsCount, float i_MaxManufacturerAirPressure, string i_ManufacturerName, float i_CurrentAirPressure)
        {
            List<Wheel> wheels = new List<Wheel>();
            for (int wheelIndex = 0; wheelIndex < i_WheelsCount; wheelIndex++)
            {
                wheels.Add(new Wheel(i_MaxManufacturerAirPressure, i_ManufacturerName, i_CurrentAirPressure));
            }

            return wheels;
        }
    }
}
