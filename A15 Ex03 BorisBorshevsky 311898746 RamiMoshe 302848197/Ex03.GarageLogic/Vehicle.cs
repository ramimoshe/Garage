using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        public string Model { get; set; }

        public string SerialNumber { get; set; }

        public float PrecentEnergyLeft { get; set; }

        
    }

    class Wheel
    {
        public string Manufactor { get; set; }

        public float AirPresure { get; set; }

        public float ManufactorAirPresure { get; set; }

        public void AddAdir(float amount)
        {
            //validate param and add the air
        }


    }

    enum eMotorcycleLincesType
    {
        A,
        A1,
        AB,
        B2
    }

    class Morotcycle
    {
        public eMotorcycleLincesType MotorcycleLincesType { get; set; }

        public int EngineCc { get; set; }
    }

    enum eColor
    {
        White,
        //.....
    }

    class Car
    {
        public eColor Color { get; set; }

        public int Doors { get; set; }
    }

    class Truck : Car
    {
        public bool IsContainsDangerusMatirial { get; set; }

        public float MaxWeight { get; set; }

        public float CurrentWeight { get; set; }
    }

    enum eFuelType
    {
        Soler,
        //....
    }

    class FuelEngine
    {
        public eFuelType FuelType { get; set; }

        public float CurrentFuelAmount { get; set; }

        public float MaxFuelAmount { get; set; }

        public void Fuel(float i_amount)
        {
            
        }
    }

    class ElectricEngine
    {
        public float WorkHoursRemining { get; set; }

        public float MaxWorkHour { get; set; }

        public void Charge(float i_amount)
        {
            // validate and add
        }
    }

    enum eVehicleState
    {
        Fixed,
        //....
    }

    class Ticket
    {
        public string CarOwnerName { get; set; }

        public string CarOwnerPhone { get; set; }

        public eVehicleState CarState { get; set; }
    }

    class Garage
    {
        private readonly List<Ticket> tickets;

        public Garage()
        {
            tickets = new List<Ticket>();
        }

        public void AddVehicle(Vehicle i_vehicle)
        {
            
        }

        public Dictionary<string, eVehicleState> GetGarageTickets()
        {
            return null;
        }

        public void UpdateVehicleState(string i_serialNumber, eVehicleState i_vehicleState)
        {
            
        }

        public void FillManufacturAirPresure(string i_serialNumber)
        {
            
        }

        public void FuelVehicle(string i_serialNumber, eFuelType i_fuelType, float i_amountCc)
        {
            
        }

        public void ChargeVehicle(string i_serialNumber, float i_amountMinutes)
        {

        }

        public CarReport GetCarReport(string i_serialNumber)
        {
            return null;
        }
    }

    class CarReport
    {
         
    }
}
