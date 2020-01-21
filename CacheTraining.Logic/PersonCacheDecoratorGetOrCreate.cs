using System;
using Microsoft.Extensions.Caching.Memory;

namespace CacheTraining.Logic
{
    public class PersonCacheDecoratorGetOrCreate : IPersonGetter
    {

        private MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
        private IPersonGetter _getter;

        public PersonCacheDecoratorGetOrCreate(IPersonGetter getter)
        {
            _getter = getter;
        }
        public Person GetPerson(int id)
        {
            return _cache.GetOrCreate(id, _ => _getter.GetPerson(id));
        }
    }
}
