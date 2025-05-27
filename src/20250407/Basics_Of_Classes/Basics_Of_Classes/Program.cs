using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics_Of_Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 5;
            Employee ma = new Employee();
            Employee ma1 = new Employee();
            Employee ma2 = new Employee();

            //ma2 => instance variable

            ma.Name = "Max Musterman";
            ma.Salary = 1500.00m;
            ma.Department = "IT";
            ma.Id = Guid.NewGuid();

            ma.Display();

            //class vs. object = instance
            ma.GiveBonus(150.80m);
            ma.Display();

        }
    }
}
