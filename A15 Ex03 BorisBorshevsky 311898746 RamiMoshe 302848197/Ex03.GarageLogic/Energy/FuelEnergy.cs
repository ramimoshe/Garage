namespace Ex03.GarageLogic.Energy
{
    /// <summary>
    /// Fuel energy
    /// </summary>
    public class FuelEnergy : BaseEnergy
    {
        public eFuelType FuelType { get; set; }

        public FuelEnergy(eFuelType i_FuelType, float i_Amount)
            :base(i_Amount)
        {
            FuelType = i_FuelType;
        }
    }
}
