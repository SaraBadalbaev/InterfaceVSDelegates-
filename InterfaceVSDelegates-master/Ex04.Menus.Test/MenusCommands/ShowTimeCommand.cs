using System;

namespace Ex04.Menus.Interfaces
{
    public class ShowTimeCommand : IListener
    {
        public void OnMenuAction()
        {
            DateTime currentTime = DateTime.Now;
            string formattedTime = currentTime.ToString("HH:mm:ss");

            Console.WriteLine($"The hour is {formattedTime}" + Environment.NewLine);
        }
    }
}
