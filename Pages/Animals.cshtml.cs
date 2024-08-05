using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAnimalsAndShapesApp.Models.Animals;
using MyAnimalsAndShapesApp.Services;

namespace MyAnimalsAndShapesApp.Pages
{
    public class AnimalsModel : PageModel
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalsModel(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public IEnumerable<IAnimal> Animals { get; private set; }

        public void OnGet()
        {
            Animals = _animalRepository.Load("animals.txt");
        }
    }
}