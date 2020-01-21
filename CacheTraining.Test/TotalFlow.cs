using System.IO.Compression;
using System;
using CacheTraining.Logic;
using Xunit;

namespace CacheTraining.Test
{
    public class TotalFlow
    {
        private PersonFileSetter setter;
        private PersonFileGetter getter;
        private Person defaultPerson;

        public TotalFlow(){
            setter = new PersonFileSetter();
            getter = new PersonFileGetter();
            defaultPerson = new Person{
                Id = 1,
                Name = "Mathieu",
                LastName = "Scolas"
            };
        }


        [Fact]
        public void WriteReadFlow()
        {
            setter.Store(defaultPerson);
            var personGet = getter.GetPerson(defaultPerson.Id);
            Assert.Equal(defaultPerson.Name, personGet.Name);

            setter.CleanUp();
        }

        [Fact]
        public void CleanFlow() {
            setter.Store(defaultPerson);
            setter.CleanUp();

            try{
            getter.GetPerson(defaultPerson.Id);
            Assert.True(false, "should fail");
            }
            catch (NotFoundException) {}
            catch (Exception) {
                Assert.True(false, "should fail with another exception");
            }

            setter.CleanUp();
        }

        [Fact]
        public void CacheFlow() {
            var cache = new PersonCacheDecorator(getter);
            setter.Store(defaultPerson);
            cache.GetPerson(defaultPerson.Id);
            setter.CleanUp();
            var p = cache.GetPerson(defaultPerson.Id);
            Assert.Equal(p.LastName, defaultPerson.LastName);
        }
    }
}
