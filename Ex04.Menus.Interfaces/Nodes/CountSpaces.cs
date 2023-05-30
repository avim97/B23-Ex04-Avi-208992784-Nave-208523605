using System;

namespace Ex04.Menus.Interfaces.Nodes
{
    public class CountSpaces : IClickListener
    {
        public void Click()
        {
            Console.WriteLine("Please enter your sentence:");
            string sentence = Console.ReadLine();

            int spaceCount = countSpaces(sentence);

            Console.WriteLine("There are {0} spaces in your sentence.\n", spaceCount);

        }

        private int countSpaces(string sentence)
        {
            int spaceCount = 0;
            foreach (char character in sentence)
            {
                if (character == ' ')
                {
                    spaceCount++;
                }
            }
            return spaceCount;
        }
    }
}