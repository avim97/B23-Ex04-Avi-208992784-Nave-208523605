using System;
using System.Linq;

namespace Ex04.Menus.Interfaces
{
    public abstract class Menu
    {
        public string Title { get; set; }
        public string EscapeLabel { get; set; }
        protected const int k_EscapeOptionIdx = 0;
        internal MenuItemCollection MenuItems { get; private set; }

        protected Menu() { }
        protected Menu(string i_Title)
        {
            Title = i_Title;
            MenuItems = null;
        }
        protected internal abstract void Operate();
        protected internal virtual void HandleUserChoice(int i_UserChoice, ref bool i_ReactivateMenu)
        {
            if (i_UserChoice == k_EscapeOptionIdx)
            {
                i_ReactivateMenu = false;
            }
            else
            {
                MenuItems
                    .ElementAt(i_UserChoice - 1)
                    ?.Operate();
            }
        }
        protected internal virtual void GetUserChoice(out int o_UserChoice)
        {
            string userInput = Console.ReadLine();
            bool isUserInputValid = int.TryParse(userInput, out int userChoice) && !string.IsNullOrEmpty(userInput);

            while (!isUserInputValid || userChoice < k_EscapeOptionIdx || userChoice > MenuItems.Count)
            {
                Console.WriteLine("Invalid input please try again");
                userInput = Console.ReadLine();
                isUserInputValid = int.TryParse(userInput, out userChoice) && !string.IsNullOrEmpty(userInput);
            }

            o_UserChoice = userChoice;
        }
        public void AddSubItem(MenuItem i_ToAdd)
        {
            if (MenuItems == null)
            {
                MenuItems = new MenuItemCollection();
            }

            MenuItems.Add(i_ToAdd);
        }
        protected internal void Display()
        {
            Console.Clear();
            Console.Write(this);
        }
        public override string ToString()
        {
            string contentToDisplay =
                $@"
**{Title}**
---------------------------
{MenuItems}
0 -> {EscapeLabel}
--------------------------
Enter your request: (1 to {MenuItems.Count} or press {k_EscapeOptionIdx} to {EscapeLabel})
";

            return contentToDisplay;
        }
    }
}
