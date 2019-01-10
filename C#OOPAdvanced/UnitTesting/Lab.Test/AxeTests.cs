using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private const int AxeAttack = 1;
    private const int AxeDurability = 1;
    private const int DummyHp = 20;
    private const int DummyXp = 1;

    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void TestInit()
    {
        // Arrange
        this.axe = new Axe(AxeAttack, AxeDurability);
        this.dummy = new Dummy(DummyHp, DummyXp);
    }

    [Test]
    public void AxeLosesDurabilityAfterAttack()
    {
        // Act
        this.axe.Attack(dummy);

        // Assert
        Assert.AreEqual(0, this.axe.DurabilityPoints, "Axe Durability doesn't change after attack");
    }

    [Test]
    public void AttackWithBrokenWeapon()
    {
        // Act
        this.axe.Attack(dummy);

        // Assert
        Assert.That(() => this.axe.Attack(this.dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }
}