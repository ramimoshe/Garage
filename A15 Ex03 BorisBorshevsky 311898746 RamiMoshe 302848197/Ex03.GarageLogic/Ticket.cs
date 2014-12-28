using System.Text;
using Ex03.GarageLogic.VehicleElements;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic
{
    public class Ticket
    {
        private const eVehicleState k_DefaultVehicleState = eVehicleState.Amendment;
        private readonly string r_VehicleOwnerName;
        private readonly string r_VehicleOwnerPhone;
        private readonly Vehicle r_Vehicle;

        public string CarOwnerName { get { return r_VehicleOwnerName; } }
        public string CarOwnerPhone { get { return r_VehicleOwnerPhone; } }
        public Vehicle Vehicle { get { return r_Vehicle; } }
        public eVehicleState VehicleState { get; set; }

        public Ticket(string i_CarOwnerName, string i_CarOwnerPhone, Vehicle i_Vehicle)
        {
            r_Vehicle = i_Vehicle;
            VehicleState = k_DefaultVehicleState;
            r_VehicleOwnerName = i_CarOwnerName;
            r_VehicleOwnerPhone = i_CarOwnerPhone;
        }

        public override string ToString()
        {
            StringBuilder report = new StringBuilder();

            report.Append("Licence Plate: ");
            report.AppendLine(Vehicle.LicencePlate);

            report.Append("Model Name: ");
            report.AppendLine(Vehicle.ModelName);

            report.Append("Owner Name: ");
            report.AppendLine(CarOwnerName);

            report.Append("Owner Phone: ");
            report.AppendLine(CarOwnerPhone);

            report.Append("Vehicle State: ");
            report.AppendLine(VehicleState.ToString());

            report.AppendLine("Vehicle Tires Information: ");
            //TODO: Num Of wheels
            foreach (var tire in Vehicle.Tires)
            {
                report.Append("     Manufacturer Name: ");
                report.AppendLine(tire.ManufacturerName);
                report.Append("     Current Air Pressure: ");
                report.AppendLine(tire.CurrentAirPressure.ToString());
                //TODO: Max Air Pressure
            }

            report.AppendLine("Vehicle Energy: ");
            report.Append("     Energy Left Precent: ");
            
            //TODO: make this precent and not 0.54156385764
            report.AppendLine(Vehicle.GetEnergyLeftPrecent().ToString());
            report.Append("     Energy Type: ");
            if (isElectricVehicle(Vehicle))
            {
                report.AppendLine("     Electric");
            }
            else
            {
                report.Append("     Fuel - ");
                string fuelType = GetVehicleFuelType(Vehicle).Value.ToString();
                report.AppendLine(fuelType);
            }


            //TODO: Motorcycly License type
            //TODO: Motorcycly engine cc
            //TODO: color
            //TODO: num of doors
            //TODO: current cargo weight
            //TODO: max cargo weight
            //TODO: dangerous materials
            //TODO: Current amount of fuel
            //TODO: Max amount of fuel
            //TODO: Current amount of Electricity
            //TODO: Max amount of max amount of electricity



            return report.ToString();
        }

        private bool isElectricVehicle(Vehicle i_Vehicle)
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
