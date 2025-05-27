using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Part_II
{
    public delegate void DoSomething(string message);  // ==> Actions

    public delegate bool Check(string message);  // ==> Func
    //Predicate

    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string, int, string> action = WriteColorMessage2;
            DoSomething customAction = WriteColorMessage;

            Func<string, bool> function = CheckParameter;
            Check customFunction = CheckParameter;

            Predicate<string> preCheck = CheckParameterValue;
        }

        private static bool CheckParameterValue(string param)
        {
            throw new NotImplementedException();
        }

        private static bool CheckParameter(string message)
        {
            //..
            //..

            return true;
        }

        private static void WriteColorMessage2(string arg1, int arg2, string arg3)
        {
            throw new NotImplementedException();
        }

        private static void WriteColorMessage(string message)
        {
            //...
        }
    }
}
