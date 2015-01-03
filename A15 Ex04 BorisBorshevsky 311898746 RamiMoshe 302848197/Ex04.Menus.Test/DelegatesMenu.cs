using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    public class DelegatesMenu
    {
        public static MainMenu CreateDelegatesMenu()
        {
            MainMenu mainMenu = new MainMenu("Main Menu - Delegates imlementation");

            mainMenu.AddMenuItem(createWordCounterMenu());
            mainMenu.AddMenuItem(createShowDateMenu());
            mainMenu.AddMenuItem(createShowVersionMenu());

            return mainMenu;
        }

        private static MenuItem createShowDateMenu()
        {
            MenuItem dateMenu = new MenuItem("Show Date/Time");
            dateMenu.AddMenuItem(new MenuItem("Show Date", new Methods.ShowDate().Execute));
            dateMenu.AddMenuItem(new MenuItem("Show Time", new Methods.ShowTime().Execute));

            return dateMenu;
        }

        private static MenuItem createWordCounterMenu()
        {
            return new MenuItem("Word Counter", new Methods.WordsCounter().Execute);
        }

        private static MenuItem createShowVersionMenu()
        {
            return new MenuItem("Show Version", new Methods.ShowVersion().Execute);
        }
    }
}
