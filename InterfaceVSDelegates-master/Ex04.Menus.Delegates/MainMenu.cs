using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class MainMenu : MenuItem
    {
        private readonly List<MenuItem> r_ListMenuItems = new List<MenuItem>();
        private readonly bool r_IsExit; 

        public MainMenu(string i_ElementMenuItem, bool i_IsExitOrBack) : base(i_ElementMenuItem)
        {
            r_IsExit = i_IsExitOrBack;
        }

        public void AddMenuItem(MenuItem i_MenuItemElement)
        {
            r_ListMenuItems.Add(i_MenuItemElement);
        }

        private int getUserInput()
        {
            bool isValid = false;
            string userInputString;
            int userInputInt = 0;

            do
            {
                userInputString = Console.ReadLine();
                try
                {
                    userInputInt = isInputValid(userInputString);
                    isValid = true;
                }
                catch(FormatException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch(ArgumentOutOfRangeException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            while (!isValid);

            return userInputInt;
        }

        private int isInputValid(string i_userInputString)
        {
            int userInputInt;
            bool isInputValid = int.TryParse(i_userInputString, out userInputInt);

            if (!isInputValid) 
            {
                throw new FormatException("Your input is not valid");
            }

            if(!isInputInListRange(userInputInt))
            {
                throw new ArgumentOutOfRangeException($"Input must be between 0-{r_ListMenuItems.Count}",(Exception)null);
            }

            return userInputInt;
        }

        private bool isInputInListRange(int i_UserInputInt)
        {
            return i_UserInputInt >= 0 && i_UserInputInt <= r_ListMenuItems.Count;
        }


        private void show()
        {
            int userInput;

            do
            {
                printMenu();
                userInput = getUserInput();
                Console.Clear();
                if (userInput != 0)
                {
                    r_ListMenuItems[userInput - 1].OnClick();
                }
            } while (userInput != 0);

            Console.Clear();
        }

        public override void OnClick()
        {
            show();
        }

        private void printMenu()
        {
            Console.WriteLine("**{0}**", Title);
            Console.WriteLine("------------------------");
            for (int item = 0; item < r_ListMenuItems.Count; item++) 
            {
                Console.WriteLine("{0} -> {1}", item + 1, r_ListMenuItems[item].Title);
            }

            string zeroMsg = r_IsExit == true ? "Exit" : "Back";

            Console.WriteLine("0 -> {0}", zeroMsg);
            Console.WriteLine("------------------------");
            if(r_ListMenuItems.Count > 0)
            {
                Console.WriteLine("Enter your request: (1 to {0} or press '0' to {1}).", r_ListMenuItems.Count, zeroMsg);
            }
            else
            {
                Console.WriteLine("Enter 0 to {0}", zeroMsg);
            }
        }
    }
}
