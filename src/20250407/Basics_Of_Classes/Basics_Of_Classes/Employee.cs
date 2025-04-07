using System;

namespace Basics_Of_Classes
{
    public class Employee
    {
        //states
        public string Name;
        public string Department;
        public decimal Salary;
        public Guid Id;

        public void GiveBonus(decimal delta)
        {
            if(delta > 0)
            {
                Salary += delta;
            }
        }

        public void Display()
        {
            Console.WriteLine($"Name: {Name} [{Id}]");
            Console.WriteLine($"Department: {Department}");
        }
    }
}
