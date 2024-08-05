namespace MyAnimalsAndShapesApp.Models.Animals
{
    public interface IAnimal
    {
        string Name { get; }
        string Sound();
    }
}