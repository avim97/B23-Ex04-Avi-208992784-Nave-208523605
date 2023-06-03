using System;

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
                    const string k_PressAnyKeyToReturnToPrevMenuMessage = @"
Press any key to return to previous menu...";

                    isRunning = false;
                    m_ActionObserver.DoAction();
                    Console.WriteLine(k_PressAnyKeyToReturnToPrevMenuMessage);
                    Console.ReadKey();
                }
            }
        }
    }
}