using System.Text;
using Ex03.GarageLogic.VehicleElements;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic
{
    public class Ticket
    {
        private readonly string r_CarOwnerName;
        private readonly string r_CarOwnerPhone;
        private readonly Vehicle r_Vehicle;

        public string CarOwnerName { get { return r_CarOwnerName; } }
        public string CarOwnerPhone { get { return r_CarOwnerPhone; } }
        public Vehicle Vehicle { get { return r_Vehicle; } }
        public eVehicleState CarState { get; set; }

        public Ticket(string i_CarOwnerName, string i_CarOwnerPhone, Vehicle i_Vehicle)
        {
            r_Vehicle = i_Vehicle;
            CarState = eVehicleState.Amendment;
        }

        public override string ToString()
        {
            StringBuilder report = new StringBuilder();

            report.Append("Serial Number: ");
            report.AppendLine(Vehicle.SerialNumber);

            report.Append("Model Name: ");
            report.AppendLine(Vehicle.ModelName);

            report.Append("Owner Name: ");
            report.AppendLine(CarOwnerName);

            report.Append("Owner Phone: ");
            report.AppendLine(CarOwnerPhone);

            report.Append("Vehicle State: ");
            report.AppendLine(CarState.ToString());

            report.AppendLine("Vehicle Tires Information: ");
            foreach (var tire in Vehicle.Tires)
            {
                report.Append(" Manufacturer Name: ");
                report.AppendLine(tire.ManufacturerName);
                report.Append(" Current Air Pressure: ");
                report.AppendLine(tire.CurrentAirPressure.ToString());
            }

            report.AppendLine("Vehicle Energy: ");
            report.Append(" Energy Left Precent: ");
            report.AppendLine(Vehicle.GetEnergyLeftPrecent().ToString());
            report.Append(" Energy Type: ");
            if (IsElectricVehicle(Vehicle))
            {
                report.AppendLine(" Electric");
            }
            else
            {
                report.Append(" Fuel - ");
                string fuelType = GetVehicleFuelType(Vehicle).Value.ToString();
                report.AppendLine(fuelType);
            }

            return report.ToString();
        }

        private bool IsElectricVehicle(Vehicle i_Vehicle)
        {
            return i_Vehicle.Engine is ElectricEngine;
        }

        private eFuelType? GetVehicleFuelType(Vehicle i_Vehicle)
        {
            eFuelType? fuelType = null;
            FuelEngine fuelEngine = i_Vehicle.Engine as FuelEngine;
            if (fuelEngine != null)
            {
                fuelType = fuelEngine.FuelType;
            }

            return fuelType;
        }
    }
}
