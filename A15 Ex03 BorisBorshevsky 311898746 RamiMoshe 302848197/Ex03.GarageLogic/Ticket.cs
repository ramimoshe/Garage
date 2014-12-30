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

            report.Append("Vehicle Type: ");
            report.AppendLine(Vehicle.ToString());

            report.Append("Owner Name: ");
            report.AppendLine(CarOwnerName);

            report.Append("Owner Phone: ");
            report.AppendLine(CarOwnerPhone);

            report.Append("Vehicle State: ");
            report.AppendLine(VehicleState.ToString());

            report.AppendLine("Vehicle Tires Information: ");
            report.Append("     Number Of Wheels: ");
            report.AppendLine(Vehicle.Tires.Count.ToString());
            foreach (var tire in Vehicle.Tires)
            {
                report.Append("     Manufacturer Name: ");
                report.AppendLine(tire.ManufacturerName);
                report.Append("     Current Air Pressure: ");
                report.AppendLine(tire.CurrentAirPressure.ToString());
                report.Append("     Maximum Air Pressure: ");
                report.AppendLine(tire.MaxManufacturerAirPressure.ToString());
            }

            report.AppendLine("Vehicle Energy: ");
            if (isElectricVehicle(Vehicle))
            {
                report.AppendLine("     Energy Type: Electric");

                report.Append("     Max Energy: "); 
                ElectricEngine electricEngine = Vehicle.Engine as ElectricEngine;
                report.Append(electricEngine.MaxWorkHour.ToString());
                report.AppendLine(" hours");

                report.Append("     Current Amount: "); 
                report.Append((Vehicle.Engine as ElectricEngine).WorkHoursRemining);
                report.AppendLine(" hours");
            }
            else
            {
                report.Append("     Energy Type: Fuel - ");
                string fuelType = getVehicleFuelType(Vehicle).Value.ToString();
                report.AppendLine(fuelType);

                report.Append("     Max Energy: "); 
                FuelEngine fuelEngine = Vehicle.Engine as FuelEngine;
                report.Append(fuelEngine.MaxFuelAmount.ToString());
                report.AppendLine(" liters");

                report.Append("     Current Amount: "); 
                report.Append((Vehicle.Engine as FuelEngine).CurrentFuelAmount);
                report.AppendLine(" liters");
            }
            report.Append("     Energy Left Precent: ");
            report.AppendLine(Vehicle.GetEnergyLeftPrecent().ToString("P"));

            Car car = Vehicle as Car;
            if (car != null)
            {
                report.Append("Car Color: ");
                report.AppendLine(car.Color.ToString());
                report.Append("Number Of Doors: ");
                report.AppendLine(car.NumOfDoors.ToString());
            }

            var motorcycle = Vehicle as Motorcycle;
            if (motorcycle != null)
            {
                report.Append("Motorcycly License Type: ");
                report.AppendLine(motorcycle.LicenseType.ToString());
                report.Append("Motorcycly Engine cc: ");
                report.AppendLine(motorcycle.EngineCc.ToString());
            }

            Truck truck = Vehicle as Truck;
            if (truck != null)
            {
                report.Append("Max Cargo Weight: ");
                report.AppendLine(truck.MaxCargoWeightAllowed.ToString());
                report.Append("Current Cargo Weight: ");
                report.AppendLine(truck.CurrentCargoWeight.ToString());
                report.Append("Contain Dangerous Materials: ");
                report.AppendLine(truck.IsContainsDangerusMatirial.ToString());
            }
            
            return report.ToString();
        }

        private bool isElectricVehicle(Vehicle i_Vehicle)
        {
            return i_Vehicle.Engine is ElectricEngine;
        }

        private eFuelType? getVehicleFuelType(Vehicle i_Vehicle)
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