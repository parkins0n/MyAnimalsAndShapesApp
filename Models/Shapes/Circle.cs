namespace MyAnimalsAndShapesApp.Models.Shapes
{
    public class Circle : IShape
    {
        public string Name => "Circle";
        public string Draw() => "Drawing a circle";
    }
}