﻿using Ex03.GarageLogic.Exceptions;
using System;

namespace Ex03.GarageLogic.VehicleElements
{
    public class ElectricEngine : Engine
    {
        private const float k_MinimumWorkHoursRemining = 0f;

        private readonly float r_MaxWorkHour;

        public float WorkHoursRemining { get; private set; }
        public float MaxWorkHour { get { return r_MaxWorkHour; } }

        public ElectricEngine(float i_WorkHoursRemining, float i_MaxWorkHour)
        {
            if (i_WorkHoursRemining > i_MaxWorkHour)
            {
                throw new ValueOutOfRangeException("Cant fill electric more then the maximum work hour", k_MinimumWorkHoursRemining, i_MaxWorkHour);    
            }

            WorkHoursRemining = i_WorkHoursRemining;
            r_MaxWorkHour = i_MaxWorkHour;
        }

        public void Charge(float i_Amount)
        {
            if (i_Amount < 0)
            {
                throw new ArgumentException("Cant add negative amount of electric");
            }

            if (i_Amount + WorkHoursRemining > r_MaxWorkHour)
            {
                throw new ValueOutOfRangeException("Cant fill air more then the maximum electric", 0, r_MaxWorkHour);
            }

            WorkHoursRemining += i_Amount;
        }

        public override void FillEnergy(Engery i_Energy)
        {
            if (i_Energy is FuelEnergy)
            {
                ElectricEnergy energy = (ElectricEnergy)i_Energy;
                Charge(energy.Amount);
            }
        }

        public override float GetEnergyLeftPrecent()
        {
            return WorkHoursRemining / MaxWorkHour;
        }
    }
}
