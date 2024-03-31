using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class MenusInterfaces
    {
        private readonly MainMenu r_MainMenu;

        public MenusInterfaces()
        {
            r_MainMenu = new MainMenu("Interface Main Menu", true);
            MenuItem dateTimeMenu = new MenuItem("Show Date/Time", false);
            MenuItem versionCapitalsMenu = new MenuItem("Version and Capitals", false);
            MenuItem showDate = new MenuItem("Show Date", false);
            MenuItem showTime = new MenuItem("Show Time", false);
            MenuItem showVersion = new MenuItem("Show Version", false);
            MenuItem countCapitals = new MenuItem("Count Capitals", false);

            showDate.AttachListener(new ShowDateCommand());
            showTime.AttachListener(new ShowTimeCommand());
            showVersion.AttachListener(new ShowVersionCommand());
            countCapitals.AttachListener(new CountCapitalsCommand());
            dateTimeMenu.AddElement(showDate);
            dateTimeMenu.AddElement(showTime);
            versionCapitalsMenu.AddElement(showVersion);
            versionCapitalsMenu.AddElement(countCapitals);
            r_MainMenu.AddSubMenu(dateTimeMenu);
            r_MainMenu.AddSubMenu(versionCapitalsMenu);
        }

        public void Show()
        {
            r_MainMenu.Show();
        }
    }
}
