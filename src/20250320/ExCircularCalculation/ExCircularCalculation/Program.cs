using System;

namespace ExCircularCalculation
{
    class Program
    {
        static void Main(string[] args)
        {            
            //variable declaration & initialisation
            double diameter = 15.12;    //Durchmesser
            double circumference = 0.0; //Umfang

            //calculation
            circumference = diameter * Math.PI;

            //output
            Console.WriteLine("The circumferenc of my circle is: " + circumference.ToString());
        }
    }
}
