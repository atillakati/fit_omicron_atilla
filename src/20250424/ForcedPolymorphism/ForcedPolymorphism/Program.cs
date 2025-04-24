using System.Diagnostics;

namespace ForcedPolymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IShape[] listOfShapes;

            foreach (var shape in listOfShapes)
            {
                Debug.WriteLine($"Drawing Shape {shape.Name}...");
                shape.Draw();                
            }
        }
    }
}
