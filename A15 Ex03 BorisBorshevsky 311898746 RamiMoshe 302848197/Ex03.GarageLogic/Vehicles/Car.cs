﻿using System.Collections.Generic;
using Ex03.GarageLogic.VehicleElements;

namespace Ex03.GarageLogic.Vehicles
{
    public class Car : Vehicle
    {
        private readonly eCarColor r_Color; //TODO: Print it into report & make private
        private readonly eNumOfDoors r_NumOfDoors; //TODO: Print it into report & make private

        public Car(string i_ModelName, string i_LicencePlate, List<Tire> i_Tires, eCarColor i_Color, eNumOfDoors i_Doors, Engine i_Engine)
            : base(i_ModelName, i_LicencePlate, i_Tires, i_Engine)
        {
            r_Color = i_Color;
            r_NumOfDoors = i_Doors;
        }

        public override float GetEnergyLeftPrecent()
        {
            return Engine.GetEnergyLeftPrecent();
        }
    }
}
