using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var listOfNames = CreateStringArray(10, "No Name");

            //var listOfYearOfBirths = CreateIntArray(15, 1880);

            listOfNames = CreateArray<string>(15, string.Empty);

            var listOfYearOfBirths = CreateArray<int>(10, 1880);

            List<string> nameList = new List<string>();

            nameList.Add("Gandalf");
            nameList.Add("Gandalf2");
            nameList.Add("Gandalf3");
            nameList.Add("Gandalf4");
            nameList.Remove("Gandalf");
        }

        private static T[] CreateArray<T>(int itemCount, T initValue)// where T : IShape
        {
            var valueList = new T[itemCount];
            
            for (int i = 0; i < itemCount; i++)
            {
                valueList[i] = initValue;
            }

            return valueList;
        }

        private static string[] CreateStringArray(int itemCount, string initValue)
        {
            var valueList = new string[itemCount];

            for (int i = 0; i < itemCount; i++)
            {
                valueList[i] = initValue;
            }

            return valueList;
        }
    }
}
