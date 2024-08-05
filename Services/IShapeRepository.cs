using MyAnimalsAndShapesApp.Models.Shapes;

namespace MyAnimalsAndShapesApp.Services
{
    public interface IShapeRepository
    {
        void Save(IEnumerable<IShape> shapes, string filePath, string format = "txt");
        IEnumerable<IShape> Load(string filePath, string format = "txt");
    }
}