using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();

            Console.WriteLine("This is my first friendly blue screen!");
            Console.Write("This is a test: ");
            Console.Write("Hi folks!");

            Console.WriteLine("This is\n a new line");
            Console.WriteLine("Age: \t55");
            Console.WriteLine("\"Hallo\"   \\t");


            /*
             *Write an application that produces the following outputs:
             *   
             *   Name:               <your name>
             *   Place of residence: <your place of residence>
             *   
             *<Here should be your motto>.                           
             *
             */

            Console.WriteLine();
            Console.WriteLine("  Name:\t\t      Atilla");
            Console.WriteLine("  Place of residence: Dornbirn");
            Console.WriteLine();
            Console.WriteLine("Happy too!");
        }
    }
}
