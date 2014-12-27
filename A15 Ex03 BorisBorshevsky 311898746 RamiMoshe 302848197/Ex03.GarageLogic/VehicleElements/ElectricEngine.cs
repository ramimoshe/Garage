using Ex03.GarageLogic.Exceptions;
using System;
namespace Ex03.GarageLogic.VehicleElements
{
    public class ElectricEngine : Engine
    {
        private const float k_minimumWorkHoursRemining = 0f;

        public readonly float r_MaxWorkHour;

        private float m_WorkHoursRemining;

        public ElectricEngine(float i_WorkHoursRemining, float i_MaxWorkHour)
        {
            if (i_WorkHoursRemining > i_MaxWorkHour)
            {
                throw new ValueOutOfRangeException("Cant fill electric more then the maximum work hour", k_minimumWorkHoursRemining, i_MaxWorkHour);    
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

        public float WorkHoursRemining
        {
            get { return m_WorkHoursRemining; }
            private set { m_WorkHoursRemining = value; }
        }

        public override void FillEnergy(Engery i_Energy)
        {
            throw new NotImplementedException();
        }
    }
}
