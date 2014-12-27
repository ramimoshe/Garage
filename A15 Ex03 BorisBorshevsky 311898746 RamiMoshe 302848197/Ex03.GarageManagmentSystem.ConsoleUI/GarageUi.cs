using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Exceptions;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageManagmentSystem.ConsoleUI
{
    class GarageConsoleUi
    {
        private const int k_numOfOptionsInMainMenu = 8;
        private const int k_numOfOptionsInShowSerialsNumbersMenu = 3;
        private const int k_numOfVehicleStates = 3;
        private const int k_numOfFuelTypes = 4;

        private Garage Garage { get; set; }

        public GarageConsoleUi()
        {
            Garage = new Garage();
        }
        
        public void Start()
        {
            bool shouldExit = false;
            while (!shouldExit)
            {
                printMainMenu();
                int option = getMenuOptionFromUser(k_numOfOptionsInMainMenu);
                switch (option)
                {
                    case 1:
                        insertVehicleToGarage();
                        break;
                    case 2:
                        vehicleSerialNumbersMenu();
                        break;
                    case 3:
                        updateVehicleState();
                        break;
                    case 4:
                        fillAirPresure();
                        break;
                    case 5:
                        fuelVehicle();
                        break;
                    case 6:
                        chargeVehicle();
                        break;
                    case 7:
                        showVehicleReport();
                        break;
                    case 8:
                        shouldExit = true;
                        break;
                }
                
                if (option != 8) 
                {
                    pressAnyKeyToContinue();
                }
            }

            Console.WriteLine("Thanks for using garage system!");
            pressAnyKeyToContinue();
        }

        private void pressAnyKeyToContinue()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private int getMenuOptionFromUser(int i_NumOfOptions)
        {
            int optionFromUser;

            while (!int.TryParse(Console.ReadLine(), out optionFromUser) || optionFromUser < 1 || optionFromUser > i_NumOfOptions)
            {
                Console.WriteLine("Invalid input, Please choose number between 1 to {0} only.", i_NumOfOptions);
            }

            return optionFromUser;
        }

        private int getIntFromUser()
        {
            int optionFromUser;

            while (!int.TryParse(Console.ReadLine(), out optionFromUser))
            {
                Console.WriteLine("Invalid input, Please enter a number only.");
            }

            return optionFromUser;
        }
        

        private void printMainMenu()
        {
            Console.Clear();
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

        private void vehicleSerialNumbersMenu()
        {
            printVehicleSerialNumbersMenu();

            int option = getMenuOptionFromUser(k_numOfOptionsInShowSerialsNumbersMenu);
            switch (option)
            {
                case 1:
                    showAllVechaleSerialNumbers();
                    break;
                case 2:
                    filteredVehicleSerialNumbersMenu();
                    break;
                case 3:
                    break;
            }

            return;
        }

        private static void printVehicleSerialNumbersMenu()
        {
            Console.Clear();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Please choose what would you like to do:");
            stringBuilder.AppendLine("----------------------------------------");
            stringBuilder.AppendLine(" (1) Show all vehicles in the garage.");
            stringBuilder.AppendLine(" (2) Show vehicles in the garage filtered by state.");
            stringBuilder.AppendLine(" (3) Back to previous menu");
            Console.WriteLine(stringBuilder);
        }

        private void showAllVechaleSerialNumbers()
        {
            /*Garage.GetGarageTickets().Keys;
            foreach (KeyValuePair<string, string> entry in MyDic)
            {
                // do something with entry.Value or entry.Key
            }*/
        }


        private void filteredVehicleSerialNumbersMenu()
        {
            printFilteredVehicleSerialNumbersMenu();
            int optionFromUser = getMenuOptionFromUser(k_numOfVehicleStates);
            switch (optionFromUser)
            {
                case 1:
                    showFilteredListOfSerialNumbers(eVehicleState.Amendment);
                    break;
                case 2:
                    showFilteredListOfSerialNumbers(eVehicleState.Fixed);
                    break;
                case 3:
                    showFilteredListOfSerialNumbers(eVehicleState.Payed);
                    break;
            }
        }

        private void printFilteredVehicleSerialNumbersMenu()
        {
            Console.Clear();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("by What State do you want to Filter:");
            stringBuilder.AppendLine("----------------------------------------");
            stringBuilder.AppendLine(" (1) Fix in progress.");
            stringBuilder.AppendLine(" (2) Fixed.");
            stringBuilder.AppendLine(" (3) Payed.");
            Console.Write(stringBuilder);
        }

        private void updateVehicleState()
        {
            
            Console.WriteLine();
            Console.WriteLine("You are about to update vehicle state");

            string vehicleSerialId = getVehicleSerialFromUser();

            Console.WriteLine();
            Console.WriteLine("Please Choose the new state:");
            Console.WriteLine(" (1) Fix in progress.");
            Console.WriteLine(" (2) Fixed.");
            Console.WriteLine(" (3) Payed.");
            int option = getMenuOptionFromUser(k_numOfVehicleStates);
            try
            {
                switch (option)
                {
                    case 1:
                        Garage.UpdateVehicleState(vehicleSerialId, eVehicleState.Amendment);
                        break;
                    case 2:
                        Garage.UpdateVehicleState(vehicleSerialId, eVehicleState.Fixed);
                        break;
                    case 3:
                        Garage.UpdateVehicleState(vehicleSerialId, eVehicleState.Payed);
                        break;
                }
                Console.WriteLine("State for vehicle {0} updated", vehicleSerialId);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine("Operation failed");
                Console.WriteLine(ae.Message);
            }
        }

        private static string getVehicleSerialFromUser()
        {
            Console.WriteLine("Please enter the vehicle serial ID:");
            string vehicleSerialId = Console.ReadLine();
            return vehicleSerialId;
        }

        private void fillAirPresure()
        {
            Console.WriteLine();
            Console.WriteLine("You are about to fill your vehicle whells:");
            
            string vehicleSerialId = getVehicleSerialFromUser();

            try
            {
                Garage.FillManufacturerAirpressure(vehicleSerialId);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine("Operation failed");
                Console.WriteLine(ae.Message);
            }

        }

        private eFuelType getFuelTypeFromUser()
        {
            Console.WriteLine(" (1) Soler.");
            Console.WriteLine(" (2) Octan95.");
            Console.WriteLine(" (3) Octan96.");
            Console.WriteLine(" (4) Octan98.");

            int option = getMenuOptionFromUser(k_numOfFuelTypes);
                        
            return (eFuelType)option;
        }

        private void fuelVehicle()
        {
            Console.WriteLine();
            Console.WriteLine("You are about to fuel your vehicle:");
            string vehicleSerialId = getVehicleSerialFromUser();

            Console.WriteLine();
            Console.WriteLine("Please Choose fuel type:");
            eFuelType fuelType = getFuelTypeFromUser();

            Console.WriteLine("Please enter the amount to fuel:");
            float amountToFuel = getFloatFromUser();

            try
            {
                Garage.FuelVehicle(vehicleSerialId, fuelType, amountToFuel);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine("Operation failed");
                Console.WriteLine(ae.Message);
            }
            catch (ValueOutOfRangeException voore)
            {
                Console.WriteLine("Operation failed");
                Console.WriteLine(voore.Message);
            }
        }

        private float getFloatFromUser()
        {
            float optionFromUser;

            while (!float.TryParse(Console.ReadLine(), out optionFromUser))
            {
                Console.WriteLine("Invalid input, Please choose floating point number only.");
            }

            return optionFromUser;
        }

        private void chargeVehicle()
        {
            Console.WriteLine();
            Console.WriteLine("You are about to charge your vehicle:");
            string vehicleSerialId = getVehicleSerialFromUser();

            Console.WriteLine("for how many minutes whould you like to charge");
            int minutesToCharge = getIntFromUser();

            try
            {
                Garage.ChargeVehicle(vehicleSerialId, minutesToCharge);
            }
            catch (ValueOutOfRangeException voore)
            {
                Console.WriteLine("Operation failed");
                Console.WriteLine(voore.Message);
            }
        }

        private void showVehicleReport()
        {
            Console.WriteLine();
            Console.WriteLine("You are about to show Cars Report:");
            string vehicleSerialId = getVehicleSerialFromUser();
            try 
            { 
                Reports carReport = Garage.GetCarReport(vehicleSerialId);
                Console.WriteLine(carReport.ToString());
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine("Operation failed");
                Console.WriteLine(ae.Message);
            } 
        }

        private void showFilteredListOfSerialNumbers(eVehicleState i_FilteredBy)
        {

        }

    }
}
