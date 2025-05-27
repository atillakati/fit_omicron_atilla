using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForcedPolymorphism
{
    public class Rectangle : IShape
    {
        private readonly int _length;
        private readonly int _width;
        private string _name;
        private int _vertices;

        public Rectangle(string rectangleName, int length, int width)
        {
            _name = "Rectangle " + rectangleName;
            _vertices = 4;

            _length = length;
            _width = width;
        }

        public string Name
        {
            get { return _name; }
        }

        public int Vertices
        {
            get { return _vertices; }
        }

        public int CompareTo(object obj)
        {
            return ShapeSortHelper.CompareTo(this, obj);
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing the {_name} with {_vertices} vertices (LxW: {_length}x{_width}).");
        }
    }
}
