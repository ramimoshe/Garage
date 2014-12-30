using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Exceptions;
using Ex03.GarageLogic.VehicleElements;

namespace Ex03.GarageLogic.Vehicles
{
    public class Truck : Vehicle
    {
        private readonly float r_MaxCargoWeightAllowed;

        private float m_CurrentCargoWeight;

        public float MaxCargoWeightAllowed { get { return r_MaxCargoWeightAllowed; } }

        public bool IsContainsDangerusMatirial { get; set; }

        public float CurrentCargoWeight 
        {
            get { return m_CurrentCargoWeight; }
            set
            {
                if (m_CurrentCargoWeight + value > MaxCargoWeightAllowed)
                {
                    throw new ValueOutOfRangeException("Cannt cary more then the maximum", 0, r_MaxCargoWeightAllowed);
                }

                m_CurrentCargoWeight = value;
            } 
        }

        public Truck(string i_ModelName, string i_LicencePlate, List<Tire> i_Tires, float i_MaxCargoWeightAllowed, Engine i_Engine)
            : base(i_ModelName, i_LicencePlate, i_Tires, i_Engine)
        {
            if (i_MaxCargoWeightAllowed > 0)
            {
                r_MaxCargoWeightAllowed = i_MaxCargoWeightAllowed;
            }
            else
            {
                throw new ArgumentException("Max cargo weight allowed should be positive only");   
            }
        }

        public override float GetEnergyLeftPrecent()
        {
            return Engine.GetEnergyLeftPrecent();
        }

        public override string ToString()
        {
            return "Truck";
        }
    }
}