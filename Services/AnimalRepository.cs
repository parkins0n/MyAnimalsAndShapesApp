using MyAnimalsAndShapesApp.Models.Animals;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace MyAnimalsAndShapesApp.Services
{
    public class AnimalRepository : IAnimalRepository
    {
        public void Save(IEnumerable<IAnimal> animals, string filePath, string format = "txt")
        {
            if (format.ToLower() == "json")
            {
                SaveAsJson(animals, filePath);
            }
            else
            {
                SaveAsTxt(animals, filePath);
            }
        }

        private void SaveAsTxt(IEnumerable<IAnimal> animals, string filePath)
        {
            var lines = animals.Select(a => $"{a.Name},{a.Sound()}").ToArray();
            File.WriteAllLines(filePath, lines);
        }

        private void SaveAsJson(IEnumerable<IAnimal> animals, string filePath)
        {
            var animalList = animals.Select(a => new AnimalDto
            {
                Name = a.Name,
                Sound = a.Sound()
            }).ToList();
            var json = JsonSerializer.Serialize(animalList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public IEnumerable<IAnimal> Load(string filePath, string format = "txt")
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

        private IEnumerable<IAnimal> LoadFromTxt(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var animals = new List<IAnimal>();

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                IAnimal animal = parts[0] switch
                {
                    "Dog" => new Dog(),
                    "Cat" => new Cat(),
                    _ => throw new ArgumentException("Unknown animal")
                };

                if (parts.Length > 1)
                {
                }

                animals.Add(animal);
            }

            return animals;
        }

        private IEnumerable<IAnimal> LoadFromJson(string filePath)
        {
            var json = File.ReadAllText(filePath);
            var animalList = JsonSerializer.Deserialize<List<AnimalDto>>(json);
            var animals = new List<IAnimal>();

            foreach (var animalDto in animalList)
            {
                IAnimal animal = animalDto.Name switch
                {
                    "Dog" => new Dog(),
                    "Cat" => new Cat(),
                    _ => throw new ArgumentException("Unknown animal")
                };
                animals.Add(animal);
            }

            return animals;
        }
    }

    public class AnimalDto
    {
        public string Name { get; set; }
        public string Sound { get; set; }
    }
}