using System;
using System.Collections.Generic;
using Wifi.Toolbox.Tools;

namespace Wifi.Toolbox.Testapplication
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            ConsoleTools.CreateHeader("Test App", 'O');

            int age = ConsoleTools.GetInputValue<int>("Please enter your age: ", ErrorHandler);
            double weight = ConsoleTools.GetInputValue<double>("Please enter your weight: ");

            Console.WriteLine($"\nYou are {age} years old and your weight is {weight:f2} kg.");  
                        
        }

        private static void ErrorHandler(Exception ex, CursorPositionDto cursorPosition)
        {
            //Age:      No no______                  
            //Birthday: _______
            //

            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.Write("HUCH: " + ex.Message);
            Console.ReadLine();

            Console.SetCursorPosition(cursorPosition.LeftPos, cursorPosition.TopPos);
            Console.Write(new string(' ', Console.WindowWidth - cursorPosition.LeftPos - 1));
            Console.SetCursorPosition(0, cursorPosition.TopPos);
        }
    }
}
