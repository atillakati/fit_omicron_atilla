using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //declaration
            int number;

            int[] numbers;
            numbers = new int[50];

            //initialisation
            number = -1;

            numbers[0] = 1;
            numbers[1] = 1;
            numbers[2] = 1;
            numbers[3] = 1;
            numbers[4] = 1;

            for(int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = 2;
                Console.WriteLine("Value: " + numbers[i].ToString());
            }


        }
    }
}
