
namespace ForcedPolymorphism
{
    public interface IShape
    {
        string Name { get; }
        
        int Vertices { get; }
        
        void Draw();
    }
}
