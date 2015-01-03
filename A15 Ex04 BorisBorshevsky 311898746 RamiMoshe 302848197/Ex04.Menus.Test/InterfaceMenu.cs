using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class InterfaceMenu
    {
        public static MainMenu CreateInterfaceMainMenu()
        {
            MainMenu mainMenu = new MainMenu("Main Menu - Inteface imlementation");

            mainMenu.AddMenuItem(createWordCounterMenu());
            mainMenu.AddMenuItem(createShowDateMenu());
            mainMenu.AddMenuItem(createShowVersionMenu());

            return mainMenu;
        }

        private static MenuItem createShowDateMenu()
        {
            MenuItem dateMenu = new MenuItem("Show Date/Time");
            dateMenu.AddMenuItem(new MenuItem("Show Date", new Methods.ShowDate()));
            dateMenu.AddMenuItem(new MenuItem("Show Time", new Methods.ShowTime()));

            return dateMenu;
        }

        private static MenuItem createWordCounterMenu()
        {
            return new MenuItem("Word Counter", new Methods.WordsCounter());
        }

        private static MenuItem createShowVersionMenu()
        {
            return new MenuItem("Show Version", new Methods.ShowVersion());
        }
    }
}
