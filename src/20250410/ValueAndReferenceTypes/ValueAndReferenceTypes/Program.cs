using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueAndReferenceTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point p3;  //null            

            Point p2 = new Point();
            Point p1 = new Point();
            p1.XPos = 5;
            p1.YPos = 2;

            //copy the point
            p2 = p1;

            p1.XPos = 9;
            p1.YPos = 10;

            //show the point contents
            Display(p1);
            Display(p2);
        }

        static void Display(Point pointToDisplay)
        {
            Console.WriteLine($"Point: ({pointToDisplay.XPos},{pointToDisplay.YPos})");

            pointToDisplay.XPos = 0;
        }
    }
}
