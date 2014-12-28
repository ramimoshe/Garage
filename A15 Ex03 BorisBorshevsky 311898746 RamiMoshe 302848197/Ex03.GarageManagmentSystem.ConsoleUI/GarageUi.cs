using System;
using System.Text;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Exceptions;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageManagmentSystem.ConsoleUI
{
    class GarageConsoleUi
    {
        private const bool v_IsPossitiveNumberOnly = true;

        private Garage Garage { get; set; }

        /*
         * -------------------SSSSSSTTTTTUUUUUUBBBBBB
         * 
         */

        public void InjectVehicls()
        {

            Vehicle car1 = VehicleFactory.GenerateFuelCar("Mazda", "F1", eCarColor.Blue, eNumOfDoors.Four, "Mislen", 23.5f, 10.5f);
            Vehicle car2 = VehicleFactory.GenerateFuelCar("Toyota", "F2", eCarColor.Blue, eNumOfDoors.Five, "Mishlen", 20.5f, 14.5f);
            Vehicle car3 = VehicleFactory.GenerateFuelCar("Audi", "F3", eCarColor.Green, eNumOfDoors.Two, "Carmel", 25.5f, 17.5f);
            Vehicle car4 = VehicleFactory.GenerateElectricCar("Audi", "E1", eCarColor.Green, eNumOfDoors.Two, "Carmel", 25.5f, 0.5f);
            Vehicle car5 = VehicleFactory.GenerateElectricCar("AR", "E2", eCarColor.White, eNumOfDoors.Three, "Mish", 22f, 1.2f);
            Vehicle car6 = VehicleFactory.GenerateElectricMorotcycle("ElMotor", "E3", eMotorcycleLicenseType.A, 100, "misg", 12f, 1f);
            Vehicle car7 = VehicleFactory.GenerateFuelMorotcycle("ElMotor", "F4", eMotorcycleLicenseType.A, 100, "misg", 12f, 1f);
            Vehicle car8 = VehicleFactory.GenerateTruck("hitachi", "T1", 100f, 80f, "mishlen", 20f, 50f, true);

            Garage.CreateTicket("Boris", "050111111", car1);
            Garage.CreateTicket("David", "050222222", car2);
            Garage.CreateTicket("Rami", "050333333", car3);
            Garage.CreateTicket("Eli", "050444444", car4);
            Garage.CreateTicket("Rafi", "050555555", car5);
            Garage.CreateTicket("Ofer", "050666666", car6);
            Garage.CreateTicket("Yossi", "050777777", car7);
            Garage.CreateTicket("Jager", "050888888", car8);
        }

        /*
         * 
         * 
         */

        public GarageConsoleUi()
        {
            Garage = new Garage();
            InjectVehicls();
        }

        public void Start()
        {
            const int numOfOptions = 8;

            bool shouldExit = false;
            while (!shouldExit)
            {
                printMainMenu();
                int option = getMenuOptionFromUser(numOfOptions);
                try
                {
                    switch (option)
                    {
                        case 1:
                            insertVehicleToGarage();
                            break;
                        case 2:
                            vehicleLicensePlateNumbersMenu();
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
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine("Operation failed");
                    Console.WriteLine(e.Message);
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

            while (true)
            {
                try
                {
                    optionFromUser = int.Parse(Console.ReadLine());
                    if (optionFromUser >= 1 && optionFromUser <= i_NumOfOptions)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, Please choose number between 1 to {0} only.", i_NumOfOptions);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Bad input, Please use integers only");
                }
            }

            return optionFromUser;
        }

        private int getMenuOptionFromUserWithTryParse(int i_NumOfOptions)
        {
            int optionFromUser;
            
            while (!int.TryParse(Console.ReadLine(), out optionFromUser) || optionFromUser < 1 || optionFromUser > i_NumOfOptions)
            {
                Console.WriteLine("Invalid input, Please choose number between 1 to {0} only.", i_NumOfOptions);
            }

            return optionFromUser;
        }

        private int getIntFromUser(bool i_IsPossitiveOnly)
        {
            int optionFromUser;

            while (!int.TryParse(Console.ReadLine(), out optionFromUser) || (optionFromUser < 0 || !i_IsPossitiveOnly))
            {
                Console.WriteLine("Invalid input, Please enter a {0}number only.", i_IsPossitiveOnly ? "possitive " : "");
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
            stringBuilder.AppendLine(" (5) Fuel your vehicle (fuel Engine).");
            stringBuilder.AppendLine(" (6) Recharge your vehicle (electric Engine)");
            stringBuilder.AppendLine(" (7) Report about your vehicle.");
            stringBuilder.AppendLine(" (8) Exit.");
            Console.WriteLine(stringBuilder);
        }

        private void insertVehicleToGarage()
        {
            string licensePlate = getLicensePlateFromUser();

            bool isInGarage = Garage.IsVehicleExists(licensePlate);
            if (!isInGarage)
            {
                Console.WriteLine("Your car isn't in the garage. Please enter your car's details in order to instert is.");
                Console.WriteLine();

                insertNewVehicleToGarage(licensePlate);
            }
            else
            {
                Console.WriteLine("Vehicle Already in the garage!!");
            }
        }

        private static string getLicensePlateFromUser()
        {
            Console.WriteLine("Please enter your car's licence plate");
            return Console.ReadLine();
        }

        private void insertNewVehicleToGarage(string i_LicencePlate)
        {
            try
            {
                int motorcycleEngineSize;
                float currentEnergyLeft;
                float currentFuelAmmount;
                eCarColor carColor;
                eNumOfDoors numOfDoors;
                eMotorcycleLicenseType motorcycleLicenseType;
                Vehicle vehicle;

                eVehicleType vehicleType = getVehicleTypeFromUser();
                string ownerPhone = getOwnerPhoneFromUser();
                string vehicleModel = getVehicleModelFromUser();
                string wheelsManufaturer = getTireManufactorerFromUser();
                float currentWheelAirPreasure = getCurrentTireAirPressureFromUser();
                string ownerName = getOwnerNameFromUser();

                switch (vehicleType)
                {
                    case eVehicleType.FuelMorotcycle:
                        motorcycleLicenseType = getMotorcycleLicenseTypeFromUser();
                        motorcycleEngineSize = getMotorcycleCcFromUser();
                        currentFuelAmmount = getCurrentFuelAmountFromUser();
                        vehicle = VehicleFactory.GenerateFuelMorotcycle(vehicleModel, i_LicencePlate, motorcycleLicenseType, motorcycleEngineSize, wheelsManufaturer, currentWheelAirPreasure, currentFuelAmmount);
                        break;

                    case eVehicleType.ElectricMorotcycle:
                        motorcycleLicenseType = getMotorcycleLicenseTypeFromUser();
                        motorcycleEngineSize = getMotorcycleCcFromUser();
                        currentEnergyLeft = getCurrentEnergyLeftFromUser();
                        vehicle = VehicleFactory.GenerateElectricMorotcycle(vehicleModel, i_LicencePlate, motorcycleLicenseType, motorcycleEngineSize, wheelsManufaturer, currentWheelAirPreasure, currentEnergyLeft);
                        break;

                    case eVehicleType.FuelCar:
                        carColor = getColorTypeFromUser();
                        numOfDoors = getNumOfDoorsFromUser();
                        currentFuelAmmount = getCurrentFuelAmountFromUser();
                        vehicle = VehicleFactory.GenerateFuelCar(vehicleModel, i_LicencePlate, carColor, numOfDoors, wheelsManufaturer, currentWheelAirPreasure, currentFuelAmmount);
                        break;

                    case eVehicleType.ElectricCar:
                        carColor = getColorTypeFromUser();
                        numOfDoors = getNumOfDoorsFromUser();
                        currentEnergyLeft = getCurrentEnergyLeftFromUser();
                        vehicle = VehicleFactory.GenerateElectricCar(vehicleModel, i_LicencePlate, carColor, numOfDoors, wheelsManufaturer, currentWheelAirPreasure, currentEnergyLeft);
                        break;

                    case eVehicleType.Truck:
                        var isCarryngDangerousMaterials = getIsCarryingDangerousMaterialsFromUser();
                        var maxCargoWeight = getMaxCargoCargoWeightFromUser();
                        var currentCargoWeight = getCurrentCargoCargoWeightFromUser();
                        currentFuelAmmount = getCurrentFuelAmountFromUser();
                        vehicle = VehicleFactory.GenerateTruck(vehicleModel, i_LicencePlate, maxCargoWeight, currentCargoWeight, wheelsManufaturer, currentWheelAirPreasure, currentFuelAmmount, isCarryngDangerousMaterials);
                        break;

                    default:
                        throw new ArgumentException("not a vehicle availble at the menu");
                }

                Garage.CreateTicket(ownerName, ownerPhone, vehicle);
                Console.WriteLine("your vehicle had been inserted to the garage!");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine("Operation Failed - bad argument");
                Console.WriteLine(ae.Message);
            }
            catch (ValueOutOfRangeException voore)
            {
                Console.WriteLine("Operation Failed - bad value entered");
                Console.WriteLine(voore.Message);
            }

        }

        private static string getOwnerPhoneFromUser()
        {
            Console.Write("please enter your phone number:  ");
            return Console.ReadLine();
        }

        private static string getOwnerNameFromUser()
        {
            Console.Write("please enter your name:  ");
            return Console.ReadLine();
        }

        private float getCurrentTireAirPressureFromUser()
        {
            Console.Write("Please enter your vehicle's wheels current air pressure:  ");
            return getFloatFromUser(v_IsPossitiveNumberOnly);
        }

        private static string getTireManufactorerFromUser()
        {
            Console.Write("Please enter your vehicle's wheels Manufactirer:  ");
            return Console.ReadLine();
        }

        private static string getVehicleModelFromUser()
        {
            Console.Write("Please enter your vehicle's model:  ");
            return Console.ReadLine();
        }

        private float getCurrentEnergyLeftFromUser()
        {
            Console.WriteLine("How many hours left in your Engine's battary?");
            return getFloatFromUser(v_IsPossitiveNumberOnly);
        }

        private float getCurrentFuelAmountFromUser()
        {
            Console.WriteLine("How much fuel do you have? (Liters)");
            return getFloatFromUser(v_IsPossitiveNumberOnly);
        }

        private bool getIsCarryingDangerousMaterialsFromUser()
        {
            Console.WriteLine("Is your truck carring dangerous materials?");
            return getBoolFromUser();
        }

        private float getCurrentCargoCargoWeightFromUser()
        {
            Console.WriteLine("What is your current cargo weight?");
            return getFloatFromUser(v_IsPossitiveNumberOnly);
        }

        private float getMaxCargoCargoWeightFromUser()
        {
            Console.WriteLine("What is your Max cargo weight?");
            return getFloatFromUser(v_IsPossitiveNumberOnly);
        }

        private eNumOfDoors getNumOfDoorsFromUser()
        {
            const int numOfOptions = 4;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("How many doors do you have?");
            stringBuilder.AppendLine(" (1) Two.");
            stringBuilder.AppendLine(" (2) Three.");
            stringBuilder.AppendLine(" (3) Four.");
            stringBuilder.AppendLine(" (4) Five.");
            Console.WriteLine(stringBuilder);

            int option = getMenuOptionFromUser(numOfOptions);

            return (eNumOfDoors)option;
        }


        private bool getBoolFromUser()
        {
            const int numOfOptions = 2;
            bool isTrue = true;

            Console.WriteLine(" (1) Yes.");
            Console.WriteLine(" (2) No.");

            int result = getMenuOptionFromUser(numOfOptions);
            if (result == 2)
            {
                isTrue = false;
            }

            return isTrue;
        }

        private eMotorcycleLicenseType getMotorcycleLicenseTypeFromUser()
        {
            const int numOfMotorcycleLicenseTypes = 4;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("What is the motorcycle license type type?");
            stringBuilder.AppendLine(" (1) A.");
            stringBuilder.AppendLine(" (2) A1.");
            stringBuilder.AppendLine(" (3) AB.");
            stringBuilder.AppendLine(" (4) B2.");
            Console.WriteLine(stringBuilder);

            int option = getMenuOptionFromUser(numOfMotorcycleLicenseTypes);

            return (eMotorcycleLicenseType)option;
        }

        private int getMotorcycleCcFromUser()
        {
            Console.WriteLine("What is the motorcycle engine size (CC)?");
            return getIntFromUser(v_IsPossitiveNumberOnly);
        }

        private eVehicleType getVehicleTypeFromUser()
        {
            const int numOfOptions = 5;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("What is your vehicle type?");
            stringBuilder.AppendLine(" (1) Fuel MotorCycle.");
            stringBuilder.AppendLine(" (2) Electric MotorCycle.");
            stringBuilder.AppendLine(" (3) Fuel Car.");
            stringBuilder.AppendLine(" (4) Electric Car.");
            stringBuilder.AppendLine(" (5) Truck.");
            Console.WriteLine(stringBuilder);

            int option = getMenuOptionFromUser(numOfOptions);

            return (eVehicleType)option;
        }

        private eCarColor getColorTypeFromUser()
        {
            const int numOfOptions = 4;

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("What is your vehicle Color?");
            stringBuilder.AppendLine(" (1) Blue.");
            stringBuilder.AppendLine(" (2) Green.");
            stringBuilder.AppendLine(" (3) Red.");
            stringBuilder.AppendLine(" (4) White.");
            Console.WriteLine(stringBuilder);

            int option = getMenuOptionFromUser(numOfOptions);

            return (eCarColor)option;
        }

        private void vehicleLicensePlateNumbersMenu()
        {
            const int numOfOptions = 3;

            Console.Clear();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Please choose what would you like to do:");
            stringBuilder.AppendLine("----------------------------------------");
            stringBuilder.AppendLine(" (1) Show all vehicles in the garage.");
            stringBuilder.AppendLine(" (2) Show vehicles in the garage filtered by state.");
            stringBuilder.AppendLine(" (3) Back to previous menu");
            Console.WriteLine(stringBuilder);

            int option = getMenuOptionFromUser(numOfOptions);

            switch (option)
            {
                case 1:
                    showAllVechaleLicensePlates();
                    break;
                case 2:
                    filteredVehicleLicensePlatesMenu();
                    break;
                case 3:
                    break;
            }
        }


        private void showAllVechaleLicensePlates()
        {
            int counter = 0;
            Console.Clear();
            Console.WriteLine("List of vehicles:");
            Console.WriteLine("-----------------");
            foreach (string licensePlate in Garage.GetLicencePlatesInGarage())
            {
                counter++;
                Console.WriteLine("{0}. {1}.", counter, licensePlate);
            }
        }

        private void filteredVehicleLicensePlatesMenu()
        {
            const int numOfOptions = 3;

            Console.Clear();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("by What State do you want to Filter:");
            stringBuilder.AppendLine("----------------------------------------");
            stringBuilder.AppendLine(" (1) Fix in progress.");
            stringBuilder.AppendLine(" (2) Fixed.");
            stringBuilder.AppendLine(" (3) Payed.");
            Console.Write(stringBuilder);

            int optionFromUser = getMenuOptionFromUser(numOfOptions);
            switch (optionFromUser)
            {
                case 1:
                    showFilteredListOfLicensePlates(eVehicleState.Amendment);
                    break;
                case 2:
                    showFilteredListOfLicensePlates(eVehicleState.Fixed);
                    break;
                case 3:
                    showFilteredListOfLicensePlates(eVehicleState.Payed);
                    break;
            }
        }

        private void updateVehicleState()
        {
            const int numOfOptions = 3;

            Console.WriteLine("You are about to update vehicle state");
            string licensePlate = getLicensePlateFromUser();
            Console.WriteLine();
            Console.WriteLine("Please Choose the new state:");
            Console.WriteLine(" (1) Fix in progress.");
            Console.WriteLine(" (2) Fixed.");
            Console.WriteLine(" (3) Payed.");
            int option = getMenuOptionFromUser(numOfOptions);
            try
            {
                switch (option)
                {
                    case 1:
                        Garage.UpdateVehicleState(licensePlate, eVehicleState.Amendment);
                        break;
                    case 2:
                        Garage.UpdateVehicleState(licensePlate, eVehicleState.Fixed);
                        break;
                    case 3:
                        Garage.UpdateVehicleState(licensePlate, eVehicleState.Payed);
                        break;
                }
                Console.WriteLine("State for vehicle {0} updated", licensePlate);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine("Operation failed");
                Console.WriteLine(ae.Message);
            }
        }

        private void fillAirPresure()
        {
            Console.WriteLine();
            Console.WriteLine("You are about to fill your vehicle tires:");

            string licensePlate = getLicensePlateFromUser();

            try
            {
                Garage.FillManufacturerAirpressure(licensePlate);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine("Operation failed");
                Console.WriteLine(ae.Message);
            }

        }

        private eFuelType getFuelTypeFromUser()
        {
            const int numOfOptions = 4;

            Console.WriteLine(" (1) Soler.");
            Console.WriteLine(" (2) Octan95.");
            Console.WriteLine(" (3) Octan96.");
            Console.WriteLine(" (4) Octan98.");

            int option = getMenuOptionFromUser(numOfOptions);

            return (eFuelType)option;
        }

        private void fuelVehicle()
        {
            Console.WriteLine();
            Console.WriteLine("You are about to fuel your vehicle:");
            string licensePlate = getLicensePlateFromUser();

            Console.WriteLine();
            Console.WriteLine("Please Choose fuel type:");
            eFuelType fuelType = getFuelTypeFromUser();

            Console.WriteLine("Please enter the amount to fuel:");
            float amountToFuel = getFloatFromUser(v_IsPossitiveNumberOnly);

            try
            {
                Garage.FuelVehicle(licensePlate, fuelType, amountToFuel);
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

        private float getFloatFromUser(bool i_IsPossitiveOnly)
        {
            float optionFromUser;

            while (!float.TryParse(Console.ReadLine(), out optionFromUser) || (optionFromUser < 0 || !i_IsPossitiveOnly))
            {
                Console.WriteLine("Invalid input, Please choose floating point {0}number only.", i_IsPossitiveOnly ? "possitive " : "");
            }

            return optionFromUser;
        }

        private void chargeVehicle()
        {
            Console.WriteLine();
            Console.WriteLine("You are about to charge your vehicle:");
            string licensePlate = getLicensePlateFromUser();

            Console.WriteLine("for how many hours would you like to charge? ");
            float hoursToCharge = getFloatFromUser(v_IsPossitiveNumberOnly);

            try
            {
                Garage.ChargeVehicle(licensePlate, hoursToCharge);
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
            string licensePlate = getLicensePlateFromUser();
            try
            {
                Console.Clear();
                string carReport = Garage.GetCarReport(licensePlate);
                Console.WriteLine(carReport);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine("Operation failed");
                Console.WriteLine(ae.Message);
            }
        }

        private void showFilteredListOfLicensePlates(eVehicleState i_FilteredBy)
        {
            int counter = 0;
            Console.Clear();
            Console.WriteLine("List of vehicles:");
            Console.WriteLine("-----------------");
            foreach (string licensePlate in Garage.GetLicencePlatesInGarage(i_FilteredBy))
            {
                counter++;
                Console.WriteLine("{0}. {1}.", counter, licensePlate);
            }
        }

    }
}
