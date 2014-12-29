using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Vehicles;
using Ex03.GarageLogic.Energy;

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
            if (IsVehicleExists(i_Vehicle.LicencePlate))
            {
                throw new ArgumentException("Vehicle already exists");
            }

            Ticket ticket = new Ticket(i_CarOwnerName, i_CarOwnerPhone, i_Vehicle);
            Tickets.Add(i_Vehicle.LicencePlate, ticket);
        }

        public bool IsVehicleExists(string i_LicencePlate)
        {
            return Tickets.ContainsKey(i_LicencePlate);
        }

        public List<string> GetLicencePlatesInGarage()
        {
            return GetLicencePlatesInGarage(eVehicleState.Amendment | eVehicleState.Fixed | eVehicleState.Payed);
        }

        public List<string> GetLicencePlatesInGarage(eVehicleState i_VehicleState)
        {
            List<string> serialNumbers = new List<string>();
            foreach (var ticket in Tickets)
            {
                if ((ticket.Value.VehicleState & i_VehicleState) == ticket.Value.VehicleState)
                {
                    serialNumbers.Add(ticket.Key);
                }
            }

            return serialNumbers;
        }

        public void UpdateVehicleState(string i_LicencePlate, eVehicleState i_VehicleState)
        {
            if (!IsVehicleExists(i_LicencePlate))
            {
                throw new ArgumentException("Vehicle does not exists");
            }

            Tickets[i_LicencePlate].VehicleState = i_VehicleState;
        }

        public void FillManufacturerAirpressure(string i_LicencePlate)
        {
            if (!IsVehicleExists(i_LicencePlate))
            {
                throw new ArgumentException("Vehicle does not exists");
            }

            Tickets[i_LicencePlate].Vehicle.FillManufacturerAirPressure();
        }

        public void FuelVehicle(string i_LicencePlate, eFuelType i_FuelType, float i_AmountCc)
        {
            if (!IsVehicleExists(i_LicencePlate))
            {
                throw new ArgumentException("Vehicle does not exists");
            }

            // TODO: throw exeption when you try to fuel electric vehicle <DONE> <Where???>
            FuelEnergy fuelEnergy = new FuelEnergy(i_FuelType, i_AmountCc);
            Tickets[i_LicencePlate].Vehicle.FillEnergy(fuelEnergy);
        }

        public void ChargeVehicle(string i_LicencePlate, float i_AmountMinutes)
        {
            if (!IsVehicleExists(i_LicencePlate))
            {
                throw new ArgumentException("Vehicle does not exists");
            }

            // TODO: throw exeption when you try to charge fuel vehicle <DONE> <Where???>
            ElectricEnergy electricEnergy = new ElectricEnergy(i_AmountMinutes);
            Tickets[i_LicencePlate].Vehicle.FillEnergy(electricEnergy);
        }

        public string GetCarReport(string i_LicencePlate)
        {
            if (!IsVehicleExists(i_LicencePlate))
            {
                throw new ArgumentException("Vehicle does not exists");
            }

            return Tickets[i_LicencePlate].ToString();
        }
    }
}
