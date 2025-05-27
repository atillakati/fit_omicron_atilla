using BetterConsoleTables;
using System;

namespace VehicleRental_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var vw_golf = new Car("Golf White Edition V6", "VW", 180, 220, 5);

            var carList = new Vehicle[]
            {
                vw_golf,
                new Car("Demo Bicycle", "Brand New", 1, 45, 1),
                new Car("Future Edition", "BadMobil", 250, 280, 2),
                new Car("Vectra 2.0i", "Opel", 110, 185, 5),
                new Scooter("Joy Rider", "Segway", 10, 15.0)
            };
            
            //do something with all vehicles
            foreach (var car in carList)
            {
                car.SpeedUp(100);
                Console.WriteLine(car.GetInfoString());
                Console.WriteLine();
            }

            Console.WriteLine($"Current Station: {vw_golf.CurrentStationName}");
            vw_golf.ChangeMediaPower(true);
            

            Console.WriteLine();

            ShowCarsAsTable(carList);
        }

        private static void ShowCarsAsTable(Vehicle[] carList)
        {
            var table = new Table();
            table.From(carList);

            Console.WriteLine(table.ToString());
        }
    }
}
