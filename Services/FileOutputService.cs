namespace MyAnimalsAndShapesApp.Services
{
    public class FileOutputService : IOutputService
    {
        private readonly string _filePath;

        public FileOutputService(string filePath) => _filePath = filePath;

        public void Output(string message)
        {
            File.AppendAllText(_filePath, message + Environment.NewLine);
        }
    }
}