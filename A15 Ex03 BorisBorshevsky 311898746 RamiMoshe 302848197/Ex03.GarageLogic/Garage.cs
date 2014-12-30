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

        /// <summary>
        /// Create a Ticket for the Garage
        /// </summary>
        /// <param name="i_CarOwnerName"></param>
        /// <param name="i_CarOwnerPhone"></param>
        /// <param name="i_Vehicle">The vehicle</param>
        public void CreateTicket(string i_CarOwnerName, string i_CarOwnerPhone, Vehicle i_Vehicle)
        {
            if (IsVehicleExists(i_Vehicle.LicencePlate))
            {
                throw new ArgumentException("Vehicle already exists");
            }

            Ticket ticket = new Ticket(i_CarOwnerName, i_CarOwnerPhone, i_Vehicle);
            Tickets.Add(i_Vehicle.LicencePlate, ticket);
        }

        /// <summary>
        /// Check it a tickit for the vehicle already in the garage
        /// </summary>
        /// <param name="i_LicencePlate"></param>
        /// <returns></returns>
        public bool IsVehicleExists(string i_LicencePlate)
        {
            return Tickets.ContainsKey(i_LicencePlate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <return>List of License Plates in the garage</returns>
        public List<string> GetLicencePlatesInGarage()
        {
            return GetLicencePlatesInGarage(eVehicleState.Amendment | eVehicleState.Fixed | eVehicleState.Payed);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i_VehicleState">filter by</param>
        /// <returns>List of License Plated filtered by the eVehicleState</returns>
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
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i_LicencePlate"></param>
        /// <param name="i_VehicleState"></param>
        public void UpdateVehicleState(string i_LicencePlate, eVehicleState i_VehicleState)
        {
            if (!IsVehicleExists(i_LicencePlate))
            {
                throw new ArgumentException("Vehicle does not exists");
            }

            Tickets[i_LicencePlate].VehicleState = i_VehicleState;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i_LicencePlate"></param>
        public void FillManufacturerAirpressure(string i_LicencePlate)
        {
            if (!IsVehicleExists(i_LicencePlate))
            {
                throw new ArgumentException("Vehicle does not exists");
            }

            Tickets[i_LicencePlate].Vehicle.FillManufacturerAirPressure();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i_LicencePlate"></param>
        /// <param name="i_FuelType"></param>
        /// <param name="i_AmountCc">amount to add</param>
        public void FuelVehicle(string i_LicencePlate, eFuelType i_FuelType, float i_AmountCc)
        {
            if (!IsVehicleExists(i_LicencePlate))
            {
                throw new ArgumentException("Vehicle does not exists");
            }

            FuelEnergy fuelEnergy = new FuelEnergy(i_FuelType, i_AmountCc);
            Tickets[i_LicencePlate].Vehicle.FillEnergy(fuelEnergy);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i_LicencePlate"></param>
        /// <param name="i_HoursToAdd"></param>
        public void ChargeVehicle(string i_LicencePlate, float i_HoursToAdd)
        {
            if (!IsVehicleExists(i_LicencePlate))
            {
                throw new ArgumentException("Vehicle does not exists");
            }

            ElectricEnergy electricEnergy = new ElectricEnergy(i_HoursToAdd);
            Tickets[i_LicencePlate].Vehicle.FillEnergy(electricEnergy);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i_LicencePlate"></param>
        /// <returns>String of report</returns>
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
