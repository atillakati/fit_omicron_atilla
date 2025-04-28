using System;
using System.Diagnostics;

namespace ForcedPolymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var listOfShapes = new IShape[]
            {
                new Circle("Olaf", 15),
                new Rectangle("Rechteck_1", 5, 18),
                new Circle("Big Olaf", 105),
                new Rectangle("Rechteck_2", 10,8)               
            };

            Array.Sort(listOfShapes);

            DrawShaps(listOfShapes);            
        }

        private static void DrawShaps(IShape[] listOfShapes)
        {
            foreach (var shape in listOfShapes)
            {
                Debug.WriteLine($"{DateTime.Now}: Drawing Shape {shape.Name}...");
                shape.Draw();
            }
        }
    }
}
