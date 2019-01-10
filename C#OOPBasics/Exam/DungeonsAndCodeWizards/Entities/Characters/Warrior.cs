using System;
using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Characters.Interfaces;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction)
            : base(name, health: 100, armor: 50, abilityPoints: 40, bag: new Satchel(), faction: faction)
        {
        }

        public void Attack(Character character)
        {
            this.EnsureAlive();
            
            if (character == this)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }
            
            if (this.Faction == character.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction} faction!");
            }

            character.TakeDamage(this.AbilityPoints);

        }
    }
}
