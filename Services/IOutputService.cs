using AnimalApp.Models;
using System.Collections.Generic;

namespace AnimalApp.Services
{
    public interface IOutputService
    {
        void OutputToFile(List<Animal> animals, string format);
    }
}
