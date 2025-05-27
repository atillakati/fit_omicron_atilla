using System;

namespace ForcedPolymorphism
{
    public class Circle : IShape
    {
        private readonly int _radius;
        private string _name;
        private int _vertices;

        public Circle(string name, int radius)
        {
            _name = name;
            _radius = radius;
            _vertices = int.MaxValue;
        }

        #region IShape implemenation

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
            Console.WriteLine($"Drawing the circle {_name} with radius = {_radius}.");
        }

        #endregion

        
    }

}
