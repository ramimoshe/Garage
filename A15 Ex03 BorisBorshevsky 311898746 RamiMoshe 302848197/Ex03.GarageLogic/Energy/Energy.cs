namespace Ex03.GarageLogic.EnergyRepo
{
    public abstract class Energy
    {
        public float Amount { get; set; }

        protected Energy(float i_Amount)
        {
            Amount = i_Amount;
        } 
    }
}
