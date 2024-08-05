namespace MyAnimalsAndShapesApp.Models.Animals
{
    public class Cat : IAnimal
    {
        public string Name => "Cat";
        public string Sound() => "Meow";
    }
}