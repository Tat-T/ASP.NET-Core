using AnimalApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace AnimalApp.Services
{
    public class XmlAnimalSerializer : IAnimalSerializer
    {
        public string Serialize(List<Animal> animals)
        {
            var serializer = new XmlSerializer(typeof(List<Animal>));
            using (var stringWriter = new StringWriter())
            {
                serializer.Serialize(stringWriter, animals);
                return stringWriter.ToString();
            }
        }
    }
}
