using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.VehicleElements
{
    public abstract class Engery
    {
        protected Engery(float i_Amount)
        {
            Amount = i_Amount;
        }

        public float Amount { get; set; }
    }
}
