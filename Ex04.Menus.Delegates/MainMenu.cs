namespace Ex04.Menus.Delegates
{
    public class MainMenu : Menu
    {
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
                Display();
                var userChoice = GetUserChoice();

                HandleUserChoice(userChoice, ref isRunning);
            }
        }
        public void Enter()
        {
            Operate();
        }
    }
}
