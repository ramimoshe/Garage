using System;
using System.Collections.Generic;
using Ex03.GarageLogic.VehicleElements;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, Ticket> r_Tickets;

        private Dictionary<string, Ticket> Tickets { get { return r_Tickets; } }

        public Garage()
        {
            r_Tickets = new Dictionary<string, Ticket>();
        }

        public void CreateTicket(string i_CarOwnerName, string i_CarOwnerPhone, Vehicle i_Vehicle)
        {
            if (!IsVehicleExists(i_Vehicle.SerialNumber))
            {
                Ticket ticket = new Ticket(i_CarOwnerName, i_CarOwnerPhone, i_Vehicle);
                Tickets.Add(i_Vehicle.SerialNumber, ticket);
            }
        }

        public bool IsVehicleExists(string i_SerialNumber)
        {
            return Tickets.ContainsKey(i_SerialNumber);
        }

        public List<string> GetSerialNumbersInGarage()
        {
            return GetSerialNumbersInGarage(eVehicleState.Amendment | eVehicleState.Fixed | eVehicleState.Payed);
        }

        public List<string> GetSerialNumbersInGarage(eVehicleState i_VehicleState)
        {
            List<string> serialNumbers = new List<string>();
            foreach (var ticket in Tickets)
            {
                if (ticket.Value.CarState == i_VehicleState)
                {
                    serialNumbers.Add(ticket.Key);
                }
            }

            return serialNumbers;
        }

        public void UpdateVehicleState(string i_SerialNumber, eVehicleState i_VehicleState)
        {
            Tickets[i_SerialNumber].CarState = i_VehicleState;
        }

        public void FillManufacturerAirpressure(string i_SerialNumber)
        {
            Tickets[i_SerialNumber].Vehicle.FillManufacturerAirPressure();
        }

        public void FuelVehicle(string i_SerialNumber, eFuelType i_FuelType, float i_AmountCc)
        {
            FuelEnergy fuelEnergy = new FuelEnergy(i_FuelType, i_AmountCc);
            Tickets[i_SerialNumber].Vehicle.Engine.FillEnergy(fuelEnergy);
        }

        public void ChargeVehicle(string i_SerialNumber, float i_AmountMinutes)
        {
            ElectricEnergy electricEnergy = new ElectricEnergy(i_AmountMinutes);
            Tickets[i_SerialNumber].Vehicle.Engine.FillEnergy(electricEnergy);
        }

        public string GetCarReport(string i_SerialNumber)
        {
            string report = String.Empty;
            if (IsVehicleExists(i_SerialNumber))
            {
                report = Tickets[i_SerialNumber].ToString();
            }

            return report;
        }
    }
}
