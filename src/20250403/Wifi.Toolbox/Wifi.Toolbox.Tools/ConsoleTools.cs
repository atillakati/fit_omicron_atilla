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


        public static T GetInputValue<T>(string inputPrompt)
            where T : struct
        {
            return GetInputValue<T>(inputPrompt, DefaultMessageHandler);
        }

        public static T GetInputValue<T>(string inputPrompt, ErrorMessageHandler messageHandler) 
            where T: struct
        {
            string userInput = string.Empty;
            T userValue = default(T);
            bool userInputIsInvalid = false;

            Type inputType = typeof(T);            

            do
            {
                Console.ResetColor();
                Console.Write(inputPrompt);

                var lastInputPostion = new CursorPositionDto
                {
                    TopPos = Console.CursorTop,
                    LeftPos = Console.CursorLeft
                };                

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
                    if (messageHandler != null)
                    {                        
                        messageHandler(ex, lastInputPostion);
                    }
                    
                    userInputIsInvalid = true;
                }
            }
            while (userInputIsInvalid);

            Console.ResetColor();

            return userValue;
        }
        
        public static void DefaultMessageHandler(Exception ex, CursorPositionDto cursorPosition)
        {
            Console.WriteLine("ERROR: " + ex.Message);
            if (ex.InnerException != null)
            {
                Console.WriteLine("\tERROR: " + ex.InnerException.Message);
            }
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
        

    }
}
