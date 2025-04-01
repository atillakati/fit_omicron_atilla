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
            int studentCount = 0;

            Student[] studentList;

            //get count of students from user
            studentCount = GetInt("\nPlease enter the count of the students: ");                                   

            //Retrieve all student data from user
            studentList = GetStudentData(studentCount);

            //output student data
            PrintStudentData(studentList);

            //save all studendata into a file
            WriteStudentData(studentList, "myStudentlist.json");
        }

        private static void WriteStudentData(Student[] studentList, string filename)
        {
            // homework
        }

        private static Student[] GetStudentData(int countOfStudents)
        {
            Student[] studentList = new Student[countOfStudents];

            for (int i = 0; i < countOfStudents; i++)
            {                
                //student data input
                Console.WriteLine("Please enter following information for student #" + (i + 1) + ":");
                Console.WriteLine();

                studentList[i].Name = GetString("\tYour full name:      ");
                studentList[i].Birthday = GetDateTime("Birthday (dd.mm.yyyy): ");
                studentList[i].PostalCode = GetInt("\tPostal code:         ");
                studentList[i].City = GetString("\tCity:                ");
            }

            return studentList;
        }

        private static void PrintStudentData(Student[] studentList)
        {
            for (int i = 0; i < studentList.Length; i++)
            {
                Console.WriteLine("\nStudent #" + (i + 1) + ":\n");
                Console.WriteLine("Name: " + studentList[i].Name);
                Console.WriteLine(studentList[i].PostalCode.ToString() + " " + studentList[i].City);
                Console.WriteLine("Day of birth: " + studentList[i].Birthday.ToShortDateString());
            }
        }

        private static string GetString(string inputPrompt)
        {
            string userInput = string.Empty;            

            Console.Write(inputPrompt);
            Console.ForegroundColor = ConsoleColor.Yellow;

            userInput = Console.ReadLine();
            Console.ResetColor();

            return userInput;
        }

        private static DateTime GetDateTime(string inputPrompt)
        {
            string userInput = string.Empty;
            DateTime dateTimeValue = DateTime.MinValue;
            bool userInputIsInvalid = false;

            do
            {
                Console.ResetColor();
                Console.Write(inputPrompt);
                Console.ForegroundColor = ConsoleColor.Yellow;
                userInput = Console.ReadLine();

                try
                {
                    dateTimeValue = DateTime.Parse(userInput);
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

            return dateTimeValue;
        }

        private static int GetInt(string inputPrompt)
        {
            string userInput = string.Empty;
            int intValue = 0;
            bool userInputIsInvalid = false;

            do
            {
                Console.ResetColor();
                Console.Write(inputPrompt);
                Console.ForegroundColor = ConsoleColor.Yellow;
                userInput = Console.ReadLine();

                try
                {
                    intValue = int.Parse(userInput);
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

            return intValue;
        }
    }
}
