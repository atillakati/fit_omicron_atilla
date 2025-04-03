using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Wifi.Toolbox.Tools;

namespace Wifi.Toolbox.Testapplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = ConsoleTools.GetInt("Please enter your age: ");

            Console.WriteLine($"You are {age} years old.");
        }
    }
}
