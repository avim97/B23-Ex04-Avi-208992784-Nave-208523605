using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem : Menu
    {
        private IActionObserver m_ActionObserver;

        public MenuItem()
        {
            EscapeLabel = "Back";
        }
        public MenuItem(string i_Title)
            : base(i_Title)
        {
            EscapeLabel = "Back";
        }
        public void SubscribeAsObserver(IActionObserver i_Subscriber)
        {
            m_ActionObserver = i_Subscriber;
        }
        protected internal override void Operate()
        {
            bool isParent = MenuItems != null;
            bool isRunning = true;
            
            while (isRunning)
            {
                if (isParent)
                {
                    this.Display();
                    this.GetUserChoice(out int userChoice);
                    this.HandleUserChoice(userChoice, ref isRunning);
                }
                else
                {
                    m_ActionObserver.DoAction();
                    isRunning = false;
                    Console.WriteLine(@"
Press any key to return to previous menu...");
                    Console.ReadKey();
                }
            }
        }
    }
}