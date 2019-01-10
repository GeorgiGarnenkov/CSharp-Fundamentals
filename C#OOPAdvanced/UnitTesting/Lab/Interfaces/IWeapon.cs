public interface IWeapon
{
    int AttackPoints { get; set; }
    int DurabilityPoints { get; }

    void Attack(ITarget target);
}