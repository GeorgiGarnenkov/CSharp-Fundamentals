using Moq;
using NUnit.Framework;

namespace Lab.Test
{
    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void HeroGetsExperianceAfterKillingTarget()
        {
            Hero hero = new Hero("Gosho", new Axe(10, 10));
            Dummy dummy = new Dummy(10, 10);

            hero.Attack(dummy);
            
            Assert.That(hero.Experience, Is.EqualTo(10), "Hero doesn't get Experiance!");
        }

        [Test]
        public void MockingTest()
        {
            Mock<IWeapon> weapon = new Mock<IWeapon>();

        }
    }
}