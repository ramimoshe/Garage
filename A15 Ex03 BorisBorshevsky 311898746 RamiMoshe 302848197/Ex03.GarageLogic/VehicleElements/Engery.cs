namespace Ex03.GarageLogic.VehicleElements
{
    public abstract class Engery
    {
        public float Amount { get; set; }

        protected Engery(float i_Amount)
        {
            Amount = i_Amount;
        } 
    }
}
