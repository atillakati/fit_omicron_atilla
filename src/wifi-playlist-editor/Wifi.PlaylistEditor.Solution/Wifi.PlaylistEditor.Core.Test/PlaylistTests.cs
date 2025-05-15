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

        [Test]
        public void Name_get()
        {
            //arrange
            _fixture = new Playlist("Gandalf", "NUnit Tests");

            //act
            var result = _fixture.Name;

            //assert
            Assert.That(result, Is.EqualTo("Gandalf"));
        }

        [Test]
        public void Author_get()
        {
            //arrange
            _fixture = new Playlist("Gandalf", "NUnit Tests");

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
