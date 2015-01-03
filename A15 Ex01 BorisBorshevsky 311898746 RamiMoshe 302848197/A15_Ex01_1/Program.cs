using System;
using System.Collections.Generic;
using System.Text;

namespace A15_Ex01_1
{
    public class Program
    {
        public static void Main()
        {
            Run(5, 3);
            Console.WriteLine("Press 'Enter' to exit...");
            Console.ReadLine();
        }

        public static void Run(int i_SizeOfInput, int i_NumberOfDigits)
        {
            string[] binaryNumbers = new string[i_SizeOfInput];
            string welcomeMassage = String.Format("Please enter {0} numbers with {1} digits each:", i_SizeOfInput, i_NumberOfDigits);
            Console.WriteLine(welcomeMassage);
            int[] numbers = getNumbersFromUser(i_SizeOfInput, i_NumberOfDigits);

            printStatistics(binaryNumbers, numbers);
        }

        private static void printStatistics(string[] i_BinaryNumbers, int[] i_DecimalNumbers)
        {
            int numOfAcsending = 0;
            int numOfDecsending = 0;

            for (int index = 0; index < i_DecimalNumbers.Length; index++)
            {
                if (checkIfAcsendingSeries(i_DecimalNumbers[index]))
                {
                    numOfAcsending++;
                }

                else if (checkIfDescendingOrder(i_DecimalNumbers[index]))
                {
                    numOfDecsending++;
                }
            }

            StringBuilder binaryNumbersStringBuilder = new StringBuilder();
            for (int index = 0; index < i_DecimalNumbers.Length; index++)
            {
                i_BinaryNumbers[index] = convertIntToBinary(i_DecimalNumbers[index]);
                binaryNumbersStringBuilder.Append(i_BinaryNumbers[index] + " ");
            }

            StringBuilder resultStringBuilder = new StringBuilder();
            resultStringBuilder.AppendLine(string.Format("The binary numbers are: {0}.", binaryNumbersStringBuilder.ToString()));
            resultStringBuilder.AppendLine(string.Format("There are {0} numbers which are an ascending series and {1} which are descending.", numOfAcsending, numOfDecsending));
            resultStringBuilder.AppendLine(string.Format("The avarage number of digits in binary number is {0}.", getAvarageLenghOfStrings(i_BinaryNumbers)));
            resultStringBuilder.AppendLine(string.Format("The general avarage of the inserted numbers is {0}.", getAvarageOfArray(i_DecimalNumbers)));
            Console.WriteLine(resultStringBuilder.ToString());
        }

        private static int[] getNumbersFromUser(int i_AmountOfNumbers, int i_AmountOfDigits)
        {
            int[] numbers = new int[i_AmountOfNumbers];

            for (int index = 0; index < i_AmountOfNumbers; index++)
            {
                numbers[index] = getNumberFromUser(i_AmountOfDigits);
            }

            return numbers;
        }

        private static int getNumberFromUser(int i_AmountOfDigits)
        {
            int parseResult;

            string valueFromUser = Console.ReadLine();
            while (!int.TryParse(valueFromUser, out parseResult) || parseResult.ToString().Length != i_AmountOfDigits)
            {
                Console.WriteLine("The input you entered is invalid, please try again");
                valueFromUser = Console.ReadLine();
            }

            return parseResult;
        }

        private static string convertIntToBinary(int i_DecimalNumber)
        {
            int remainder;
            string binaryNumberString = string.Empty;

            while (i_DecimalNumber > 0)
            {
                remainder = i_DecimalNumber % 2;
                i_DecimalNumber /= 2;
                binaryNumberString = remainder.ToString() + binaryNumberString;
            }

            return binaryNumberString;
        }

        private static bool checkIfDescendingOrder(int i_NumberToCheck)
        {
            int lastDigit;
            bool isDescendingOrder = true;

            while (i_NumberToCheck >= 10)
            {
                lastDigit = i_NumberToCheck % 10;
                i_NumberToCheck = i_NumberToCheck / 10;
                if (i_NumberToCheck % 10 <= lastDigit)
                {
                    isDescendingOrder = false;
                    break;
                }
            }

            return isDescendingOrder;
        }

        private static bool checkIfAcsendingSeries(int i_NumberToCheck)
        {
            int lastDigit;
            bool isAcsendingSeries = true;

            while (i_NumberToCheck >= 10)
            {
                lastDigit = i_NumberToCheck % 10;
                i_NumberToCheck = i_NumberToCheck / 10;
                if (i_NumberToCheck % 10 >= lastDigit)
                {
                    isAcsendingSeries = false;
                    break;
                }
            }

            return isAcsendingSeries;
        }

        private static float getAvarageOfArray(int[] i_Numbers)
        {
            float sum = 0f;

            for (int index = 0; index < i_Numbers.Length; index++)
            {
                sum += i_Numbers[index];
            }

            return sum / i_Numbers.Length;
        }

        private static float getAvarageLenghOfStrings(string[] i_InputString)
        {
            float sum = 0f;

            for (int index = 0; index < i_InputString.Length; index++)
            {
                sum += i_InputString[index].Length;
            }

            return sum / i_InputString.Length;
        }

    }
}
