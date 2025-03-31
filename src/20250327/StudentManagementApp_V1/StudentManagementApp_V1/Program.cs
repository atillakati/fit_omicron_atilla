using System;


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
            bool userInputIsInvalid = false;
            string userInput = string.Empty;
            int studentCount = 0;

            string[] fullNameList;
            DateTime[] birthdayList;
            int[] postalCodeList;
            string[] cityList;


            do
            {
                Console.ResetColor();
                Console.Write("\tPlease enter the count of students: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                userInput = Console.ReadLine();
                try
                {
                    studentCount = int.Parse(userInput);
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

            //dimension the arrays
            fullNameList = new string[studentCount];
            postalCodeList = new int[studentCount];
            birthdayList = new DateTime[studentCount];
            cityList = new string[studentCount];


            for (int i = 0; i < studentCount; i++)
            {
                Console.ResetColor();

                //student data input
                Console.WriteLine("Please enter following information for student #" + (i + 1) + ":");
                Console.WriteLine();
                Console.Write("\tYour full name:             ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                fullNameList[i] = Console.ReadLine();

                do
                {
                    Console.ResetColor();
                    Console.Write("\tYour birthday (dd.mm.yyyy): ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    userInput = Console.ReadLine();

                    try
                    {
                        birthdayList[i] = DateTime.Parse(userInput);
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
                        postalCodeList[i] = int.Parse(userInput);
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
                cityList[i] = Console.ReadLine();
            }
            Console.ResetColor();

            //output student data            
            for (int i = 0; i < studentCount; i++)
            {
                Console.WriteLine("\nStudent #" + (i + 1) + ":\n");
                Console.WriteLine("Name: " + fullNameList[i]);
                Console.WriteLine(postalCodeList[i].ToString() + " " + cityList[i]);
                Console.WriteLine("Day of birth: " + birthdayList[i].ToShortDateString());
            }
        }
    }
}
