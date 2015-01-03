using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    /// <summary>
    /// Single item in menu
    /// </summary>
    public class MenuItem
    {
        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();
        private readonly string r_Title;
        protected readonly IMenuAction r_MenuAction; 
        
        public MenuItem(string i_Title, IMenuAction i_Action)
        {
            r_Title = i_Title;
            r_MenuAction = i_Action;
        }

        public MenuItem(string i_Title)
        {
            r_Title = i_Title;
        }
        
        /// <summary>
        /// Display the menu selsected or execute the required task
        /// </summary>
        protected void Run()
        {
            bool isBackAction = false;
            while (!isBackAction)
            {
                if (r_MenuItems.Count > 0)
                {
                    printMenu();
                    Console.WriteLine("Please Choose from the menu:");
                    int optionFromUser = getMenuOptionFromUser(r_MenuItems.Count);
                    if (optionFromUser != 0)
                    {
                        r_MenuItems[optionFromUser - 1].Run();
                        continue;
                    }

                    isBackAction = true;
                }
                else
                {
                    Console.Clear();
                    r_MenuAction.Execute();
                    isBackAction = true;
                }
            }
        }

        private void printMenu()
        {
            Console.Clear();
            Console.WriteLine(r_Title);
            for (int i = 1 ; i <= r_MenuItems.Count; i++)
            {
                Console.WriteLine("{0} - {1}.", i, r_MenuItems[i - 1].r_Title);
            }

            PrintExit();
        }

        protected virtual void PrintExit()
        {
            Console.WriteLine("0 - Back.");
        }

        private static int getMenuOptionFromUser(int i_NumOfOptions)
        {
            int optionFromUser;

            while (!int.TryParse(Console.ReadLine(), out optionFromUser) || optionFromUser < 0 || optionFromUser > i_NumOfOptions)
            {
                Console.WriteLine("Invalid input, Please choose number between 0 to {0} only.", i_NumOfOptions);
            }

            return optionFromUser;
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            r_MenuItems.Add(i_MenuItem);
        }
    }
}
