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
            bool userInputIsInvalid = false;
            int studenCount = 0;

            string[] studenFullNames;
            DateTime[] studenBirthdays;
            int[] studenPostalCodes;
            string[] studenCities;
            

            //retrieve count of students
            do
            {
                Console.ResetColor();
                Console.Write("Please enter the count of your students: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                userInput = Console.ReadLine();
                try
                {
                    studenCount = int.Parse(userInput);
                    userInputIsInvalid = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                    userInputIsInvalid = true;
                }
            }
            while (userInputIsInvalid);

            //dimension the arrays
            studenFullNames = new string[studenCount];
            studenBirthdays = new DateTime[studenCount];
            studenCities = new string[studenCount];
            studenPostalCodes = new int[studenCount];

            for (int i = 0; i < studenCount; i++)
            {
                //student data input
                Console.ResetColor();
                Console.WriteLine("Please enter following information for student #{0}:", i+1);
                Console.WriteLine();

                //get student name
                Console.Write("\tYour full name:             ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                studenFullNames[i] = Console.ReadLine();

                //get student birthday
                do
                {
                    Console.ResetColor();
                    Console.Write("\tYour birthday (dd.mm.yyyy): ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    userInput = Console.ReadLine();

                    try
                    {
                        studenBirthdays[i] = DateTime.Parse(userInput);
                        userInputIsInvalid = false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ERROR: " + ex.Message);
                        userInputIsInvalid = true;
                    }
                }
                while (userInputIsInvalid);

                //get student postal code
                do
                {
                    Console.ResetColor();
                    Console.Write("\tPostal code:                ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    userInput = Console.ReadLine();
                    try
                    {
                        studenPostalCodes[i] = int.Parse(userInput);
                        userInputIsInvalid = false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ERROR: " + ex.Message);
                        userInputIsInvalid = true;
                    }
                }
                while (userInputIsInvalid);

                //get student city
                Console.ResetColor();
                Console.Write("\tCity:                       ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                studenCities[i] = Console.ReadLine();                
            }

            Console.ResetColor();

            //output student data
            if (!userInputIsInvalid)
            {
                for (int i = 0; i < studenCount; i++)
                {
                    Console.WriteLine("\nStudent #{0}:", i+1);
                    Console.WriteLine("Name: " + studenFullNames[i]);
                    Console.WriteLine(studenPostalCodes[i].ToString() + " " + studenCities[i]);
                    Console.WriteLine("Day of birth: " + studenBirthdays[i].ToShortDateString());
                }
            }
        }
    }
}
