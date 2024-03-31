using System;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    public class MenusDelegates
    {
        private MainMenu m_MainMenu;

        public MenusDelegates() 
        {
            m_MainMenu = new MainMenu("Delegates Main Menu", true);
            MainMenu dateTimeMenu = new MainMenu("Show Date/Time", false);
            MainMenu versionCapitalsMenu = new MainMenu("Version and Capitals", false);
            SubMenuItem showTime = new SubMenuItem("Show Time");
            SubMenuItem showDate = new SubMenuItem("Show Date");
            SubMenuItem countCapitals = new SubMenuItem("Count Capitals");
            SubMenuItem showVersion = new SubMenuItem("Show Version");

            showTime.m_Click += showTime_Click;
            showDate.m_Click += showDate_Click;
            countCapitals.m_Click += countCapitals_Click;
            showVersion.m_Click += showVersion_Click;
            dateTimeMenu.AddMenuItem(showTime);
            dateTimeMenu.AddMenuItem(showDate);
            m_MainMenu.AddMenuItem(dateTimeMenu);
            versionCapitalsMenu.AddMenuItem(showVersion);
            versionCapitalsMenu.AddMenuItem(countCapitals);
            m_MainMenu.AddMenuItem(versionCapitalsMenu);
        }

        public void Show()
        {
            m_MainMenu.OnClick();
        }

        private void showTime_Click()
        {
            DateTime currentTime = DateTime.Now;
            string formattedTime = currentTime.ToString("HH:mm:ss");

            Console.WriteLine($"The hour is {formattedTime}" + Environment.NewLine);
        }

        private void showDate_Click()
        {
            DateTime currentDate = DateTime.Now;
            string formattedDate = currentDate.ToString("dd/MM/yyyy");

            Console.WriteLine($"The date is {formattedDate}" + Environment.NewLine);
        }

        private void countCapitals_Click()
        {
            Console.WriteLine("Please enter your sentance:");
            string userInput = Console.ReadLine();
            int capitalCounter = 0;

            foreach (char c in userInput)
            {
                if (char.IsUpper(c))
                {
                    capitalCounter++;
                }
            }

            Console.WriteLine($"The are {capitalCounter} capitals in your sentance" + Environment.NewLine);
        }

        private void showVersion_Click()
        {
            Console.WriteLine("Version: 24.1.4.9633" + Environment.NewLine);
        } 
          
    }
}
