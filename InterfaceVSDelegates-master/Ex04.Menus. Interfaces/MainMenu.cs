using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu : MenuItem
    {
        private readonly List<MenuItem> r_ListMenuItems;

        public MainMenu(string i_MenuItemTitle, bool i_IsExitOrBack) : base(i_MenuItemTitle, i_IsExitOrBack)
        {
            r_ListMenuItems = new List<MenuItem>();
        }

        public void AddSubMenu(MenuItem i_SubMenuItem)
        {
            r_ListMenuItems.Add(i_SubMenuItem);
        }

        protected override int IsInputValid(string i_userInputString)
        {
            int userInputInt;
            bool isInputValid = int.TryParse(i_userInputString, out userInputInt);

            if (!isInputValid)
            {
                throw new FormatException("Your input is not valid");
            }

            if (!IsInputInListRange(userInputInt))
            {
                throw new ArgumentOutOfRangeException($"Input must be between 0-{r_ListMenuItems.Count}", (Exception)null);
            }

            return userInputInt;
        }

        protected override void PrintMenu()
        {
            Console.WriteLine("**{0}**", Title);
            Console.WriteLine("------------------------");
            for (int item = 0; item < r_ListMenuItems.Count; item++)
            {
                Console.WriteLine("{0} -> {1}", item + 1, r_ListMenuItems[item].Title);
            }

            string zeroMsg = IsExit == true ? "Exit" : "Back";

            Console.WriteLine("0 -> {0}", zeroMsg);
            Console.WriteLine("------------------------");
            if (r_ListMenuItems.Count > 0)
            {
                Console.WriteLine("Enter your request: (1 to {0} or press '0' to {1}).", r_ListMenuItems.Count, zeroMsg);
            }
            else
            {
                Console.WriteLine("Enter 0 to {0}", zeroMsg);
            }
        }

        protected override bool IsInputInListRange(int i_UserInputInt)
        {
            return i_UserInputInt >= 0 && i_UserInputInt <= r_ListMenuItems.Count;
        }

        public override void Show()
        {
            int userInput;

            do
            {
                PrintMenu();
                userInput = GetUserInput();
                Console.Clear();
                if (userInput != 0)
                {
                    r_ListMenuItems[userInput - 1].Execute();
                }
            } while (userInput != 0);

            Console.Clear();
        }
    }
}
