using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.PlaylistEditor.Core.Test
{
    [TestFixture]
    public class PlaylistTests
    {
        private Playlist _fixture;
        private Mock<IPlaylistItem> _mockedItem1;
        private Mock<IPlaylistItem> _mockedItem2;

        [SetUp]
        public void Init()
        {
            _fixture = new Playlist("Gandalf", "NUnit Tests");

            _mockedItem1 = new Mock<IPlaylistItem>();
            _mockedItem2 = new Mock<IPlaylistItem>();
        }


        [Test]
        public void Clear()
        {
            //arrange
            _fixture.Add(_mockedItem1.Object);
            _fixture.Add(_mockedItem2.Object);
            var oldCount = _fixture.ItemList.Count();

            //act
            _fixture.Clear();

            //assert
            Assert.That(oldCount, Is.EqualTo(2));
            Assert.That(_fixture.ItemList.Count(), Is.EqualTo(0));
        }


        [Test]
        public void Remove()
        {
            //arrange
            _fixture.Add(_mockedItem1.Object);
            var oldCount = _fixture.ItemList.Count();

            //act
            _fixture.Remove(_mockedItem1.Object);

            //assert
            Assert.That(_fixture.ItemList.Count(), Is.EqualTo(oldCount - 1));
        }

        [Test]
        public void Remove_ItemIsNull()
        {
            //arrange
            _fixture.Add(_mockedItem1.Object);
            var oldCount = _fixture.ItemList.Count();

            //act
            _fixture.Remove(null);

            //assert
            Assert.That(_fixture.ItemList.Count(), Is.EqualTo(oldCount));
        }


        [Test]
        public void Add()
        {
            //arrange
            var oldCount = _fixture.ItemList.Count();

            //act
            _fixture.Add(_mockedItem1.Object);

            //assert
            Assert.That(_fixture.ItemList.Count(), Is.EqualTo(oldCount + 1));
        }


        [Test]
        public void Add_ItemIsNull()
        {
            //arrange
            var oldCount = _fixture.ItemList.Count();

            //act
            _fixture.Add(null);

            //assert
            Assert.That(_fixture.ItemList.Count(), Is.EqualTo(oldCount));
        }


        [Test]
        public void ItemList_get()
        {
            //arrange            
            _fixture.Add(_mockedItem1.Object);
            _fixture.Add(_mockedItem2.Object);

            //act
            var result = _fixture.ItemList;

            //assert
            Assert.That(result.Count(), Is.EqualTo(2));
        }


        [Test]
        public void Duration_get()
        {
            //arrange            
            _mockedItem1.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(68));            
            _mockedItem2.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(40));

            _fixture.Add(_mockedItem1.Object);
            _fixture.Add(_mockedItem2.Object);

            //act
            var result = _fixture.Duration;

            //assert
            Assert.That(result, Is.EqualTo(TimeSpan.FromSeconds(108)));
        }

        [Test]
        public void CreatedAt_get()
        {
            //arrange
            var createDate = new DateTime(2025, 5, 15);
            _fixture = new Playlist("Gandalf", "NUnit Tests", createDate);

            //act
            var result = _fixture.CreatedAt;

            //assert
            Assert.That(result, Is.EqualTo(createDate));
        }

        [Test]
        public void Name_get()
        {
            //arrange            

            //act
            var result = _fixture.Name;

            //assert
            Assert.That(result, Is.EqualTo("Gandalf"));
        }

        [Test]
        public void Author_get()
        {
            //arrange            

            //act
            var result = _fixture.Author;

            //assert
            Assert.That(result, Is.EqualTo("NUnit Tests"));
        }


        [Test]
        public void TestSomething()
        {
            //AAA
            //arrange
            int result = 0;
            int value1 = 40;
            int value2 = 50;

            //act
            result = value1 + value2;

            //assert
            Assert.That(result, Is.EqualTo(90));
        }
    }
}
