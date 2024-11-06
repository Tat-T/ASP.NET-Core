using AnimalApp.Models;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Xml.Serialization;

namespace AnimalApp.Services
{
    public class FileOutputService : IOutputService
    {
        public void OutputToFile(List<Animal> animals, string format)
        {
            if (format.ToLower() == "json")
            {
                var options = new JsonSerializerOptions
                {
                  WriteIndented = true,
                  Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                string jsonString = JsonSerializer.Serialize(animals, options);
                File.WriteAllText("animals.json", jsonString);
                
            }
            else if (format.ToLower() == "xml")
            {
                SaveAsXml(animals);
            }
            else
            {
                throw new ArgumentException("Указан не потдерживаемый формат.");
            }
        }

        private void SaveAsJson(List<Animal> animals)
        {
            var json = JsonSerializer.Serialize(animals, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("animals.json", json);
        }

        private void SaveAsXml(List<Animal> animals)
        {
            var serializer = new XmlSerializer(typeof(List<Animal>));
            using var writer = new StreamWriter("animals.xml");
            serializer.Serialize(writer, animals);
        }
    }
}
