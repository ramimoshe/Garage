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
            if (!IsVehicleExists(i_Vehicle.LicencePlate))
            {
                Ticket ticket = new Ticket(i_CarOwnerName, i_CarOwnerPhone, i_Vehicle);
                Tickets.Add(i_Vehicle.LicencePlate, ticket);
            }
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
                if ((ticket.Value.CarState & i_VehicleState) == ticket.Value.CarState)
                {
                    serialNumbers.Add(ticket.Key);
                }
            }

            return serialNumbers;
        }

        public void UpdateVehicleState(string i_LicencePlate, eVehicleState i_VehicleState)
        {
            Tickets[i_LicencePlate].CarState = i_VehicleState;
        }

        public void FillManufacturerAirpressure(string i_LicencePlate)
        {
            Tickets[i_LicencePlate].Vehicle.FillManufacturerAirPressure();
        }

        public void FuelVehicle(string i_LicencePlate, eFuelType i_FuelType, float i_AmountCc)
        {
            FuelEnergy fuelEnergy = new FuelEnergy(i_FuelType, i_AmountCc);
            Tickets[i_LicencePlate].Vehicle.Engine.FillEnergy(fuelEnergy);
        }

        public void ChargeVehicle(string i_LicencePlate, float i_AmountMinutes)
        {
            ElectricEnergy electricEnergy = new ElectricEnergy(i_AmountMinutes);
            Tickets[i_LicencePlate].Vehicle.Engine.FillEnergy(electricEnergy);
        }

        public string GetCarReport(string i_LicencePlate)
        {
            string report = String.Empty;
            if (IsVehicleExists(i_LicencePlate))
            {
                report = Tickets[i_LicencePlate].ToString();
            }

            return report;
        }
    }
}
