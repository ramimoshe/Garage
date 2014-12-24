using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly List<Ticket> r_tickets;

        public Garage()
        {
            r_tickets = new List<Ticket>();
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
            throw new ArgumentException("Licence card not found");
        }

        public void FillManufacturerAirpressure(string i_serialNumber)
        {
            throw new ArgumentException("Licence card not found");
        }

        public void FuelVehicle(string i_serialNumber, eFuelType i_fuelType, float i_amountCc)
        {
            throw new ArgumentException("Licence card not found");
        }

        public void ChargeVehicle(string i_serialNumber, float i_amountMinutes)
        {
            throw new ArgumentException("Licence card not found");
        }

        public CarReport GetCarReport(string i_serialNumber)
        {
            throw new ArgumentException("Licence card not found");
        }
    }
}
