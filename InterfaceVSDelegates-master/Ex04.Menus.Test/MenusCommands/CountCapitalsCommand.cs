using System;

namespace Ex04.Menus.Interfaces
{
    public class CountCapitalsCommand : IListener
    {
        public void OnMenuAction()
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
    }
}
