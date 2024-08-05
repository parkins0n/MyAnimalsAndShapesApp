namespace MyAnimalsAndShapesApp.Models.Shapes
{
    public class Square : IShape
    {
        public string Name => "Square";
        public string Draw() => "Drawing a square";
    }
}