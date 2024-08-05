using MyAnimalsAndShapesApp.Models.Shapes;
using System.Text.Json;

namespace MyAnimalsAndShapesApp.Services
{
    public class ShapeRepository : IShapeRepository
    {
        public void Save(IEnumerable<IShape> shapes, string filePath, string format = "txt")
        {
            if (format.ToLower() == "json")
            {
                SaveAsJson(shapes, filePath);
            }
            else
            {
                SaveAsTxt(shapes, filePath);
            }
        }

        private void SaveAsTxt(IEnumerable<IShape> shapes, string filePath)
        {
            var lines = shapes.Select(s => s.Name).ToArray();
            File.WriteAllLines(filePath, lines);
        }

        private void SaveAsJson(IEnumerable<IShape> shapes, string filePath)
        {
            var shapeList = shapes.Select(s => new ShapeDto
            {
                Name = s.Name,
                VisualRepresentation = s.Draw()
            }).ToList();
            var json = JsonSerializer.Serialize(shapeList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public IEnumerable<IShape> Load(string filePath, string format = "txt")
        {
            if (format.ToLower() == "json")
            {
                return LoadFromJson(filePath);
            }
            else
            {
                return LoadFromTxt(filePath);
            }
        }

        private IEnumerable<IShape> LoadFromTxt(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var shapes = new List<IShape>();

            foreach (var line in lines)
            {
                IShape shape = line switch
                {
                    "Circle" => new Circle(),
                    "Square" => new Square(),
                    _ => throw new ArgumentException("Unknown shape")
                };
                shapes.Add(shape);
            }

            return shapes;
        }

        private IEnumerable<IShape> LoadFromJson(string filePath)
        {
            var json = File.ReadAllText(filePath);
            var shapeList = JsonSerializer.Deserialize<List<ShapeDto>>(json);
            var shapes = new List<IShape>();

            foreach (var shapeDto in shapeList)
            {
                IShape shape = shapeDto.Name switch
                {
                    "Circle" => new Circle(),
                    "Square" => new Square(),
                    _ => throw new ArgumentException("Unknown shape")
                };
                shapes.Add(shape);
            }

            return shapes;
        }
    }

    public class ShapeDto
    {
        public string Name { get; set; }
        public string VisualRepresentation { get; set; }
    }
}