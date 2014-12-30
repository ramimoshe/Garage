using System;

namespace Ex03.GarageLogic.Exceptions
{
    /// <summary>
    /// Compatible when the value is out of range
    /// </summary>
    public class ValueOutOfRangeException : Exception
    {
        public float MaxValue { get; private set; }
        public float MinValue { get; private set; }

        public ValueOutOfRangeException(string i_Message, float i_MinValue, float i_MaxValue)
            : base(i_Message)
        {
            MaxValue = i_MaxValue;
            MinValue = i_MinValue;
        }

        public override string Message
        {
            get
            {
                return string.Format("Error! Your choice must be between {0} and {1}", MinValue, MaxValue);
            }
        }
    }
}