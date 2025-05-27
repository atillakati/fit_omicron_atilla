using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Wifi.PlaylistEditor.Core;
using Wifi.PlaylistEditor.Repositories.Database;

namespace Wifi.PlaylistEditor.Repositories.Test.Database
{
    [TestFixture]
    public class MongoDbDriverTests
    {
        private IDataBaseDriver<Person> _fixture;


        [OneTimeSetUp]
        public async Task CreateData()
        {
            var connection = "mongodb://admin:password@localhost:27017";
            _fixture = new MongoDbDriver<Person>(connection, "person-db", "person-collection");

            var person = CreateDummyPerson("Max");
            var person1 = CreateDummyPerson("Gandalf");
            var person2 = CreateDummyPerson("Susi");

            await _fixture.CreateAsync(person);
            await _fixture.CreateAsync(person1);
            await _fixture.CreateAsync(person2);
        }

        [OneTimeTearDown]
        public async Task CleanUp()
        {
            var testPersons = await _fixture.GetAllAsync();
            var personsToRemove = testPersons.Where(x => x.LastName == "NUnit-Mustermann");

            foreach (var person in personsToRemove)
            {
                await _fixture.DeleteAsync(person.Id);
            }
        }


        [Test]
        public async Task DeleteAsync()
        {
            //arrange
            //arrange
            var testPersons = await _fixture.GetAllAsync();
            var testPerson = testPersons.First();

            //act
            await _fixture.DeleteAsync(testPerson.Id);

            //assert
            var result = await _fixture.GetAllAsync();
            Assert.That(result.Count(), Is.EqualTo(testPersons.Count()-1));
        }

        [Test]
        public void DeleteAsync_NullItem()
        {
            //arrange

            //act
            //assert
            Assert.ThrowsAsync<ArgumentNullException>(() => _fixture.DeleteAsync(null));
        }

        [Test]
        public void DeleteAsync_EmptyItem()
        {
            //arrange

            //act
            //assert
            Assert.ThrowsAsync<ArgumentNullException>(() => _fixture.DeleteAsync(string.Empty));
        }

        [Test]
        public async Task GetAllAsync()
        {
            //arrange

            //act
            var result = await _fixture.GetAllAsync();

            //assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.GreaterThanOrEqualTo(3));
        }

        [Test]
        public async Task GetByIdAsync()
        {
            //arrange
            var testPersons = await _fixture.GetAllAsync();
            var firstPerson = testPersons.First();

            //act
            var result = await _fixture.GetByIdAsync(firstPerson.Id);

            //assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.FirstName, Is.EqualTo(firstPerson.FirstName));
            Assert.That(result.LastName, Is.EqualTo(firstPerson.LastName));
            Assert.That(result.Age, Is.EqualTo(firstPerson.Age));
            Assert.That(result.Id, Is.EqualTo(firstPerson.Id));
        }

        [Test]
        public async Task UpdateAsync()
        {
            //arrange
            var testPersons = await _fixture.GetAllAsync();
            var testPerson = testPersons.First();
            testPerson.Age += 5;
            testPerson.FirstName += "_changed";

            //act
            await _fixture.UpdateAsync(testPerson.Id, testPerson);

            //assert
            var result = await _fixture.GetByIdAsync(testPerson.Id);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.FirstName.EndsWith("_changed"), Is.True);
        }

        [Test]
        public void UpdateAsync_NullItem()
        {
            //arrange
            //act
            //assert
            Assert.ThrowsAsync<ArgumentNullException>(() => _fixture.UpdateAsync("asdfasdf", null));
        }

        [Test]
        public void UpdateAsync_EmptyId()
        {
            //arrange
            //act
            //assert
            Assert.ThrowsAsync<ArgumentNullException>(() => _fixture.UpdateAsync(string.Empty, new Person()));
        }

        private Person CreateDummyPerson(string firstName)
        {
            return  new Person
            {
                FirstName = firstName,
                LastName = "NUnit-Mustermann",
                Age = 42
            };
        }

        [Test]
        public async Task Create()
        {
            //arrange
            var actualContent = await _fixture.GetAllAsync();
            var person = CreateDummyPerson("Max");

            //act
            await _fixture.CreateAsync(person);

            //assert
            var result = await _fixture.GetAllAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.GreaterThan(actualContent.Count()));
        }

        [Test]
        public void CreateAsync_NullItem()
        {
            //arrange
            //act
            //assert
            Assert.ThrowsAsync<ArgumentNullException>(() => _fixture.CreateAsync(null));
        }

    }
}
