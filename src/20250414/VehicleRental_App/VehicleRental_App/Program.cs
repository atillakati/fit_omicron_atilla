using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRental_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var age = 0;
            var name = "Atilla";

            var vw_golf = new Car("Golf White Edition V6", "VW", 180, 220);

            Console.WriteLine(vw_golf.GetInfoString());

            var employeeList = GetListOfEmployees();

        }

        private static IEnumerable<Employee> GetListOfEmployees()
        {
            data = 5;
            throw new NotImplementedException();
        }
    }
}
