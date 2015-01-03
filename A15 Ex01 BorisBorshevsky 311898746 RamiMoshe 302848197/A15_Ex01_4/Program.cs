using System;
using System.Collections.Generic;
using System.Text;

namespace A15_Ex01_4
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
            string inputFromUser = getStringFromUser();
            printRequiredInfoForInput(inputFromUser);
        }

        static private string getStringFromUser()
        {
            Console.WriteLine("Please enter a string for Ex01_4 (8 chars - all letters or all numbers):");
            string inputFromUser = Console.ReadLine();
            while (!validateString(inputFromUser))
            {
                Console.WriteLine("Invalid input, Please try again.");
                inputFromUser = Console.ReadLine();
            }
            
            return inputFromUser;
        }

        static private void printRequiredInfoForInput(string i_InputFromUser)
        {
            StringBuilder infoStringBuilder = new StringBuilder();
            
            infoStringBuilder.AppendFormat("The string is {0}a polindrome." + Environment.NewLine, isStringPolindrome(i_InputFromUser) ? "" : "not ");
            if (IsAllDigits(i_InputFromUser))
            {
                infoStringBuilder.AppendFormat("The sum of all digits is {0}.", getSumOfAllDigits(i_InputFromUser));
            }

            if (IsAllLetters(i_InputFromUser))
            {
                infoStringBuilder.AppendFormat("The amount of uppercase letters is {0}.", getNumOfUppercaseLetters(i_InputFromUser));
            }

            Console.WriteLine(infoStringBuilder.ToString());
        }

        static private int getNumOfUppercaseLetters(string i_StringOfLetters)
        {
            int NumOfUppercaseLetters = 0;

            foreach (char character in i_StringOfLetters)
            {
                if (Char.IsUpper(character))
                {
                    NumOfUppercaseLetters++; 
                } 
            }

            return NumOfUppercaseLetters;
        }

        static private int getSumOfAllDigits(string i_StringOfDigits)
        {
            int sumOfDigits = 0;

            foreach (char character in i_StringOfDigits)
            {
                sumOfDigits += character - '0';
            }

            return sumOfDigits;
        }
        
        static public bool validateString(string i_StringToValidate)
        {
            bool isValidated = true;
            
            if (i_StringToValidate.Length != 8)
            {
                isValidated = false;
            }

            if (!IsAllDigits(i_StringToValidate) && !IsAllLetters(i_StringToValidate))
            {
                isValidated = false;
            }

            return isValidated;
        }
        
        public static bool IsAllLetters(string i_StringToCheck)
        {
            bool IsAllLetters = true;
            foreach (char character in i_StringToCheck)
            {
                if (!Char.IsLetter(character))
                {
                    IsAllLetters = false;
                    break;
                }
            }
            
            return IsAllLetters;
        }
        
        public static bool IsAllDigits(string i_StringToCheck)
        {
            bool IsAllDigits = true;
            foreach (char character in i_StringToCheck)
            {
                if (!Char.IsDigit(character))
                {
                    IsAllDigits = false;
                    break;
                }
            }
            
            return IsAllDigits;
        }
        static public bool isStringPolindrome(string i_StringToCheck)
        {
            char[] arrayOfChars = i_StringToCheck.ToCharArray();
            Array.Reverse(arrayOfChars);
            string reversedString = new string(arrayOfChars);

            return i_StringToCheck.Equals(reversedString);
        }
    }
}
