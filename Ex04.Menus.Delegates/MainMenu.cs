using System;

namespace Ex04.Menus.Delegates
{
    public class MainMenu : Menu
    {
        public MainMenu()
        {
            EscapeLabel = "Exit";
        }
        public MainMenu(string i_Title)
            : base(i_Title)
        {
            EscapeLabel = "Exit";
        }
        protected internal override void Operate()
        {
            bool isRunning = true;

            while (isRunning)
            {
                this.Display();
                this.GetUserChoice(out int userChoice);
                this.HandleUserChoice(userChoice, ref isRunning);
            }

            Console.Clear();
        }
        public void Enter()
        {
            Operate();
        }
    }
}
