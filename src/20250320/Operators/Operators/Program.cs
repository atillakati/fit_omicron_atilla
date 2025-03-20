using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            //arithmetic operators
            // + - * / %


            //PEMDAS  => KlaPuStri (ger)
            int erg = 4 + 6 * 2 - (2 - 1);
            erg = 4 + 6 * 2 - 1;

            //Math functions
            double s = Math.Sin(1.0);

            //composite operators
            int number = 0;

            number = number + 5;

            number += 5;
            number *= 2;

            number += 1;
            number++;   // increment
            number--;   // decrement

            //++number  vs. number++
            //pre-increment vs. post-increment

            Console.WriteLine("Number: {0}", ++number);

        }
    }
}

