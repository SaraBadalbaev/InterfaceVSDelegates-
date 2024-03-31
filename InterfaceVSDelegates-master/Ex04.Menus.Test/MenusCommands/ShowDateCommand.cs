using System;

namespace Ex04.Menus.Interfaces
{
    public class ShowDateCommand : IListener
    {
        public void OnMenuAction()
        {
            DateTime currentDate = DateTime.Now;
            string formattedDate = currentDate.ToString("dd/MM/yyyy");

            Console.WriteLine($"The date is {formattedDate}" + Environment.NewLine);
        }
    }
}
