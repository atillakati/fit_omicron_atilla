using System;

using TextToAsciiArt;

namespace Wifi.Toolbox.Tools
{
    public abstract class ConsoleTools
    {
        public static void CreateHeader(string headerText, char textFillChar)
        {
            IArtWriter writer = new ArtWriter();

            var settings = new ArtSetting
            {
                ConsoleSpeed = 50,
                IsBreakSpace = false,
                Text = textFillChar.ToString(),
                BgText = " "
            };

            writer.WriteConsole(headerText, settings);
        }

        public static void CreateHeader(string headerText)
        {
            CreateHeader(headerText, '*');
        }


        public static T GetInputValue<T>(string inputPrompt) where T: struct
        {
            string userInput = string.Empty;
            T userValue = default(T);
            bool userInputIsInvalid = false;

            Type inputType = typeof(T);            

            do
            {
                Console.ResetColor();
                Console.Write(inputPrompt);
                Console.ForegroundColor = ConsoleColor.Yellow;
                userInput = Console.ReadLine();

                try
                {
                    var parseMethodInfo = inputType.GetMethod("Parse", new Type[] { typeof(string) });
                    if(parseMethodInfo == null)
                    {
                        throw new NotImplementedException($"Type '{inputType.Name}' doesn't support Parse().");
                    }

                    userValue = (T)parseMethodInfo.Invoke(null, new object[] { userInput });

                    //userValue = int.Parse(userInput);
                    userInputIsInvalid = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: " + ex.Message);
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine("\tERROR: " + ex.InnerException.Message);
                    }
                    
                    userInputIsInvalid = true;
                }
            }
            while (userInputIsInvalid);

            Console.ResetColor();

            return userValue;
        }

        public static int GetInt(string inputPrompt)
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

        public static double GetDouble(string inputPrompt)
        {
            string userInput = string.Empty;
            double doubleValue = 0.0;
            bool userInputIsInvalid = false;

            do
            {
                Console.ResetColor();
                Console.Write(inputPrompt);
                Console.ForegroundColor = ConsoleColor.Yellow;
                userInput = Console.ReadLine();

                try
                {
                    doubleValue = double.Parse(userInput);
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

            return doubleValue;
        }

        public static string GetString(string inputPrompt)
        {
            string userInput = string.Empty;

            Console.Write(inputPrompt);
            Console.ForegroundColor = ConsoleColor.Yellow;

            userInput = Console.ReadLine();
            Console.ResetColor();

            return userInput;
        }

        public static DateTime GetDateTime(string inputPrompt)
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

    }
}
