using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda_Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> doSomething;

            //default delegates
            doSomething = WriteColoredMessage;            
            doSomething("Calling a existing method....");
            //doSomething?.Invoke("Calling a existing method....");

            //anonymous method
            doSomething = delegate (string msg)
            {
                Console.WriteLine(msg);
                Console.Beep();
            };
            doSomething("Test");

            //Introduction to lambda
            doSomething = (string msg) => 
            { 
                Console.WriteLine(msg); 
            };

            doSomething = (msg) => Console.WriteLine(msg);
            doSomething = msg => Console.WriteLine(msg);

            doSomething("Hello lambda!");

            //example
            var valueList = new List<int> { 5, 8, 10, 2, 15, 20, 29 };

            var filteredValues = FilterToOdd(valueList);


            var evenValues = Filter(valueList, x => x % 2 == 0);
            var greaterThen10Values = Filter(valueList, x => x > 10);


            var greaterThen8Values = Filter(valueList, GreaterThen8);

            //LINQ
            var result = valueList.Where(x => x > 5).Select(x => 2 * x);
        }

        private static bool GreaterThen8(int value)
        {
            if (value > 8)
            {
                return true;
            }

            return false;
        }

        private static IEnumerable<T> Filter<T>(IEnumerable<T> valueList, Predicate<T> filterCondition)
        {
            var resultList = new List<T>();

            foreach (var value in valueList)
            {
                if( filterCondition(value) )
                {
                    resultList.Add(value);
                }
            }

            return resultList;
        }

        private static IEnumerable<int> FilterToOdd(List<int> valueList)
        {
            var resultList = new List<int>();

            foreach (var value in valueList)
            {
                if(value % 2 != 0)
                {
                    resultList.Add(value);
                }
            }

            return resultList;
        }

        private static void WriteColoredMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(message);

            Console.ResetColor();
        }
    }
}
