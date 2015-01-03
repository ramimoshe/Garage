using System;
using System.Collections.Generic;
using System.Text;

namespace A15_Ex01_5
{
    public class Program
    {
        static void Main()
        {
            Run();
            Console.WriteLine("Press 'Enter' to exit...");
            Console.ReadLine();
        }
        static public void Run()
        {
            int numberFromUser = getNumberFromUser(8);
            printRequiredInfoForInput(numberFromUser);
        }

        static private void printRequiredInfoForInput(int i_NumbersFromUser)
        {
            StringBuilder statistcsStringBuilder = new StringBuilder();
            int aboveFirstDigit;
            int belowFirstDigit;
            int biggestDigit;
            int smallestDigit;

            getStatisticsAboutNumber(i_NumbersFromUser, out aboveFirstDigit, out belowFirstDigit, out biggestDigit, out smallestDigit);
            statistcsStringBuilder.AppendLine(string.Format("The number evaluated is {0}.", i_NumbersFromUser));
            statistcsStringBuilder.AppendLine(string.Format("It has {0} digits bigger than the first digit.", aboveFirstDigit));
            statistcsStringBuilder.AppendLine(string.Format("It has {0} digits smaller than the first digit.", belowFirstDigit));
            statistcsStringBuilder.AppendLine(string.Format("The biggest digit is {0}.", biggestDigit));
            statistcsStringBuilder.AppendLine(string.Format("The smallest digit is {0}.", smallestDigit));
            Console.WriteLine(statistcsStringBuilder.ToString());
        }
        static public void getStatisticsAboutNumber(int i_NumberToCheck, out int o_AboveFirstDigit, out int o_BelowFirstDigit, out int o_BiggestDigit, out int o_SmallestDigit)
        {
            int firstDigit = getFirstDigit(i_NumberToCheck);
            int currentDigit;

            o_AboveFirstDigit = 0;
            o_BelowFirstDigit = 0;
            o_BiggestDigit = 0;
            o_SmallestDigit = 9;
            
            while (i_NumberToCheck > 0)
            {
                currentDigit = i_NumberToCheck % 10 ;
                if (currentDigit < firstDigit)
                {
                    o_BelowFirstDigit++;
                }
                
                if (currentDigit > firstDigit)
                {
                    o_AboveFirstDigit++;
                }

                o_BiggestDigit = Math.Max(currentDigit, o_BiggestDigit);
                o_SmallestDigit = Math.Min(currentDigit, o_SmallestDigit);
                i_NumberToCheck /= 10;
            }
        }
        
        static private int getNumberFromUser(int i_NumOfDigitsRequested)
        {
            Console.WriteLine("Please enter a string for Ex01_5 (number with 8 digits):");
            string inputFromUser = Console.ReadLine();
            int integerToReturn;

            while (!int.TryParse(inputFromUser, out integerToReturn) || integerToReturn.ToString().Length != i_NumOfDigitsRequested)
            {
                Console.WriteLine("Invalid input, Please try again.");
                inputFromUser = Console.ReadLine();
            }

            return integerToReturn;
        }

        static private int getFirstDigit(int i_numberToCheck)
        {
            while (i_numberToCheck >= 10)
            {
                i_numberToCheck /= 10;
            }
           
            return i_numberToCheck;
        }
    
    }   
}
