using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructBasics
{     
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = string.Empty;

            //declaration
            Student mike;
            Student[] studentList = new Student[5];

            //create the object
            mike = new Student();

            //init
            mike.Name = "Mike";
            mike.City = "Lustenau";
            mike.Birthday = new DateTime(1980, 4, 1);
            mike.PostalCode = 6930;            

            Console.WriteLine(mike.Name);

            
        }

    }


}
