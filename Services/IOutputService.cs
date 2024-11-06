using AnimalApp.Models;

namespace AnimalApp.Services
{
    public interface IOutputService
    {
        void OutputToFile(List<Animal> animals, string format);
    }
}
