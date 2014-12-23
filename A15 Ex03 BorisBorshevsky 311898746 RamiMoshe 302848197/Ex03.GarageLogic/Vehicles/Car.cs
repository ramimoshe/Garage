using System.Collections.Generic;
using Ex03.GarageLogic.VehicleElements;

namespace Ex03.GarageLogic.Vehicles
{
    public abstract class Car : Vehicle
    {
        public readonly eCarColor r_Color;
        public readonly eNumOfDoors r_NumOfDoors;

        protected Car(string i_ModelName, string i_SerialNumber, List<Wheel> i_Wheels, eCarColor i_Color, eNumOfDoors i_Doors)
            : base(i_ModelName, i_SerialNumber, i_Wheels)
        {
            r_Color = i_Color;
            r_NumOfDoors = i_Doors;
        }
    }
}
