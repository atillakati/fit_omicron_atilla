using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 5;

            for(int i = 0; i<count; i++)
            {
                Console.WriteLine("Step: " + i.ToString());
                //..
                //..                
            }

            //for (int i = 50; i > 15; i+=3)
            //{

            //}

            DateTime now = DateTime.Now;

            while(DateTime.Now.Hour == 20)
            {
                //
                //do something
            }

            do
            {
                //
                //do something
            }
            while (DateTime.Now.Hour == 20);
        }
    }
}
