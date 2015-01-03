using System;
using System.Collections.Generic;
using System.Text;

namespace A15_Ex01_2
{
    public class Program
    {
        public static void Main()
        {
            Run();
            Console.WriteLine("Press 'Enter' to exit...");
            Console.ReadLine();
        }

        public static void Run()
        {
            PrintHourglassOnScreen(5, '*');
        }
        
        public static void PrintHourglassOnScreen(int i_HourglassHeight, Char i_CharToUse)
        {
            StringBuilder hourglassStringBuilder = new StringBuilder();
            int halfOfTheHeight;
            bool isHeightEven = i_HourglassHeight % 2 == 0;

            if (isHeightEven)
            {
                i_HourglassHeight++;
            }

            halfOfTheHeight = i_HourglassHeight / 2;
            for (int index = 0; index < halfOfTheHeight; index++)
            {
                generateLine(ref hourglassStringBuilder, index, i_HourglassHeight - (index * 2), i_CharToUse);
            }

            generateLine(ref hourglassStringBuilder, halfOfTheHeight, 1, i_CharToUse);
            for (int index = halfOfTheHeight - 1; index >= 0; index--)
            {
                generateLine(ref hourglassStringBuilder, index, i_HourglassHeight - (index * 2), i_CharToUse);
            }
           
            Console.WriteLine(hourglassStringBuilder.ToString());
        }

        private static void generateLine(ref StringBuilder io_HourglassStringBuilder, int i_Spaces, int i_Stars, Char i_CharToUse)
        {
            for (int currentAmount = 0; currentAmount < i_Spaces; currentAmount++)
            {
                io_HourglassStringBuilder.Append(' ');
            }
            
            for (int currentAmount = 0; currentAmount < i_Stars; currentAmount++)
            {
                io_HourglassStringBuilder.Append(i_CharToUse);
            }
            
            io_HourglassStringBuilder.AppendLine();
        }
    }
}
