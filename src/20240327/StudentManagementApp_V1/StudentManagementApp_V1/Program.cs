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
        - Clear user guidance through formatting and color coding (e.g.: colored inputs)
        - Student data should be able to be entered
        - Student data should be displayed on the screen
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
            bool userInputIsInvalid = false;

            
            //student data input
            Console.WriteLine("Please enter following information:");
            Console.WriteLine();
            Console.Write("\tYour full name:             ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            fullName = Console.ReadLine();

            do
            {
                Console.ResetColor();
                Console.Write("\tYour birthday (dd.mm.yyyy): ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                userInput = Console.ReadLine();

                try
                {
                    birthday = DateTime.Parse(userInput);
                    userInputIsInvalid = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                    userInputIsInvalid = true;
                } 
            } 
            while (userInputIsInvalid);

            do
            {
                Console.ResetColor();
                Console.Write("\tPostal code:                ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                userInput = Console.ReadLine();
                try
                {
                    postalCode = int.Parse(userInput);
                    userInputIsInvalid = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                    userInputIsInvalid = true;
                } 
            } 
            while (userInputIsInvalid);

            Console.ResetColor();
            Console.Write("\tCity:                       ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            city = Console.ReadLine();

            Console.ResetColor();

            //output student data
            if (!userInputIsInvalid)
            {
                Console.WriteLine("\n\n");
                Console.WriteLine("Name: " + fullName);
                Console.WriteLine(postalCode.ToString() + " " + city);
                Console.WriteLine("Day of birth: " + birthday.ToShortDateString());
            }
        }
    }
}
