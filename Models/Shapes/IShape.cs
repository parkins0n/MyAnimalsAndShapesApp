namespace MyAnimalsAndShapesApp.Models.Shapes
{
    public interface IShape
    {
        string Name { get; }
        string Draw();
    }
}