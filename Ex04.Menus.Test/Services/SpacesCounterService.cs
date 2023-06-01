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

        public void DoAction()
        {
            Console.WriteLine(k_InputRequestMessage);
            string sentence = Console.ReadLine();
            int spaceCount = countSpaces(sentence);
            string responseMessage = string.Format(k_ResponseMessageFormat, spaceCount);
            Console.WriteLine(responseMessage);
        }
        private int countSpaces(string sentence)
        {
            int numSpaces = sentence.Count(character => character.Equals(k_SpaceSymbol));

            return numSpaces;
        }
    }
}
