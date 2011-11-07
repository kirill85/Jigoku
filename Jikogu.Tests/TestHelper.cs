using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jigoku.Tests
{
    public static class TestHelper
    {
        public static void log(string text)
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("---> " + text);
        }
        public static void done()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" ......... Done");
        }
        public static void warning(string text)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("---> " + text);
        }
        public static void error(string text)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("---> " + text);
        }
    }
}
