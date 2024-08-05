using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAnimalsAndShapesApp.Models.Shapes;
using MyAnimalsAndShapesApp.Services;

namespace MyAnimalsAndShapesApp.Pages
{
    public class ShapesModel : PageModel
    {
        private readonly IShapeRepository _shapeRepository;

        public ShapesModel(IShapeRepository shapeRepository)
        {
            _shapeRepository = shapeRepository;
        }

        public IEnumerable<IShape> Shapes { get; private set; }

        public void OnGet()
        {
            Shapes = _shapeRepository.Load("shapes.txt");
        }
    }
}