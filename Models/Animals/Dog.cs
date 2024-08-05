namespace MyAnimalsAndShapesApp.Models.Animals
{
    public class Dog : IAnimal
    {
        public string Name => "Dog";
        public string Sound() => "Bark";
    }
}