using System;

using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test.Services
{
    public class TimeShowerService : IActionObserver
    {
        public static TimeShowerService CreateInstance()
        {
            return new TimeShowerService();
        }

        private const string k_TimeFormat = "HH:mm:ss";

        public void MenuItem_BeenSelected()
        {
            string time = DateTime.Now.ToString(k_TimeFormat);
            string versionMessage = string.Format(@"The hour is: {0}", time);

            Console.WriteLine(versionMessage);
        }
        void IActionObserver.DoAction()
        {
            MenuItem_BeenSelected();
        }
    }
}
