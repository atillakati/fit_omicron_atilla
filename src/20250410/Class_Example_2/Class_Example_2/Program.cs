using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Example_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle myCar = new Vehicle("Badmobil Black Edition V18", 250);            
            
            myCar.Display();

            myCar.SpeedUp(120);
            //myCar.CurrentSpeed = 320;                        
            myCar.Display();
            
            int speed = myCar.CurrentSpeed * 150;            

            myCar.Color = ConsoleColor.Yellow;
            Console.WriteLine("Color of my car: " + myCar.Color);

            myCar.Display();
        }
    }
}
