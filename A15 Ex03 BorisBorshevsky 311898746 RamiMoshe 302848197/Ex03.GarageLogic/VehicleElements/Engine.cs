using Ex03.GarageLogic.Energy;

namespace Ex03.GarageLogic.VehicleElements
{
    public abstract class Engine
    {
        public abstract void FillEnergy(BaseEnergy i_Energy);

        public abstract float GetEnergyLeftPrecent();
    }
}
