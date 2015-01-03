using System;
using System.Collections.Generic;
using System.Text;

namespace A15_Ex01_3
{
    class Program
    {
        static void Main()
        {
            Run();
            Console.WriteLine("Press 'Enter' to exit...");
            Console.ReadLine();
        }
        public static void Run()
        {
            Console.Write("Please enter the number of lines for the hourglass: ");
            int hourglassHeight = getHeightFromUser();
            A15_Ex01_2.Program.PrintHourglassOnScreen(hourglassHeight, '*');
        }

        private static int getHeightFromUser()
        {
            int parseResult;
            string valueFromUser = Console.ReadLine();

            while (!int.TryParse(valueFromUser, out parseResult) || parseResult < 1)
            {
                Console.WriteLine("The input you entered is invalid, please try again");
                valueFromUser = Console.ReadLine();
            }

            return parseResult;
        }

    }
}
