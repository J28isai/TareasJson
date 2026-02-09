using System.IO;
using System.Text.Json;
using TareasJson.Models;

namespace TareasJson.Services
{
    public class JsonService
    {
        private const string FileName = "contacts.json";

        public List<Contact> Load()
        {
            if (!File.Exists(FileName))
                return new List<Contact>();

            return JsonSerializer.Deserialize<List<Contact>>(
                File.ReadAllText(FileName)
            ) ?? new List<Contact>();
        }

        public void Save(IEnumerable<Contact> contacts)
        {
            File.WriteAllText(
                FileName,
                JsonSerializer.Serialize(
                    contacts,
                    new JsonSerializerOptions { WriteIndented = true }
                )
            );
        }
    }
}
