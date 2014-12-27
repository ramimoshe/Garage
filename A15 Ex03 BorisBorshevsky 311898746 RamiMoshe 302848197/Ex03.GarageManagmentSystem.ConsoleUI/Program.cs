using Ex03.GarageLogic;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageManagmentSystem.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            VehicleFactory.GenerateFuelCar("rami", "123", eCarColor.Blue, eNumOfDoors.Five, "asd", 1f, 2f);
            new GarageConsoleUi().Start();
        }
    }
}
