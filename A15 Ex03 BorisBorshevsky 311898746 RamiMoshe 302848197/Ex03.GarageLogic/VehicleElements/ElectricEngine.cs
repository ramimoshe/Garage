using Ex03.GarageLogic.Energy;
using Ex03.GarageLogic.Exceptions;
using System;

namespace Ex03.GarageLogic.VehicleElements
{
    public class ElectricEngine : Engine
    {
        private const float k_MinimumWorkHoursRemining = 0f;

        private readonly float r_MaxWorkHour;

        public float WorkHoursRemining { get; private set; }
        public float MaxWorkHour { get { return r_MaxWorkHour; } }

        /// <param name="i_WorkHoursRemining">work hour remining</param>
        /// <param name="i_MaxWorkHour">max work hour</param>
        public ElectricEngine(float i_WorkHoursRemining, float i_MaxWorkHour)
        {
            if (i_WorkHoursRemining > i_MaxWorkHour)
            {
                throw new ValueOutOfRangeException("Can't fill more elextricity than maximum", k_MinimumWorkHoursRemining, i_MaxWorkHour);    
            }

            WorkHoursRemining = i_WorkHoursRemining;
            r_MaxWorkHour = i_MaxWorkHour;
        }

        /// <summary>
        /// Charge the engine
        /// </summary>
        /// <param name="i_Amount">Amount to charge</param>
        public void Charge(float i_Amount)
        {
            if (i_Amount < 0)
            {
                throw new ArgumentException("Cant add negative amount of electric");
            }

            if (i_Amount + WorkHoursRemining > r_MaxWorkHour)
            {
                throw new ValueOutOfRangeException("Cant fill air more then the maximum electric", k_MinimumWorkHoursRemining, r_MaxWorkHour);
            }

            WorkHoursRemining += i_Amount;
        }
        /// <summary>
        /// fill energy to engine
        /// </summary>
        /// <param name="i_Energy">Energy to add</param>
        public override void FillEnergy(BaseEnergy i_EnergyToAdd)
        {
            ElectricEnergy electricEnergy = i_EnergyToAdd as ElectricEnergy;
            if (electricEnergy == null)
            {
                throw new ArgumentException("Invalid type of energy");
            }

            ElectricEnergy energy = electricEnergy;
            Charge(energy.Amount);
        }

        public override float GetEnergyLeftPrecent()
        {
            return WorkHoursRemining / MaxWorkHour;
        }
    }
}
