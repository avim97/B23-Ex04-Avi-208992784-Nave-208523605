using System;

using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test.Services
{
    internal class DateShowerService : IActionObserver
    {
        private readonly string r_DateFormat = "dd/MM/yyyy";

        public void DoAction()
        {
            string date = DateTime.Now.ToString(r_DateFormat);

            Console.WriteLine($"{date}");
        }
    }
}
