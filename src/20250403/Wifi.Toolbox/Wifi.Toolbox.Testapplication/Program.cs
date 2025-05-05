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

            int age = ConsoleTools.GetInputValue<int>("Please enter your age: ");
            double weight = ConsoleTools.GetInputValue<double>("Please enter your weight: ");

            Console.WriteLine($"\nYou are {age} years old and your weight is {weight:f2} kg.");  
                        
        }
    }
}
