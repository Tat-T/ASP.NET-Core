using AnimalApp.Models;

namespace AnimalApp.Services
{
    public interface IAnimalSerializer
    {
        string Serialize(List<Animal> animals);
    }
}
