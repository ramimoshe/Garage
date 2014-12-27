using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, Ticket> r_Tickets;

        private Dictionary<string, Ticket> Tickets
        {
            get { return r_Tickets; }
        }

        public Garage()
        {
            r_Tickets = new Dictionary<string, Ticket>();
        }

        public void CreateTicket(string i_CarOwnerName, string i_CarOwnerPhone, Vehicle i_vehicle)
        {
            if (!IsVehicleExists(i_vehicle.SerialNumber))
            {
                Ticket ticket = new Ticket(i_CarOwnerName, i_CarOwnerPhone, i_vehicle);
                Tickets.Add(i_vehicle.SerialNumber, ticket);
            }
        }

        public bool IsVehicleExists(string i_SerialNumber)
        {
            return Tickets.ContainsKey(i_SerialNumber);
        }

        public List<string> GetGarageTickets()
        {
            return GetGarageTickets(eVehicleState.Amendment | eVehicleState.Fixed | eVehicleState.Payed);
        }

        public List<string> GetGarageTickets(eVehicleState i_eVehicleState)
        {
            List<string> serialNumbers = new List<string>();
            foreach (var ticket in Tickets)
            {
                if (ticket.Value.CarState == i_eVehicleState)
                {
                    serialNumbers.Add(ticket.Key);
                }
            }

            return serialNumbers;
        }

        public void UpdateVehicleState(string i_serialNumber, eVehicleState i_vehicleState)
        {
            Tickets[i_serialNumber].CarState = i_vehicleState;
        }

        public void FillManufacturerAirpressure(string i_serialNumber)
        {
            Tickets[i_serialNumber].Vehicle.FillManufacturerAirPressure();
        }

        public void FuelVehicle(string i_serialNumber, eFuelType i_fuelType, float i_amountCc)
        {
            //Tickets[i_serialNumber].Vehicle.
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
