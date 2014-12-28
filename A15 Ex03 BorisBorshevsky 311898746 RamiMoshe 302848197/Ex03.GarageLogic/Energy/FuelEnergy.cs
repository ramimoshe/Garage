namespace Ex03.GarageLogic.EnergyRepo
{
    public class FuelEnergy : Energy
    {
        public eFuelType FuelType { get; set; }

        public FuelEnergy(eFuelType i_FuelType, float i_Amount)
            :base(i_Amount)
        {
            FuelType = i_FuelType;
        }
    }
}
