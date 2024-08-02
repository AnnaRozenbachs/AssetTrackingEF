using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingEF.Helpers
{
    public static class ConsoleHelper
    {
        public static string ConsoleWrite(string message, bool read = true, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);          
            if (read)
            {
                return Console.ReadLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            return string.Empty;
        }
    }
}
