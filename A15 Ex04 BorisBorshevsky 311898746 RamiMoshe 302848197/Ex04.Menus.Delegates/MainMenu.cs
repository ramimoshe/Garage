using System;

namespace Ex04.Menus.Delegates
{
    /// <summary>
    /// Main Menu
    /// </summary>
    public class MainMenu : MenuItem
    {
        public MainMenu(string i_Title) : base(i_Title)
        { }

        protected override void PrintExit()
        {
            Console.WriteLine("0 - Exit.");
        }
        public void Show()
        {
            Run();
        }

    }
}