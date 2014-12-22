using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        public Vehicle()
        {
                
        }
        public Vehicle(string i_Model, string i_SerialNumber, List<Wheel> i_Wheels)
        {
            
        }

        public string Model { get; private set; }

        public string SerialNumber { get; private set; }

        public float PrecentEnergyLeft {
            get { 
                return 1;
            }
        }

        protected List<Wheel> Wheels;

    }

    public class Wheel
    {
        public string Manufactor { get; set; }

        public float AirPresure { get; set; }

        public float MaxManufactorAirPresure { get; set; }

        public void AddAdir(float amount)
        {
            //validate param and add the air
            throw new ValueOutOfRangeException("asd", 1,1);
        }
    }


    public class ValueOutOfRangeException : Exception
    {
        public float MaxValue { get; private set; }
        public float MinValue { get; private set; }

        public ValueOutOfRangeException(string i_Message, float i_MinValue, float i_MaxValue) : base(i_Message)
        {
            MaxValue = i_MaxValue;
            MinValue = i_MinValue;
        }
    }



    public enum eMotorcycleLincesType
    {
        A,
        A1,
        AB,
        B2
    }

    public abstract class Motorcycle : Vehicle
    {
        public eMotorcycleLincesType MotorcycleLincesType { get; set; }

        public int EngineCc { get; set; }
    }

    public class FuelMorotcycle : Motorcycle
    {
        public FuelEngine Engine { get; set; }    
    }

    public class ElectricMorotcycle : Motorcycle
    {
        public ElectricEngine Engine { get; set; }
    }

    public enum eCarColor
    {
        White,
        Green,
        Blue,
        Red
    }

    public enum eNumOfDoors
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5
    }

    public abstract class Car : Vehicle
    {
        public eCarColor Color { get; set; }

        public eNumOfDoors NumOfDoors { get; set; }
    }

    public class ElectricCar : Car
    {
        public ElectricEngine Engine { get; set; }
    }

    public class FuelCar : Car
    {
        public FuelEngine Engine { get; set; }
    }

    public class Truck : Vehicle
    {
        public bool IsContainsDangerusMatirial { get; set; }

        public float MaxCargoWeightAllowed { get; set; }

        public float CurrentCargoWeight { get; set; }
    }

    public enum eFuelType
    {
        Soler,
        Octan95,
        Octan96,
        Octan98
    }

    public class FuelEngine
    {
        public eFuelType FuelType { get; set; }

        public float CurrentFuelAmount { get; set; }

        public float MaxFuelAmount { get; set; }

        public void Fuel(float i_AmountFuelToAdd, eFuelType i_FuelTypeToAdd)
        {
            throw new ArgumentException();
            throw new ValueOutOfRangeException("aa",2,3);
        }
    }

    public class ElectricEngine
    {
        public float WorkHoursRemining { get; set; }

        public float MaxWorkHour { get; set; }

        public void Charge(float i_amount)
        {
            // validate and add
        }
    }

    public enum eVehicleState
    {
        Fixed,
        //....
    }

    public class Ticket
    {
        public string CarOwnerName { get; set; }

        public string CarOwnerPhone { get; set; }

        public eVehicleState CarState { get; set; }
    }

    public class Garage
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

    public class CarReport
    {
         
    }
}
