using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceholderInStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 5;
            int maxNumber = 50;


            Console.WriteLine("Here were " + number + " of itmes found." );
            Console.WriteLine("{0} items of {1} are found.", number, maxNumber);

            Console.WriteLine($"{number} items of {maxNumber} are found.");

            string name = $"Atilla-\"{DateTime.Now.Date}\"";
            Console.WriteLine(name);

        }
    }
}
