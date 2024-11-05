using AnimalApp.Models;
using System.Collections.Generic;

namespace AnimalApp.Services
{
    public interface IAnimalSerializer
    {
        string Serialize(List<Animal> animals);
    }
}
