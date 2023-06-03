using System;
using System.Linq;

using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test.Services
{
    public class SpacesCounterService : IActionObserver
    {
        private const char k_SpaceSymbol = ' ';
        private const string k_InputRequestMessage = "Please enter your sentence:";
        private const string k_ResponseMessageFormat = "There are {0} spaces in your sentence.";

        public static SpacesCounterService CreateInstance()
        {
            return new SpacesCounterService();
        }
        private int countSpaces(string i_SentenceToAnalyze)
        {
            int numSpaces = i_SentenceToAnalyze.Count(character => character.Equals(k_SpaceSymbol));

            return numSpaces;
        }
        public void MenuItem_BeenSelected()
        {
            Console.Clear();
            Console.WriteLine(k_InputRequestMessage);
            string sentence = Console.ReadLine();
            int spaceCount = countSpaces(sentence);
            string responseMessage = string.Format(k_ResponseMessageFormat, spaceCount);
            Console.WriteLine(responseMessage);
        }
        void IActionObserver.DoAction()
        {
            MenuItem_BeenSelected();
        }
    }
}
