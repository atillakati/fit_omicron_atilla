using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Basics
{
    public delegate double SimpleOperationDelegate(double number1, double number2);
    public delegate T OperationDelegate<T>(T number1, T number2);

    internal class Program
    {
        static void Main(string[] args)
        {
            //declaration & assign a method (as value)
            OperationDelegate<double> action = Substraction;
            
            //declaration & assign a method (as value)
            SimpleOperationDelegate op = Addition;

            //method call using delegate
            var result = action(5.0, 8.0);
            Console.WriteLine(result);

            result = op(15.0, 2.5);
            Console.WriteLine(result);

            //using delegate as parameter
            OperationHandler<double>(5.0, 4.0, Addition);
        }

        private static void OperationHandler<T>(T n1, T n2, OperationDelegate<T> operation)
        {
            operation(n1, n2);
        }

        private static double Substraction(double value1, double value2)
        {
            return value1 - value2;
        }

        private static double Addition(double value1, double value2)
        {
            return value1 + value2;
        }
    }
}
