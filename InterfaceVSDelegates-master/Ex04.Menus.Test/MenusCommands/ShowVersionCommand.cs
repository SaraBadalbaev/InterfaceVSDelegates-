using System;

namespace Ex04.Menus.Interfaces
{
    public class ShowVersionCommand : IListener
    {
        public void OnMenuAction()
        {
            Console.WriteLine("Version: 24.1.4.9633" + Environment.NewLine);
        }
    }
}
