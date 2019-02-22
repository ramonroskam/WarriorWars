using System;

namespace WarriorWars
{
    public class Tools
    {
        public static void colorfulWrilteLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
        }
    }
}