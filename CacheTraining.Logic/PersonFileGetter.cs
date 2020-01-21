using System.IO;
using System.Text.Json;

namespace CacheTraining.Logic
{
    public class PersonFileGetter : IPersonGetter
    {
        public Person GetPerson(int id)
        {
            string path = $"./{id}.person";
            if (!File.Exists(path)) {
                throw new NotFoundException();
            }
            var fileContent = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Person>(fileContent);
        }
    }
}