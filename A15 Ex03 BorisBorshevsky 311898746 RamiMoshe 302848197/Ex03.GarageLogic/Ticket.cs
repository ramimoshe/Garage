namespace Ex03.GarageLogic
{
    public class Ticket
    {
        public readonly string r_CarOwnerName;

        public readonly string r_CarOwnerPhone;

        public eVehicleState CarState { get; private set; }
    }
}
