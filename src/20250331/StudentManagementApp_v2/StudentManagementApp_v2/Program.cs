using System;


namespace StudentManagementApp_v2
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

            Student[] studentList;

            
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
            studentList = new Student[studentCount];            

            for (int i = 0; i < studentCount; i++)
            {
                Console.ResetColor();

                //student data input
                Console.WriteLine("Please enter following information for student #" + (i + 1) + ":");
                Console.WriteLine();
                Console.Write("\tYour full name:             ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                studentList[i].Name = Console.ReadLine();

                do
                {
                    Console.ResetColor();
                    Console.Write("\tYour birthday (dd.mm.yyyy): ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    userInput = Console.ReadLine();

                    try
                    {
                        studentList[i].Birthday = DateTime.Parse(userInput);
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
                        studentList[i].PostalCode = int.Parse(userInput);
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
                studentList[i].City = Console.ReadLine();
            }
            Console.ResetColor();

            //output student data            
            for (int i = 0; i < studentCount; i++)
            {
                Console.WriteLine("\nStudent #" + (i + 1) + ":\n");
                Console.WriteLine("Name: " + studentList[i].Name);
                Console.WriteLine(studentList[i].PostalCode.ToString() + " " + studentList[i].City);
                Console.WriteLine("Day of birth: " + studentList[i].Birthday.ToShortDateString());
            }
        }
    }
}
