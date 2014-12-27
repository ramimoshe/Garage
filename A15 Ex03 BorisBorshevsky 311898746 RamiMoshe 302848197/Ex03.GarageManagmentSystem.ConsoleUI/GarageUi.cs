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
        private const int k_numOfVehicleTypes = 5;
        private const int k_numOfMotorcycleLicenseTypes = 4;
        private const int k_numOfColors = 4;
        private const bool v_isPossitiveNumberOnly = true;
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
                        vehicleLicencePlatesMenu();
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

        private uint getUintFromUser()
        {
            uint optionFromUser;

            while (!uint.TryParse(Console.ReadLine(), out optionFromUser))
            {
                Console.WriteLine("Invalid input, Please enter a positive number only.");
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
            Console.WriteLine("Please enter your car's licence plate");
            string serialNumber = Console.ReadLine();
            
            bool isInGarage = true;
            //bool isInGarage = Garage.IsVehicleInGarage(serialNumber);
            if (!isInGarage)
            {
                Console.WriteLine("Your car isn't in the garage. Please enter your car's details in order to instert is.");
                Console.WriteLine();

                InsertNewCarToGarage(serialNumber);
            }


        }

        private void InsertNewCarToGarage(string i_LicencePlate)
        {
            eVehicleType vehicleType = getVehicleTypeFromUser();
            Console.Write("Please enter your vehicle's Manufactirer:  ");
            string carsManufactorer = Console.ReadLine();


            if (vehicleType == eVehicleType.ElectricCar || vehicleType == eVehicleType.FuelCar)
            {
                eCarColor carColor = getColorTypeFromUser();
                eNumOfDoors numOfDoors = getNumOfDoorsFromUser();
            }
            else if (vehicleType == eVehicleType.ElectricMorotcycle || vehicleType == eVehicleType.FuelMorotcycle)
            {
                eMotorcycleLicenseType motorcycleLicenseType = getMotorcycleLicenseTypeFromUser();
                uint motorcycleEngineSize = getMotorcycleCcFromUser();
            }
            else if (vehicleType == eVehicleType.Truck)
            {
                Console.WriteLine("Is your truck carring dangerous materials?");
                bool isCarryngDangerousMatorials = getBoolFromUser();

                float maxCargoWeight = getMaxCargoCargoWeightFromUser();
                float currentCargoWeight = getCurrentCargoCargoWeightFromUser();
            }

            Console.Write("Please enter your vehicle's wheels Manufactirer:  ");
            string wheelsManufaturer = Console.ReadLine();
            Console.Write("Please enter your vehicle's wheels current air pressure:  ");
            float CurrentWheelAirPreasure = getFloatFromUser(v_isPossitiveNumberOnly);
        }

        private float getCurrentCargoCargoWeightFromUser()
        {
            Console.WriteLine("What is your current cargo weight?");
            return getFloatFromUser(v_isPossitiveNumberOnly);
        }

        private float getMaxCargoCargoWeightFromUser()
        {
            Console.WriteLine("What is your Max cargo weight?");
            return getFloatFromUser(v_isPossitiveNumberOnly);
        }


        private eNumOfDoors getNumOfDoorsFromUser()
        {
            const int k_numOfOptions = 4;
            
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("How many doors do you have?");
            stringBuilder.AppendLine(" (1) Two.");
            stringBuilder.AppendLine(" (2) Three.");
            stringBuilder.AppendLine(" (3) Four.");
            stringBuilder.AppendLine(" (4) Five.");
            Console.WriteLine(stringBuilder);

            int option = getMenuOptionFromUser(k_numOfOptions);

            return (eNumOfDoors)option;
        }


        private bool getBoolFromUser()
        {
            const int numOfOptions = 2;
            bool isTrue = true;;
            
            Console.WriteLine(" (1) Yes.");
            Console.WriteLine(" (2 No.");
            
            int result = getMenuOptionFromUser(numOfOptions);
            if (result == 2)
            {
                isTrue = false;
            }

            return isTrue;
        }

        private eMotorcycleLicenseType getMotorcycleLicenseTypeFromUser()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("What is the motorcycle license type type?");
            stringBuilder.AppendLine(" (1) A.");
            stringBuilder.AppendLine(" (2) A1.");
            stringBuilder.AppendLine(" (3) AB.");
            stringBuilder.AppendLine(" (4) B2.");
            Console.WriteLine(stringBuilder);

            int option = getMenuOptionFromUser(k_numOfMotorcycleLicenseTypes);
            
            return (eMotorcycleLicenseType)option;
        }

        private uint getMotorcycleCcFromUser()
        {
            Console.WriteLine("What is the motorcycle engine size (CC)?");
            return getUintFromUser();
        }


        private eVehicleType getVehicleTypeFromUser()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("What is your vehicle type?");
            stringBuilder.AppendLine(" (1) Fuel MotorCycle.");
            stringBuilder.AppendLine(" (2) Electric MotorCycle.");
            stringBuilder.AppendLine(" (3) Fuel Car.");
            stringBuilder.AppendLine(" (4) Electric Car.");
            stringBuilder.AppendLine(" (5) Truck.");
            Console.WriteLine(stringBuilder);

            int option = getMenuOptionFromUser(k_numOfVehicleTypes);

            return (eVehicleType)option;
        }

        private eCarColor getColorTypeFromUser()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("What is your vehicle Color?");
            stringBuilder.AppendLine(" (1) Blue.");
            stringBuilder.AppendLine(" (2) Green.");
            stringBuilder.AppendLine(" (3) Red.");
            stringBuilder.AppendLine(" (4) White.");
            Console.WriteLine(stringBuilder);
            
            int option = getMenuOptionFromUser(k_numOfColors);

            return (eCarColor)option;
        }




        private void vehicleLicencePlatesMenu()
        {
            printVehicleLicencePlatesMenu();

            int option = getMenuOptionFromUser(k_numOfOptionsInShowSerialsNumbersMenu);
            switch (option)
            {
                case 1:
                    showAllVechaleLicencePlates();
                    break;
                case 2:
                    filteredVehicleLicencePlatesMenu();
                    break;
                case 3:
                    break;
            }

            return;
        }

        private static void printVehicleLicencePlatesMenu()
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

        private void showAllVechaleLicencePlates()
        {
            /*Garage.GetGarageTickets().Keys;
            foreach (KeyValuePair<string, string> entry in MyDic)
            {
                // do something with entry.Value or entry.Key
            }*/
        }


        private void filteredVehicleLicencePlatesMenu()
        {
            printFilteredVehicleLicencePlatesMenu();
            int optionFromUser = getMenuOptionFromUser(k_numOfVehicleStates);
            switch (optionFromUser)
            {
                case 1:
                    showFilteredListOfLicencePlates(eVehicleState.Amendment);
                    break;
                case 2:
                    showFilteredListOfLicencePlates(eVehicleState.Fixed);
                    break;
                case 3:
                    showFilteredListOfLicencePlates(eVehicleState.Payed);
                    break;
            }
        }

        private void printFilteredVehicleLicencePlatesMenu()
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
            float amountToFuel = getFloatFromUser(v_isPossitiveNumberOnly);

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

        private float getFloatFromUser(bool isPossitiveOnly)
        {
            float optionFromUser;

            while (!float.TryParse(Console.ReadLine(), out optionFromUser) || (optionFromUser < 0 || !isPossitiveOnly))
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
            uint minutesToCharge = getUintFromUser();

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
                string carReport = Garage.GetCarReport(vehicleSerialId); // Garage.GetCarReport(vehicleSerialId);
                Console.WriteLine(carReport);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine("Operation failed");
                Console.WriteLine(ae.Message);
            } 
        }

        private void showFilteredListOfLicencePlates(eVehicleState i_FilteredBy)
        {

        }

    }
}
