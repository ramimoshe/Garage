using System;
using System.Collections.Generic;
using System.Text;

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
        public void Start()
        {
            bool shouldExit = false;
            while (!shouldExit)
            {
                showMenu();
                int option = GetMenuOptionFromUser();
                switch (option)
                {
                    case 1:
                        insertVechaleToGarage();
                        break;
                    case 2:
                        ShowVechaleSerialNumbersMenu();
                        break;
                    case 3:
                        UpdateVechaleState();
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
                        ShowVihecleReport();
                        break;
                    case 8:
                        shouldExit = true;    
                        break;
                }
            }

            // show bye bye
        }

        private int GetMenuOptionFromUser()
        {
            throw new NotImplementedException();
        }

        private void showMenu()
        {
            
        }

        private void insertVechaleToGarage()
        {
            
        }

        private void ShowVechaleSerialNumbersMenu()
        {
            ShowAllVechaleSerialNumbers();
            //or
            ShowFilteredVechaleSerialNumbers();

        }

        private void ShowAllVechaleSerialNumbers()
        {
            
        }

        private void ShowFilteredVechaleSerialNumbers()
        {

        }

        private void UpdateVechaleState()
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

        private void ShowVihecleReport()
        {

        }
    }
}
