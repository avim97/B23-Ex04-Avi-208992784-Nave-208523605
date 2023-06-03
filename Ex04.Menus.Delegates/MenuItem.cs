using System;

namespace Ex04.Menus.Delegates
{
    public class MenuItem : Menu
    {
        public event Action Selected;

        public MenuItem()
        {
            EscapeLabel = "Back";
        }
        public MenuItem(string i_Title)
            : base(i_Title)
        {
            EscapeLabel = "Back";
        }
        protected virtual void OnSelected()
        {
            Selected?.Invoke();
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
                    this.OnSelected();
                    Console.WriteLine(k_PressAnyKeyToReturnToPrevMenuMessage);
                    Console.ReadKey();
                }
            }
        }
        public void SubscribeAsObserver(Action i_Subscriber)
        {
            this.Selected = i_Subscriber;
        }
    }
}
