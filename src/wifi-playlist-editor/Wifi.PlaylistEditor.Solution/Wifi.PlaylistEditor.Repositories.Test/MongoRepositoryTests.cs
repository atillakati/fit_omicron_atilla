using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.PlaylistEditor.Repositories.Database;

namespace Wifi.PlaylistEditor.Repositories.Test
{
    [TestFixture]
    public class MongoRepositoryTests
    {
        private MongoRepository<Person> _fixture;

        [Test]
        public async Task Create()
        {
            //arrange
            var connection = "mongodb://admin:password@localhost:27017";

            _fixture = new MongoRepository<Person>(connection, "person-db", "person-collection");

            var person = new Person
            {
                FirstName = "Max",
                LastName = "Mustermann",
                Age = 42
            };

            //act
            await _fixture.CreateAsync(person);

            //assert
            var result = await _fixture.GetAllAsync();
            
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.GreaterThanOrEqualTo(1));
        }
    }
}
