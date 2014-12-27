namespace Ex03.GarageLogic.VehicleElements
{
    public class FuelEnergy : Engery
    {
        public eFuelType FuelType { get; set; }

        public FuelEnergy(eFuelType i_FuelType, float i_Amount)
            :base(i_Amount)
        {
            FuelType = i_FuelType;
        }
    }
}
