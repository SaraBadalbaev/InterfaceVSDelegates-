using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem 
    {
        private readonly string r_Title;
        private IListener m_Listener;
        private readonly List<MenuItem> r_MenuSubItems;
        private readonly bool r_IsExit;

        public MenuItem(string i_Title, bool i_IsExitMenu)
        {
            r_Title = i_Title;
            r_MenuSubItems = new List<MenuItem>();
            r_IsExit = i_IsExitMenu;
        }

        public string Title
        {
            get { return r_Title; }
        }

        public bool IsExit
        {
            get { return r_IsExit; }
        }

        public void AttachListener(IListener i_Listener)
        {
            m_Listener = i_Listener;
        }

        public void AddElement(MenuItem i_MenuItemElements)
        {
            r_MenuSubItems.Add(i_MenuItemElements);
        }

        public void Execute()
        {
            if (m_Listener != null)
            {
                m_Listener.OnMenuAction();
            }
            else
            {
                if (r_MenuSubItems.Count > 0)
                {
                    Show();
                }
            }
        }

        public virtual void Show()
        {
            int userInput;

            do
            {
                PrintMenu();
                userInput = GetUserInput();
                Console.Clear();
                if (userInput != 0)
                {
                    r_MenuSubItems[userInput - 1].Execute();
                }
            } while (userInput != 0);

            Console.Clear();
        }

        protected virtual void PrintMenu()
        {
            Console.WriteLine("**{0}**", r_Title);
            Console.WriteLine("------------------------");
            for (int item = 0; item < r_MenuSubItems.Count; item++)
            {
                Console.WriteLine("{0} -> {1}", item + 1, r_MenuSubItems[item].r_Title);
            }

            string zeroMsg = r_IsExit == true ? "Exit" : "Back";

            Console.WriteLine("0 -> {0}", zeroMsg);
            Console.WriteLine("------------------------");
            if (r_MenuSubItems.Count > 0)
            {
                Console.WriteLine("Enter your request: (1 to {0} or press '0' to {1}).", r_MenuSubItems.Count, zeroMsg);
            }
            else
            {
                Console.WriteLine("Enter 0 to {0}", zeroMsg);
            }
        }

        protected virtual int GetUserInput()
        {
            bool isValid = false;
            string userInputString;
            int userInputInt = 0;

            do
            {
                userInputString = Console.ReadLine();
                try
                {
                    userInputInt = IsInputValid(userInputString);
                    isValid = true;
                }
                catch (FormatException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (ArgumentOutOfRangeException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            while (!isValid);

            return userInputInt;
        }

        protected virtual int IsInputValid(string i_userInputString)
        {
            int userInputInt;
            bool isInputValid = int.TryParse(i_userInputString, out userInputInt);

            if (!isInputValid)
            {
                throw new FormatException("Your input is not valid");
            }

            if (!IsInputInListRange(userInputInt))
            {
                throw new ArgumentOutOfRangeException($"Input must be between 0-{r_MenuSubItems.Count}", (Exception)null);
            }

            return userInputInt;
        }

        protected virtual bool IsInputInListRange(int i_UserInputInt)
        {
            return i_UserInputInt >= 0 && i_UserInputInt <= r_MenuSubItems.Count;
        }
    }
}
