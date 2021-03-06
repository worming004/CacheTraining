﻿using System;
using Microsoft.Extensions.Caching.Memory;

namespace CacheTraining.Logic
{
    public class PersonCacheDecoratorTryGetValue : IPersonGetter
    {

        private MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
        private IPersonGetter _getter;

        public PersonCacheDecoratorTryGetValue(IPersonGetter getter)
        {
            _getter = getter;
        }
        public Person GetPerson(int id)
        {
            Person person;
            if (!_cache.TryGetValue(id, out person)) {
                person = _getter.GetPerson(id);
                _cache.Set(id, person);
            }
            return person;
        }
    }
}
