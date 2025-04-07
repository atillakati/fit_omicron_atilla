using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foreachIntroduction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[] { "Gandalf", "Max Musterman", "Golom", "Eomer"};

            int itemCount = names.Length;
            int counter = 0;


            foreach(string name in names)
            {
                //name = name.ToUpper();

                Console.WriteLine($"{counter+1}/{itemCount} - Name: {name}");
                counter++;
            }
        }
    }
}
