using System.IO;
using System.Text.Json;

namespace CacheTraining.Logic
{
    public class PersonFileSetter
    {
        public void Store(Person person)
        {
            File.WriteAllText($"./{person.Id}.person", JsonSerializer.Serialize(person));
        }

        public void CleanUp()
        {
            foreach (var file in Directory.GetFiles("./", "*.person"))
            {
                File.Delete(file);
            }
        }
    }
}