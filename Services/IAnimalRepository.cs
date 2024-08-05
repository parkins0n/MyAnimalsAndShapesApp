using MyAnimalsAndShapesApp.Models.Animals;

namespace MyAnimalsAndShapesApp.Services
{
    public interface IAnimalRepository
    {
        void Save(IEnumerable<IAnimal> animals, string filePath, string format = "txt");
        IEnumerable<IAnimal> Load(string filePath, string format = "txt");
    }
}