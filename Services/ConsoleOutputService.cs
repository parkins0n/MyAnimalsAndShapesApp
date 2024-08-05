namespace MyAnimalsAndShapesApp.Services
{
    public class ConsoleOutputService : IOutputService
    {
        public void Output(string message) => Console.WriteLine(message);
    }
}