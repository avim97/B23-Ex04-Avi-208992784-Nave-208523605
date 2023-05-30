using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private readonly string m_Title;
        private LinkedList<MenuItem> m_MenuItems;
        private MenuItem m_ParentMenuItem;
        public MenuItem ParentMenuItem { set => m_ParentMenuItem = value; }
        private IClickListener m_ClickListener;
        public IClickListener ClickListener { set => m_ClickListener = value; }
        private readonly string r_ExitMessage;
        private readonly string r_EnterRequestMessage = "Enter your request: (1 to 2 or press '0' to Back)";
        private readonly string r_ChooseOptionMessage = "Please choose an option:";

        public MenuItem(string i_Title, bool i_IsFirstMenuItem)
        {
            this.m_Title = i_Title;
            m_MenuItems = new LinkedList<MenuItem>();
            if (i_IsFirstMenuItem == true)
            {
                r_ExitMessage = "Exit";
            }
            else
            {
                r_ExitMessage = "Back";
            }
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            m_MenuItems.AddLast(i_MenuItem);
        }

        public void Click()
        {
            if(m_MenuItems.Count > 0)
            {
                printThisMenu();
                int userChoice = getUserChoice();
                handleUserChoice(userChoice);
            }


            else if(m_ClickListener != null)
            {
                m_ClickListener.Click();
                m_ParentMenuItem.Click();
            }
        }

        private void printThisMenu()
        {
            printMenuItemTitle();
            printSubMenu();
            Console.WriteLine(r_EnterRequestMessage);
        }

        private void printSubMenu()
        {
            int index = 1;
            foreach(MenuItem menuItem in m_MenuItems)
            {
                Console.WriteLine("{0} -> {1}", index, menuItem.m_Title);
                index++;
            }
            Console.WriteLine($"0 -> {r_ExitMessage}");
            Console.WriteLine(r_ChooseOptionMessage);
        }

        private void printMenuItemTitle()
        {
            string title = $"**{m_Title}**\n-----------------------";
            Console.WriteLine(title);
        }

        private int getUserChoice()
        {
            string userInput = Console.ReadLine();
            Boolean isUserInputValid = int.TryParse(userInput, out int userChoice);
            while(!isUserInputValid && (userChoice < 0 || userChoice > m_MenuItems.Count))
            {
                Console.WriteLine("Invalid input, enter a number please try again");
            }
            return userChoice;
        }

        private void handleUserChoice(int i_UserChoice)
        {
            if(i_UserChoice == 0)
            {
                if(m_ParentMenuItem == null)
                {
                    string message = "\n Bye Bye!";
                    Console.WriteLine(message);
                    Console.ReadKey();
                    // Environment.Exit(0);
                }else
                {
                    m_ParentMenuItem.Click();
                }
            }
            else
            {
                m_MenuItems.ElementAt(i_UserChoice - 1).Click();
            }
        }
    }
}