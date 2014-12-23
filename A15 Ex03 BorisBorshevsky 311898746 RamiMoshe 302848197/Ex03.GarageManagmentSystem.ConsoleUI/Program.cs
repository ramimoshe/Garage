using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.GarageManagmentSystem.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            GarageUi ui = new GarageUi();
            ui.Start();
        }
    }

    class GarageUi
    {
        const int k_numOfOptionsInMainMenu = 8;
        const int k_numOfOptionsInShowSerialsNumbersMenu = 3;
        public void Start()
        {
            bool shouldExit = false;
            while (!shouldExit)
            {
                printMainMenu();
                int option = GetMenuOptionFromUser(k_numOfOptionsInMainMenu);
                switch (option)
                {
                    case 1:
                        insertVehicleToGarage();
                        break;
                    case 2:
                        VehicleSerialNumbersMenu();
                        break;
                    case 3:
                        UpdateVehicleState();
                        break;
                    case 4:
                        FillAirPresure();
                        break;
                    case 5:
                        FuelVehicle();
                        break;
                    case 6:
                        ChargeVehicle();
                        break;
                    case 7:
                        ShowVehicleReport();
                        break;
                    case 8:
                        shouldExit = true;    
                        break;
                }
            }

            // show bye bye
        }

        private int GetMenuOptionFromUser(int i_NumOfOptions)
        {
            int optionFromUser;

            while (!int.TryParse(Console.ReadLine(), out optionFromUser) || optionFromUser < 1 || optionFromUser > i_NumOfOptions)
            {
                Console.WriteLine("Invalid input, Please choose number between 1 to {0} only.",i_NumOfOptions);
            }

            return optionFromUser;
        }

        private void printMainMenu()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Please choose what would you like to do:");
            stringBuilder.AppendLine("----------------------------------------");
            stringBuilder.AppendLine(" (1) Insert a new vehicle to the Garage.");
            stringBuilder.AppendLine(" (2) Show a list of Vehicles in the garage.");
            stringBuilder.AppendLine(" (3) Change vehicle state.");
            stringBuilder.AppendLine(" (4) Fill air in vehicle's wheels.");
            stringBuilder.AppendLine(" (5) Change vehicle state.");
            stringBuilder.AppendLine(" (6) Fuel your vehicle (fuel Engine).");
            stringBuilder.AppendLine(" (7) Recharge your vehicle (electric Engine)");
            stringBuilder.AppendLine(" (8) Exit.");
            Console.WriteLine(stringBuilder);
        }

        private void insertVehicleToGarage()
        {
            
        }

        private void VehicleSerialNumbersMenu()
        {
            PrintVehicleSerialNumbersMenu();
            
            int option = GetMenuOptionFromUser(k_numOfOptionsInShowSerialsNumbersMenu);
            switch (option)
            {
                case 1:
                    ShowAllVechaleSerialNumbers();
                    break;
                case 2:
                    FilteredVehicleSerialNumbersMenu();
                    break;
                case 3:
                    break;
            }

            return;
        }

        private static void PrintVehicleSerialNumbersMenu()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Please choose what would you like to do:");
            stringBuilder.AppendLine("----------------------------------------");
            stringBuilder.AppendLine(" (1) Show all vehicles in the garage.");
            stringBuilder.AppendLine(" (2) Show vehicles in the garage filtered by state.");
            stringBuilder.AppendLine(" (3) Back to previous menu");
            Console.WriteLine(stringBuilder);
        }

        private void ShowAllVechaleSerialNumbers()
        {
            
        }

        private void FilteredVehicleSerialNumbersMenu()
        {
            PrintFilteredVehicleSerialNumbersMenu();
            int optionFromUser = GetMenuOptionFromUser(Enum.GetValues(typeof(eVehicleState)).Length);
            
            // print serial by filter(option)
        }

        private void PrintFilteredVehicleSerialNumbersMenu()
        {
            int menuCounter = 0;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("by What State do you want to Filter:");
            stringBuilder.AppendLine("----------------------------------------");

            foreach (eVehicleState vehicleState in (eVehicleState[])Enum.GetValues(typeof(eVehicleState)))
            {
                menuCounter++;
                stringBuilder.AppendFormat(" ({0}) {1}{2}", menuCounter, vehicleState.ToString(), Environment.NewLine);
            }
           
            Console.Write(stringBuilder);
        }

        private void UpdateVehicleState()
        {
            
        }

        private void FillAirPresure()
        {

        }

        private void FuelVehicle()
        {

        }

        private void ChargeVehicle()
        {

        }

        private void ShowVehicleReport()
        {

        }
    }
}
