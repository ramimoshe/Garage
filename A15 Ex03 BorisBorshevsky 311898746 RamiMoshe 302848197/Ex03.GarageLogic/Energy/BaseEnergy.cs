namespace Ex03.GarageLogic.Energy
{
    public abstract class BaseEnergy
    {
        public float Amount { get; set; }

        protected BaseEnergy(float i_Amount)
        {
            Amount = i_Amount;
        } 
    }
}
