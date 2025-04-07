using System;
using Wifi.Toolbox.Tools;

namespace Wifi.Toolbox.Testapplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = ConsoleTools.GetInt("Please enter your age: ");
            double weight = ConsoleTools.GetDouble("Please enter your weight: ");

            Console.WriteLine($"\nYou are {age} years old and your weight is {weight:f2} kg.");
        }
    }
}
