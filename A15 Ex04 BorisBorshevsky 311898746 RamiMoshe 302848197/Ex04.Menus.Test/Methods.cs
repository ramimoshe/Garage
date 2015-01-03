using Ex04.Menus.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace Ex04.Menus.Test
{
    public class Methods
    {
        public class ShowVersion : IMenuAction
        {
            public void Execute()
            {
                Console.WriteLine("Version: 15.1.4.0"); 
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        public class ShowDate : IMenuAction
        {
            public void Execute()
            {
                Console.WriteLine("The date is: {0}.", DateTime.Today.ToShortDateString());
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        public class ShowTime : IMenuAction
        {
            public void Execute()
            {
                Console.WriteLine("The time is: {0}.", DateTime.Now.ToShortTimeString());
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        public class WordsCounter : IMenuAction
        {
            public void Execute()
            {
                Console.WriteLine("Please enter a sentence");
                string sentence = Console.ReadLine();
                Console.WriteLine("Number of words in your sentence: {0}", countWords(sentence));
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            private static int countWords(string i_Sentence)
            {
                MatchCollection collection = Regex.Matches(i_Sentence, @"[\S]+");
                
                return collection.Count;
            }
        }
    }
}
