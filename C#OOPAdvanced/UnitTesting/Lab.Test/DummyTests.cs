using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private const int DummyHealth = 20;
    private const int DummyExperiance = 20;
        
    private Dummy dummy;

    [SetUp]
    public void TestInit()
    {
        this.dummy = new Dummy(DummyHealth, DummyExperiance);
    }

    [Test]
    public void LosesHpIfAttacked()
    {
        this.dummy.TakeAttack(5);

        Assert.That(this.dummy.Health, Is.EqualTo(15));
    }

    [Test]
    public void ThrowsExeptionIfAttacked()
    {
        this.dummy = new Dummy(0 , DummyExperiance);

        Assert.That(() => this.dummy.TakeAttack(5), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void CanGiveXp()
    {
        this.dummy = new Dummy(0, DummyExperiance);

        var experiance = this.dummy.GiveExperience();

        Assert.That(experiance, Is.EqualTo(20));
    }

    [Test]
    public void CantGiveXp()
    {
        Assert.That(() => this.dummy.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}