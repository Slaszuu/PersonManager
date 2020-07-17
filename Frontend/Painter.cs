using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend;

namespace Frontend
{
    static class Painter
    {
        public static void Write(string text, ConsoleColor textColor, ConsoleColor backgroundColor)
        {
            ConsoleColor textColorTemp = Console.ForegroundColor;
            ConsoleColor backgroungColorTemp = Console.BackgroundColor;
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(text);
            Console.ForegroundColor = textColorTemp;
            Console.BackgroundColor = backgroungColorTemp;
           
        }

        public static void WriteWithTextColor(string text, ConsoleColor textColor)
        {
            ConsoleColor textColorTemp = Console.ForegroundColor;
            Console.ForegroundColor = textColor;
            Console.Write(text);
            Console.ForegroundColor = textColorTemp;
        }

        public static void WriteWithBackgroundColor(string text, ConsoleColor backgroundColor)
        {
            ConsoleColor backgroungColorTemp = Console.BackgroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(text);
            Console.BackgroundColor = backgroungColorTemp;
        }

        public static void WriteLine(string text, ConsoleColor textColor, ConsoleColor backgroundColor)
        {
            ConsoleColor textColorTemp = Console.ForegroundColor;
            ConsoleColor backgroungColorTemp = Console.BackgroundColor;
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(text);
            Console.ForegroundColor = textColorTemp;
            Console.BackgroundColor = backgroungColorTemp;
        }

        public static void WriteLineWithTextColor(string text, ConsoleColor textColor)
        {
            ConsoleColor textColorTemp = Console.ForegroundColor;
            Console.ForegroundColor = textColor;
            Console.WriteLine(text);
            Console.ForegroundColor = textColorTemp;
        }

        public static void WriteLineWithBackgroundColor(string text, ConsoleColor backgroundColor)
        {
            ConsoleColor backgroungColorTemp = Console.BackgroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(text);
            Console.BackgroundColor = backgroungColorTemp;
        }
    }
}
