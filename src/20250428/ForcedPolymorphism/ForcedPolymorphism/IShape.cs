
using System;

namespace ForcedPolymorphism
{
    public interface IShape : IComparable
    {
        string Name { get; }
        
        int Vertices { get; }
        
        void Draw();
    }
}
