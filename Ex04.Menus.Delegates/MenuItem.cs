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

            do
            {
                if (isParent)
                {
                    this.Display();
                    this.GetUserChoice(out int userChoice);
                    this.HandleUserChoice(userChoice, ref isRunning);
                }
                else
                {
                    this.OnSelected();
                    isRunning = false;
                }
            } while (isRunning);
        }
        public void SubscribeAsObserver(Action i_Subscriber)
        {
            this.Selected = i_Subscriber;
        }
    }
}
