using System;

using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test.Services
{
    public class VersionShowerService : IActionObserver
    {
        private readonly string r_Version = "23.2.4.9805";

        public void DoAction()
        {
            string versionMessage = string.Format(@"Version: {0}", r_Version);

            Console.WriteLine($"{versionMessage}");
        }
    }
}
