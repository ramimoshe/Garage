using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    /// <summary>
    /// Single item in menu
    /// </summary>
    public class MenuItem
    {
        public delegate void MenuActionDelegate();
        
        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();
        private readonly string r_Title;
        public event MenuActionDelegate MenuActionSelected;

        public MenuItem(string i_Title, MenuActionDelegate i_Action)
        {
            r_Title = i_Title;
            MenuActionSelected += i_Action;
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
                    onMenuActionSelected();
                    isBackAction = true;
                }
            }
        }

        private void onMenuActionSelected()
        {
            if (MenuActionSelected == null)
            {
                Console.WriteLine("Menu Action does not exists");
            }
            else
            {
                MenuActionSelected.Invoke();                
            }
        }

        private void printMenu()
        {
            Console.Clear();
            Console.WriteLine(r_Title); 
            Console.WriteLine("--------------");
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

        private int getMenuOptionFromUser(int i_NumOfOptions)
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