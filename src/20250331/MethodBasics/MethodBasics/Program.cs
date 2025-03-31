using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodBasics
{



    internal class Program
    {
        static void Main(string[] args)
        {
            // - reduce code line
            // - reuse code
            // - increase readability
            // - easier debugging
            // - unit tests

            PrintHelloWorld();
            PrintHelloWorld();

            PrintHelloWorld();

            PrintMessage("This is a test.");

            PrintColoredMessage("Hello world!", ConsoleColor.Yellow);
        }

        static void PrintColoredMessage(string message, ConsoleColor messageColor)
        {
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = messageColor;

            Console.WriteLine(message);
            Console.ForegroundColor = oldColor;
        }

        static void PrintMessage(string message)
        {            
            Console.WriteLine(message);
        }

        //signature
        // return type - name ( parameter list )
        static void PrintHelloWorld()
        {

            Console.WriteLine("Hello world!");
        }
    }
}
