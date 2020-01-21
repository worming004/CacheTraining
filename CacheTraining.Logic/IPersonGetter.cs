namespace CacheTraining.Logic
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
    public interface IPersonGetter
    {
        Person GetPerson(int id);
    }
}