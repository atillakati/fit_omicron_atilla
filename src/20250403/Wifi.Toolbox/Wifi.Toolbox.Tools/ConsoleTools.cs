using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.Toolbox.Tools
{
    public abstract class ConsoleTools
    {
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
    }
}
