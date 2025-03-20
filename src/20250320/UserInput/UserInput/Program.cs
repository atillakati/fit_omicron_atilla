using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInput
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = string.Empty;
            string userInput = string.Empty;
            int yearOfBirth = 0;
            int age = 0;

            //read user name
            Console.Write("Please enter your name: ");
            name = Console.ReadLine();

            //read year of birth
            Console.Write("Hello, " + name);
            Console.WriteLine(" please enter the year of your birth: ");
            userInput = Console.ReadLine();

            //implicilty ==> indirekt, unbeabsichtigt
            //explicit ==> klar definiert

            //convert user input into a numeric value
            yearOfBirth = int.Parse(userInput);            

            //calculate the age
            age = DateTime.Now.Year - yearOfBirth;

            //output all user info          
            Console.WriteLine(name + " your are " + age + " years old.");

        }
    }
}
