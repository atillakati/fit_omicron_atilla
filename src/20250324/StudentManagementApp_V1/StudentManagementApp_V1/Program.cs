using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementApp_V1
{
    class Program
    {
        /*         
        Write an application with which student data can be managed. Following features 
        should be implemented:

        - Console application
        - Clear user guidance through formatting and color coding (e.g.: color inputs)
        - Student data should be able to be entered
        - Participant data should be displayed on the screen
        - All entries should be implemented in an exception free manner

        a) Initial implementation for one student only          
           - Name
           - Birthday
           - Adress (postal code, city)
           
        */

        static void Main(string[] args)
        {
            string userInput = string.Empty;
            string fullName = string.Empty;
            DateTime birthday = DateTime.MinValue;
            int postalCode = 0;
            string city = string.Empty;

            //student data input
            Console.WriteLine("Please enter following information:");
            Console.WriteLine();
            Console.Write("\tYour full name:             ");
            fullName = Console.ReadLine();

            Console.Write("\tYour birthday (dd.mm.yyyy): ");
            userInput = Console.ReadLine();
            birthday = DateTime.Parse(userInput);

            Console.Write("\tPostal code:                ");
            userInput = Console.ReadLine();
            postalCode = int.Parse(userInput);

            Console.Write("\tCity:                       ");
            city = Console.ReadLine();

            //output student data
            Console.WriteLine("\n\n");
            Console.WriteLine("Name: " + fullName);
            Console.WriteLine(postalCode.ToString() + " " + city);
            Console.WriteLine("Day of birth: " + birthday.ToShortDateString());
        }
    }
}
