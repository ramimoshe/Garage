using Ex03.GarageLogic;
using Ex03.GarageLogic.Vehicles;
using System;

namespace Ex03.GarageManagmentSystem.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
               Console.WriteLine(getIntFromUser());
            }
         
            new GarageConsoleUi().Start();
        }


        static private uint getIntFromUser()
        {
            uint optionFromUser;

            while (!uint.TryParse(Console.ReadLine(), out optionFromUser))
            {
                Console.WriteLine("Invalid input, Please enter a number only.");
            }

            return optionFromUser;
        }
            
    
    }


}
