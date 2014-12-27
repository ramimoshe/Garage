using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic
{
    public class Ticket
    {
        private readonly string r_CarOwnerName;
        private readonly string r_CarOwnerPhone;
        private readonly Vehicle r_Vehicle;

        public Ticket(string i_CarOwnerName, string i_CarOwnerPhone,  Vehicle i_vehicle)
        {
            r_Vehicle = i_vehicle;
            CarState = eVehicleState.Amendment;
        }

        public string CarOwnerName
        {
            get { return r_CarOwnerName; }
        }

        public string CarOwnerPhone
        {
            get { return r_CarOwnerPhone; }
        }

        public Vehicle Vehicle
        {
            get { return r_Vehicle; }
        }

        public eVehicleState CarState { get; set; }
    }
}
