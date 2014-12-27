using Ex03.GarageLogic.Exceptions;
using System;
namespace Ex03.GarageLogic.VehicleElements
{
    public class ElectricEngine
    {
        public readonly float r_MaxWorkHour;

        public ElectricEngine(float i_MaxWorkHour)
        {
            WorkHoursRemining = 0;
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

        public float WorkHoursRemining { get; private set; }
    }
}
