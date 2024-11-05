using AnimalApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AnimalApp.Services
{
    public class JsonAnimalSerializer : IAnimalSerializer
    {
        public string Serialize(List<Animal> animals)
        {
            return JsonConvert.SerializeObject(animals, Formatting.Indented);
        }
    }
}
