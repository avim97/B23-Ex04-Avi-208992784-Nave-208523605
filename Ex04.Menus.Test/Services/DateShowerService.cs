using System;

using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test.Services
{
    internal class DateShowerService : IActionObserver
    {
        private const string k_DateFormat = "dd/MM/yyyy";

        public static DateShowerService CreateInstance()
        {
            return new DateShowerService();
        }
        public void MenuItem_BeenSelected()
        {
            string date = DateTime.Now.ToString(k_DateFormat);
            string versionMessage = string.Format(@"The date is: {0}", date);

            Console.WriteLine(versionMessage);
        }
        void IActionObserver.DoAction()
        {
            MenuItem_BeenSelected();
        }
    }
}
