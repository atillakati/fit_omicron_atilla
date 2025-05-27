using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForcedPolymorphism
{
    public class Rectangle : IShape
    {
        private string _name;
        private int _vertices;

        public Rectangle(string rectangleName)
        {
            _name = "Rectangle " + rectangleName;
            _vertices = 4;
        }

        public string Name 
        {
            get { return _name; }
        }

        public int Vertices 
        {
            get { return _vertices; }
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing the {_name} with {_vertices} vertices.");
        }
    }
}
