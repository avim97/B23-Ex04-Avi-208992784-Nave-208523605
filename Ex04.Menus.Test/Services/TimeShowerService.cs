using System;

using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test.Services
{
    public class TimeShowerService : IActionObserver
    {
        private const string k_TimeFormat = "HH:mm:ss";

        public void DoAction()
        {
            string time = DateTime.Now.ToString(k_TimeFormat);

            Console.WriteLine($"{time}");
        }
    }
}
