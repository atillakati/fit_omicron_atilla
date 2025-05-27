using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForcedPolymorphism
{
    public abstract class ShapeSortHelper 
    {
        public static int CompareTo(IShape shape, object obj2 )
        {
            //parameter check and conversion part
            if (shape == null || obj2 == null)
            {
                return 1;
            }
                        
            var otherShape = obj2 as IShape;
            if (otherShape == null)
            {
                return 1;
            }

            //comparison part
            if (otherShape.Vertices == shape.Vertices)
            {
                return 0;
            }
            else if (otherShape.Vertices > shape.Vertices)
            {
                return -1;
            }

            return 1;
        }
    }
}
