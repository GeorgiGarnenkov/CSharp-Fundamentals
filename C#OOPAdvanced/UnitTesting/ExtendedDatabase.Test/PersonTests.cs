using NUnit.Framework;

namespace ExtendedDatabase.Test
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        [TestCase(20, "Gosho")]
        [TestCase(5, "Tosho")]
        [TestCase(46, "Pesho")]
        [TestCase(456622, "Kiko")]
        [TestCase(2365489, "Venko")]
        [TestCase(long.MaxValue, "Simo")]
        public void TestValidPersonConstructor(long id, string name)
        {
            Person person = new Person(id, name);

            Assert.That(person.Id, Is.EqualTo(id));
            Assert.That(person.UserName, Is.EqualTo(name));
        }
        
    }
}